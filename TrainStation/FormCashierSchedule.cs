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
    public partial class FormCashierSchedule : Form
    {
        public FormCashierSchedule()
        {
            InitializeComponent();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormCashierSchedule_Load(object sender, EventArgs e)
        {
            string date = DateTime.Today.ToString("yyyyMMdd");
            string dateDep = date + " 00:00:00";
            string dateAr = date + " 23:59:59";

            //Расписание
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

            //Пункт отправления
            DataSet dsDep = new DataSet();
            SqlDataAdapter daDep = new SqlDataAdapter();
            daDep.SelectCommand = new SqlCommand("select DepartureCity from Routes", ClassTotal.connection);
            daDep.Fill(dsDep);
            comboBoxDeparture.DataSource = dsDep.Tables[0];
            comboBoxDeparture.DisplayMember = "DepartureCity";

            comboBoxDep.DataSource = dsDep.Tables[0];
            comboBoxDep.DisplayMember = "DepartureCity";

            //Пункт назначения
            DataSet dsAr = new DataSet();
            SqlDataAdapter daAr = new SqlDataAdapter();
            daAr.SelectCommand = new SqlCommand("select CityOfArrival from Routes", ClassTotal.connection);
            daAr.Fill(dsAr);
            comboBoxArrival.DataSource = dsAr.Tables[0];
            comboBoxArrival.DisplayMember = "CityOfArrival";

            comboBoxArr.DataSource = dsAr.Tables[0];
            comboBoxArr.DisplayMember = "CityOfArrival";

            //Билеты
            DataSet dsTickets = new DataSet();
            SqlDataAdapter daTickets = new SqlDataAdapter();
            daTickets.SelectCommand = new SqlCommand("select concat_ws(' ', ID_carriage, Compartment, Seat) as Tick from Tickets where Availability = 'False'", ClassTotal.connection);
            daTickets.Fill(dsTickets);
            comboBoxTicket.DataSource = dsTickets.Tables[0];
            comboBoxTicket.DisplayMember = "Tick";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToShortDateString();
        }

        private void buttonFree_Click(object sender, EventArgs e)
        {
            //Запрос на невыкупленные билеты
            string date = dateTimePicker1.Value.ToString("yyyyMMdd");
            string dateDep = date + " 00:00:00";
            string dateAr = date + " 23:59:59";

            string selectedDep = comboBoxDeparture.GetItemText(comboBoxDeparture.SelectedItem);
            string selectedAr = comboBoxArrival.GetItemText(comboBoxArrival.SelectedItem);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("select Tickets.ID_route as [Маршрут], Tickets.ID_train as [Номер поезда], Tickets.ID_carriage as [Номер вагона], Carriages.Type as [Тип вагона], Tickets.Compartment as [Номер купе], Tickets.Seat as [Место]" +
                "from Tickets inner join Routes on Tickets.ID_route = Routes.ID_route inner join Carriages on Tickets.ID_carriage = Carriages.ID_carriage inner join Schedule on Routes.ID_route = Schedule.ID_route where Routes.DepartureCity = '" + selectedDep + "' and Routes.CityOfArrival = '" + selectedAr + "' and Schedule.DepartureTime between '" + dateDep + "' and '" + dateAr + "'", ClassTotal.connection);

            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[5].Width = 100;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //Отменнные рейсы
            string date = dateTimePicker1.Value.ToString("yyyyMMdd");
            string date1 = dateTimePicker1.Value.AddDays(7).ToString("yyyyMMdd");
            string dateDep = date + " 00:00:00";
            string dateAr = date1 + " 23:59:59";

            string selectedDep = comboBoxDeparture.GetItemText(comboBoxDeparture.SelectedItem);
            string selectedAr = comboBoxArrival.GetItemText(comboBoxArrival.SelectedItem);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("select TimeTableDrivers.ID_route as [Номер маршрута], TimeTableDrivers.ID_train as [Номер поезда], TimeTableDrivers.DateDeparture as [Дата отправления], concat_ws(' -  ', Routes.DepartureCity, Routes.CityOfArrival) as [Маршрут], TimeTableDrivers.Status as [Статус]" +
                "from TimeTableDrivers inner join Routes on TimeTableDrivers.ID_route = Routes.ID_route where Routes.DepartureCity = '" + selectedDep + "' and Routes.CityOfArrival = '" + selectedAr + "' and TimeTableDrivers.DateDeparture between '" + dateDep + "' and '" + dateAr + "' and TimeTableDrivers.Status = 'Отменен'", ClassTotal.connection);

            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void buttonSale_Click(object sender, EventArgs e)
        {
            //string selected = comboBoxTicket.GetItemText(comboBoxTicket.SelectedItem);

            //SqlCommand com = new SqlCommand();
            //com.Connection = ClassTotal.connection;
            //com.CommandText = ("update Tickets set Tickets.Availability = 'True' where Tickets.ID_task = '" + id + "'");
            //com.ExecuteNonQuery();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("select Routes.ID_route as [Номер], Trains.Type as [Категория], concat_ws(' -  ', Routes.DepartureCity, Routes.CityOfArrival) as [Маршрут], Schedule.NumberPlatform as [Номер платформы], format(Schedule.DepartureTime, 'HH:mm') as [Время прибытия], format(Schedule.ArrivalTime, 'HH:mm')  as [Время отправления]" +
                "from Routes inner join Schedule on Routes.ID_route = Schedule.ID_route inner join Trains on Schedule.ID_train = Trains.ID_train", ClassTotal.connection);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 90;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 80;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}
