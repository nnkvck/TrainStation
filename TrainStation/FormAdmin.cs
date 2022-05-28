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
    public partial class FormAdmin : Form
    {
        string selectedDep;
        string selectedBr;
        string selectedSex;
        int selectedChildren;

        public FormAdmin()
        {
            InitializeComponent();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            //Заполнение comboboxDepartment
            DataSet dsDep = new DataSet();
            SqlDataAdapter daDep = new SqlDataAdapter();
            daDep.SelectCommand = new SqlCommand("select Department from Departments", ClassTotal.connection);
            daDep.Fill(dsDep);
            comboBoxDepartment.DataSource = dsDep.Tables[0];
            comboBoxDepartment.DisplayMember = "Department";

            //Заполнение comboboxSex
            comboBoxSex.Items.Add("мужской");
            comboBoxSex.Items.Add("женский");
            selectedSex = comboBoxSex.GetItemText(comboBoxSex.SelectedItem);

            //Заполнение comboboxChildren
            comboBoxChildren.Items.Add("Детей нет");
            comboBoxChildren.Items.Add("1-2 ребенка");
            comboBoxChildren.Items.Add("3 и более");
        }
        

        private void comboBoxDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedDep = comboBoxDepartment.GetItemText(comboBoxDepartment.SelectedItem);

            if (selectedDep == "Repairmen" || selectedDep == "employees of the train preparation service")
            {
                //Открытие comboboxDrigade
                label2.Visible = true;
                comboBoxBrigade.Visible = true;

                //Заполнение comboboxBrigade
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("select ID_brigade from Brigades", ClassTotal.connection);
                da.Fill(ds);
                comboBoxBrigade.DataSource = ds.Tables[0];
                comboBoxBrigade.DisplayMember = "ID_brigade";
            }
            else
            {
                //Скрыть comboboxBrigade
                label2.Visible = false;
                comboBoxBrigade.Visible = false;
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)   //Запрос 1 на выборку сотрудников по зп и возрасту
        {
            selectedDep = comboBoxDepartment.GetItemText(comboBoxDepartment.SelectedItem); //Получение названия департамента

            //Получение диапазона лет
            int ot = (int)numericUpDownOt.Value;
            int doo = (int)numericUpDownDo.Value;

            //Диапазон лет в даты
            string yearOt = Convert.ToString(DateTime.Today.Year - ot) + "-01-01";
            string yearDo = Convert.ToString(DateTime.Today.Year - doo) + "-12-31";

            //Получение диапазона зп
            double salaryOt = Convert.ToDouble(textBoxOt.Text);
            double salaryDo = Convert.ToDouble(textBoxDo.Text);

            if (comboBoxBrigade.Visible == true) //при наличии бригады
            {
                selectedBr = comboBoxBrigade.GetItemText(comboBoxBrigade.SelectedItem);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("select Users.ID_user as ID, concat_ws(' ', Users.SureName, Users.Name, Users.LastName) as [ФИО], Departments.Department as [Департамент], Users.ID_brigade as [Номер бригады], Users.Age as [Дата рождения], Users.Salary as [Зарплата]" +
                    "from Users inner join Departments on Users.ID_department = Departments.ID_department where Departments.Department = '" + selectedDep + "' and Users.ID_brigade = '" + selectedBr + "' and Users.Age between '" + yearDo + "' and '" + yearOt + "' and Users.Salary between '" + salaryOt + "' and '" + salaryDo + "'", ClassTotal.connection);
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                dataGridView1.Columns[0].Width = 20;
                dataGridView1.Columns[1].Width = 250;
                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[3].Width = 50;
                dataGridView1.Columns[4].Width = 80;
                dataGridView1.Columns[5].Width = 60;
            }
            else //отсутствие бригады
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("select Users.ID_user as ID, concat_ws(' ', Users.SureName, Users.Name, Users.LastName) as [ФИО], Departments.Department as [Департамент], Users.Age as [Дата рождения], Users.Salary as [Зарплата]" +
                    "from Users inner join Departments on Users.ID_department = Departments.ID_department where Departments.Department = '" + selectedDep + "' and Users.ID_brigade is null and Users.Age between '" + yearDo + "' and '" + yearOt + "' and Users.Salary between '" + salaryOt + "' and '" + salaryDo + "'", ClassTotal.connection);
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }   
        }

        private void buttonEnter2_Click(object sender, EventArgs e)  //Запрос 2 на выборку сотрудников по стажу, полу и детям
        {
            selectedDep = comboBoxDepartment.GetItemText(comboBoxDepartment.SelectedItem); //Получение названия департамента

            //Получение диапазона лет стажа
            int ot = (int)numericUpDownStajOt.Value;
            int doo = (int)numericUpDownStajDo.Value;

            //Диапазон лет стажа в даты
            string stajOt = Convert.ToString(DateTime.Today.Year - ot) + "-01-01";
            string stajDo = Convert.ToString(DateTime.Today.Year - doo) + "-12-31";

            if (comboBoxBrigade.Visible == true)  //при наличии бригады
            {
                selectedChildren = comboBoxChildren.SelectedIndex;   //Получение индекса строки с количеством детей
                selectedBr = comboBoxBrigade.GetItemText(comboBoxBrigade.SelectedItem);   //Получение номера бригады
                selectedSex = comboBoxSex.GetItemText(comboBoxSex.SelectedItem);   //Получение названия пола

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                if (selectedChildren == 0)  //если детей выбрано 0
                {
                    da.SelectCommand = new SqlCommand("select Users.ID_user as ID, concat_ws(' ', Users.SureName, Users.Name, Users.LastName) as [ФИО], Users.Sex as [Пол], Departments.Department as [Департамент], Users.ID_brigade as [Номер бригады], Users.Salary as [Зарплата], Users.Priem as [Дата приема на работу], Users.Chidren as [Количество детей]" +
                        "from Users inner join Departments on Users.ID_department = Departments.ID_department where Departments.Department = '" + selectedDep + "' and Users.ID_brigade = '" + selectedBr + "' and Users.Priem between '" + stajDo + "' and '" + stajOt + "' and Users.Sex = '" + selectedSex + "' and Users.Chidren = '" + selectedChildren + "'", ClassTotal.connection);
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if(selectedChildren == 1)  //если детей выбрано 1-2
                {
                    da.SelectCommand = new SqlCommand("select Users.ID_user as ID, concat_ws(' ', Users.SureName, Users.Name, Users.LastName) as [ФИО], Users.Sex as [Пол], Departments.Department as [Департамент], Users.ID_brigade as [Номер бригады], Users.Salary as [Зарплата], Users.Priem as [Дата приема на работу], Users.Chidren as [Количество детей]" +
                       "from Users inner join Departments on Users.ID_department = Departments.ID_department where Departments.Department = '" + selectedDep + "' and Users.ID_brigade = '" + selectedBr + "' and Users.Priem between '" + stajDo + "' and '" + stajOt + "' and Users.Sex = '" + selectedSex + "' and Users.Chidren = 1 or Users.Chidren = 2", ClassTotal.connection);
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if(selectedChildren == 2)  //если детей выбрано 3 и более 
                {
                    da.SelectCommand = new SqlCommand("select Users.ID_user as ID, concat_ws(' ', Users.SureName, Users.Name, Users.LastName) as [ФИО], Users.Sex as [Пол], Departments.Department as [Департамент], Users.ID_brigade as [Номер бригады], Users.Salary as [Зарплата], Users.Priem as [Дата приема на работу], Users.Chidren as [Количество детей]" +
                       "from Users inner join Departments on Users.ID_department = Departments.ID_department where Departments.Department = '" + selectedDep + "' and Users.ID_brigade = '" + selectedBr + "' and Users.Priem between '" + stajDo + "' and '" + stajOt + "' and Users.Sex = '" + selectedSex + "' and Users.Chidren > 2", ClassTotal.connection);
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                
            }
            else  //отсутствие бригады
            {
                selectedChildren = comboBoxChildren.SelectedIndex;
                selectedBr = comboBoxBrigade.GetItemText(comboBoxBrigade.SelectedItem);
                selectedSex = comboBoxSex.GetItemText(comboBoxSex.SelectedItem);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                if (selectedChildren == 0)  //если детей выбрано 0
                {
                    da.SelectCommand = new SqlCommand("select Users.ID_user as ID, concat_ws(' ', Users.SureName, Users.Name, Users.LastName) as [ФИО], Users.Sex as [Пол], Departments.Department as [Департамент], Users.ID_brigade as [Номер бригады], Users.Salary as [Зарплата], Users.Priem as [Дата приема на работу], Users.Chidren as [Количество детей]" +
                        "from Users inner join Departments on Users.ID_department = Departments.ID_department where Departments.Department = '" + selectedDep + "' and Users.Priem between '" + stajDo + "' and '" + stajOt + "' and Users.Sex = '" + selectedSex + "' and Users.Chidren = '" + selectedChildren + "'", ClassTotal.connection);
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if (selectedChildren == 1)   //если детей выбрано 1-2
                {
                    da.SelectCommand = new SqlCommand("select Users.ID_user as ID, concat_ws(' ', Users.SureName, Users.Name, Users.LastName) as [ФИО], Users.Sex as [Пол], Departments.Department as [Департамент], Users.ID_brigade as [Номер бригады], Users.Salary as [Зарплата], Users.Priem as [Дата приема на работу], Users.Chidren as [Количество детей]" +
                       "from Users inner join Departments on Users.ID_department = Departments.ID_department where Departments.Department = '" + selectedDep + "' and Users.Priem between '" + stajDo + "' and '" + stajOt + "' and Users.Sex = '" + selectedSex + "' and Users.Chidren = 1 or Users.Chidren = 2", ClassTotal.connection);
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if (selectedChildren == 2)  //если детей выбрано 3 и более 
                {
                    da.SelectCommand = new SqlCommand("select Users.ID_user as ID, concat_ws(' ', Users.SureName, Users.Name, Users.LastName) as [ФИО], Users.Sex as [Пол], Departments.Department as [Департамент], Users.ID_brigade as [Номер бригады], Users.Salary as [Зарплата], Users.Priem as [Дата приема на работу], Users.Chidren as [Количество детей]" +
                       "from Users inner join Departments on Users.ID_department = Departments.ID_department where Departments.Department = '" + selectedDep + "' and Users.Priem between '" + stajDo + "' and '" + stajOt + "' and Users.Sex = '" + selectedSex + "' and Users.Chidren > 2", ClassTotal.connection);
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToShortDateString();
        }
    }
}
