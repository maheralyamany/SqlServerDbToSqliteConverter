using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

using DbAccess;

namespace SqlServerDbToSqliteConverter {
	public partial class MainForm : Form {
		#region Constructor
		public MainForm() {
			InitializeComponent();
			radDb.Tag = SqliteFileType.NewType("SQLiteDb.db");
			radDb3.Tag = SqliteFileType.NewType("SQLiteDb.db3");
			radSql.Tag = SqliteFileType.NewType("SQLiteScript.sql");
			txtSqlAddress.Text = Environment.MachineName;
		}
		#endregion

		#region Event Handler

		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			radDb.Checked = true;
			BtnSet_Click(btnSet, EventArgs.Empty);

		}



		private void CboDatabases_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateSensitivity();
			pbrProgress.Value = 0;
			lblMessage.Text = string.Empty;
		}

		private void BtnSet_Click(object sender, EventArgs e) {
			try {
				string constr;
				if (cbxIntegrated.Checked) {
					constr = GetSqlServerConnectionString(txtSqlAddress.Text, "master");
				} else {
					constr = GetSqlServerConnectionString(txtSqlAddress.Text, "master", txtUserDB.Text, txtPassDB.Text);
				}
				using (SqlConnection conn = new SqlConnection(constr)) {
					conn.Open();

					// Get the names of all DBs in the database server.
					SqlCommand query = new SqlCommand(@"select distinct [name] from sysdatabases", conn);
					using (SqlDataReader reader = query.ExecuteReader()) {
						cboDatabases.Items.Clear();
						while (reader.Read())
							cboDatabases.Items.Add((string)reader[0]);

					} // using
				} // using

				cboDatabases.Enabled = true;

				pbrProgress.Value = 0;
				lblMessage.Text = string.Empty;
			} catch (Exception ex) {
				MessageBox.Show(this,
					ex.Message,
					"Failed To Connect",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			} // catch
		}

		private SqliteFileType sqliteFileType;

		private SqliteFileType GetSqliteFileType() {
			if (sqliteFileType == null) {
				var checkedRad = sqliteFileTypeGrp.Controls.OfType<RadioButton>().FirstOrDefault(s => s.Checked);
				if (checkedRad == null) {
					radDb.Checked = true;
					checkedRad = radDb;
				}
				var sqliteFile = GetCheckedRadTag(checkedRad);
				if (sqliteFile == null) {
					sqliteFile = SqliteFileType.NewType("SQLiteDb.db");
				}
				SetSqliteFileType(sqliteFile);
			}
			return sqliteFileType;
		}

		private SqliteFileType GetCheckedRadTag(RadioButton checkedRad) {

			if (checkedRad.Tag is SqliteFileType sqliteFile && sqliteFile != null)
				return sqliteFile;
			sqliteFile = SqliteFileType.NewType($"SQLiteFile{checkedRad.Text}");
			checkedRad.Tag = sqliteFile;
			return sqliteFile;
		}

		private void SetSqliteFileType(SqliteFileType value) {
			sqliteFileType = value;
			txtSQLitePath.Text = GetSqliteFileType().FilePath;
			pbrProgress.Value = 0;
			lblMessage.Text = string.Empty;
			encryptPanel.Visible = sqliteFileType.IsSqliteDb;
			if (!sqliteFileType.IsSqliteDb)
				cbxEncrypt.Checked = false;
		}

		private void BtnBrowseSQLitePath_Click(object sender, EventArgs e) {
			GetSqliteFileType();

			if (sqliteFileType == null) {
				MessageBox.Show("Please Select SQLite Output file Type");
				return;
			}


			using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
				saveFileDialog.DefaultExt = sqliteFileType.DefaultExt;
				saveFileDialog.Filter = sqliteFileType.Filter;
				saveFileDialog.RestoreDirectory = true;
				DialogResult res = saveFileDialog.ShowDialog(this);
				if (res == DialogResult.OK) {
					SetSqliteFileType(new SqliteFileType(saveFileDialog.FileName));
				}
			}




		}

		private void TxtSQLitePath_TextChanged(object sender, EventArgs e) {
			UpdateSensitivity();
		}
		private void RadDb_CheckedChanged(object sender, EventArgs e) {
			var rad = (RadioButton)sender;
			if (rad.Checked) {

				var sqliteFile = GetCheckedRadTag(rad);
				SetSqliteFileType(sqliteFile);


				//sqliteFileTypeGrp.Controls.OfType<RadioButton>().FirstOrDefault(s => s.Checked);
			}
		}
		private void MainForm_Load(object sender, EventArgs e) {
			UpdateSensitivity();

			//string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			this.Text = "SQL Server To SQLite DB Converter";
		}

		private void TxtSqlAddress_TextChanged(object sender, EventArgs e) {
			UpdateSensitivity();
		}

		private void BtnCancel_Click(object sender, EventArgs e) {
			SqlServerToSQLite.CancelConversion();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (SqlServerToSQLite.IsActive) {
				SqlServerToSQLite.CancelConversion();
				_shouldExit = true;
				e.Cancel = true;
			} else
				e.Cancel = false;
		}

		private void CbxEncrypt_CheckedChanged(object sender, EventArgs e) {
			UpdateSensitivity();
		}

		private void TxtPassword_TextChanged(object sender, EventArgs e) {
			UpdateSensitivity();
		}

		private void ChkIntegratedCheckedChanged(object sender, EventArgs e) {
			if (cbxIntegrated.Checked) {
				lblPassword.Visible = false;
				lblUser.Visible = false;
				txtPassDB.Visible = false;
				txtUserDB.Visible = false;
			} else {
				lblPassword.Visible = true;
				lblUser.Visible = true;
				txtPassDB.Visible = true;
				txtUserDB.Visible = true;
			}
		}

		private void BtnStart_Click(object sender, EventArgs e) {
			string sqlConnString;
			if (cbxIntegrated.Checked) {
				sqlConnString = GetSqlServerConnectionString(txtSqlAddress.Text, (string)cboDatabases.SelectedItem);
			} else {
				sqlConnString = GetSqlServerConnectionString(txtSqlAddress.Text, (string)cboDatabases.SelectedItem, txtUserDB.Text, txtPassDB.Text);
			}
			GetSqliteFileType();
			bool createViews = cbxCreateViews.Checked;

			this.Cursor = Cursors.WaitCursor;
			string password = txtPassword.Text.Trim();
			if (!cbxEncrypt.Checked)
				password = null;
			ConverterParams prams = new ConverterParams(sqlConnString, sqliteFileType.FilePath) {
				Password = password,
				Handler = NewConversionHandler(),
				CreateTriggers = cbxTriggers.Checked,
				CreateViews = createViews,
				IsSqliteDb = sqliteFileType.IsSqliteDb,
				IsCopyData = cbxCopyData.Checked,
				SelectionHandler = NewTableSelectionHandler(),
				ViewFailureHandler = NewViewDefinitionHandler(),
			};
			SqlServerToSQLite.ConvertSqlServerToSQLiteDatabase(prams);
		}
		#region Handlers
		private SqlConversionHandler NewConversionHandler() {
			return new SqlConversionHandler(delegate (bool done,
				 bool success, int percent, string msg) {
					 Invoke(new MethodInvoker(delegate () {
						 UpdateSensitivity();
						 lblMessage.Text = msg;
						 pbrProgress.Value = percent;

						 if (done) {
							 btnStart.Enabled = true;
							 this.Cursor = Cursors.Default;
							 UpdateSensitivity();

							 if (success) {
								 MessageBox.Show(this, msg, "Conversion Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
								 pbrProgress.Value = 0;
								 lblMessage.Text = string.Empty;
							 } else {
								 if (!_shouldExit) {
									 MessageBox.Show(this,
										 msg,
										 "Conversion Failed",
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Error);
									 pbrProgress.Value = 0;
									 lblMessage.Text = string.Empty;
								 } else
									 Application.Exit();
							 }
						 }
					 }));
				 });
		}

		private FailedViewDefinitionHandler NewViewDefinitionHandler() {
			return new FailedViewDefinitionHandler(delegate (ViewSchema vs) {
				string updated = null;
				Invoke(new MethodInvoker(delegate {
					ViewFailureDialog dlg = new ViewFailureDialog();
					dlg.View = vs;
					DialogResult res = dlg.ShowDialog(this);
					if (res == DialogResult.OK)
						updated = dlg.ViewSQL;
					else
						updated = null;
				}));

				return updated;
			});
		}

		private SqlTableSelectionHandler NewTableSelectionHandler() {
			SqlTableSelectionHandler selectionHandler = new SqlTableSelectionHandler(delegate (DatabaseSchema schema) {
				DatabaseSchema selschema = null;
				Invoke(new MethodInvoker(delegate {
					// Allow the user to select which tables to include by showing him the 
					// table selection dialog.
					TableSelectionDialog dlg = new TableSelectionDialog();
					DialogResult res = dlg.ShowTables(schema, this);
					if (res == DialogResult.OK)
						selschema = dlg.GetSelectedSchema();
				}));
				return selschema;
			});
			return selectionHandler;
		}
		#endregion
		#endregion

		#region Private Methods
		private void UpdateSensitivity() {
			if (this.InvokeRequired) {
				this.BeginInvoke(new MethodInvoker(delegate { UpdateSensitivity(); }));
			} else {
				if (txtSQLitePath.Text.Trim().Length > 0 && cboDatabases.Enabled &&
				(!cbxEncrypt.Checked || txtPassword.Text.Trim().Length > 0))
					btnStart.Enabled = true && !SqlServerToSQLite.IsActive;
				else
					btnStart.Enabled = false;

				SetControlsEnbled(sqlServerGroup.Controls, !SqlServerToSQLite.IsActive);
				SetControlsEnbled(sqliteGroup.Controls, !SqlServerToSQLite.IsActive);

				btnCancel.Visible = SqlServerToSQLite.IsActive;
				btnSet.Enabled = txtSqlAddress.Text.Trim().Length > 0 && !SqlServerToSQLite.IsActive;
				cboDatabases.Enabled = cboDatabases.Items.Count > 0 && !SqlServerToSQLite.IsActive;
				txtPassword.Enabled = cbxEncrypt.Checked && cbxEncrypt.Enabled;


				/*txtSqlAddress.Enabled = !SqlServerToSQLite.IsActive;
                txtSQLitePath.Enabled = !SqlServerToSQLite.IsActive;
                btnBrowseSQLitePath.Enabled = !SqlServerToSQLite.IsActive;
                cbxEncrypt.Enabled = !SqlServerToSQLite.IsActive;
                cbxIntegrated.Enabled = !SqlServerToSQLite.IsActive;
                cbxCreateViews.Enabled = !SqlServerToSQLite.IsActive;
                cbxTriggers.Enabled = !SqlServerToSQLite.IsActive;
                txtPassDB.Enabled = !SqlServerToSQLite.IsActive;
                txtUserDB.Enabled = !SqlServerToSQLite.IsActive;
                foreach (var radioButton in sqliteFileTypeGrp.Controls.OfType<RadioButton>()) {
                    radioButton.Enabled = !SqlServerToSQLite.IsActive;
                }
                cbxCopyData.Enabled = !SqlServerToSQLite.IsActive;*/
			}
		}
		public void SetControlsEnbled(System.Windows.Forms.Control.ControlCollection collection, bool state) {
			for (int i = 0; i < collection.Count; i++) {
				var control = collection[i];
				try {
					if (!(control is Label)) {
						if ((control is Panel Pnl)) {
							SetControlsEnbled(Pnl.Controls, state);
						} else if ((control is GroupBox Grp)) {
							SetControlsEnbled(Grp.Controls, state);
						} else if (control.Controls.Count > 0)
							SetControlsEnbled(control.Controls, state);
						else {
							control.Enabled = state;
						}
					}
				} catch (Exception ex) {
					control.Enabled = state;
					Debug.WriteLine(ex.Message);
				}
			}
		}
		private static string GetSqlServerConnectionString(string address, string db) {
			string res = @"Data Source=" + address.Trim() +
					";Initial Catalog=" + db.Trim() + ";Integrated Security=SSPI;";
			return res;
		}
		private static string GetSqlServerConnectionString(string address, string db, string user, string pass) {
			string res = @"Data Source=" + address.Trim() +
				";Initial Catalog=" + db.Trim() + ";User ID=" + user.Trim() + ";Password=" + pass.Trim();
			return res;
		}
		#endregion

		#region Private Variables
		private bool _shouldExit = false;
		#endregion


	}
}
