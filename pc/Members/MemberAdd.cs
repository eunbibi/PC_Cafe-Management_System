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
    public partial class MemberAdd : Form
    {
        

        public MemberAdd()
        {
            InitializeComponent();
           
        }


        private void button1_Click(object sender, EventArgs e)
        {

            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Members.accdb");
            connection.Open();
            //실제 DB 테이블에 레코드 넣음
            OleDbCommand command = new OleDbCommand(string.Format("insert into member values('{0}', '{1}', '{2}', '{3}')", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text), connection);
            command.ExecuteNonQuery();
            //데이터 그리드 뷰와 바인딩 작업
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from member", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            // gm.dataGridView1.DataSource = table;
            this.Close();
          

            if (this.textBox1.Text == "")
            {
                MessageBox.Show("ID를 입력하지 않았습니다.");
            }
            else if (this.textBox2.Text == "")
            {
                MessageBox.Show("비밀번호를 입력하지 않았습니다.");
            }
            else if (this.textBox3.Text == "")
            {
                MessageBox.Show("이름을 입력하지 않았습니다.");
            }
            else if (this.textBox4.Text == "")
            {
                MessageBox.Show("전화번호를 입력하지 않았습니다.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        
    }
}
