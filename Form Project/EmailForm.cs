using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailForm
{
    public partial class EmailForm : Form
    {
        DataTable my_data;

        // Constructor
        public EmailForm()
        {
            InitializeComponent();
        }

        // Load the main form
        private void EmailForm_Load(object sender, EventArgs e)
        {
            my_data = new DataTable();
            my_data.Columns.Add("Email Title: ", typeof(string));
            my_data.Columns.Add("Email message: ", typeof(string));
            dataGridView1.DataSource = my_data;

            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;
            dataGridView1.Columns["Email message: "].Visible = false;
            dataGridView1.Columns["Email Title: "].Width = 238;
        }
        
        // Delete email
        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                int index = -1;
                if (dataGridView1.CurrentCell != null)
                    index = dataGridView1.CurrentCell.RowIndex;
                else
                    throw new Exception();
                if (index > -1)
                {
                    my_data.Rows[index].Delete();
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                    throw new Exception();
            }
            catch
            {
                textBox1.Text = "No emails to delete!";
                textBox2.Clear();
            }
        }

        // Read Email
        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int index = -1;
                if (dataGridView1.CurrentCell != null)
                    index = dataGridView1.CurrentCell.RowIndex;
                else
                    throw new Exception();
                if (index > -1)
                {
                    textBox1.Text = my_data.Rows[index].ItemArray[0].ToString();
                    textBox2.Text = my_data.Rows[index].ItemArray[1].ToString();
                }
            }
            catch
            {
                textBox1.Text = "No emails to read!";
            }
        }

        // Clear email fields
        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        // Send email
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    my_data.Rows.Add(textBox1.Text, textBox2.Text);
                    textBox1.Clear();
                }
                else throw new ArgumentException();
            }
            catch
            {
                textBox1.Text = "Please don't send a blank email!";
                textBox2.Text = "";
            }
            finally
            {
                textBox2.Clear();
            }
        }
    }
}
