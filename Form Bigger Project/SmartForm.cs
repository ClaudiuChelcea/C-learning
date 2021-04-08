using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class SmartForm : Form
    {
        DataTable mydata;
        public SmartForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mydata = new DataTable();
            mydata.Columns.Add("Name:", typeof(string));
            mydata.Columns.Add("Mobile:", typeof(string));
            mydata.Columns.Add("Email:", typeof(string));
            mydata.Columns.Add("Importance:", typeof(string));
            dataGridView1.DataSource = mydata;
            dataGridView1.Columns["Name:"].Width = 181;
            dataGridView1.Columns["Mobile:"].Width = 181;
            dataGridView1.Columns["Email:"].Width = 181;
            dataGridView1.Columns["Importance:"].Width = 181;
            this.ActiveControl = textBox1;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            erase();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.SelectedIndex != -1)
            {
               mydata.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedItem);
               erase();
            }
            else
            {
                erase();
                MessageBox.Show("Invalid submission! All fields are mandatory!");
            }
        }

        private void erase()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            SmartForm.ActiveForm.ActiveControl = textBox1;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            erase();
            if(dataGridView1.CurrentCell != null)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                string mystring = mydata.Rows[index].ItemArray[0].ToString();
                textBox1.Text = mystring;
                mystring = mydata.Rows[index].ItemArray[1].ToString();
                textBox2.Text = mystring;
                mystring = mydata.Rows[index].ItemArray[2].ToString();
                textBox3.Text = mystring;
                comboBox1.SelectedIndex = index;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                mydata.Rows[index].Delete();
                erase();
            }
            else
            {
                MessageBox.Show("Agenda is empty!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.SelectedIndex != -1)
            {
                int index = -1;
                if (dataGridView1.CurrentCell != null)
                {
                    index = dataGridView1.CurrentCell.RowIndex;
                }
                else
                {
                    MessageBox.Show("Nothing to update!");
                    return;
                }
                
                string string1 = textBox1.Text;
                string string2 = textBox2.Text;
                string string3 = textBox3.Text;
                string x = comboBox1.SelectedItem.ToString();
                mydata.Rows[index].Delete();
                mydata.Rows.Add(string1, string2, string3, x);
                erase();
            }
            else
            {
                erase();
                MessageBox.Show("Invalid submission! All fields are mandatory!");
            }
        }
    }
}
