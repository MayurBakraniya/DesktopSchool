using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopSchool
{
    public partial class ClassForm : Form
    {
        private DesktopSchoolDatabaseEntities entities = new DesktopSchoolDatabaseEntities();

        public ClassForm()
        {
            InitializeComponent();
        }

        private void ClassForm_Load(object sender, EventArgs e)
        {
            cmbSchool.DataSource = entities.Schools.Select(a => new { a.Id, a.Name }).ToList();
        }
    }
}
