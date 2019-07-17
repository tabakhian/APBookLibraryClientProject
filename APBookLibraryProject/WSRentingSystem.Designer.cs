namespace APBookLibraryProject
{
	partial class WSRentingSystem
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
			this.label3 = new System.Windows.Forms.Label();
			this.gridViewRentedBooks = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.gridviewLeasedBooks = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.gridviewRentingRequest = new System.Windows.Forms.DataGridView();
			this.bookImage = new System.Windows.Forms.DataGridViewImageColumn();
			this.bookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.userFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.libraryRent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.registerData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.context = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.accept = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reject = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.requestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bookCover = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.library = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cancel = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cover = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.libraryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.returnbtn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rentId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.gridViewRentedBooks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridviewLeasedBooks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridviewRentingRequest)).BeginInit();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 394);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 18);
			this.label3.TabIndex = 31;
			this.label3.Text = "Rented books :";
			// 
			// gridViewRentedBooks
			// 
			this.gridViewRentedBooks.AllowUserToAddRows = false;
			this.gridViewRentedBooks.AllowUserToDeleteRows = false;
			this.gridViewRentedBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridViewRentedBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cover,
            this.dataGridViewTextBoxColumn4,
            this.libraryName,
            this.dataGridViewTextBoxColumn6,
            this.returnbtn,
            this.rentId2});
			this.gridViewRentedBooks.Location = new System.Drawing.Point(15, 423);
			this.gridViewRentedBooks.Name = "gridViewRentedBooks";
			this.gridViewRentedBooks.ReadOnly = true;
			this.gridViewRentedBooks.RowTemplate.Height = 40;
			this.gridViewRentedBooks.Size = new System.Drawing.Size(1015, 122);
			this.gridViewRentedBooks.TabIndex = 30;
			this.gridViewRentedBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewRentedBooks_CellContentClick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 204);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 18);
			this.label2.TabIndex = 29;
			this.label2.Text = "Leased Books :";
			// 
			// gridviewLeasedBooks
			// 
			this.gridviewLeasedBooks.AllowUserToAddRows = false;
			this.gridviewLeasedBooks.AllowUserToDeleteRows = false;
			this.gridviewLeasedBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridviewLeasedBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bookCover,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.library,
            this.dataGridViewTextBoxColumn3,
            this.cancel,
            this.rentId});
			this.gridviewLeasedBooks.Location = new System.Drawing.Point(15, 233);
			this.gridviewLeasedBooks.Name = "gridviewLeasedBooks";
			this.gridviewLeasedBooks.ReadOnly = true;
			this.gridviewLeasedBooks.RowTemplate.Height = 40;
			this.gridviewLeasedBooks.Size = new System.Drawing.Size(1026, 122);
			this.gridviewLeasedBooks.TabIndex = 28;
			this.gridviewLeasedBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridviewLeasedBooks_CellContentClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(167, 18);
			this.label1.TabIndex = 27;
			this.label1.Text = "New Renting Requests :";
			// 
			// gridviewRentingRequest
			// 
			this.gridviewRentingRequest.AllowUserToAddRows = false;
			this.gridviewRentingRequest.AllowUserToDeleteRows = false;
			this.gridviewRentingRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridviewRentingRequest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bookImage,
            this.bookName,
            this.userFullName,
            this.libraryRent,
            this.registerData,
            this.context,
            this.accept,
            this.reject,
            this.requestId});
			this.gridviewRentingRequest.Location = new System.Drawing.Point(15, 47);
			this.gridviewRentingRequest.Name = "gridviewRentingRequest";
			this.gridviewRentingRequest.ReadOnly = true;
			this.gridviewRentingRequest.RowTemplate.Height = 40;
			this.gridviewRentingRequest.Size = new System.Drawing.Size(1026, 122);
			this.gridviewRentingRequest.TabIndex = 0;
			this.gridviewRentingRequest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridviewRentingRequest_CellContentClick);
			// 
			// bookImage
			// 
			this.bookImage.HeaderText = "Cover";
			this.bookImage.Name = "bookImage";
			this.bookImage.ReadOnly = true;
			this.bookImage.Width = 40;
			// 
			// bookName
			// 
			dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.bookName.DefaultCellStyle = dataGridViewCellStyle31;
			this.bookName.HeaderText = "BookName";
			this.bookName.Name = "bookName";
			this.bookName.ReadOnly = true;
			this.bookName.Width = 150;
			// 
			// userFullName
			// 
			dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.userFullName.DefaultCellStyle = dataGridViewCellStyle32;
			this.userFullName.HeaderText = "Renter Name";
			this.userFullName.Name = "userFullName";
			this.userFullName.ReadOnly = true;
			this.userFullName.Width = 120;
			// 
			// libraryRent
			// 
			dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.libraryRent.DefaultCellStyle = dataGridViewCellStyle33;
			this.libraryRent.HeaderText = "Renter Library";
			this.libraryRent.Name = "libraryRent";
			this.libraryRent.ReadOnly = true;
			this.libraryRent.Width = 120;
			// 
			// registerData
			// 
			dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.registerData.DefaultCellStyle = dataGridViewCellStyle34;
			this.registerData.HeaderText = "Register Date";
			this.registerData.Name = "registerData";
			this.registerData.ReadOnly = true;
			this.registerData.Width = 150;
			// 
			// context
			// 
			this.context.HeaderText = "Context";
			this.context.Name = "context";
			this.context.ReadOnly = true;
			this.context.Width = 150;
			// 
			// accept
			// 
			dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.accept.DefaultCellStyle = dataGridViewCellStyle35;
			this.accept.HeaderText = "Accept";
			this.accept.Name = "accept";
			this.accept.ReadOnly = true;
			this.accept.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.accept.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// reject
			// 
			dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			dataGridViewCellStyle36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.reject.DefaultCellStyle = dataGridViewCellStyle36;
			this.reject.HeaderText = "Reject";
			this.reject.Name = "reject";
			this.reject.ReadOnly = true;
			this.reject.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.reject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// requestId
			// 
			this.requestId.HeaderText = "Request Id";
			this.requestId.Name = "requestId";
			this.requestId.ReadOnly = true;
			this.requestId.Visible = false;
			// 
			// bookCover
			// 
			this.bookCover.HeaderText = "Cover";
			this.bookCover.Name = "bookCover";
			this.bookCover.ReadOnly = true;
			this.bookCover.Width = 40;
			// 
			// dataGridViewTextBoxColumn1
			// 
			dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle37;
			this.dataGridViewTextBoxColumn1.HeaderText = "BookName";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 150;
			// 
			// dataGridViewTextBoxColumn2
			// 
			dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle38;
			this.dataGridViewTextBoxColumn2.HeaderText = "Renter Name";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 150;
			// 
			// library
			// 
			dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.library.DefaultCellStyle = dataGridViewCellStyle39;
			this.library.HeaderText = "Renter Library";
			this.library.Name = "library";
			this.library.ReadOnly = true;
			this.library.Width = 150;
			// 
			// dataGridViewTextBoxColumn3
			// 
			dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle40;
			this.dataGridViewTextBoxColumn3.HeaderText = "Register Date";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Width = 150;
			// 
			// cancel
			// 
			dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle41.ForeColor = System.Drawing.Color.Navy;
			this.cancel.DefaultCellStyle = dataGridViewCellStyle41;
			this.cancel.HeaderText = "Cancel";
			this.cancel.Name = "cancel";
			this.cancel.ReadOnly = true;
			this.cancel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.cancel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// rentId
			// 
			this.rentId.HeaderText = "RentId";
			this.rentId.Name = "rentId";
			this.rentId.ReadOnly = true;
			this.rentId.Visible = false;
			// 
			// cover
			// 
			this.cover.HeaderText = "Cover";
			this.cover.Name = "cover";
			this.cover.ReadOnly = true;
			this.cover.Width = 40;
			// 
			// dataGridViewTextBoxColumn4
			// 
			dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle42;
			this.dataGridViewTextBoxColumn4.HeaderText = "BookName";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Width = 200;
			// 
			// libraryName
			// 
			dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.libraryName.DefaultCellStyle = dataGridViewCellStyle43;
			this.libraryName.HeaderText = "From Library";
			this.libraryName.Name = "libraryName";
			this.libraryName.ReadOnly = true;
			this.libraryName.Width = 150;
			// 
			// dataGridViewTextBoxColumn6
			// 
			dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle44;
			this.dataGridViewTextBoxColumn6.HeaderText = "Register Date";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Width = 200;
			// 
			// returnbtn
			// 
			dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle45.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.returnbtn.DefaultCellStyle = dataGridViewCellStyle45;
			this.returnbtn.HeaderText = "Return Book";
			this.returnbtn.Name = "returnbtn";
			this.returnbtn.ReadOnly = true;
			this.returnbtn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.returnbtn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// rentId2
			// 
			this.rentId2.HeaderText = "RentId";
			this.rentId2.Name = "rentId2";
			this.rentId2.ReadOnly = true;
			this.rentId2.Visible = false;
			// 
			// WSRentingSystem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1053, 560);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.gridViewRentedBooks);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.gridviewLeasedBooks);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.gridviewRentingRequest);
			this.Name = "WSRentingSystem";
			this.Text = "Book Renting Info";
			this.Activated += new System.EventHandler(this.WSRentingSystem_Activated);
			this.Load += new System.EventHandler(this.WSRentingSystem_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridViewRentedBooks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridviewLeasedBooks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridviewRentingRequest)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView gridviewRentingRequest;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView gridviewLeasedBooks;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView gridViewRentedBooks;
		private System.Windows.Forms.DataGridViewImageColumn bookImage;
		private System.Windows.Forms.DataGridViewTextBoxColumn bookName;
		private System.Windows.Forms.DataGridViewTextBoxColumn userFullName;
		private System.Windows.Forms.DataGridViewTextBoxColumn libraryRent;
		private System.Windows.Forms.DataGridViewTextBoxColumn registerData;
		private System.Windows.Forms.DataGridViewTextBoxColumn context;
		private System.Windows.Forms.DataGridViewTextBoxColumn accept;
		private System.Windows.Forms.DataGridViewTextBoxColumn reject;
		private System.Windows.Forms.DataGridViewTextBoxColumn requestId;
		private System.Windows.Forms.DataGridViewImageColumn bookCover;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn library;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn cancel;
		private System.Windows.Forms.DataGridViewTextBoxColumn rentId;
		private System.Windows.Forms.DataGridViewImageColumn cover;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn libraryName;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn returnbtn;
		private System.Windows.Forms.DataGridViewTextBoxColumn rentId2;
	}
}