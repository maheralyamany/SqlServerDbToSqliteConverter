namespace SqlServerDbToSqliteConverter {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.txtSqlAddress = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSQLitePath = new System.Windows.Forms.TextBox();
			this.btnBrowseSQLitePath = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cboDatabases = new System.Windows.Forms.ComboBox();
			this.btnSet = new System.Windows.Forms.Button();
			this.pbrProgress = new System.Windows.Forms.ProgressBar();
			this.lblMessage = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.cbxEncrypt = new System.Windows.Forms.CheckBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.cbxIntegrated = new System.Windows.Forms.CheckBox();
			this.txtUserDB = new System.Windows.Forms.TextBox();
			this.txtPassDB = new System.Windows.Forms.TextBox();
			this.lblUser = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.cbxTriggers = new System.Windows.Forms.CheckBox();
			this.cbxCreateViews = new System.Windows.Forms.CheckBox();
			this.sqlServerGroup = new System.Windows.Forms.GroupBox();
			this.sqliteGroup = new System.Windows.Forms.GroupBox();
			this.encryptPanel = new System.Windows.Forms.Panel();
			this.sqliteFileTypeGrp = new System.Windows.Forms.GroupBox();
			this.radSql = new System.Windows.Forms.RadioButton();
			this.radDb3 = new System.Windows.Forms.RadioButton();
			this.radDb = new System.Windows.Forms.RadioButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.cbxCopyData = new System.Windows.Forms.CheckBox();
			this.sqlServerGroup.SuspendLayout();
			this.sqliteGroup.SuspendLayout();
			this.encryptPanel.SuspendLayout();
			this.sqliteFileTypeGrp.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(11, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "SQL Server Address:";
			// 
			// txtSqlAddress
			// 
			this.txtSqlAddress.Location = new System.Drawing.Point(153, 19);
			this.txtSqlAddress.Name = "txtSqlAddress";
			this.txtSqlAddress.Size = new System.Drawing.Size(395, 20);
			this.txtSqlAddress.TabIndex = 1;
			this.txtSqlAddress.TextChanged += new System.EventHandler(this.TxtSqlAddress_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(7, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(135, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "SQLite Database File Path:";
			// 
			// txtSQLitePath
			// 
			this.txtSQLitePath.Location = new System.Drawing.Point(149, 72);
			this.txtSQLitePath.Name = "txtSQLitePath";
			this.txtSQLitePath.Size = new System.Drawing.Size(403, 20);
			this.txtSQLitePath.TabIndex = 11;
			this.txtSQLitePath.TextChanged += new System.EventHandler(this.TxtSQLitePath_TextChanged);
			// 
			// btnBrowseSQLitePath
			// 
			this.btnBrowseSQLitePath.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnBrowseSQLitePath.Location = new System.Drawing.Point(555, 70);
			this.btnBrowseSQLitePath.Name = "btnBrowseSQLitePath";
			this.btnBrowseSQLitePath.Size = new System.Drawing.Size(75, 23);
			this.btnBrowseSQLitePath.TabIndex = 12;
			this.btnBrowseSQLitePath.Text = "Browse...";
			this.btnBrowseSQLitePath.UseVisualStyleBackColor = true;
			this.btnBrowseSQLitePath.Click += new System.EventHandler(this.BtnBrowseSQLitePath_Click);
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnStart.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnStart.Location = new System.Drawing.Point(355, 53);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(198, 23);
			this.btnStart.TabIndex = 17;
			this.btnStart.Text = "Start The Conversion Process";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(11, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Select DB:";
			// 
			// cboDatabases
			// 
			this.cboDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDatabases.Enabled = false;
			this.cboDatabases.FormattingEnabled = true;
			this.cboDatabases.Location = new System.Drawing.Point(153, 45);
			this.cboDatabases.Name = "cboDatabases";
			this.cboDatabases.Size = new System.Drawing.Size(429, 21);
			this.cboDatabases.TabIndex = 4;
			this.cboDatabases.SelectedIndexChanged += new System.EventHandler(this.CboDatabases_SelectedIndexChanged);
			// 
			// btnSet
			// 
			this.btnSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnSet.Location = new System.Drawing.Point(553, 17);
			this.btnSet.Name = "btnSet";
			this.btnSet.Size = new System.Drawing.Size(75, 23);
			this.btnSet.TabIndex = 2;
			this.btnSet.Text = "Set";
			this.btnSet.UseVisualStyleBackColor = true;
			this.btnSet.Click += new System.EventHandler(this.BtnSet_Click);
			// 
			// pbrProgress
			// 
			this.pbrProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pbrProgress.Location = new System.Drawing.Point(2, 32);
			this.pbrProgress.Name = "pbrProgress";
			this.pbrProgress.Size = new System.Drawing.Size(652, 18);
			this.pbrProgress.TabIndex = 16;
			// 
			// lblMessage
			// 
			this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMessage.ForeColor = System.Drawing.Color.White;
			this.lblMessage.Location = new System.Drawing.Point(2, 4);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(652, 23);
			this.lblMessage.TabIndex = 15;
			this.lblMessage.Text = "fd";
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnCancel.Location = new System.Drawing.Point(559, 53);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(95, 23);
			this.btnCancel.TabIndex = 18;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// cbxEncrypt
			// 
			this.cbxEncrypt.AutoSize = true;
			this.cbxEncrypt.ForeColor = System.Drawing.Color.White;
			this.cbxEncrypt.Location = new System.Drawing.Point(6, 6);
			this.cbxEncrypt.Name = "cbxEncrypt";
			this.cbxEncrypt.Size = new System.Drawing.Size(130, 17);
			this.cbxEncrypt.TabIndex = 13;
			this.cbxEncrypt.Text = "Encryption password:";
			this.cbxEncrypt.UseVisualStyleBackColor = true;
			this.cbxEncrypt.CheckedChanged += new System.EventHandler(this.CbxEncrypt_CheckedChanged);
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(145, 4);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(197, 20);
			this.txtPassword.TabIndex = 14;
			this.txtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
			// 
			// cbxIntegrated
			// 
			this.cbxIntegrated.Checked = true;
			this.cbxIntegrated.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbxIntegrated.ForeColor = System.Drawing.Color.White;
			this.cbxIntegrated.Location = new System.Drawing.Point(14, 73);
			this.cbxIntegrated.Name = "cbxIntegrated";
			this.cbxIntegrated.Size = new System.Drawing.Size(130, 21);
			this.cbxIntegrated.TabIndex = 5;
			this.cbxIntegrated.Text = "Integrated security";
			this.cbxIntegrated.UseVisualStyleBackColor = true;
			this.cbxIntegrated.CheckedChanged += new System.EventHandler(this.ChkIntegratedCheckedChanged);
			// 
			// txtUserDB
			// 
			this.txtUserDB.Location = new System.Drawing.Point(188, 73);
			this.txtUserDB.Name = "txtUserDB";
			this.txtUserDB.Size = new System.Drawing.Size(100, 20);
			this.txtUserDB.TabIndex = 7;
			this.txtUserDB.Visible = false;
			// 
			// txtPassDB
			// 
			this.txtPassDB.Location = new System.Drawing.Point(353, 73);
			this.txtPassDB.Name = "txtPassDB";
			this.txtPassDB.PasswordChar = '*';
			this.txtPassDB.Size = new System.Drawing.Size(113, 20);
			this.txtPassDB.TabIndex = 9;
			this.txtPassDB.Visible = false;
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.ForeColor = System.Drawing.Color.White;
			this.lblUser.Location = new System.Drawing.Point(150, 76);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(33, 13);
			this.lblUser.TabIndex = 6;
			this.lblUser.Text = "User:";
			this.lblUser.Visible = false;
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.ForeColor = System.Drawing.Color.White;
			this.lblPassword.Location = new System.Drawing.Point(294, 76);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(57, 13);
			this.lblPassword.TabIndex = 8;
			this.lblPassword.Text = "Password:";
			this.lblPassword.Visible = false;
			// 
			// cbxTriggers
			// 
			this.cbxTriggers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbxTriggers.AutoSize = true;
			this.cbxTriggers.Checked = true;
			this.cbxTriggers.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbxTriggers.ForeColor = System.Drawing.Color.White;
			this.cbxTriggers.Location = new System.Drawing.Point(10, 149);
			this.cbxTriggers.Name = "cbxTriggers";
			this.cbxTriggers.Size = new System.Drawing.Size(209, 17);
			this.cbxTriggers.TabIndex = 19;
			this.cbxTriggers.Text = "Create triggers enforcing foreign keys";
			this.cbxTriggers.UseVisualStyleBackColor = true;
			// 
			// cbxCreateViews
			// 
			this.cbxCreateViews.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbxCreateViews.AutoSize = true;
			this.cbxCreateViews.Checked = true;
			this.cbxCreateViews.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbxCreateViews.ForeColor = System.Drawing.Color.White;
			this.cbxCreateViews.Location = new System.Drawing.Point(239, 149);
			this.cbxCreateViews.Name = "cbxCreateViews";
			this.cbxCreateViews.Size = new System.Drawing.Size(254, 17);
			this.cbxCreateViews.TabIndex = 20;
			this.cbxCreateViews.Text = "Try to create views (works only in simple cases)";
			this.cbxCreateViews.UseVisualStyleBackColor = true;
			// 
			// sqlServerGroup
			// 
			this.sqlServerGroup.Controls.Add(this.txtSqlAddress);
			this.sqlServerGroup.Controls.Add(this.label1);
			this.sqlServerGroup.Controls.Add(this.label3);
			this.sqlServerGroup.Controls.Add(this.lblUser);
			this.sqlServerGroup.Controls.Add(this.txtPassDB);
			this.sqlServerGroup.Controls.Add(this.lblPassword);
			this.sqlServerGroup.Controls.Add(this.txtUserDB);
			this.sqlServerGroup.Controls.Add(this.cboDatabases);
			this.sqlServerGroup.Controls.Add(this.cbxIntegrated);
			this.sqlServerGroup.Controls.Add(this.btnSet);
			this.sqlServerGroup.ForeColor = System.Drawing.Color.White;
			this.sqlServerGroup.Location = new System.Drawing.Point(9, 10);
			this.sqlServerGroup.Name = "sqlServerGroup";
			this.sqlServerGroup.Size = new System.Drawing.Size(659, 123);
			this.sqlServerGroup.TabIndex = 21;
			this.sqlServerGroup.TabStop = false;
			this.sqlServerGroup.Text = "SQL Server";
			// 
			// sqliteGroup
			// 
			this.sqliteGroup.Controls.Add(this.encryptPanel);
			this.sqliteGroup.Controls.Add(this.sqliteFileTypeGrp);
			this.sqliteGroup.Controls.Add(this.txtSQLitePath);
			this.sqliteGroup.Controls.Add(this.label2);
			this.sqliteGroup.Controls.Add(this.cbxCopyData);
			this.sqliteGroup.Controls.Add(this.cbxCreateViews);
			this.sqliteGroup.Controls.Add(this.btnBrowseSQLitePath);
			this.sqliteGroup.Controls.Add(this.cbxTriggers);
			this.sqliteGroup.ForeColor = System.Drawing.Color.White;
			this.sqliteGroup.Location = new System.Drawing.Point(9, 144);
			this.sqliteGroup.Name = "sqliteGroup";
			this.sqliteGroup.Size = new System.Drawing.Size(659, 209);
			this.sqliteGroup.TabIndex = 21;
			this.sqliteGroup.TabStop = false;
			this.sqliteGroup.Text = "SQLite";
			// 
			// encryptPanel
			// 
			this.encryptPanel.Controls.Add(this.cbxEncrypt);
			this.encryptPanel.Controls.Add(this.txtPassword);
			this.encryptPanel.Location = new System.Drawing.Point(10, 100);
			this.encryptPanel.Name = "encryptPanel";
			this.encryptPanel.Size = new System.Drawing.Size(368, 28);
			this.encryptPanel.TabIndex = 23;
			// 
			// sqliteFileTypeGrp
			// 
			this.sqliteFileTypeGrp.Controls.Add(this.radSql);
			this.sqliteFileTypeGrp.Controls.Add(this.radDb3);
			this.sqliteFileTypeGrp.Controls.Add(this.radDb);
			this.sqliteFileTypeGrp.ForeColor = System.Drawing.Color.White;
			this.sqliteFileTypeGrp.Location = new System.Drawing.Point(10, 23);
			this.sqliteFileTypeGrp.Name = "sqliteFileTypeGrp";
			this.sqliteFileTypeGrp.Size = new System.Drawing.Size(173, 43);
			this.sqliteFileTypeGrp.TabIndex = 22;
			this.sqliteFileTypeGrp.TabStop = false;
			this.sqliteFileTypeGrp.Text = "Output file Type";
			// 
			// radSql
			// 
			this.radSql.AutoSize = true;
			this.radSql.Location = new System.Drawing.Point(116, 19);
			this.radSql.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.radSql.Name = "radSql";
			this.radSql.Size = new System.Drawing.Size(42, 17);
			this.radSql.TabIndex = 0;
			this.radSql.Tag = "SQLiteScript.sql";
			this.radSql.Text = ".sql";
			this.radSql.UseVisualStyleBackColor = true;
			this.radSql.CheckedChanged += new System.EventHandler(this.RadDb_CheckedChanged);
			// 
			// radDb3
			// 
			this.radDb3.AutoSize = true;
			this.radDb3.Location = new System.Drawing.Point(63, 19);
			this.radDb3.Name = "radDb3";
			this.radDb3.Size = new System.Drawing.Size(47, 17);
			this.radDb3.TabIndex = 0;
			this.radDb3.Tag = "SQLiteDb.db3";
			this.radDb3.Text = ".db3";
			this.radDb3.UseVisualStyleBackColor = true;
			this.radDb3.CheckedChanged += new System.EventHandler(this.RadDb_CheckedChanged);
			// 
			// radDb
			// 
			this.radDb.AutoSize = true;
			this.radDb.Location = new System.Drawing.Point(6, 19);
			this.radDb.Name = "radDb";
			this.radDb.Size = new System.Drawing.Size(41, 17);
			this.radDb.TabIndex = 0;
			this.radDb.Tag = "SQLiteDb.db";
			this.radDb.Text = ".db";
			this.radDb.UseVisualStyleBackColor = true;
			this.radDb.CheckedChanged += new System.EventHandler(this.RadDb_CheckedChanged);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.pbrProgress);
			this.panel2.Controls.Add(this.btnStart);
			this.panel2.Controls.Add(this.lblMessage);
			this.panel2.Controls.Add(this.btnCancel);
			this.panel2.ForeColor = System.Drawing.Color.White;
			this.panel2.Location = new System.Drawing.Point(9, 375);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(659, 82);
			this.panel2.TabIndex = 22;
			// 
			// cbxCopyData
			// 
			this.cbxCopyData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbxCopyData.AutoSize = true;
			this.cbxCopyData.Checked = true;
			this.cbxCopyData.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbxCopyData.ForeColor = System.Drawing.Color.White;
			this.cbxCopyData.Location = new System.Drawing.Point(10, 181);
			this.cbxCopyData.Name = "cbxCopyData";
			this.cbxCopyData.Size = new System.Drawing.Size(126, 17);
			this.cbxCopyData.TabIndex = 20;
			this.cbxCopyData.Text = "Copy data  to SQLite";
			this.cbxCopyData.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(40)))), ((int)(((byte)(140)))));
			this.ClientSize = new System.Drawing.Size(676, 467);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.sqliteGroup);
			this.Controls.Add(this.sqlServerGroup);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SQL Server To SQLite DB Converter";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.sqlServerGroup.ResumeLayout(false);
			this.sqlServerGroup.PerformLayout();
			this.sqliteGroup.ResumeLayout(false);
			this.sqliteGroup.PerformLayout();
			this.encryptPanel.ResumeLayout(false);
			this.encryptPanel.PerformLayout();
			this.sqliteFileTypeGrp.ResumeLayout(false);
			this.sqliteFileTypeGrp.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtPassDB;
        private System.Windows.Forms.TextBox txtUserDB;
        private System.Windows.Forms.CheckBox cbxIntegrated;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSqlAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSQLitePath;
        private System.Windows.Forms.Button btnBrowseSQLitePath;
        private System.Windows.Forms.Button btnStart;
        
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDatabases;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.ProgressBar pbrProgress;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbxEncrypt;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox cbxTriggers;
        private System.Windows.Forms.CheckBox cbxCreateViews;
        private System.Windows.Forms.GroupBox sqlServerGroup;
        private System.Windows.Forms.GroupBox sqliteGroup;
        private System.Windows.Forms.GroupBox sqliteFileTypeGrp;
        private System.Windows.Forms.RadioButton radDb3;
        private System.Windows.Forms.RadioButton radDb;
        private System.Windows.Forms.RadioButton radSql;
        private System.Windows.Forms.Panel encryptPanel;
        private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.CheckBox cbxCopyData;
	}
}
