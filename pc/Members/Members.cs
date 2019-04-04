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
    public partial class Members : Form
    {
        

        private OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Members.accdb");
    
               
        public Members()
        {
            
             InitializeComponent();
                        

            //string[] data = new string[4];

            //XDB myDB = new XDB(
            //"Provider=Microsoft.ACE.OLEDB.12.0; " +
            //"Data Source=../../../Members.accdb; " +
            //"Persist Security Info=False");

            //string query = "select * from member";
            //myDB.Query(query);
            //while (myDB.ReadNext())
            //{
            //    data[0] = myDB.GetData("ID");
            //    data[1] = myDB.GetData("비밀번호");
            //    data[2] = myDB.GetData("이름");
            //    data[3] = myDB.GetData("전화번호");
               
            //    dataGridView1.Rows.Add(data);
            //}


        }




        // 쿼리를 실행하여 데이터 그리드 뷰와 바인딩합니다.

        //실행할 쿼리문입니다.
        //바인딩할 데이터 그리드 뷰입니다
        private void BindData(string query, DataGridView dgv)
        {
            //connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            dgv.DataSource = table;
        }


        // 레코드를 추가하거나 삭제합니다.

        //실행할 쿼리입니다.
        private void ExecuteQuery(string query)
        {
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }








        private void button2_Click(object sender, EventArgs e)
        {
            MemberAdd memberadd = new MemberAdd();
            memberadd.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string query = string.Format("select * from member where 이름 = '" + textBox1.Text + "'");
            BindData(query, dataGridView1);
            
                               
             
            

        }
        //------------------------------삭제버튼------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                //현재 선택된 행들을 가져옴
                DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
                //DB연결 엶
                for (int i = 0; i < rows.Count; i++)//여러행이 있기때문에 돌면서 삭제
                {
                    string key = rows[i].Cells["전화번호"].Value.ToString().Trim();
                    ExecuteQuery(string.Format("delete from member where 전화번호 = {0}", key));
                }
                
                BindData("select * from goodssell", dataGridView1);
            }


        }




        private void button4_Click(object sender, EventArgs e)
        {

            BindData("select * from member", dataGridView1);
        }

        private void Members_Load(object sender, EventArgs e)
        {
            BindData("select * from member", dataGridView1);
        }

      
    }
}
