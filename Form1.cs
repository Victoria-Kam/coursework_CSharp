using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

/*

Целью данного курсового проекта является разработка программного средства для ведения учета домашних животных. 
Данная программа должна сохранять и накапливать информацию о владельце и его домашнего животного.

*/


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Database1.mdb;Persist Security Info=False;"; // подключение 
        public OleDbConnection OleDbConnection;
        public string id_home_animal;   // для запроса 
        public int id_dom_animal = 0;   // когда нашли в запросе, то будем прибавлять +1 или -1

        public Form1()
        {
            InitializeComponent();
            OleDbConnection = new OleDbConnection(ConnectionString);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            ToolTip tip = new ToolTip();
            tip.SetToolTip(pictureBox1, "Следующая запись");
            tip.SetToolTip(pictureBox2, "Предыдущая запись");

            try   // заполнение бокса для владельца
            {
                OleDbConnection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = OleDbConnection;
                string query = "select * from Владелец ";
                oleDbCommand.CommandText = query;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                while (oleDbDataReader.Read())
                {
                    comboBox1.Items.Add(oleDbDataReader["id_vlad"].ToString());
                    comboBox8.Items.Add(oleDbDataReader["id_vlad"].ToString());
                }
                OleDbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }


            try   //заполнение бокса для питомца
            {
                OleDbConnection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = OleDbConnection;
                string query = "select * from Карточка_учета_животных ";
                oleDbCommand.CommandText = query;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                while (oleDbDataReader.Read())
                {
                    comboBox2.Items.Add(oleDbDataReader["id_karta"].ToString());
                    comboBox9.Items.Add(oleDbDataReader["id_karta"].ToString());
                }
                OleDbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }


            try   //заполнение бокса для  состояния здоровья питомца
            {
                OleDbConnection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = OleDbConnection;
                string query = "select * from Состояние_животного ";
                oleDbCommand.CommandText = query;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                while (oleDbDataReader.Read())
                {
                    comboBox5.Items.Add(oleDbDataReader["naimen"].ToString());
                }
                OleDbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }


            try   //заполнение бокса для  пола питомца
            {
                OleDbConnection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = OleDbConnection;
                string query = "select * from Пол ";
                oleDbCommand.CommandText = query;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                while (oleDbDataReader.Read())
                {
                    comboBox3.Items.Add(oleDbDataReader["naimen"].ToString());
                }
                OleDbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }


            try   //заполнение бокса для  класса питомца
            {
                OleDbConnection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = OleDbConnection;
                string query = "select * from Класс_животных ";
                oleDbCommand.CommandText = query;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                while (oleDbDataReader.Read())
                {
                    comboBox6.Items.Add(oleDbDataReader["naimen"].ToString());
                }
                OleDbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }


            try   //заполнение бокса для  отряда питомца
            {
                OleDbConnection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = OleDbConnection;
                string query = "select * from Отряд_животных ";
                oleDbCommand.CommandText = query;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                while (oleDbDataReader.Read())
                {
                    comboBox7.Items.Add(oleDbDataReader["naimen"].ToString());
                }
                OleDbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }

            try   //заполнение бокса для  вида питомца
            {
                OleDbConnection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = OleDbConnection;
                string query = "select * from Вид_животных ";
                oleDbCommand.CommandText = query;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                while (oleDbDataReader.Read())
                {
                    comboBox4.Items.Add(oleDbDataReader["naimenovan"].ToString());
                }
                OleDbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)   // просмотр следующей записи
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            vladelec vladelec = new vladelec();
            animal animal = new animal();
            ++id_dom_animal;
            string familiya, imya, otchestvo, phone_numder;
            string klichka, age, poroda, health_animals, pol, klass, otryad, vid, norma_korma, korm;
            familiya = vladelec.information_about_the_owner_fam(id_dom_animal);
            imya = vladelec.information_about_the_owner_imya(id_dom_animal);
            otchestvo = vladelec.information_about_the_owner_otchestvo(id_dom_animal);
            phone_numder = vladelec.information_about_the_owner_phone_number(id_dom_animal);
            klichka = animal.information_klichka(id_dom_animal);
            age = animal.information_age(id_dom_animal);
            poroda = animal.information_poroda(id_dom_animal);
            health_animals = animal.information_health(id_dom_animal);
            pol = animal.information_pol(id_dom_animal);
            klass = animal.information_klass(id_dom_animal);
            otryad = animal.information_otr(id_dom_animal);
            vid = animal.information_vid(id_dom_animal);
            korm = animal.information_korm(id_dom_animal);
            norma_korma = animal.information_norma_korma(id_dom_animal);
            textBox1.Text = familiya;
            textBox2.Text = imya;
            textBox3.Text = otchestvo;
            textBox4.Text = phone_numder;
            textBox5.Text = klichka;
            textBox6.Text = age;
            textBox9.Text = poroda;
            comboBox5.Text = health_animals;
            comboBox3.Text = pol;
            comboBox6.Text = klass;
            comboBox7.Text = otryad;
            comboBox4.Text = vid;
            textBox13.Text = korm;
            textBox14.Text = norma_korma;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)   // для редактирования таблицы животного
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Enabled = false;
                checkBox3.Enabled = false;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox7.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox9.Enabled = true;
                pictureBox5.Visible = true;
                pictureBox6.Visible = true;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox9.Enabled = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)   // для редактирования таблицы владельца 
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                comboBox1.Enabled = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                comboBox1.Enabled = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)   // заполняем комбобокс владельца животного, т.е. будем выводить из таблицы данные хозяина
        {
            vladelec vladelec = new vladelec();
            string id_vlad = comboBox1.Text;
            string familiya, imya, otchestvo, phone_number;
            familiya = vladelec.inf_famil(id_vlad);
            imya = vladelec.inf_imya(id_vlad);
            otchestvo = vladelec.inf_otchestvo(id_vlad);
            phone_number = vladelec.inf_phone_number(id_vlad);
            textBox1.Text = familiya;
            textBox2.Text = imya;
            textBox3.Text = otchestvo;
            textBox4.Text = phone_number;
        }


        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)   // заполняем комбобокс для состояния животного
        {
            try
            {
                OleDbConnection.Open();
                string query = "SELECT * FROM Состояние_животного  WHERE naimen = '" + comboBox5.Text + "';";    //запрос на состояние животного
                OleDbCommand oleDbCommand = new OleDbCommand(query, OleDbConnection);
                OleDbDataReader reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {

                    string txt = reader["id_sost"].ToString();   // заполняем текстбокс для дальнейших запросов
                    textBox10.Text = txt;

                }
                OleDbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)   // заполняем комбобокс для пола животного
        {
            try
            {
                OleDbConnection.Open();
                string query = "SELECT * FROM Пол  WHERE naimen = '" + comboBox3.Text + "';";    //запрос на пол животного
                OleDbCommand oleDbCommand = new OleDbCommand(query, OleDbConnection);
                OleDbDataReader reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    string txt = reader["id_pola"].ToString();   // заполняем текстбокс для дальнейших запросов
                    textBox7.Text = txt;
                }
                OleDbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)   // заполняем комбобокс для класса животного
        {
            try
            {
                OleDbConnection.Open();
                string query = "SELECT * FROM Класс_животных  WHERE naimen = '" + comboBox6.Text + "';";    //запрос на класс животного
                OleDbCommand oleDbCommand = new OleDbCommand(query, OleDbConnection);
                OleDbDataReader reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    string txt = reader["id_klassa"].ToString();   // заполняем текстбокс для дальнейших запросов
                    textBox11.Text = txt;
                }
                OleDbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)   // заполняем комбобокс для отряда животных
        {
            try
            {
                OleDbConnection.Open();
                string query = "SELECT * FROM Отряд_животных  WHERE naimen = '" + comboBox7.Text + "';";    //запрос на отряд  животного
                OleDbCommand oleDbCommand = new OleDbCommand(query, OleDbConnection);
                OleDbDataReader reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    string txt = reader["id_otr"].ToString();   // заполняем текстбокс для дальнейших запросов
                    textBox12.Text = txt;
                }
                OleDbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)   // заполняем комбобокс для вида животного
        {
            try
            {
                OleDbConnection.Open();
                string query = "SELECT * FROM Вид_животных  WHERE naimenovan = '" + comboBox4.Text + "';";    //запрос на вид  животного
                OleDbCommand oleDbCommand = new OleDbCommand(query, OleDbConnection);
                OleDbDataReader reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    string txt = reader["id_vid"].ToString();   // заполняем текстбокс для дальнейших запросов
                    textBox8.Text = txt;
                }
                OleDbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)   // добавить данные владельца в таблицу владелец
        {
            vladelec vladelec = new vladelec();
            string familiya, imya, otchestvo, phone_number;
            familiya = textBox1.Text;
            imya = textBox2.Text;
            otchestvo = textBox3.Text;
            phone_number = textBox4.Text;
            vladelec.add_data_about_owner(familiya, imya, otchestvo, phone_number);   // передаем заданные параметры в метод, чтобы добавить данные
        }

        private void pictureBox4_Click(object sender, EventArgs e)   // изменить данные владельца
        {
            vladelec vladelec = new vladelec();
            string familiya, imya, otchestvo, phone_number, id_vlad;
            familiya = textBox1.Text;
            imya = textBox2.Text;
            otchestvo = textBox3.Text;
            phone_number = textBox4.Text;
            id_vlad = comboBox1.Text;
            vladelec.change_data_owner(familiya, imya, otchestvo, phone_number, id_vlad);
        }


        private void pictureBox2_Click(object sender, EventArgs e)   // просмотр предыдущей записи
        {

            comboBox1.Text = "";
            comboBox2.Text = "";
            vladelec vladelec = new vladelec();
            animal animal = new animal();
            --id_dom_animal;
            string familiya, imya, otchestvo, phone_numder;
            string klichka, age, poroda, health_animals, pol, klass, otryad, vid, norma_korma, korm;
            if (id_dom_animal <= 0)
            {
                MessageBox.Show("Больше нет записей!");
            }
            else
            {
                familiya = vladelec.information_about_the_owner_fam(id_dom_animal);
                imya = vladelec.information_about_the_owner_imya(id_dom_animal);
                otchestvo = vladelec.information_about_the_owner_otchestvo(id_dom_animal);
                phone_numder = vladelec.information_about_the_owner_phone_number(id_dom_animal);
                klichka = animal.information_klichka(id_dom_animal);
                age = animal.information_age(id_dom_animal);
                poroda = animal.information_poroda(id_dom_animal);
                health_animals = animal.information_health(id_dom_animal);
                pol = animal.information_pol(id_dom_animal);
                klass = animal.information_klass(id_dom_animal);
                otryad = animal.information_otr(id_dom_animal);
                vid = animal.information_vid(id_dom_animal);
                korm = animal.information_korm(id_dom_animal);
                norma_korma = animal.information_norma_korma(id_dom_animal);
                textBox1.Text = familiya;
                textBox2.Text = imya;
                textBox3.Text = otchestvo;
                textBox4.Text = phone_numder;
                textBox5.Text = klichka;
                textBox6.Text = age;
                textBox9.Text = poroda;
                comboBox5.Text = health_animals;
                comboBox3.Text = pol;
                comboBox6.Text = klass;
                comboBox7.Text = otryad;
                comboBox4.Text = vid;
                textBox13.Text = korm;
                textBox14.Text = norma_korma;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e) // добавить данные в таблицу животные
        {
            animal animal = new animal();
            string klich, poroda, id_pola, age, id_sost, id_klassa, id_vid, id_otr;
            klich = textBox5.Text;
            poroda = textBox9.Text;
            id_pola = textBox7.Text;
            age = textBox6.Text;
            id_sost = textBox10.Text;
            id_klassa = textBox11.Text;
            id_vid = textBox8.Text;
            id_otr = textBox12.Text;
            animal.add_inf_animal(klich, poroda, id_pola, age, id_sost, id_klassa, id_vid, id_otr);

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            animal animal = new animal();
            string klichka, age, poroda, health_animals, pol, klass, otryad, vid, norma_korma, korm;
            string id_animal = comboBox2.Text;
             klichka = animal.inf_klichka(id_animal);
             age = animal.inf_age(id_animal);
             poroda = animal.inf_poroda(id_animal);
             health_animals = animal.inf_health(id_animal);
             pol = animal.inf_pol(id_animal);
             klass = animal.inf_klass(id_animal);
             otryad = animal.inf_otr(id_animal);
             vid = animal.inf_vid(id_animal);
             korm = animal.inf_korm(id_animal);
            norma_korma = animal.inf_norma_korma(id_animal);
            textBox5.Text = klichka;
            textBox6.Text = age;
            textBox9.Text = poroda;
            comboBox5.Text = health_animals;
            comboBox3.Text = pol;
            comboBox6.Text = klass;
            comboBox7.Text = otryad;
            comboBox4.Text = vid;
            textBox13.Text = korm;
            textBox14.Text = norma_korma;
        }

        private void pictureBox6_Click(object sender, EventArgs e)   // изменяем таблицу животных 
        {
            animal animal = new animal();
            string klich, poroda, id_pola, age, id_sost, id_klassa, id_vid, id_otr;
            string id_animal;
            klich = textBox5.Text;
            poroda = textBox9.Text;
            id_pola = textBox7.Text;
            age = textBox6.Text;
            id_sost = textBox10.Text;
            id_klassa = textBox11.Text;
            id_vid = textBox8.Text;
            id_otr = textBox12.Text;
            id_animal = comboBox2.Text;
            animal.change_data_animal(klich, poroda, id_pola, age, id_sost, id_klassa, id_vid, id_otr, id_animal);
        }


        private void checkBox3_CheckedChanged(object sender, EventArgs e)   // добавляем в таблицу домашнее животное
        {
            if (checkBox3.Checked == true)
            {
                comboBox8.Enabled = true;
                comboBox9.Enabled = true;
                comboBox1.Enabled = true;
                pictureBox7.Visible = true;
                checkBox2.Enabled = false;
                checkBox1.Enabled = false;
            }
            else
            {
                comboBox8.Enabled = false;
                comboBox9.Enabled = false;
                comboBox1.Enabled = false;
                pictureBox7.Visible = false;
                checkBox2.Enabled = true;
                checkBox1.Enabled = true;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)   //добавить данные в таблцу домашнее животное
        {
            try
            {
                OleDbConnection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = OleDbConnection;
                string query = "INSERT INTO Домашнее_животное (id_vlad, id_karta) VALUES ('" + comboBox8.Text + "','" + comboBox9.Text + "'); ";
                oleDbCommand.CommandText = query;
                oleDbCommand.ExecuteNonQuery();
                MessageBox.Show("Добавлено!");
                OleDbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------

        class home_animal
        {

        }

        class vladelec
        {
            Form1 form1 = new Form1();

            public string information_about_the_owner_fam(int id_dom_animal)   // находим и выводим фамилию хозяина 
            {

                string familiya = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "select * from Владелец inner join Домашнее_животное on Владелец.id_vlad = Домашнее_животное.id_vlad where Домашнее_животное.id_domanim =" + id_dom_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        familiya = oleDbDataReader["famil"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return familiya;
            }

            public string information_about_the_owner_imya(int id_dom_animal)   // находим и выводим имя хозяина
            {
                Form1 form1 = new Form1();
                string imya = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "select * from Владелец inner join Домашнее_животное on Владелец.id_vlad = Домашнее_животное.id_vlad where Домашнее_животное.id_domanim =" + id_dom_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        imya = oleDbDataReader["imya"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return imya;
            }

            public string information_about_the_owner_otchestvo(int id_dom_animal)   // находим и выводим отчество хозяина
            {
                Form1 form1 = new Form1();
                string otchestvo = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "select * from Владелец inner join Домашнее_животное on Владелец.id_vlad = Домашнее_животное.id_vlad where Домашнее_животное.id_domanim =" + id_dom_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        otchestvo = oleDbDataReader["otch"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return otchestvo;
            }


            public string information_about_the_owner_phone_number(int id_dom_animal)   // находим и выводим номер телефона хозяина
            {
                Form1 form1 = new Form1();
                string phone_number = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "select * from Владелец inner join Домашнее_животное on Владелец.id_vlad = Домашнее_животное.id_vlad where Домашнее_животное.id_domanim =" + id_dom_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        phone_number = oleDbDataReader["tel"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return phone_number;
            }

            public string inf_famil(string id_vlad)   // для выбора фамилии, кодга выбираем номер в комбобоксе
            {
                string familiya = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "select * from Владелец where id_vlad =" + id_vlad + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        familiya = oleDbDataReader["famil"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return familiya;
            }
            public string inf_imya(string id_vlad)    // для выбора имени, кодга выбираем номер в комбобоксе
            {
                string imya = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "select * from Владелец where id_vlad =" + id_vlad + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        imya = oleDbDataReader["imya"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return imya;
            }
            public string inf_otchestvo(string id_vlad)    // для выбора отчества, кодга выбираем номер в комбобоксе
            {
                string otchotchestvo = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "select * from Владелец where id_vlad =" + id_vlad + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        otchotchestvo = oleDbDataReader["otch"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return otchotchestvo;
            }
            public string inf_phone_number(string id_vlad)    // для выбора номера телефона, кодга выбираем номер в комбобоксе
            {
                string phone_number = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "select * from Владелец where id_vlad =" + id_vlad + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        phone_number = oleDbDataReader["tel"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return phone_number;
            }

            public void add_data_about_owner(string familiya, string imya, string otchestvo, string phone_number) // добавление нового владельца
            {
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "insert into Владелец (famil,imya,otch,tel) values ('" + familiya + "','" + imya + "','" + otchestvo + "','" + phone_number + "')";
                    oleDbCommand.CommandText = query;
                    oleDbCommand.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
            }


            public void change_data_owner(string familiya, string imya, string otchestvo, string phone_number, string id_vlad)   // изменение 
            {
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string change_data = "update Владелец  set famil = '" + familiya + "', imya = '" + imya + "', otch='" + otchestvo + "', tel = '" + phone_number + "'  where id_vlad = " + id_vlad + ";";
                    oleDbCommand.CommandText = change_data;
                    oleDbCommand.ExecuteNonQuery();
                    // MessageBox.Show(change_data);
                    MessageBox.Show("Данные успешно изменены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
            }
        }

        class animal
        {
            Form1 form1 = new Form1();

            public string information_klichka(int id_dom_animal)   // находим и выводим кличку животного 
            {
                string klichka = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "select * from Карточка_учета_животных inner join Домашнее_животное on Карточка_учета_животных.id_karta = Домашнее_животное.id_karta where Домашнее_животное.id_domanim =" + id_dom_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        klichka = oleDbDataReader["klich"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return klichka;
            }

            public string information_age(int id_dom_animal)   // находим и выводим возраст животного 
            {
                string age = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "select * from Карточка_учета_животных inner join Домашнее_животное on Карточка_учета_животных.id_karta = Домашнее_животное.id_karta where Домашнее_животное.id_domanim =" + id_dom_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        age = oleDbDataReader["age"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return age;
            }

            public string information_poroda(int id_dom_animal)   // находим и выводим породу животного 
            {
                string poroda = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "select * from Карточка_учета_животных inner join Домашнее_животное on Карточка_учета_животных.id_karta = Домашнее_животное.id_karta where Домашнее_животное.id_domanim =" + id_dom_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        poroda = oleDbDataReader["poroda"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return poroda;
            }

            public string information_health(int id_dom_animal)   // находим и выводим состояние здоровья животного 
            {
                string health = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "SELECT * FROM Состояние_животного INNER JOIN (Карточка_учета_животных INNER JOIN Домашнее_животное ON Карточка_учета_животных.id_karta = Домашнее_животное.id_karta) ON Состояние_животного.id_sost = Карточка_учета_животных.id_sost where Домашнее_животное.id_domanim =" + id_dom_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        health = oleDbDataReader["naimen"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return health;
            }

            public string information_pol(int id_dom_animal)   // находим и выводим пол животного 
            {
                string pol = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "SELECT * FROM Пол INNER JOIN(Карточка_учета_животных INNER JOIN Домашнее_животное ON Карточка_учета_животных.id_karta = Домашнее_животное.id_karta) ON Пол.id_pola = Карточка_учета_животных.id_pola where Домашнее_животное.id_domanim =" + id_dom_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        pol = oleDbDataReader["naimen"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return pol;
            }


            public string information_klass(int id_dom_animal)   // находим и выводим класс животного 
            {
                string klass = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "SELECT * FROM Класс_животных INNER JOIN(Карточка_учета_животных INNER JOIN Домашнее_животное ON Карточка_учета_животных.id_karta = Домашнее_животное.id_karta) ON Класс_животных.id_klassa = Карточка_учета_животных.id_klassa where Домашнее_животное.id_domanim =" + id_dom_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        klass = oleDbDataReader["naimen"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return klass;
            }


            public string information_otr(int id_dom_animal)   // находим и выводим отряд животного 
            {
                string otryad = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "SELECT * FROM Отряд_животных INNER JOIN(Карточка_учета_животных INNER JOIN Домашнее_животное ON Карточка_учета_животных.id_karta = Домашнее_животное.id_karta) ON Отряд_животных.id_otr = Карточка_учета_животных.id_otr where Домашнее_животное.id_domanim =" + id_dom_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        otryad = oleDbDataReader["naimen"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return otryad;
            }


            public string information_vid(int id_dom_animal)   // находим и выводим вид животного 
            {
                string vid = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "SELECT * FROM Вид_животных INNER JOIN(Карточка_учета_животных INNER JOIN Домашнее_животное ON Карточка_учета_животных.id_karta = Домашнее_животное.id_karta) ON Вид_животных.id_vid = Карточка_учета_животных.id_vid where Домашнее_животное.id_domanim =" + id_dom_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        vid = oleDbDataReader["naimenovan"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return vid;
            }


            public string information_korm(int id_dom_animal)   // находим и выводим корм животного 
            {
                string korm = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "SELECT * FROM Корм INNER JOIN(Вид_животных INNER JOIN (Карточка_учета_животных INNER JOIN Домашнее_животное ON Карточка_учета_животных.id_karta = Домашнее_животное.id_karta) ON Вид_животных.id_vid = Карточка_учета_животных.id_vid) ON Корм.id_korma = Вид_животных.id_korma where Домашнее_животное.id_domanim =" + id_dom_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        korm = oleDbDataReader["naimen"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return korm;
            }


            public string information_norma_korma(int id_dom_animal)   // находим и выводим корм животного 
            {
                string norma_korma = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "SELECT * FROM Вид_животных INNER JOIN(Карточка_учета_животных INNER JOIN Домашнее_животное ON Карточка_учета_животных.id_karta = Домашнее_животное.id_karta) ON Вид_животных.id_vid = Карточка_учета_животных.id_vid where Домашнее_животное.id_domanim =" + id_dom_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        norma_korma = oleDbDataReader["norma_korma"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return norma_korma;
            }

            public string inf_klichka(string id_animal)   // находим и выводим кличку животного 
            {
                string klichka = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "select * from Карточка_учета_животных  where id_karta =" + id_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        klichka = oleDbDataReader["klich"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return klichka;
            }

            public string inf_age(string id_animal)   // находим и выводим возраст животного 
            {
                string age = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "select * from Карточка_учета_животных where id_karta =" + id_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        age = oleDbDataReader["age"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return age;
            }

            public string inf_poroda(string id_animal)   // находим и выводим породу животного 
            {
                string poroda = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "select * from Карточка_учета_животных  where id_karta =" + id_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        poroda = oleDbDataReader["poroda"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return poroda;
            }

            public string inf_health(string id_animal)   // находим и выводим состояние здоровья животного 
            {
                string health = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "SELECT * FROM Состояние_животного INNER JOIN Карточка_учета_животных ON Состояние_животного.id_sost = Карточка_учета_животных.id_sost  where Карточка_учета_животных.id_karta =" + id_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        health = oleDbDataReader["naimen"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return health;
            }

            public string inf_pol(string id_animal)   // находим и выводим пол животного 
            {
                string pol = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "SELECT * FROM Пол INNER JOIN Карточка_учета_животных ON Пол.id_pola = Карточка_учета_животных.id_pola where Карточка_учета_животных.id_karta =" + id_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        pol = oleDbDataReader["naimen"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return pol;
            }


            public string inf_klass(string id_animal)   // находим и выводим класс животного 
            {
                string klass = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "SELECT * FROM Класс_животных INNER JOIN Карточка_учета_животных ON Класс_животных.id_klassa = Карточка_учета_животных.id_klassa where Карточка_учета_животных.id_karta =" + id_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        klass = oleDbDataReader["naimen"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return klass;
            }


            public string inf_otr(string id_animal)   // находим и выводим отряд животного 
            {
                string otryad = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "SELECT * FROM Отряд_животных INNER JOIN Карточка_учета_животных ON Отряд_животных.id_otr = Карточка_учета_животных.id_otr where Карточка_учета_животных.id_karta =" + id_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        otryad = oleDbDataReader["naimen"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return otryad;
            }


            public string inf_vid(string id_animal)   // находим и выводим вид животного 
            {
                string vid = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "SELECT * FROM Вид_животных INNER JOIN Карточка_учета_животных ON Вид_животных.id_vid = Карточка_учета_животных.id_vid where Карточка_учета_животных.id_karta =" + id_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        vid = oleDbDataReader["naimenovan"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return vid;
            }


            public string inf_korm(string id_animal)   // находим и выводим корм животного 
            {
                string korm = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "SELECT * FROM Корм INNER JOIN (Вид_животных INNER JOIN Карточка_учета_животных ON Вид_животных.id_vid = Карточка_учета_животных.id_vid) ON Корм.id_korma = Вид_животных.id_korma where Карточка_учета_животных.id_karta =" + id_animal + ";";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        korm = oleDbDataReader["naimen"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return korm;
            }

            public string inf_norma_korma(string id_animal)   // находим и выводим корм животного 
            {
                string norma_korma = "";
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    // string query = "SELECT * FROM Вид_животных INNER JOIN Карточка_учета_животных ON Вид_животных.id_vid = Карточка_учета_животных.id_vid where Карточка_учета_животных.id_vid = " + id_animal + ";";
                    string query = "SELECT * FROM Вид_животных INNER JOIN Карточка_учета_животных ON Вид_животных.id_vid = Карточка_учета_животных.id_vid WHERE(((Карточка_учета_животных.id_karta) = "+ id_animal +" ));";
                    oleDbCommand.CommandText = query;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    while (oleDbDataReader.Read())
                    {
                        norma_korma = oleDbDataReader["norma_korma"].ToString();
                    }
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                return norma_korma;
            }

            public void add_inf_animal(string klich,string  poroda, string id_pola, string age, string id_sost, string  id_klassa, string id_vid, string id_otr)
            {
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string query = "INSERT INTO Карточка_учета_животных ( klich, poroda, id_pola, age, id_sost, id_klassa, id_vid, id_otr ) VALUES ('" + klich + "','" + poroda + "','" + id_pola + "','" + age + "'," + id_sost + "," + id_klassa + "," + id_vid + "," + id_otr + "); ";
                    oleDbCommand.CommandText = query;
                    oleDbCommand.ExecuteNonQuery();
                    MessageBox.Show("Добавлено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
            }

            public void change_data_animal(string klich, string poroda, string id_pola, string age, string id_sost, string id_klassa, string id_vid, string id_otr, string id_animal)  // изменение 
            {
                try
                {
                    form1.OleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.Connection = form1.OleDbConnection;
                    string change_data = " UPDATE Карточка_учета_животных SET Карточка_учета_животных.klich = '" + klich + "', Карточка_учета_животных.poroda = '" + poroda + "', Карточка_учета_животных.id_pola = '" + id_pola + "', Карточка_учета_животных.age = '" + age + "', Карточка_учета_животных.id_sost = '" + id_sost + "', Карточка_учета_животных.id_klassa = '" + id_klassa + "', Карточка_учета_животных.id_vid = '" + id_vid + "', Карточка_учета_животных.id_otr = '" + id_otr + "'  where id_karta = " + id_animal + ";";
                    oleDbCommand.CommandText = change_data;
                    oleDbCommand.ExecuteNonQuery();
                    MessageBox.Show("Изменено!");
                    form1.OleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
            }
        }
    }

}
