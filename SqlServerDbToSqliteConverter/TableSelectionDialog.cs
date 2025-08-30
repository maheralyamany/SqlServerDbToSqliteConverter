using System;
using System.Linq;
using System.Windows.Forms;

using DbAccess;

namespace SqlServerDbToSqliteConverter {
	/// <summary>
	/// The dialog allows the user to select which tables to include in the 
	/// converstion process.
	/// </summary>
	public partial class TableSelectionDialog : Form {
		private DatabaseSchema Schema = new DatabaseSchema();
		#region Constructors
		public TableSelectionDialog() {
			InitializeComponent();
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Returns the list of included table schema objects.
		/// </summary>
		public DatabaseSchema GetSelectedSchema() {
			DatabaseSchema schema = new DatabaseSchema();
			foreach (DataGridViewRow row in grdTables.Rows) {
				bool include = (bool)row.Cells["colInclude"].Value;
				if (include) {
					var tableName = (row.Cells["colTableName"].Value ?? "").ToString();
					if (!string.IsNullOrWhiteSpace(tableName)) {
						var tableType = (row.Cells["colTableType"].Value ?? "").ToString();
						if (tableType == "Table") {
							var table = Schema.Tables.FirstOrDefault(s => s.TableName == tableName);
							schema.Tables.Add(table);
						} else if (tableType == "View") {
							var view = Schema.Views.FirstOrDefault(s => s.ViewName == tableName);
							schema.Views.Add(view);
						}

					}
				}
			} // foreach

			return schema;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Opens the table selection dialog and uses the specified schema list in order
		/// to update the tables grid.
		/// </summary>
		/// <param name="schema">The DB schema to display in the grid</param>
		/// <param name="owner">The owner form</param>
		/// <returns>dialog result according to user decision.</returns>
		public DialogResult ShowTables(DatabaseSchema schema, IWin32Window owner) {
			this.Schema = schema;
			UpdateGuiFromSchema();
			return this.ShowDialog(owner);
		}
		#endregion

		#region Event Handlers
		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
		}

		private void btnDeselectAll_Click(object sender, EventArgs e) {
			foreach (DataGridViewRow row in grdTables.Rows) {
				// Uncheck the [V] for this row.
				row.Cells[0].Value = false;
			} // foreach
		}

		private void btnSelectAll_Click(object sender, EventArgs e) {
			foreach (DataGridViewRow row in grdTables.Rows) {
				// Check the [V] for this row.
				row.Cells[0].Value = true;
			} // foreach
		}
		#endregion

		#region Private Methods
		private void UpdateGuiFromSchema() {
			grdTables.Rows.Clear();
			foreach (var table in this.Schema.Tables) {
				grdTables.Rows.Add(true, table.TableName, "Table");
			}
			foreach (var view in this.Schema.Views) {
				grdTables.Rows.Add(false, view.ViewName, "View");
			}
		}
		#endregion
	}
}
