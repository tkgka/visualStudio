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

namespace DB수행
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter adapter;
        DataSet dataSet;
        public Form1()
        {
            InitializeComponent();
        }

       private void Form1_Load(object sender, EventArgs e)
        {
           string connStr = "server=localhost;port=3306;database=alpha;uid=root;pwd=root";
            conn = new MySqlConnection(connStr);
            adapter = new MySqlDataAdapter("SELECT * FROM 고객", conn);
            dataSet = new DataSet();

            adapter.Fill(dataSet, "고객");
            dataGridView1.DataSource = dataSet.Tables["고객"];

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                if (radioButton1.Checked)
                {
                    dataSet.Clear();
                    adapter = new MySqlDataAdapter("SELECT * FROM 고객", conn);
                    adapter.Fill(dataSet, "고객");
                    dataGridView1.DataSource = dataSet.Tables["고객"];
                    label1.Text = "고객아이디";
                    label2.Text = "고객이름";
                    label3.Text = "나이";
                    label4.Text = "등급";
                    label5.Text = "직업";
                    label6.Text = "적립금";
                }
                else if (radioButton2.Checked)
                {
                    dataSet.Clear();
                    adapter = new MySqlDataAdapter("SELECT * FROM 주문", conn);
                    adapter.Fill(dataSet, "주문");
                    dataGridView1.DataSource = dataSet.Tables["주문"];
                    label1.Text = "주문번호";
                    label2.Text = "주문고객";
                    label3.Text = "제품번호";
                    label4.Text = "수량";
                    label5.Text = "배송지";
                    label6.Text = "주문일자";
                }
                else if (radioButton3.Checked)
                {
                    dataSet.Clear();
                    adapter = new MySqlDataAdapter("SELECT * FROM 제품", conn);
                    adapter.Fill(dataSet, "제품");
                    dataGridView1.DataSource = dataSet.Tables["제품"];
                    label1.Text = "제품번호";
                    label2.Text = "제품명";
                    label3.Text = "재고량";
                    label4.Text = "단가";
                    label5.Text = "제공업체";
                    label6.Text = "";
                }
                else
                {
                    MessageBox.Show("테이블을 선택하세요");
                }
            }
            else
            {
                if (radioButton1.Checked)
                {
                    dataSet.Clear();
                    string sql = "SELECT * FROM 고객 where 고객아이디 = @고객아이디 ";

                    adapter.SelectCommand = new MySqlCommand(sql, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@고객아이디", textBox1.Text);

                    try
                    {
                        conn.Open();
                        //select 결과를 dataSet에 city라는 이름의 테이블로 만들어라.
                        if (adapter.Fill(dataSet, "고객") > 0) // 검색된 데이터의 행숫자 반환
                            dataGridView1.DataSource = dataSet.Tables["고객"];

                        else
                        {
                            MessageBox.Show("데이터가 검색되지 않았습니다");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else if (radioButton1.Checked)
                {
                    dataSet.Clear();
                    string sql = "SELECT * FROM 제품 where 고객아이디 = @고객아이디 ";

                    adapter.SelectCommand = new MySqlCommand(sql, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@고객아이디", textBox1.Text);

                    try
                    {
                        conn.Open();
                        //select 결과를 dataSet에 city라는 이름의 테이블로 만들어라.
                        if (adapter.Fill(dataSet, "제품") > 0) // 검색된 데이터의 행숫자 반환
                            dataGridView1.DataSource = dataSet.Tables["제품"];

                        else
                        {
                            MessageBox.Show("데이터가 검색되지 않았습니다");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else if (radioButton1.Checked)
                {
                    dataSet.Clear();
                    string sql = "SELECT * FROM 주문 where 고객아이디 = @고객아이디 ";

                    adapter.SelectCommand = new MySqlCommand(sql, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@고객아이디", textBox1.Text);

                    try
                    {
                        conn.Open();
                        //select 결과를 dataSet에 city라는 이름의 테이블로 만들어라.
                        if (adapter.Fill(dataSet, "주문") > 0) // 검색된 데이터의 행숫자 반환
                            dataGridView1.DataSource = dataSet.Tables["주문"];

                        else
                        {
                            MessageBox.Show("데이터가 검색되지 않았습니다");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            string sql = "insert into 고객 (고객아이디,고객이름,나이,등급,직업,적립금)" + "values(@고객아이디,@고객이름,@나이,@등급,@직업,@적립금)";
            adapter.InsertCommand = new MySqlCommand(sql, conn);
            adapter.InsertCommand.Parameters.AddWithValue("@고객아이디", textBox1);
            adapter.InsertCommand.Parameters.AddWithValue("@고객이름", textBox2);
            adapter.InsertCommand.Parameters.AddWithValue("@나이", textBox3);
            adapter.InsertCommand.Parameters.AddWithValue("@등급", textBox4);
            adapter.InsertCommand.Parameters.AddWithValue("@직업", textBox5);
            adapter.InsertCommand.Parameters.AddWithValue("@적립금", textBox6);

            DataRow newRow = dataSet.Tables["고객아이디"].NewRow();
            
            newRow["고객아이디"] = textBox1.Text;
            newRow["고객이름"] = textBox2.Text;
            newRow["나이"] = textBox3.Text;
            newRow["등급"] = textBox4.Text;
            newRow["직업"] = textBox5.Text;
            newRow["적립금"] = textBox6.Text;
            dataSet.Tables["고객"].Rows.Add(newRow);


            try
            {
                conn.Open();
                adapter.Update(dataSet, "고객");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string sql = "update 고객 set 고객아이디 = @고객아이디 where countrycode = @countrycode";
            adapter.UpdateCommand = new MySqlCommand(sql, conn);
            adapter.UpdateCommand.Parameters.AddWithValue("@district", textBox4.Text);
            adapter.UpdateCommand.Parameters.AddWithValue("@countrycode", textBox3.Text);
            
            
            int id = (int)dataGridView1.SelectedRows[0].Cells["id"].Value;
            string filter = "id= " + id;
            DataRow[] findRows = dataSet.Tables["city"].Select(filter);
            findRows[0]["id"] = id;
            findRows[0]["name"] = textBox2.Text;
            findRows[0]["countrycode"] = textBox3.Text;
            findRows[0]["district"] = textBox4.Text;
            findRows[0]["population"] = textBox5.Text;
            try
            {
                conn.Open();
                adapter.Update(dataSet, "city");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }
    }
}
