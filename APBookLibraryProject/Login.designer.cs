namespace APBookLibraryProject
{
	partial class Login
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
			this.LoginClick = new System.Windows.Forms.Button();
			this.SignupClick = new System.Windows.Forms.Button();
			this.Passwordtxt = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Usernametxt = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// LoginClick
			// 
			this.LoginClick.Location = new System.Drawing.Point(41, 133);
			this.LoginClick.Name = "LoginClick";
			this.LoginClick.Size = new System.Drawing.Size(128, 31);
			this.LoginClick.TabIndex = 2;
			this.LoginClick.Text = "Login";
			this.LoginClick.UseVisualStyleBackColor = true;
			this.LoginClick.Click += new System.EventHandler(this.Button1_Click);
			// 
			// SignupClick
			// 
			this.SignupClick.Location = new System.Drawing.Point(175, 133);
			this.SignupClick.Name = "SignupClick";
			this.SignupClick.Size = new System.Drawing.Size(133, 31);
			this.SignupClick.TabIndex = 3;
			this.SignupClick.Text = "Signup";
			this.SignupClick.UseVisualStyleBackColor = true;
			this.SignupClick.Click += new System.EventHandler(this.Button2_Click);
			// 
			// Passwordtxt
			// 
			this.Passwordtxt.Location = new System.Drawing.Point(114, 87);
			this.Passwordtxt.Name = "Passwordtxt";
			this.Passwordtxt.Size = new System.Drawing.Size(194, 20);
			this.Passwordtxt.TabIndex = 1;
			this.Passwordtxt.Text = "";
			this.Passwordtxt.UseSystemPasswordChar = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(38, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "Username :";
			// 
			// Usernametxt
			// 
			this.Usernametxt.Location = new System.Drawing.Point(114, 52);
			this.Usernametxt.Name = "Usernametxt";
			this.Usernametxt.Size = new System.Drawing.Size(194, 20);
			this.Usernametxt.TabIndex = 0;
			this.Usernametxt.Text = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(38, 94);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Password :";
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 204);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Passwordtxt);
			this.Controls.Add(this.Usernametxt);
			this.Controls.Add(this.SignupClick);
			this.Controls.Add(this.LoginClick);
			this.Name = "Login";
			this.Text = "Login";
			this.Load += new System.EventHandler(this.Login_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button LoginClick;
		private System.Windows.Forms.Button SignupClick;
		private System.Windows.Forms.TextBox Passwordtxt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox Usernametxt;
		private System.Windows.Forms.Label label4;
	}
}