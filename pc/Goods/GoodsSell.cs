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
    public partial class GoodsSell : Form
    {

        private OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Members.accdb");

        public GoodsSell()
          {
            InitializeComponent();

        //    string[] data = new string[6];

        //        XDB myDB = new XDB(
        //        "Provider=Microsoft.ACE.OLEDB.12.0; " +
        //        "Data Source=../../../Members.accdb; " +
        //        "Persist Security Info=False");

        //        string query = "select * from goodssell";
        //        myDB.Query(query);
        //        while (myDB.ReadNext())
        //        {
        //            data[0] = myDB.GetData("회원ID");
        //            data[1] = myDB.GetData("상품코드");
        //            data[2] = myDB.GetData("상품이름");
        //            data[3] = myDB.GetData("판매날짜");
        //            data[4] = myDB.GetData("판매개수");
        //            data[5] = myDB.GetData("판매금액");
        //            dataGridView1.Rows.Add(data);
        //        }

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

       



        private void button1_Click(object sender, EventArgs e)
        {


            string query = string.Format("select * from goodssell where 상품이름 = '" + textBox1.Text + "'");
            BindData(query, dataGridView1);



        }

        private void button4_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                //현재 선택된 행들을 가져옴
                DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
                //DB연결 엶
                for (int i = 0; i < rows.Count; i++)//여러행이 있기때문에 돌면서 삭제
                {
                    string key = rows[i].Cells["상품코드"].Value.ToString().Trim();
                    ExecuteQuery(string.Format("delete from goodssell where 상품코드 = {0}", key));
                }
                BindData("select * from goodssell", dataGridView1);
            }
            
        }






        private void button2_Click(object sender, EventArgs e)
        {
            GoodsSellAdd goodsselladd = new GoodsSellAdd(this);
            goodsselladd.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            BindData("select * from goodssell", dataGridView1);
           

        }

      
        //--------------수정버튼--------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Members.accdb");
            connection.Open();
            //실제 DB 테이블에 레코드 넣음
            OleDbCommand command = new OleDbCommand(string.Format("UPDATE goodssell SET 회원ID='{0}', 상품이름='{1}', 판매날짜='{2}', 판매개수='{3}', 판매금액 = '{4}' Where 상품코드={5}  ", textBox2.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox3.Text), connection);
            command.ExecuteNonQuery();
            //데이터 그리드 뷰와 바인딩 작업
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from goodssell", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();



        }

        private void GoodsSell_Load(object sender, EventArgs e)
        {
          

            BindData("select * from goodssell", dataGridView1);

        
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
        }

        }
    }

