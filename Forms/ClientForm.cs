using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgencyRepository;
using TravelAgencyRepository.Factory;
using TravelAgencyRepository.Models;

namespace TravelAgencyWinFormsApp
{
    public partial class ClientForm : Form
    {
        private MainForm mainForm;
        private int idForUpdate;
        public ClientForm(MainForm form, int idForUpdate = -1)
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
            string pass = textBox4.Text.Trim();
            if (idForUpdate != -1)
            {
                RepositoryFactory.ClientRepo.UpdateEntitybyId(idForUpdate, new Client(-1, fname, sname, oname, pass));
            }
            else
            {
                RepositoryFactory.ClientRepo.Create(new Client(-1, fname, sname, oname, pass));
            }
            mainForm.UpdateDataViewDataSource();
            Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            if (idForUpdate != -1)
            {
                Client client = RepositoryFactory.ClientRepo.GetEntitybyId(idForUpdate);
                textBox1.Text = client.FirstName;
                textBox2.Text = client.SecondName;
                textBox3.Text = client.FatherName;
                textBox4.Text = client.Passport;
            }
        }
    }
}
