using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APBookLibraryProject.Domain.Enums;

namespace APBookLibraryProject
{
	public partial class Change_personal_Information : Form
	{
		public Change_personal_Information()
		{
			InitializeComponent();
		}

		private void Label3_Click(object sender, EventArgs e)
		{

		}

		private void Label4_Click(object sender, EventArgs e)
		{

		}

		private void Label2_Click(object sender, EventArgs e)
		{

		}

		private void Label5_Click(object sender, EventArgs e)
		{

		}

		private void Label1_Click(object sender, EventArgs e)
		{

		}

		private void Nametxt_TextChanged(object sender, EventArgs e)
		{

		}

		private void LastNametxt_TextChanged(object sender, EventArgs e)
		{

		}

		private void PhoneNumbertxt_TextChanged(object sender, EventArgs e)
		{

		}

		private void Usernametxt_TextChanged(object sender, EventArgs e)
		{

		}

		private void Passwordtxt_TextChanged(object sender, EventArgs e)
		{

		}

		private void Setting_Load(object sender, EventArgs e)
		{

		}

		private void Yeartxt_TextChanged(object sender, EventArgs e)
		{

		}

		private void Monthtxt_TextChanged(object sender, EventArgs e)
		{

		}

		private void Daytxt_TextChanged(object sender, EventArgs e)
		{

		}

		private void Emailtxt_TextChanged(object sender, EventArgs e)
		{

		}

		private void Set_Click(object sender, EventArgs e)
		{
			if (Nametxt.Text == "" )
			{
				MessageBox.Show("Your Name is empty!", "Error!");
			}
			if (LastNametxt.Text == "")
			{
				MessageBox.Show("Your LastName is empty!", "Error!");
			}
			if (Usernametxt.Text == "")
			{
				MessageBox.Show("Your username is empty!", "Error!");
			}
			if (Passwordtxt.Text == "")
			{
				MessageBox.Show("Your Password is empty!", "Error!");
			}


			if (System.Text.RegularExpressions.Regex.IsMatch(Emailtxt.Text, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
			{
			}

			else
			{
				MessageBox.Show("Email is not correct!", "Error!");
			}
			int ComboBox = 0;
			ComboBox = Convert.ToInt32(GenderComboBox.Text);
			if (ComboBox >= 4 && ComboBox < 0 )
			{
				MessageBox.Show("Select Your Gender Again!", "Oops!");
			}
		}

		private void GenderComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			GenderComboBox.Items.Add("Female");
			GenderComboBox.Items.Add("Male");
			GenderComboBox.Items.Add("Unspecified");
		}
	}
}
