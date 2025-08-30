using System.Collections.Generic;

namespace DbAccess {
	/// <summary>
	/// Contains the entire database schema
	/// </summary>
	public class DatabaseSchema {
		public DatabaseSchema() {
			Tables = new List<TableSchema>();
			Views = new List<ViewSchema>();
		}
		public List<TableSchema> Tables { get; set; } = new List<TableSchema>();
		public List<ViewSchema> Views { get; set; } = new List<ViewSchema>();
		public bool HasTables => Tables != null && Tables.Count > 0;
		public bool HasViews => Views != null && Views.Count > 0;
	}
}
