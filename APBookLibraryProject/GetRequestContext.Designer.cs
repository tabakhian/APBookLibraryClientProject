namespace APBookLibraryProject
{
	partial class GetRequestContext
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
			this.btnOk = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.richTextBox = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
			this.btnOk.Location = new System.Drawing.Point(10, 122);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(310, 32);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "Rent The Book";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.label1.Location = new System.Drawing.Point(7, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(204, 17);
			this.label1.TabIndex = 28;
			this.label1.Text = "Why Do You Need This Book ?";
			// 
			// richTextBox
			// 
			this.richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
			this.richTextBox.Location = new System.Drawing.Point(12, 39);
			this.richTextBox.Name = "richTextBox";
			this.richTextBox.Size = new System.Drawing.Size(308, 77);
			this.richTextBox.TabIndex = 29;
			this.richTextBox.Text = "";
			// 
			// GetRequestContext
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(332, 162);
			this.Controls.Add(this.richTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOk);
			this.Name = "GetRequestContext";
			this.Text = "Request Context";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox richTextBox;
	}
}