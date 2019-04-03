using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using DB_1;

namespace pc
{
    public partial class GoodsAdd : Form
    {


        private GoodsMgr gm;

        public GoodsAdd(GoodsMgr gmr)
        {
            InitializeComponent();
            this.gm = gmr;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Members.accdb");
            connection.Open();
            //실제 DB 테이블에 레코드 넣음
            
                OleDbCommand command = new OleDbCommand(string.Format("insert into goods values('{0}', '{1}', '{2}', '{3}', '{4}')",textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text), connection);
                command.ExecuteNonQuery();
             
            //데이터 그리드 뷰와 바인딩 작업
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from goods", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            // gm.dataGridView1.DataSource = table;
           
            
            this.Close(); 
            




            if (this.textBox1.Text == "")
            {
                MessageBox.Show("코드번호를 입력하지 않았습니다.");
            }
            else if (this.textBox2.Text == "")
            {
                MessageBox.Show("상품이름을 입력하지 않았습니다.");
            }
            else if (this.textBox3.Text == "")
            {
                MessageBox.Show("전체수량을 입력하지 않았습니다.");
            }
            else if (this.textBox4.Text == "")
            {
                MessageBox.Show("판매수량을 입력하지 않았습니다.");
            }
            else if (this.textBox5.Text == "")
            {
                MessageBox.Show("단가를 입력하지 않았습니다.");
            }



        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

       
    }
}
