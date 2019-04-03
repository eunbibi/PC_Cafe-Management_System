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
    public partial class MonAccounts : Form
    {


        private OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Members.accdb");

        public MonAccounts()
        {
            InitializeComponent();


            //string[] data = new string[4];

            //XDB myDB = new XDB(
            //"Provider=Microsoft.ACE.OLEDB.12.0; " +
            //"Data Source=../../../Members.accdb; " +
            //"Persist Security Info=False");

            //string query = "select * from month_count";
            //myDB.Query(query);
            //while (myDB.ReadNext())
            //{
            //    data[0] = myDB.GetData("월");
            //    data[1] = myDB.GetData("PC요금");
            //    data[2] = myDB.GetData("매점판매액");
            //    data[3] = myDB.GetData("총매출액");
                

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

        private void MonAccounts_Load(object sender, EventArgs e)
        {

            BindData("select * from month_count", dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            

        }

       
    }
}
