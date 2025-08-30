using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DbAccess {
	public class TableSchema {
		private string tableName;
		private string tableSchemaName;
		private List<ColumnSchema> columns = new List<ColumnSchema>();
		private List<IndexSchema> indexes = new List<IndexSchema>();
		private List<ForeignKeySchema> foreignKeys = new List<ForeignKeySchema>();
		private List<string> primaryKey = new List<string>();

		public TableSchema() {
			foreignKeys = new List<ForeignKeySchema>();
			indexes = new List<IndexSchema>();
			primaryKey = new List<string>();
			columns = new List<ColumnSchema>();
		}
		public string TableName { get => tableName; set => SetTableName(value); }



		public string TableSchemaName { get => tableSchemaName; set => SetTableSchemaName(value); }

		public List<ColumnSchema> Columns { get => columns; set => SetColumns(value); }



		public List<string> PrimaryKey { get => primaryKey; set => SetPrimaryKey(value); }

		public List<ForeignKeySchema> ForeignKeys { get => foreignKeys; set => SetForeignKeys(value); }

		public List<IndexSchema> Indexes { get => indexes; set => SetIndexes(value); }
		public void SetPrimaryKey(List<string> value) {
			if (value == primaryKey)
				return;
			primaryKey = value;
			ClearCreateTableQuery();
		}
		public void SetForeignKeys(List<ForeignKeySchema> value) {
			if (value == foreignKeys)
				return;
			foreignKeys = value;
			ClearCreateTableQuery();
		}
		public void SetIndexes(List<IndexSchema> value) {
			if (value == indexes)
				return;
			indexes = value;
			ClearCreateTableQuery();
		}
		public void SetColumns(List<ColumnSchema> value) {
			if (value == columns)
				return;
			columns = value;
			ClearCreateTableQuery();
		}
		public void SetTableName(string value) {
			if (value == tableName)
				return;
			tableName = value;
			ClearCreateTableQuery();
		}
		public void SetTableSchemaName(string value) {
			if (value == tableSchemaName)
				return;
			tableSchemaName = value;
			ClearCreateTableQuery();
		}
		private void ClearCreateTableQuery() {
			createTableQuery = null;
		}
		private string createTableQuery = null;
		/// <summary>
		/// returns the CREATE TABLE DDL for creating the SQLite table from the specified
		/// table schema object.
		/// </summary>
		/// <param name="ts">The table schema object from which to create the SQL statement.</param>
		/// <returns>CREATE TABLE DDL for the specified table.</returns>
		public string BuildCreateTableQuery() {
			if (createTableQuery == null) {
				StringBuilder sb = new StringBuilder();

				sb.Append("CREATE TABLE [" + this.TableName + "] (\n");

				bool pkey = false;
				for (int i = 0; i < this.Columns.Count; i++) {
					ColumnSchema col = this.Columns[i];
					string cline = BuildColumnStatement(col, ref pkey);
					sb.Append(cline);
					if (i < this.Columns.Count - 1)
						sb.Append(",\n");
				} // foreach

				// add primary keys...
				if (this.PrimaryKey != null && this.PrimaryKey.Count > 0 & !pkey) {
					sb.Append(",\n");
					sb.Append("    PRIMARY KEY (");
					for (int i = 0; i < this.PrimaryKey.Count; i++) {
						sb.Append("[" + this.PrimaryKey[i] + "]");
						if (i < this.PrimaryKey.Count - 1)
							sb.Append(", ");
					} // for
					sb.Append(")\n");
				} else
					sb.Append("\n");

				// add foreign keys...
				if (this.ForeignKeys.Count > 0) {
					sb.Append(",\n");
					for (int i = 0; i < this.ForeignKeys.Count; i++) {
						ForeignKeySchema foreignKey = this.ForeignKeys[i];
						string stmt = string.Format("    FOREIGN KEY ([{0}])\n        REFERENCES [{1}]([{2}])",
									foreignKey.ColumnName, foreignKey.ForeignTableName, foreignKey.ForeignColumnName);

						sb.Append(stmt);
						if (i < this.ForeignKeys.Count - 1)
							sb.Append(",\n");
					} // for
				}

				sb.Append("\n");
				sb.Append(");\n");

				// Create any relevant indexes
				if (this.Indexes != null) {
					for (int i = 0; i < this.Indexes.Count; i++) {
						string stmt = BuildCreateIndex(this.TableName, this.Indexes[i]);
						sb.Append(stmt + ";\n");
					} // for
				} // if

				createTableQuery = sb.ToString();
			}
			return createTableQuery;
		}

		/// <summary>
		/// Creates a CREATE INDEX DDL for the specified table and index schema.
		/// </summary>
		/// <param name="tableName">The name of the indexed table.</param>
		/// <param name="indexSchema">The schema of the index object</param>
		/// <returns>A CREATE INDEX DDL (SQLite format).</returns>
		private string BuildCreateIndex(string tableName, IndexSchema indexSchema) {
			StringBuilder sb = new StringBuilder();
			sb.Append("CREATE ");
			if (indexSchema.IsUnique)
				sb.Append("UNIQUE ");
			sb.Append("INDEX [" + tableName + "_" + indexSchema.IndexName + "]\n");
			sb.Append("ON [" + tableName + "]\n");
			sb.Append("(");
			for (int i = 0; i < indexSchema.Columns.Count; i++) {
				sb.Append("[" + indexSchema.Columns[i].ColumnName + "]");
				if (!indexSchema.Columns[i].IsAscending)
					sb.Append(" DESC");
				if (i < indexSchema.Columns.Count - 1)
					sb.Append(", ");
			} // for
			sb.Append(")");

			return sb.ToString();
		}
		/// <summary>
		/// Used when creating the CREATE TABLE DDL. Creates a single row
		/// for the specified column.
		/// </summary>
		/// <param name="col">The column schema</param>
		/// <returns>A single column line to be inserted into the general CREATE TABLE DDL statement</returns>
		private string BuildColumnStatement(ColumnSchema col, ref bool pkey) {
			StringBuilder sb = new StringBuilder();
			sb.Append("\t[" + col.ColumnName + "]\t");

			// Special treatment for IDENTITY columns
			if (col.IsIdentity) {
				if (this.PrimaryKey.Count == 1 && (col.ColumnType == "tinyint" || col.ColumnType == "int" || col.ColumnType == "smallint" || col.ColumnType == "bigint" || col.ColumnType == "integer")) {
					sb.Append("integer PRIMARY KEY AUTOINCREMENT");
					pkey = true;
				} else
					sb.Append("integer");
			} else {
				if (col.ColumnType == "int")
					sb.Append("integer");
				else {
					sb.Append(col.ColumnType);
				}
				if (col.Length > 0)
					sb.Append("(" + col.Length + ")");
			}
			if (!col.IsNullable)
				sb.Append(" NOT NULL");

			if (col.IsCaseSensitivite.HasValue && !col.IsCaseSensitivite.Value)
				sb.Append(" COLLATE NOCASE");

			string defval = StripParens(col.DefaultValue);
			defval = DiscardNational(defval);

			if (defval != string.Empty && defval.ToUpper().Contains("GETDATE")) {

				sb.Append(" DEFAULT (CURRENT_TIMESTAMP)");
			} else if (defval != string.Empty && IsValidDefaultValue(defval))
				sb.Append(" DEFAULT " + defval);

			return sb.ToString();
		}




		/// <summary>
		/// Discards the national prefix if exists (e.g., N'sometext') which is not
		/// supported in SQLite.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		private static string DiscardNational(string value) {
			Regex rx = new Regex(@"N\'([^\']*)\'");
			Match m = rx.Match(value);
			if (m.Success)
				return m.Groups[1].Value;
			else
				return value;
		}

		/// <summary>
		/// Check if the DEFAULT clause is valid by SQLite standards
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static bool IsValidDefaultValue(string value) {
			if (IsSingleQuoted(value))
				return true;

			double testnum;
			if (!double.TryParse(value, out testnum))
				return false;
			return true;
		}

		private static bool IsSingleQuoted(string value) {
			value = value.Trim();
			if (value.StartsWith("'") && value.EndsWith("'"))
				return true;
			return false;
		}

		/// <summary>
		/// Strip any parentheses from the string.
		/// </summary>
		/// <param name="value">The string to strip</param>
		/// <returns>The stripped string</returns>
		private static string StripParens(string value) {
			Regex rx = new Regex(@"\(([^\)]*)\)");
			Match m = rx.Match(value);
			if (!m.Success)
				return value;
			else
				return StripParens(m.Groups[1].Value);
		}

	}
}
