using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pc
{
    public partial class MasterCode : Form
    {
        public MasterCode()
        {
            InitializeComponent();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "1111")
            {
                
                MasterMgr MaMgr = new MasterMgr();
                MessageBox.Show("관리자모드로 로그인 하셨습니다");
                MaMgr.ShowDialog();

                this.Close();

               
                
               
                
            }
            else if (this.textBox1.Text == "")
            {
                MessageBox.Show("입력되지 않았습니다.");

            }

            else
            {
                MessageBox.Show("잘못 입력 되었습니다.");
            }
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            

        }

        private void MasterCode_Load(object sender, EventArgs e)
        {

        }

        

       
    }
}
