using Microsoft.Azure.Amqp.Framing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Versioning;
using System.Windows.Forms;
using ГОВНО;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form form = new Form();
            Form1 form1 = new Form1();
            DataGridView dataGridView = new DataGridView();

            form1.RefreshDataGrid(dataGridView);

            form.Controls.Add(dataGridView);  
        }

        [TestMethod]
        public void TestMethod2()
        {
            Form form = new Form();
            Form1 form1 = new Form1();
            DataGridView dataGridView = new DataGridView();
            ComboBox comboBox1 = new ComboBox();

            form1.RefreshDataGrid(dataGridView);
            comboBox1.Items.Add("Kia");
            comboBox1.Items.Add("BMW");


            comboBox1.SelectedIndex = 1;

            form.Controls.Add(dataGridView);
            form.Controls.Add(comboBox1);

            Assert.AreEqual(1, comboBox1.SelectedIndex);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Form form = new Form();
            Form1 form1 = new Form1();
            DataGridView dataGridView = new DataGridView();
            ComboBox comboBox1 = new ComboBox();
            PictureBox pictureBox = new PictureBox();

            form1.RefreshDataGrid(dataGridView);
            comboBox1.Items.Add("Kia");
            comboBox1.Items.Add("BMW");


            comboBox1.SelectedIndex = 0;

            form.Controls.Add(dataGridView);
            form.Controls.Add(comboBox1);
            form.Controls.Add(pictureBox);

            Assert.AreEqual(0, comboBox1.SelectedIndex);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Form form = new Form();
            Form1 form1 = new Form1();
            DataGridView dataGridView = new DataGridView();
            ComboBox comboBox1 = new ComboBox();
            PictureBox pictureBox = new PictureBox();

            form1.RefreshDataGrid(dataGridView);
            comboBox1.Items.Add("Kia");
            comboBox1.Items.Add("BMW");

            dataGridView.CellClick += form1.dataGridView1_CellClick_1;


            comboBox1.SelectedIndex = 0;

            form.Controls.Add(dataGridView);
            form.Controls.Add(comboBox1);
            form.Controls.Add(pictureBox);

            Assert.AreEqual(0, comboBox1.SelectedIndex);
        }
    }
}
