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
    public partial class Price : Form
    {

        private OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Members.accdb");


        public Price()
        {
            InitializeComponent();


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


            string query = string.Format("select * from price where 이름 = '" + textBox1.Text + "'");
            BindData(query, dataGridView1);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Price_Load(object sender, EventArgs e)
        {
            BindData("select * from price", dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindData("select * from price", dataGridView1);
        }
    }
}
