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
    public partial class MasterMgr : Form
    {
        
        public MasterMgr()
        {
            InitializeComponent();
        
            
        }
        //--------------------------  메뉴  -----------------------------------------------------
        private void button19_Click(object sender, EventArgs e)
        {
            Members members = new Members();
            members.ShowDialog();

        }

        private void button20_Click(object sender, EventArgs e)
        {
            GoodsMgr goodsmgr = new GoodsMgr();
            goodsmgr.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            GoodsSell goodssell = new GoodsSell();
            goodssell.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Price price = new Price();
            price.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            MonAccounts monaccounts = new MonAccounts();
            monaccounts.ShowDialog();
        }

        //-----------------------------------  PC 자리 ---------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {

            this.Close();
            
            
        }










    }
}
