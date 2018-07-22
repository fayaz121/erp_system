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
    
    public partial class Form6 : Form
    {
        Myconn conn = new Myconn();
        public Form6()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select VID from vendor", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["VID"].ToString());
            }
            conn.oleDbConnection1.Close();


            Form7 F7 = new Form7();
            F7.Show();
            this.Hide();
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
                textBox4.Text = dr["PH1"].ToString();
                textBox5.Text = dr["PH2"].ToString();
                textBox10.Text = dr["VFAX"].ToString();
               
            }
            conn.oleDbConnection1.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select VID from vendor", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["VID"].ToString());
            }
            conn.oleDbConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox12.Text = "APPROVE";
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("update vendor set vstatus='Approve' where vid='" + comboBox1.Text + "'", conn.oleDbConnection1);

            cmd.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox12.Text = "Disapprove";
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("update vendor set vstatus='Disapprove' where vid='" + comboBox1.Text + "'", conn.oleDbConnection1);

            cmd.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 F5 = new Form5();
            F5.Show();
            this.Hide();
        }

       
    }
}
