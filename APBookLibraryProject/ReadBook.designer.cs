namespace APBookLibraryProject
{
	partial class ReadBook
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
			this.label1 = new System.Windows.Forms.Label();
			this.ComboFontStyle = new System.Windows.Forms.ComboBox();
			this.comboFontFamily = new System.Windows.Forms.ComboBox();
			this.comboFontSize = new System.Windows.Forms.ComboBox();
			this.btnLastPage = new System.Windows.Forms.Button();
			this.btnNextPage = new System.Windows.Forms.Button();
			this.txtGotoPage = new System.Windows.Forms.TextBox();
			this.txtBookText = new System.Windows.Forms.RichTextBox();
			this.txtPageCount = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnExportPDF = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.btnExportToWord = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 16);
			this.label1.TabIndex = 8;
			this.label1.Text = "Font Settings :";
			// 
			// ComboFontStyle
			// 
			this.ComboFontStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ComboFontStyle.FormattingEnabled = true;
			this.ComboFontStyle.Location = new System.Drawing.Point(24, 131);
			this.ComboFontStyle.Name = "ComboFontStyle";
			this.ComboFontStyle.Size = new System.Drawing.Size(127, 24);
			this.ComboFontStyle.TabIndex = 7;
			this.ComboFontStyle.SelectedIndexChanged += new System.EventHandler(this.ComboFontStyle_SelectedIndexChanged);
			// 
			// comboFontFamily
			// 
			this.comboFontFamily.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboFontFamily.FormattingEnabled = true;
			this.comboFontFamily.Location = new System.Drawing.Point(24, 44);
			this.comboFontFamily.Name = "comboFontFamily";
			this.comboFontFamily.Size = new System.Drawing.Size(127, 24);
			this.comboFontFamily.TabIndex = 6;
			this.comboFontFamily.SelectedIndexChanged += new System.EventHandler(this.ComboFontFamily_SelectedIndexChanged);
			// 
			// comboFontSize
			// 
			this.comboFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboFontSize.FormattingEnabled = true;
			this.comboFontSize.Location = new System.Drawing.Point(24, 89);
			this.comboFontSize.Name = "comboFontSize";
			this.comboFontSize.Size = new System.Drawing.Size(127, 24);
			this.comboFontSize.TabIndex = 5;
			this.comboFontSize.SelectedIndexChanged += new System.EventHandler(this.ComboFontSize_SelectedIndexChanged);
			// 
			// btnLastPage
			// 
			this.btnLastPage.Location = new System.Drawing.Point(353, 570);
			this.btnLastPage.Name = "btnLastPage";
			this.btnLastPage.Size = new System.Drawing.Size(75, 23);
			this.btnLastPage.TabIndex = 4;
			this.btnLastPage.Text = "Last";
			this.btnLastPage.UseVisualStyleBackColor = true;
			this.btnLastPage.Click += new System.EventHandler(this.BtnLastPage_Click);
			// 
			// btnNextPage
			// 
			this.btnNextPage.Location = new System.Drawing.Point(575, 570);
			this.btnNextPage.Name = "btnNextPage";
			this.btnNextPage.Size = new System.Drawing.Size(75, 23);
			this.btnNextPage.TabIndex = 3;
			this.btnNextPage.Text = "Next ";
			this.btnNextPage.UseVisualStyleBackColor = true;
			this.btnNextPage.Click += new System.EventHandler(this.BtnNextPage_Click);
			// 
			// txtGotoPage
			// 
			this.txtGotoPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtGotoPage.Location = new System.Drawing.Point(434, 566);
			this.txtGotoPage.Name = "txtGotoPage";
			this.txtGotoPage.Size = new System.Drawing.Size(42, 29);
			this.txtGotoPage.TabIndex = 2;
			this.txtGotoPage.Text = "0";
			this.txtGotoPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtGotoPage.TextChanged += new System.EventHandler(this.TxtGotoPage_TextChanged);
			// 
			// txtBookText
			// 
			this.txtBookText.Location = new System.Drawing.Point(172, 12);
			this.txtBookText.Name = "txtBookText";
			this.txtBookText.ReadOnly = true;
			this.txtBookText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtBookText.Size = new System.Drawing.Size(639, 540);
			this.txtBookText.TabIndex = 1;
			this.txtBookText.Text = "";
			// 
			// txtPageCount
			// 
			this.txtPageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPageCount.Location = new System.Drawing.Point(527, 566);
			this.txtPageCount.Name = "txtPageCount";
			this.txtPageCount.ReadOnly = true;
			this.txtPageCount.Size = new System.Drawing.Size(42, 29);
			this.txtPageCount.TabIndex = 9;
			this.txtPageCount.Text = "0";
			this.txtPageCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(482, 573);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 16);
			this.label2.TabIndex = 10;
			this.label2.Text = "From";
			// 
			// btnExportPDF
			// 
			this.btnExportPDF.Location = new System.Drawing.Point(15, 469);
			this.btnExportPDF.Name = "btnExportPDF";
			this.btnExportPDF.Size = new System.Drawing.Size(136, 33);
			this.btnExportPDF.TabIndex = 11;
			this.btnExportPDF.Text = "Export Book To PDF";
			this.btnExportPDF.UseVisualStyleBackColor = true;
			this.btnExportPDF.Click += new System.EventHandler(this.BtnExportPDF_Click);
			// 
			// btnExportToWord
			// 
			this.btnExportToWord.Location = new System.Drawing.Point(15, 430);
			this.btnExportToWord.Name = "btnExportToWord";
			this.btnExportToWord.Size = new System.Drawing.Size(136, 33);
			this.btnExportToWord.TabIndex = 12;
			this.btnExportToWord.Text = "Export Book To Word";
			this.btnExportToWord.UseVisualStyleBackColor = true;
			this.btnExportToWord.Click += new System.EventHandler(this.BtnExportToWord_Click);
			// 
			// ReadBook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(823, 605);
			this.Controls.Add(this.btnExportToWord);
			this.Controls.Add(this.btnExportPDF);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtPageCount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ComboFontStyle);
			this.Controls.Add(this.comboFontFamily);
			this.Controls.Add(this.comboFontSize);
			this.Controls.Add(this.btnLastPage);
			this.Controls.Add(this.btnNextPage);
			this.Controls.Add(this.txtGotoPage);
			this.Controls.Add(this.txtBookText);
			this.Name = "ReadBook";
			this.Text = "Read Book";
			this.Load += new System.EventHandler(this.ReadBook_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox txtBookText;
		private System.Windows.Forms.TextBox txtGotoPage;
		private System.Windows.Forms.Button btnNextPage;
		private System.Windows.Forms.Button btnLastPage;
		private System.Windows.Forms.ComboBox comboFontSize;
		private System.Windows.Forms.ComboBox comboFontFamily;
		private System.Windows.Forms.ComboBox ComboFontStyle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPageCount;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnExportPDF;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button btnExportToWord;
	}
}