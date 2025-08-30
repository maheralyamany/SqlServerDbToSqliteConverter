namespace DbAccess {
	/// <summary>
	/// Describes a single view schema
	/// </summary>
	public class ViewSchema {
		/// <summary>
		/// Contains the view name
		/// </summary>
		public string ViewName;
		private string viewSQL;

		/// <summary>
		/// Contains the view SQL statement
		/// </summary>
		public string ViewSQL { get => viewSQL; set => SetViewSQL(value); }



		public void SetViewSQL(string value) {

			if (!string.IsNullOrWhiteSpace(value)) {
				value = value.Replace("\r\n", " ").Replace("ISNULL", "IFNULL").Replace("isnull", "IFNULL");
			}
			viewSQL = value;
		}
	}
}
