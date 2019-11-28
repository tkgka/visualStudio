using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDB02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        private void Form1_Load(object sender, EventArgs e)
        {
            string connectingString = "server = localhost;port=3306;username=root;password=root";
            conn = new MySqlConnection(connectingString);

            try
            {
                conn.Open();
                

                if(conn.State == ConnectionState.Open)
                {
                    label1.Text = "Connected";
                    label1.ForeColor = Color.Green;
                }
                else
                {
                    label1.Text = "NotConnected";
                    label1.ForeColor = Color.Red;
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
