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
    public partial class FormPassenger : Form
    {
        public FormPassenger()
        {
            InitializeComponent();
        }

        private void FormPassenger_Load(object sender, EventArgs e)
        {
            string date = DateTime.Today.ToString("yyyyMMdd");
            string dateDep = date + " 00:00:00";
            string dateAr = date + " 23:59:59";

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("select Routes.ID_route as [Номер], Trains.Type as [Категория], concat_ws(' -  ', Routes.DepartureCity, Routes.CityOfArrival) as [Маршрут], Schedule.NumberPlatform as [Номер платформы], format(Schedule.DepartureTime, 'HH:mm') as [Время прибытия], format(Schedule.ArrivalTime, 'HH:mm')  as [Время отправления]" +
                "from Routes inner join Schedule on Routes.ID_route = Schedule.ID_route inner join Trains on Schedule.ID_train = Trains.ID_train where Schedule.DepartureTime between '" + dateDep + "' and '" + dateAr + "'", ClassTotal.connection);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 90;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 80;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToShortDateString();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
