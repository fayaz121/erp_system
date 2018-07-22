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
    public partial class Form5 : Form
    {
        Myconn conn = new Myconn();

        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Close();
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into vendor(vid,cpname,vcity,vaddress,cpph,ph1,ph2,vname,vemail,vgroup) values(@vid,@cpname,@vcity,@vaddress,@cpph,@ph1,@ph2,@vname,@vemail,@vgroup)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@vid", textBox13.Text);
            cmd.Parameters.AddWithValue("@cpname", textBox7.Text);
            cmd.Parameters.AddWithValue("@vcity", textBox3.Text);
            cmd.Parameters.AddWithValue("@vaddress", textBox6.Text);
            cmd.Parameters.AddWithValue("@cpph", textBox8.Text);
            cmd.Parameters.AddWithValue("@ph1", textBox4.Text);
            cmd.Parameters.AddWithValue("@ph2", textBox5.Text);
            cmd.Parameters.AddWithValue("@vname", textBox1.Text);
            cmd.Parameters.AddWithValue("@vemail", textBox9.Text);

            cmd.Parameters.AddWithValue("@vgroup", textBox11.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Your Request Goes To Admin For Approval");
           
            Form6 F6 = new Form6();
            F6.Show();
            this.Hide();
            conn.oleDbConnection1.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 F3 = new Form3();
            F3.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            int f=04;

             conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(VID) from vendor", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                f = Convert.ToInt32(dr[0]);
                f++;
                textBox13.Text = f.ToString();
            }



        }
    }

        
}
