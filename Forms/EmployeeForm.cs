using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TravelAgencyRepository.Factory;
using TravelAgencyRepository.Models;
using TravelAgencyEFRepository.Factory;

namespace TravelAgencyWinFormsApp.Forms
{
    public partial class EmployeeForm : Form
    {
        private MainForm mainForm;
        private int idForUpdate;
        public EmployeeForm(MainForm form, int idForUpdate = -1)
        {
            mainForm = form;
            this.idForUpdate = idForUpdate;
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text.Trim();
            string sname = textBox2.Text.Trim();
            string oname = textBox3.Text.Trim();
            Post post = (Post)comboBox1.SelectedItem;
            int postId = post.Id;
            if (idForUpdate != -1)
            {
                EFRepositoryFactory.EmployeeRepo.UpdateEntitybyId(idForUpdate, new TravelAgencyEFRepository.Models.Employee { FirstName = fname, SecondName = sname, FatherName = oname, PostId = postId });
            }
            else
            {
                EFRepositoryFactory.EmployeeRepo.Create(new TravelAgencyEFRepository.Models.Employee { FirstName = fname, SecondName = sname, FatherName = oname, PostId = postId });
            }
            mainForm.UpdateDataViewDataSource();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            var postList = RepositoryFactory.PostRepo.GetEntities();
            comboBox1.DataSource = postList;

            if (idForUpdate != -1)
            {
                Employee employee = RepositoryFactory.EmployeeRepo.GetEntitybyId(idForUpdate);
                textBox1.Text = employee.FirstName;
                textBox2.Text = employee.SecondName;
                textBox3.Text = employee.FatherName;
                comboBox1.SelectedIndex = postList.IndexOf(RepositoryFactory.PostRepo.GetEntitybyId(employee.PostId));

            }
            else
            {
                comboBox1.SelectedIndex = -1;
            }
            
        }
    }
}
