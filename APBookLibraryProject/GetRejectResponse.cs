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
	public partial class GetRejectResponse : Form
	{
		public GetRejectResponse()
		{
			InitializeComponent();
		}

		public WSRentingSystem ParretForm { get; set; }
		public string RequestId { get; set; }
		public int RequestIndex { get; set; }
		private void BtnOk_Click(object sender, EventArgs e)
		{
			ParretForm.GetRejectionContextResult(richTextBox.Text, RequestId, RequestIndex);
			this.Close();
		}

		private void GetRejectResponse_Load(object sender, EventArgs e)
		{

		}
	}
}
