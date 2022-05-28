using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainStation
{
    public partial class FormTrainDriver : Form
    {
        public FormTrainDriver()
        {
            InitializeComponent();
        }

        private void FormTrainDriver_Load(object sender, EventArgs e)
        {
            string date = DateTime.Today.ToString("yyyyMMdd");
            string date1 = DateTime.Today.AddDays(7).ToString("yyyyMMdd");
            string dateDep = date + " 00:00:00";
            string dateAr = date1 + " 00:00:00";

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("select concat_ws(' -  ', Routes.DepartureCity, Routes.CityOfArrival) as [Маршрут], TimeTableDrivers.DateDeparture as [Дата отправления], TimeTableDrivers.DateOfArrival as [Дата прибытия], TimeTableDrivers.ID_train as [Номер поезда], TimeTableDrivers.Status as [Статус] from TimeTableDrivers inner join Routes on Routes.ID_route = TimeTableDrivers.ID_route where TimeTableDrivers.ID_user = '" + ClassTotal.id + "' and TimeTableDrivers.DateDeparture between '" + dateDep + "' and '" + dateAr + "'", ClassTotal.connection);
            da.Fill(ds);
            dataGridViewDriver.DataSource = ds.Tables[0];

            dataGridViewDriver.Columns[0].Width = 200;
            dataGridViewDriver.Columns[1].Width = 100;
            dataGridViewDriver.Columns[2].Width = 100;
            dataGridViewDriver.Columns[3].Width = 50;
            dataGridViewDriver.Columns[4].Width = 70;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToShortDateString();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
