using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace TrainStation
{
    public partial class FormAuth : Form
    {
        private string text = String.Empty;
        int w = 2;

        public FormAuth()
        {
            InitializeComponent();
        }

        private void FormAuth_Load(object sender, EventArgs e)
        {
            pictureBoxCaptcha.Image = CreateImage(pictureBoxCaptcha.Width, pictureBoxCaptcha.Height);
        }

        private Bitmap CreateImage(int Width, int Height) //генерация изображения со случайным текстом
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = rnd.Next(0, Width - 50);
            int Ypos = rnd.Next(15, Height - 15);


            //Добавим различные цвета
            Brush[] colors =
            {
                 Brushes.Black,
                 Brushes.Red,
                 Brushes.RoyalBlue,
                 Brushes.Green
            };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((Image)result);

            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);

            //Сгенерируем текст
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(text,
                         new Font("Arial", 15),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));

            //Добавим немного помех
            /////Линии из углов
            g.DrawLine(Pens.Black,
                       new Point(0, 0),
                       new Point(Width - 1, Height - 1));
            g.DrawLine(Pens.Black,
                       new Point(0, Height - 1),
                       new Point(Width - 1, 0));
            ////Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);
            textBoxCaptcha.Text = text;
            return result;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (w > 0)
            {
                if (textBoxCaptcha.Text == text)
                {
                    string login = textBoxLogin.Text;
                    string password = textBoxPassword.Text;
                    SqlCommand command = ClassTotal.connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from [Users] Where [Login] = @login and [Password] = @password";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (!(bool)reader["Status"])
                        {
                            ClassTotal.id = (int)reader["ID_user"];
                            ClassTotal.idDepartament = (int)reader["ID_department"];
                            reader.Close();
                            switch (ClassTotal.idDepartament)
                            {
                                case (1):
                                    FormPassenger formPassenger = new FormPassenger();
                                    Hide();
                                    formPassenger.ShowDialog();
                                    Show(); 
                                    break;
                                case (2):
                                    FormTrainDriver formDriver = new FormTrainDriver();
                                    Hide();
                                    formDriver.ShowDialog();
                                    Show();
                                    break;
                                case (3):
                                    FormBrigade formBrigade = new FormBrigade();
                                    Hide();
                                    formBrigade.ShowDialog();
                                    Show();
                                    break;
                                case (4):
                                    FormBrigade formBrigade1 = new FormBrigade();
                                    Hide();
                                    formBrigade1.ShowDialog();
                                    Show();
                                    break;
                                case (5):
                                    FormCashierSchedule formCashier = new FormCashierSchedule();
                                    Hide();
                                    formCashier.ShowDialog();
                                    Show();
                                    break;
                                case (6):
                                    FormAdmin formAdmin = new FormAdmin();
                                    Hide();
                                    formAdmin.ShowDialog();
                                    Show();
                                    break;
                            }
                        }
                        else
                        {
                            reader.Close();
                            MessageBox.Show("Вы заблокированы в системе");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Логин и/или пароль введены неверно. Осталось попыток:" + w);
                        reader.Close();
                        w--;
                    }
                }
                else
                {
                    MessageBox.Show("Капча введена неверно");
                    pictureBoxCaptcha.Image = CreateImage(pictureBoxCaptcha.Width, pictureBoxCaptcha.Height);
                    textBoxCaptcha.Clear();
                }
            }
            else
            {
                tsec = 5;
                labelLogin.Visible = false;
                labelPassword.Visible = false;
                labelWelcome.Visible = false;
                labelName.Visible = false;

                textBoxLogin.Visible = false;
                textBoxPassword.Visible = false;
                textBoxCaptcha.Visible = false;

                pictureBoxCaptcha.Visible = false;

                buttonCapchaRefresh.Visible = false;
                buttonLogin.Visible = false;
                buttonLook.Visible = false;

                textBoxTimer.Visible = true;
                textBoxAlert.Visible = true;
                textBoxTimer.Text = "01:00";
                timerDeny.Start();
                ActiveForm.ControlBox = false;
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            pictureBoxCaptcha.Image = CreateImage(pictureBoxCaptcha.Width, pictureBoxCaptcha.Height);
        }

        private void buttonLook_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.UseSystemPasswordChar == true)
                textBoxPassword.UseSystemPasswordChar = false;
            else
                textBoxPassword.UseSystemPasswordChar = true;

        }

        private void timerDeny_Tick(object sender, EventArgs e)
        {
            if (tmin == 0 && tsec == 0)
            {
                timerDeny.Stop();
                w = 2;
                labelLogin.Visible = true;
                labelPassword.Visible = true;
                labelWelcome.Visible = true;
                labelName.Visible = true;

                textBoxLogin.Visible = true;
                textBoxPassword.Visible = true;
                textBoxCaptcha.Visible = true;

                pictureBoxCaptcha.Visible = true;
                pictureBoxCaptcha.Image = CreateImage(pictureBoxCaptcha.Width, pictureBoxCaptcha.Height);

                buttonCapchaRefresh.Visible = true;
                buttonLogin.Visible = true;
                buttonLook.Visible = true;
                ActiveForm.ControlBox = true;


                textBoxAlert.Visible = false;
                textBoxTimer.Visible = false;
            }
            if (tsec > 0)
            {
                tsec--;
            }
            if (tsec == 0)
            {
                if (tmin > 0)
                {
                    tmin--;
                    if (tmin == 0)
                    { tsec = 59; }
                }
                if (tmin > 0)
                { tsec = 59; }
            }
            textBoxTimer.Text = printNumber(tmin) + ':' + printNumber(tsec);
        }

        int tsec, tmin;
        private static string printNumber(int num)
        {
            string str;
            if (num < 10)
                str = "0" + num;
            else
                str = "" + num;
            return str;
        }
    }
}
