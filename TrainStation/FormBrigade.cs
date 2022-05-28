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
    public partial class FormBrigade : Form
    {
        public FormBrigade()
        {
            InitializeComponent();
        }

        private void FormBrigade_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void comboBoxBrigade_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void refresh()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("select ID_brigade from Brigades", ClassTotal.connection);
            da.Fill(ds);
            comboBoxBrigade.DataSource = ds.Tables[0];
            comboBoxBrigade.DisplayMember = "ID_brigade";
        }

        private void comboBoxBrigade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selected = comboBoxBrigade.GetItemText(comboBoxBrigade.SelectedItem);
            int sel = Convert.ToInt32(selected);
            
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("select ID_task as [Номер], Task as [Задача], Status as [Статус] from ToDoList where ToDoList.ID_brigade = '" + selected + "' and ToDoList.Date = '" + DateTime.Today +"'", ClassTotal.connection);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].Width = 50;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            if (index >= 0)
            {
                int id = (int)dataGridView1.Rows[index].Cells[0].Value;
                bool active = (bool)dataGridView1.Rows[index].Cells[2].Value;
                int костыль;
                if (active)
                    костыль = 1;
                else костыль = 0;
                SqlCommand com = new SqlCommand();
                com.Connection = ClassTotal.connection;
                com.CommandText = ("update ToDoList set ToDoList.Status = '" + костыль + "' where ToDoList.ID_task = '" + id + "'");
                com.ExecuteNonQuery();
                refresh();
            }
        }
    }
}
