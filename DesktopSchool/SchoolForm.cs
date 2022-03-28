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
    public partial class SchoolForm : Form
    {
        private DesktopSchoolDatabaseEntities entities = new DesktopSchoolDatabaseEntities();
        public SchoolForm()
        {
            InitializeComponent();
        }

        private void SchoolForm_Load(object sender, EventArgs e)
        {
            Select();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;

            School school = new School();

            school.Name = Name;

            entities.Schools.Add(school);
            entities.SaveChanges();

            Select();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text);

            School school = entities.Schools.Find(Id);

            school.Name = txtName.Text;

            entities.SaveChanges();

            Select();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text);

            School school = entities.Schools.Find(Id);

            entities.Schools.Remove(school);
            entities.SaveChanges();

            Select();
        }

        private void Select()
        {
            dgSchool.DataSource = entities.Schools.Select(a => new { a.Id, a.Name }).ToList();
        }

        private void btnSmartSearch_Click(object sender, EventArgs e)
        {
            string SmartSearch = txtSeachName.Text;

            dgSchool.DataSource = entities.Schools.Where(a => a.Name.Contains(SmartSearch)).Select(a => new { a.Id, a.Name }).ToList();
        }
    }
}
