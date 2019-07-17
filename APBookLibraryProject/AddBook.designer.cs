namespace APBookLibraryProject
{
    partial class AddBook
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
			this.AddClick = new System.Windows.Forms.Button();
			this.Pricetxt = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.Circulationtxt = new System.Windows.Forms.TextBox();
			this.PublishedDatetxt = new System.Windows.Forms.TextBox();
			this.Publishertxt = new System.Windows.Forms.TextBox();
			this.Authoretxt = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.Nametxt = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.Translatortxt = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.BookTextRichBox = new System.Windows.Forms.RichTextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.AddImageClick = new System.Windows.Forms.Button();
			this.ISBNtxt = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.pictureBook = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBook)).BeginInit();
			this.SuspendLayout();
			// 
			// AddClick
			// 
			this.AddClick.Location = new System.Drawing.Point(12, 440);
			this.AddClick.Name = "AddClick";
			this.AddClick.Size = new System.Drawing.Size(726, 34);
			this.AddClick.TabIndex = 1;
			this.AddClick.Text = "AddBook";
			this.AddClick.UseVisualStyleBackColor = true;
			this.AddClick.Click += new System.EventHandler(this.AddClick_Click);
			// 
			// Pricetxt
			// 
			this.Pricetxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.Pricetxt.Location = new System.Drawing.Point(100, 234);
			this.Pricetxt.Name = "Pricetxt";
			this.Pricetxt.Size = new System.Drawing.Size(138, 20);
			this.Pricetxt.TabIndex = 34;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(14, 237);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(37, 13);
			this.label9.TabIndex = 33;
			this.label9.Text = "Price :";
			// 
			// Circulationtxt
			// 
			this.Circulationtxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.Circulationtxt.Location = new System.Drawing.Point(100, 197);
			this.Circulationtxt.Name = "Circulationtxt";
			this.Circulationtxt.Size = new System.Drawing.Size(138, 20);
			this.Circulationtxt.TabIndex = 30;
			// 
			// PublishedDatetxt
			// 
			this.PublishedDatetxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.PublishedDatetxt.Location = new System.Drawing.Point(100, 161);
			this.PublishedDatetxt.Name = "PublishedDatetxt";
			this.PublishedDatetxt.Size = new System.Drawing.Size(138, 20);
			this.PublishedDatetxt.TabIndex = 28;
			// 
			// Publishertxt
			// 
			this.Publishertxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.Publishertxt.Location = new System.Drawing.Point(100, 126);
			this.Publishertxt.Name = "Publishertxt";
			this.Publishertxt.Size = new System.Drawing.Size(138, 20);
			this.Publishertxt.TabIndex = 27;
			// 
			// Authoretxt
			// 
			this.Authoretxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.Authoretxt.Location = new System.Drawing.Point(100, 55);
			this.Authoretxt.Name = "Authoretxt";
			this.Authoretxt.Size = new System.Drawing.Size(138, 20);
			this.Authoretxt.TabIndex = 26;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(27, 157);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(0, 13);
			this.label7.TabIndex = 25;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(26, 210);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(0, 13);
			this.label6.TabIndex = 24;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 204);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(62, 13);
			this.label5.TabIndex = 23;
			this.label5.Text = "Circulation :";
			// 
			// Nametxt
			// 
			this.Nametxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.Nametxt.Location = new System.Drawing.Point(100, 17);
			this.Nametxt.Name = "Nametxt";
			this.Nametxt.Size = new System.Drawing.Size(138, 20);
			this.Nametxt.TabIndex = 22;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(81, 13);
			this.label4.TabIndex = 21;
			this.label4.Text = "Published Year:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 133);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 20;
			this.label3.Text = "Publisher :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "Authore :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 18;
			this.label1.Text = "Name :";
			// 
			// Translatortxt
			// 
			this.Translatortxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.Translatortxt.Location = new System.Drawing.Point(100, 90);
			this.Translatortxt.Name = "Translatortxt";
			this.Translatortxt.Size = new System.Drawing.Size(138, 20);
			this.Translatortxt.TabIndex = 36;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 97);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(60, 13);
			this.label8.TabIndex = 35;
			this.label8.Text = "Translator :";
			// 
			// BookTextRichBox
			// 
			this.BookTextRichBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.BookTextRichBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BookTextRichBox.Location = new System.Drawing.Point(256, 17);
			this.BookTextRichBox.Name = "BookTextRichBox";
			this.BookTextRichBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.BookTextRichBox.Size = new System.Drawing.Size(482, 417);
			this.BookTextRichBox.TabIndex = 37;
			this.BookTextRichBox.Text = "";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "OpenFileDialog";
			// 
			// AddImageClick
			// 
			this.AddImageClick.Location = new System.Drawing.Point(12, 299);
			this.AddImageClick.Name = "AddImageClick";
			this.AddImageClick.Size = new System.Drawing.Size(82, 24);
			this.AddImageClick.TabIndex = 39;
			this.AddImageClick.Text = "AddImage";
			this.AddImageClick.UseVisualStyleBackColor = true;
			this.AddImageClick.Click += new System.EventHandler(this.AddImage_Click);
			// 
			// ISBNtxt
			// 
			this.ISBNtxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.ISBNtxt.Location = new System.Drawing.Point(100, 267);
			this.ISBNtxt.Name = "ISBNtxt";
			this.ISBNtxt.Size = new System.Drawing.Size(138, 20);
			this.ISBNtxt.TabIndex = 42;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(13, 270);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(38, 13);
			this.label10.TabIndex = 41;
			this.label10.Text = "ISBN :";
			// 
			// pictureBook
			// 
			this.pictureBook.Location = new System.Drawing.Point(100, 299);
			this.pictureBook.Name = "pictureBook";
			this.pictureBook.Size = new System.Drawing.Size(135, 135);
			this.pictureBook.TabIndex = 66;
			this.pictureBook.TabStop = false;
			this.pictureBook.Visible = false;
			// 
			// AddBook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(745, 479);
			this.Controls.Add(this.pictureBook);
			this.Controls.Add(this.ISBNtxt);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.AddImageClick);
			this.Controls.Add(this.BookTextRichBox);
			this.Controls.Add(this.Translatortxt);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.Pricetxt);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.Circulationtxt);
			this.Controls.Add(this.PublishedDatetxt);
			this.Controls.Add(this.Publishertxt);
			this.Controls.Add(this.Authoretxt);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.Nametxt);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.AddClick);
			this.Name = "AddBook";
			this.Text = "Add Book";
			this.Load += new System.EventHandler(this.AddBook_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBook)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddClick;
        private System.Windows.Forms.TextBox Pricetxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Circulationtxt;
        private System.Windows.Forms.TextBox PublishedDatetxt;
        private System.Windows.Forms.TextBox Publishertxt;
        private System.Windows.Forms.TextBox Authoretxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Nametxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Translatortxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox BookTextRichBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button AddImageClick;
		private System.Windows.Forms.TextBox ISBNtxt;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.PictureBox pictureBook;
	}
}