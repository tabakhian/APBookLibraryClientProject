namespace APBookLibraryProject
{
    partial class MainPage
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
			this.BooksGridView = new System.Windows.Forms.DataGridView();
			this.image = new System.Windows.Forms.DataGridViewImageColumn();
			this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.author = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.translator = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.publishing = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Searchtxt = new System.Windows.Forms.TextBox();
			this.AddBookClick = new System.Windows.Forms.Button();
			this.ShowAllClick = new System.Windows.Forms.Button();
			this.lblWelcome = new System.Windows.Forms.Label();
			this.btnLogout = new System.Windows.Forms.PictureBox();
			this.btnManageUsers = new System.Windows.Forms.Button();
			this.btnWSBookList = new System.Windows.Forms.Button();
			this.btnBookRentingSystem = new System.Windows.Forms.Button();
			this.btnSettings = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lblRequestCount = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.BooksGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnLogout)).BeginInit();
			this.SuspendLayout();
			// 
			// BooksGridView
			// 
			this.BooksGridView.AllowUserToAddRows = false;
			this.BooksGridView.AllowUserToDeleteRows = false;
			this.BooksGridView.AllowUserToOrderColumns = true;
			this.BooksGridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.BooksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.BooksGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.image,
            this.name,
            this.author,
            this.translator,
            this.publishing,
            this.price});
			this.BooksGridView.Location = new System.Drawing.Point(273, 44);
			this.BooksGridView.Name = "BooksGridView";
			this.BooksGridView.ReadOnly = true;
			this.BooksGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.BooksGridView.RowTemplate.Height = 50;
			this.BooksGridView.Size = new System.Drawing.Size(687, 471);
			this.BooksGridView.TabIndex = 0;
			this.BooksGridView.DoubleClick += new System.EventHandler(this.BookGridView_SelectionChanged);
			// 
			// image
			// 
			this.image.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.image.HeaderText = "Image";
			this.image.Name = "image";
			this.image.ReadOnly = true;
			this.image.Width = 50;
			// 
			// name
			// 
			this.name.HeaderText = "Name";
			this.name.Name = "name";
			this.name.ReadOnly = true;
			// 
			// author
			// 
			this.author.HeaderText = "Author";
			this.author.Name = "author";
			this.author.ReadOnly = true;
			this.author.Width = 150;
			// 
			// translator
			// 
			this.translator.HeaderText = "Translator";
			this.translator.Name = "translator";
			this.translator.ReadOnly = true;
			this.translator.Width = 150;
			// 
			// publishing
			// 
			this.publishing.HeaderText = "Publishing";
			this.publishing.Name = "publishing";
			this.publishing.ReadOnly = true;
			// 
			// price
			// 
			this.price.HeaderText = "Price";
			this.price.Name = "price";
			this.price.ReadOnly = true;
			this.price.Width = 50;
			// 
			// Searchtxt
			// 
			this.Searchtxt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.Searchtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Searchtxt.Location = new System.Drawing.Point(273, 12);
			this.Searchtxt.Name = "Searchtxt";
			this.Searchtxt.Size = new System.Drawing.Size(533, 24);
			this.Searchtxt.TabIndex = 2;
			this.Searchtxt.Text = "Search here...";
			this.Searchtxt.TextChanged += new System.EventHandler(this.Searchtxt_TextChanged);
			this.Searchtxt.Enter += new System.EventHandler(this.SearchPlaceHolderRemoveText);
			this.Searchtxt.Leave += new System.EventHandler(this.SearchPlaceHolderAddText);
			// 
			// AddBookClick
			// 
			this.AddBookClick.Location = new System.Drawing.Point(23, 73);
			this.AddBookClick.Name = "AddBookClick";
			this.AddBookClick.Size = new System.Drawing.Size(229, 37);
			this.AddBookClick.TabIndex = 5;
			this.AddBookClick.Text = "Add New Book";
			this.AddBookClick.UseVisualStyleBackColor = true;
			this.AddBookClick.Click += new System.EventHandler(this.AddBookClick_Click);
			// 
			// ShowAllClick
			// 
			this.ShowAllClick.Location = new System.Drawing.Point(812, 12);
			this.ShowAllClick.Name = "ShowAllClick";
			this.ShowAllClick.Size = new System.Drawing.Size(148, 24);
			this.ShowAllClick.TabIndex = 7;
			this.ShowAllClick.Text = "ShowAllBooks";
			this.ShowAllClick.UseVisualStyleBackColor = true;
			this.ShowAllClick.Click += new System.EventHandler(this.ShowAllClick_Click);
			// 
			// lblWelcome
			// 
			this.lblWelcome.AutoSize = true;
			this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWelcome.Location = new System.Drawing.Point(43, 17);
			this.lblWelcome.Name = "lblWelcome";
			this.lblWelcome.Size = new System.Drawing.Size(58, 16);
			this.lblWelcome.TabIndex = 8;
			this.lblWelcome.Text = "Welcom";
			// 
			// btnLogout
			// 
			this.btnLogout.Location = new System.Drawing.Point(12, 12);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.Size = new System.Drawing.Size(25, 25);
			this.btnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.btnLogout.TabIndex = 9;
			this.btnLogout.TabStop = false;
			this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
			// 
			// btnManageUsers
			// 
			this.btnManageUsers.Location = new System.Drawing.Point(23, 125);
			this.btnManageUsers.Name = "btnManageUsers";
			this.btnManageUsers.Size = new System.Drawing.Size(229, 37);
			this.btnManageUsers.TabIndex = 10;
			this.btnManageUsers.Text = "Manage All Users";
			this.btnManageUsers.UseVisualStyleBackColor = true;
			this.btnManageUsers.Visible = false;
			this.btnManageUsers.Click += new System.EventHandler(this.BtnManageUsers_Click);
			// 
			// btnWSBookList
			// 
			this.btnWSBookList.Location = new System.Drawing.Point(23, 227);
			this.btnWSBookList.Name = "btnWSBookList";
			this.btnWSBookList.Size = new System.Drawing.Size(229, 37);
			this.btnWSBookList.TabIndex = 11;
			this.btnWSBookList.Text = "Online Book World !";
			this.btnWSBookList.UseVisualStyleBackColor = true;
			this.btnWSBookList.Visible = false;
			this.btnWSBookList.Click += new System.EventHandler(this.BtnWSBookList_Click);
			// 
			// btnBookRentingSystem
			// 
			this.btnBookRentingSystem.Location = new System.Drawing.Point(23, 309);
			this.btnBookRentingSystem.Name = "btnBookRentingSystem";
			this.btnBookRentingSystem.Size = new System.Drawing.Size(229, 37);
			this.btnBookRentingSystem.TabIndex = 12;
			this.btnBookRentingSystem.Text = "Book Renting System";
			this.btnBookRentingSystem.UseVisualStyleBackColor = true;
			this.btnBookRentingSystem.Visible = false;
			this.btnBookRentingSystem.Click += new System.EventHandler(this.BtnBookRentingSystem_Click);
			// 
			// btnSettings
			// 
			this.btnSettings.Location = new System.Drawing.Point(23, 478);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(229, 37);
			this.btnSettings.TabIndex = 13;
			this.btnSettings.Text = "Administrative Library Settings";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Visible = false;
			this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(23, 283);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(190, 16);
			this.label1.TabIndex = 14;
			this.label1.Text = "Check Last Renting Requests :";
			// 
			// lblRequestCount
			// 
			this.lblRequestCount.AutoSize = true;
			this.lblRequestCount.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblRequestCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRequestCount.ForeColor = System.Drawing.Color.Red;
			this.lblRequestCount.Location = new System.Drawing.Point(220, 282);
			this.lblRequestCount.Name = "lblRequestCount";
			this.lblRequestCount.Size = new System.Drawing.Size(19, 20);
			this.lblRequestCount.TabIndex = 15;
			this.lblRequestCount.Text = "0";
			// 
			// MainPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ClientSize = new System.Drawing.Size(972, 527);
			this.Controls.Add(this.lblRequestCount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.btnBookRentingSystem);
			this.Controls.Add(this.btnWSBookList);
			this.Controls.Add(this.btnManageUsers);
			this.Controls.Add(this.btnLogout);
			this.Controls.Add(this.lblWelcome);
			this.Controls.Add(this.ShowAllClick);
			this.Controls.Add(this.AddBookClick);
			this.Controls.Add(this.Searchtxt);
			this.Controls.Add(this.BooksGridView);
			this.Name = "MainPage";
			this.Text = "Library Main";
			this.Activated += new System.EventHandler(this.MainPage_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainPage_FormClosed);
			this.Load += new System.EventHandler(this.MainPage_Load);
			((System.ComponentModel.ISupportInitialize)(this.BooksGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnLogout)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView BooksGridView;
        private System.Windows.Forms.TextBox Searchtxt;
        private System.Windows.Forms.Button AddBookClick;
        private System.Windows.Forms.Button ShowAllClick;
		private System.Windows.Forms.DataGridViewImageColumn image;
		private System.Windows.Forms.DataGridViewTextBoxColumn name;
		private System.Windows.Forms.DataGridViewTextBoxColumn author;
		private System.Windows.Forms.DataGridViewTextBoxColumn translator;
		private System.Windows.Forms.DataGridViewTextBoxColumn publishing;
		private System.Windows.Forms.DataGridViewTextBoxColumn price;
		private System.Windows.Forms.Label lblWelcome;
		private System.Windows.Forms.PictureBox btnLogout;
		private System.Windows.Forms.Button btnManageUsers;
		private System.Windows.Forms.Button btnWSBookList;
		private System.Windows.Forms.Button btnBookRentingSystem;
		private System.Windows.Forms.Button btnSettings;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblRequestCount;
	}
}