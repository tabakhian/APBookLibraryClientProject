using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APBookLibraryProject
{
	public partial class GetRequestContext : Form
	{
		public GetRequestContext()
		{
			InitializeComponent();
		}

		public WSBookDetail ParretForm { get; set; }

		private void BtnOk_Click(object sender, EventArgs e)
		{
			ParretForm.GetRequestContextFormResult(richTextBox.Text);
			this.Close();
		}
	}
}
