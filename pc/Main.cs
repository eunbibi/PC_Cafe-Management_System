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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

          
            MasterCode code = new MasterCode();
            code.ShowDialog();

            
           
            
            
                       
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            Login lo = new Login();
            lo.ShowDialog();
            
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

       

     
       
    }
}
