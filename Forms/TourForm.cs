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

namespace TravelAgencyWinFormsApp.Forms
{
    public partial class TourForm : Form
    {
        private MainForm mainForm;
        private int idForUpdate;
        public TourForm(MainForm form, int idForUpdate = -1)
        {
            mainForm = form;
            this.idForUpdate = idForUpdate;
            InitializeComponent();
        }

        private void TourForm_Load(object sender, EventArgs e)
        {
            var hotelList = RepositoryFactory.HotelRepo.GetEntities();
            var tourKindList = RepositoryFactory.TourKindRepo.GetEntities();
            comboBox1.DataSource = tourKindList;
            comboBox2.DataSource = hotelList;


            if (idForUpdate != -1)
            {
                Tour tour = RepositoryFactory.TourRepo.GetEntitybyId(idForUpdate);
                numericUpDown1.Value = tour.Duration;
                comboBox1.SelectedIndex = tourKindList.IndexOf(RepositoryFactory.TourKindRepo.GetEntitybyId(tour.TourKindId));
                comboBox2.SelectedIndex = hotelList.IndexOf(RepositoryFactory.HotelRepo.GetEntitybyId(tour.HotelId));
            }
            else
            {
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            TourKind tourKind = (TourKind)comboBox1.SelectedItem;
            Hotel hotel = (Hotel)comboBox2.SelectedItem;

            int duration = (int)numericUpDown1.Value;
            int tourKindId = tourKind.Id;
            int hotelId = hotel.Id;

            if (idForUpdate != -1)
            {
                RepositoryFactory.TourRepo.UpdateEntitybyId(idForUpdate, new Tour(-1,duration,hotelId,tourKindId));
            }
            else
            {
                RepositoryFactory.TourRepo.Create(new Tour(-1, duration, hotelId, tourKindId));
            }
            mainForm.UpdateDataViewDataSource();
            Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
