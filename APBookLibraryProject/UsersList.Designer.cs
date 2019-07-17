namespace APBookLibraryProject
{
	partial class UsersList
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ShowAllClick = new System.Windows.Forms.Button();
			this.Searchtxt = new System.Windows.Forms.TextBox();
			this.UsersGridView = new System.Windows.Forms.DataGridView();
			this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.emailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.phoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.role = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lblRole = new System.Windows.Forms.Label();
			this.lblCanEdit = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// ShowAllClick
			// 
			this.ShowAllClick.Location = new System.Drawing.Point(812, 12);
			this.ShowAllClick.Name = "ShowAllClick";
			this.ShowAllClick.Size = new System.Drawing.Size(148, 24);
			this.ShowAllClick.TabIndex = 10;
			this.ShowAllClick.Text = "ShowAllUsers";
			this.ShowAllClick.UseVisualStyleBackColor = true;
			this.ShowAllClick.Click += new System.EventHandler(this.ShowAllClick_Click);
			// 
			// Searchtxt
			// 
			this.Searchtxt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.Searchtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Searchtxt.Location = new System.Drawing.Point(202, 12);
			this.Searchtxt.Name = "Searchtxt";
			this.Searchtxt.Size = new System.Drawing.Size(604, 24);
			this.Searchtxt.TabIndex = 9;
			this.Searchtxt.Text = "Search here...";
			this.Searchtxt.TextChanged += new System.EventHandler(this.Searchtxt_TextChanged);
			this.Searchtxt.Enter += new System.EventHandler(this.SearchPlaceHolderRemoveText);
			this.Searchtxt.Leave += new System.EventHandler(this.SearchPlaceHolderAddText);
			// 
			// UsersGridView
			// 
			this.UsersGridView.AllowUserToAddRows = false;
			this.UsersGridView.AllowUserToDeleteRows = false;
			this.UsersGridView.AllowUserToOrderColumns = true;
			this.UsersGridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.UsersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.UsersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.firstName,
            this.lastName,
            this.username,
            this.emailAddress,
            this.phoneNumber,
            this.role});
			this.UsersGridView.Location = new System.Drawing.Point(202, 44);
			this.UsersGridView.Name = "UsersGridView";
			this.UsersGridView.ReadOnly = true;
			this.UsersGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.UsersGridView.RowTemplate.Height = 30;
			this.UsersGridView.Size = new System.Drawing.Size(758, 471);
			this.UsersGridView.TabIndex = 8;
			this.UsersGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UsersGridView_MouseDoubleClick);
			// 
			// firstName
			// 
			this.firstName.HeaderText = "FirstName";
			this.firstName.Name = "firstName";
			this.firstName.ReadOnly = true;
			this.firstName.Width = 130;
			// 
			// lastName
			// 
			this.lastName.HeaderText = "LastName";
			this.lastName.Name = "lastName";
			this.lastName.ReadOnly = true;
			this.lastName.Width = 130;
			// 
			// username
			// 
			this.username.HeaderText = "Username";
			this.username.Name = "username";
			this.username.ReadOnly = true;
			// 
			// emailAddress
			// 
			this.emailAddress.HeaderText = "EmailAddress";
			this.emailAddress.Name = "emailAddress";
			this.emailAddress.ReadOnly = true;
			this.emailAddress.Width = 130;
			// 
			// phoneNumber
			// 
			this.phoneNumber.HeaderText = "PhoneNumber";
			this.phoneNumber.Name = "phoneNumber";
			this.phoneNumber.ReadOnly = true;
			// 
			// role
			// 
			this.role.HeaderText = "Role";
			this.role.Name = "role";
			this.role.ReadOnly = true;
			this.role.Width = 80;
			// 
			// lblRole
			// 
			this.lblRole.AutoSize = true;
			this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRole.Location = new System.Drawing.Point(12, 16);
			this.lblRole.Name = "lblRole";
			this.lblRole.Size = new System.Drawing.Size(68, 16);
			this.lblRole.TabIndex = 13;
			this.lblRole.Text = "Your Role";
			// 
			// lblCanEdit
			// 
			this.lblCanEdit.AutoSize = true;
			this.lblCanEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCanEdit.Location = new System.Drawing.Point(12, 48);
			this.lblCanEdit.Name = "lblCanEdit";
			this.lblCanEdit.Size = new System.Drawing.Size(124, 32);
			this.lblCanEdit.TabIndex = 14;
			this.lblCanEdit.Text = "You Can Edit Users\r\nWith Lower Role";
			// 
			// UsersList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(972, 527);
			this.Controls.Add(this.lblCanEdit);
			this.Controls.Add(this.lblRole);
			this.Controls.Add(this.ShowAllClick);
			this.Controls.Add(this.Searchtxt);
			this.Controls.Add(this.UsersGridView);
			this.Name = "UsersList";
			this.Text = "Users List";
			this.Activated += new System.EventHandler(this.UsersList_Enter);
			this.Load += new System.EventHandler(this.UsersList_Load);
			((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ShowAllClick;
		private System.Windows.Forms.TextBox Searchtxt;
		private System.Windows.Forms.DataGridView UsersGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
		private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
		private System.Windows.Forms.DataGridViewTextBoxColumn username;
		private System.Windows.Forms.DataGridViewTextBoxColumn emailAddress;
		private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn role;
		private System.Windows.Forms.Label lblRole;
		private System.Windows.Forms.Label lblCanEdit;
	}
}