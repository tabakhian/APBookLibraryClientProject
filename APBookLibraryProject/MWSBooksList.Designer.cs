namespace APBookLibraryProject
{
	partial class MWSBooksList
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
			this.BooksGridView = new System.Windows.Forms.DataGridView();
			this.image = new System.Windows.Forms.DataGridViewImageColumn();
			this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.HostLibrary = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.author = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.translator = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.publishing = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.BooksGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// ShowAllClick
			// 
			this.ShowAllClick.Location = new System.Drawing.Point(693, 8);
			this.ShowAllClick.Name = "ShowAllClick";
			this.ShowAllClick.Size = new System.Drawing.Size(148, 24);
			this.ShowAllClick.TabIndex = 10;
			this.ShowAllClick.Text = "ShowAllBooks";
			this.ShowAllClick.UseVisualStyleBackColor = true;
			this.ShowAllClick.Click += new System.EventHandler(this.ShowAllClick_Click);
			// 
			// Searchtxt
			// 
			this.Searchtxt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.Searchtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Searchtxt.Location = new System.Drawing.Point(12, 8);
			this.Searchtxt.Name = "Searchtxt";
			this.Searchtxt.Size = new System.Drawing.Size(675, 24);
			this.Searchtxt.TabIndex = 9;
			this.Searchtxt.Text = "Search here...";
			this.Searchtxt.TextChanged += new System.EventHandler(this.Searchtxt_TextChanged);
			this.Searchtxt.Enter += new System.EventHandler(this.SearchPlaceHolderRemoveText);
			this.Searchtxt.Leave += new System.EventHandler(this.SearchPlaceHolderAddText);
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
            this.HostLibrary,
            this.author,
            this.translator,
            this.publishing,
            this.price});
			this.BooksGridView.Location = new System.Drawing.Point(12, 40);
			this.BooksGridView.Name = "BooksGridView";
			this.BooksGridView.ReadOnly = true;
			this.BooksGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.BooksGridView.RowTemplate.Height = 50;
			this.BooksGridView.Size = new System.Drawing.Size(829, 471);
			this.BooksGridView.TabIndex = 8;
			this.BooksGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BookGridView_SelectionChanged);
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
			this.name.Width = 130;
			// 
			// HostLibrary
			// 
			this.HostLibrary.HeaderText = "Host Library";
			this.HostLibrary.Name = "HostLibrary";
			this.HostLibrary.ReadOnly = true;
			this.HostLibrary.Width = 120;
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
			// MWSBooksList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(853, 520);
			this.Controls.Add(this.ShowAllClick);
			this.Controls.Add(this.Searchtxt);
			this.Controls.Add(this.BooksGridView);
			this.Name = "MWSBooksList";
			this.Text = "Online Books World";
			this.Activated += new System.EventHandler(this.Page_Activated);
			this.Load += new System.EventHandler(this.MWSBooksList_Load);
			((System.ComponentModel.ISupportInitialize)(this.BooksGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ShowAllClick;
		private System.Windows.Forms.TextBox Searchtxt;
		private System.Windows.Forms.DataGridView BooksGridView;
		private System.Windows.Forms.DataGridViewImageColumn image;
		private System.Windows.Forms.DataGridViewTextBoxColumn name;
		private System.Windows.Forms.DataGridViewTextBoxColumn HostLibrary;
		private System.Windows.Forms.DataGridViewTextBoxColumn author;
		private System.Windows.Forms.DataGridViewTextBoxColumn translator;
		private System.Windows.Forms.DataGridViewTextBoxColumn publishing;
		private System.Windows.Forms.DataGridViewTextBoxColumn price;
	}
}