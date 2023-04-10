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
using System.Xml.Linq;

namespace TravelAgencyWinFormsApp.Forms
{
    public partial class TourKindForm : Form
    {
        private MainForm mainForm;
        private int idForUpdate;
        public TourKindForm(MainForm form, int idForUpdate = -1)
        {
            mainForm = form;
            this.idForUpdate = idForUpdate;
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string kind = textBox1.Text.Trim();
            if (idForUpdate != -1)
            {
                RepositoryFactory.TourKindRepo.UpdateEntitybyId(idForUpdate, new TourKind(-1,kind));
            }
            else
            {
                RepositoryFactory.TourKindRepo.Create(new TourKind(-1,kind));
            }
            mainForm.UpdateDataViewDataSource();
            Close();
        }

        private void TourKind_Load(object sender, EventArgs e)
        {
            if (idForUpdate != -1)
            {
                TourKind tourKind = RepositoryFactory.TourKindRepo.GetEntitybyId(idForUpdate);
                textBox1.Text = tourKind.Kind;
            }
        }
    }
}
