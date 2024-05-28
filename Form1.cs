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
using System.Xml.Linq;

namespace ГОВНО
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection($@"Data Source=DESKTOP-QAK3A45\SQLEXPRESS; Initial Catalog=kyrcachBeta; Integrated Security = True");
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumns();
            CreateColumns2();
        }

        private void CreateColumns()
        {

            dataGridView1.Columns.Add("марка", "марка");
            dataGridView1.Columns.Add("модель", "модель");
            dataGridView1.Columns.Add("id_двигатели", "двигатель");


        }

        private void CreateRows(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add ( record.GetString(0), record.GetString(1), record.GetString(2));
        }

        public void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"select vin.марка,vin.модель,dd.название from vin, двигатели dd where dd.id = vin.id_двигатели and марка='{comboBox1.Text}'";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();


            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                CreateRows(dgw, sqlDataReader);
            }
            sqlDataReader.Close();
            con.Close(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            if (comboBox1.SelectedIndex == 3)
            {
                pictureBox1.Image = Properties.Resources.BMW;
                pictureBox1.Visible = true;

            }

            if (comboBox1.SelectedIndex == 6)
            {
                pictureBox1.Image = Properties.Resources.Nissan;
                pictureBox1.Visible = true;

            }
            if (comboBox1.SelectedIndex == 0)
            {
                pictureBox1.Image = Properties.Resources.kia;
                pictureBox1.Visible = true;

            }
            if (comboBox1.SelectedIndex == 1)
            {
                pictureBox1.Image = Properties.Resources.ford2;
                pictureBox1.Visible = true;

            }
            if (comboBox1.SelectedIndex == 2)
            {
                pictureBox1.Image = Properties.Resources.kamri;
                pictureBox1.Visible = true;

            }
            if (comboBox1.SelectedIndex == 4)
            {
                pictureBox1.Image = Properties.Resources.volkswagen;
                pictureBox1.Visible = true;

            }
            if (comboBox1.SelectedIndex == 5)
            {
                pictureBox1.Image = Properties.Resources.skoda;
                pictureBox1.Visible = true;

            }
            if (comboBox1.SelectedIndex == 7)
            {
                pictureBox1.Image = Properties.Resources.solaris;
                pictureBox1.Visible = true;

            }
            if (comboBox1.SelectedIndex == 8)
            {
                pictureBox1.Image = Properties.Resources.mazda;
                pictureBox1.Visible = true;

            }
            if (comboBox1.SelectedIndex == 9)
            {
                pictureBox1.Image = Properties.Resources.audi;
                pictureBox1.Visible = true;

            }
            if (comboBox1.SelectedIndex == 10)
            {
                pictureBox1.Image = Properties.Resources.omegaBjpg;
                pictureBox1.Visible = true;

            }
            if (comboBox1.SelectedIndex == 11)
            {
                pictureBox1.Image = Properties.Resources.mitsu;
                pictureBox1.Visible = true;

            }
            if (comboBox1.SelectedIndex == 12)
            {
                pictureBox1.Image = Properties.Resources.chevro;
                pictureBox1.Visible = true;

            }
            if (comboBox1.SelectedIndex == 13)
            {
                pictureBox1.Image = Properties.Resources.logan;
                pictureBox1.Visible = true;

            }
            if (comboBox1.SelectedIndex == 14)
            {
                pictureBox1.Image = Properties.Resources.mers;
                pictureBox1.Visible = true;

            }



        }

        public void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrows;
            selectedrows = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedrows];

                if (row.Cells[0].Value == null)
                {
                    MessageBox.Show("Выбрано пустое значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    textBox1.Text = row.Cells[2].Value.ToString();
                }

            }

        }
        private void CreateColumns2()
        {

            dataGridView2.Columns.Add("название", "название_акпп");
            dataGridView2.Columns.Add("описание", "описание");
            dataGridView2.Columns.Add("аналоги_акпп", "аналоги_акпп");


        }
        private void CreateRows2(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2));
        }

        public void RefreshDataGrid2(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"select акпп.название, акпп.описание, акпп.аналоги_акпп from двигатели, акпп where акпп.id_двигатели = двигатели.id and двигатели.название = '{textBox1.Text}'";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();


            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                CreateRows2(dgw, sqlDataReader);
            }
            sqlDataReader.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid2(dataGridView2);
            dataGridView2.Visible = true;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Вы не выбрали двигатель", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {


                e.Handled = true; // Если это не буква, игнорируем ввод


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

                e.Handled = true; // Если это не буква и не цифра, игнорируем ввод

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            e.Control.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Отменяем ввод любого символа
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column2_KeyPress);
            e.Control.KeyPress += new KeyPressEventHandler(Column2_KeyPress);
        }

        private void Column2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Отменяем ввод любого символа
        }
    }
}
