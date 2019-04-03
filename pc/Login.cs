using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DB_1;

namespace pc
{
    
    public partial class Login : Form
    {

       
        public Login()
        {
            InitializeComponent();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            XDB myDB = new XDB(
                "Provider=Microsoft.ACE.OLEDB.12.0; " +
                "Data Source=Members.accdb; " +
                 "Persist Security Info=False");

            string query = "select * from member where ID = '" + textBox1.Text + "' and 비밀번호 = '" + textBox2.Text + "'";
            myDB.Query(query);


                if (this.textBox1.Text == "")
                {
                    MessageBox.Show("ID를 입력하지 않으셨습니다.");
                }
                else if (this.textBox2.Text == "")
                {
                    MessageBox.Show("비밀번호를 입력하지 않으셨습니다.");
                }            

             
            while(myDB.ReadNext())
            {
                
                if (textBox1.Text == myDB.GetData("ID") && textBox2.Text == myDB.GetData("비밀번호"))
                {
                    this.Close();
                    MessageBox.Show("로그인됬습니다");
                    PCset pcset = new PCset();
                    pcset.ShowDialog();
                    
                   
                }
                
            }
           

            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemberAdd add = new MemberAdd();
            add.ShowDialog();
            
        }

       
    }
}
