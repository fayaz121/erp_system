using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        Myconn conn=new Myconn();
        


        public Form4()
        {
            InitializeComponent();
        }

      

        private void Form4_Load(object sender, EventArgs e)
        {

            conn.oleDbConnection1.Open();
            OleDbCommand Cmd = new  OleDbCommand("select vid from vendor", conn.oleDbConnection1);
            OleDbDataReader dr = Cmd.ExecuteReader();

            while(dr.Read())
            {
                comboBox1.Items.Add(dr["vid"].ToString());
            }
            conn.oleDbConnection1.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from vendor where VID='" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox7.Text = dr["CPNAME"].ToString();
                textBox3.Text = dr["VCITY"].ToString();
                textBox6.Text = dr["VADDRESS"].ToString();
                textBox11.Text = dr["VGROUP"].ToString();
                textBox9.Text = dr["VEMAIL"].ToString();
                textBox8.Text = dr["CPPH"].ToString();
                textBox1.Text = dr["VNAME"].ToString();
                textBox12.Text = dr["VSTATUS"].ToString();
                textBox2.Text = dr["VCODE"].ToString();
                textBox4.Text = dr["PH1"].ToString();
                textBox5.Text = dr["PH2"].ToString();
                textBox10.Text = dr["VFAX"].ToString();

            }
            conn.oleDbConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 F3 = new Form3();
            F3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.Show();
            this.Hide();
               
        }

       
       
    }
}
