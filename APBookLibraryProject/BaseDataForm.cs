using APBookLibraryProject.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APBookLibraryProject
{
	public class BaseDataForm : Form
	{
		public DatabaseContext db { get; set; }
		public BaseDataForm()
		{
			db = new DatabaseContext();
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseDataForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "BaseDataForm";
            this.Load += new System.EventHandler(this.BaseDataForm_Load);
            this.ResumeLayout(false);

        }

        private void BaseDataForm_Load(object sender, EventArgs e)
        {

        }
    }
}
