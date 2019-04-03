using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DB_1
{
    public class XDB
    {
        private OleDbConnection conn = null;
        private OleDbCommand comm = null;
        private OleDbDataReader read = null;

        public XDB(string connectionString)
        {
            conn = new OleDbConnection();
            comm = new OleDbCommand();
            try
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                comm.Connection = conn;
            }
            catch (Exception e)
            {
                conn = null;
                comm = null;
                MessageBox.Show(e.ToString());
            }
        }//XDB()
        //----------------------------------------
        //insert, delete, update같은 데이터를 읽지는 않고
        //처리만 하는 함수
        public bool NonQuery(string query)
        {
            if (conn == null || comm == null)
            {
                MessageBox.Show("DB가 연결되어 있지 않습니다.");
                return false;
            }

            try
            {
                comm.CommandText = query;
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;
        }//NonQuery()
        //---------------------------------------
        public bool Query(string query)
        {
            if (conn == null || comm == null)
            {
                MessageBox.Show("DB가 연결되어 있지 않습니다.");
                return false;
            }

            if (read != null) read.Close();

            try
            {
                comm.CommandText = query;
                read = comm.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
            return true;
        }//Query()
        //----------------------------------------------
        public bool ReadNext()
        {
            if (read != null) return read.Read();
            return false;
        }
        //--------------------------------------------
        public string GetData(string name)
        {
            if (read != null) return read[name].ToString();
            MessageBox.Show("읽은 데이터가 없습니다.");
            return "";
        }
    }//class
}//nameSpace

