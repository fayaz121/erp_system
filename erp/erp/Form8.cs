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
    public partial class Form8 : Form
    {
        Myconn conn = new Myconn();
        public Form8()
        {
            InitializeComponent();
        }

      

        private void Form8_Load(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select vdept from po", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["vdept"].ToString());
            }
            conn.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 0;


            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(poid) from po where vdept='" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            if (comboBox1.Text == "Consumer")
            {
                textBox1.Text = "Con-00" + c.ToString() + "-" + System.DateTime.Today.Year;

            }

            if (comboBox1.Text == "Sales")
            {
                textBox1.Text = "Sal-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }

            if (comboBox1.Text == "HR")
            {
                textBox1.Text = "HR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }

            if (comboBox1.Text == "IT")
            {
                textBox1.Text = "IT-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            conn.oleDbConnection1.Close();

            int i = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmm = new OleDbCommand("select count(vid) from po where vdept='" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader drr = cmm.ExecuteReader();
            if (drr.Read())
            {
                i = Convert.ToInt32(drr[0]);
                i++;
            }

            if (comboBox1.Text == "Consumer")
            {
                textBox2.Text = "0" + i.ToString();

            }

            if (comboBox1.Text == "Sales")
            {
                textBox1.Text = "0" + i.ToString();
            }

            if (comboBox1.Text == "HR")
            {
                textBox2.Text = "0" + i.ToString(); ;
            }
            conn.oleDbConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into po(poid,vcontectperson,vcpph,ddate,podate,approve,vid,vdept) values(@poid,@vcontectperson,@vcpph,@ddate,@podate,@approve,@vid,@vdept)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@poid", textBox1.Text);
            cmd.Parameters.AddWithValue("@vcontectperson", textBox2.Text);
            cmd.Parameters.AddWithValue("@vcpph", textBox3.Text);
            cmd.Parameters.AddWithValue("@ddate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@podate", dateTimePicker2);
            cmd.Parameters.AddWithValue("@approve", textBox6.Text);
            // cmd.Parameters.AddWithValue("@totalamount", textBox6.Text);
           // cmd.Parameters.AddWithValue("@vid", textBox8.Text);
            cmd.Parameters.AddWithValue("@vdept", comboBox1.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show(":Your Purchase Order Is Create:");
            conn.oleDbConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.Show();
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
