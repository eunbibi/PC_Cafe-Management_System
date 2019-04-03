using System;
using System.Windows;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace pjkim.xDB
{
   class xDB
   {
      OleDbConnection conn = null;
      OleDbCommand comm = null;
      OleDbDataReader read = null;
      string conStr;

      public xDB(string conStr)
      {
         this.conStr = conStr;
         OpenDB();
      }
      //---------------------------------------------------
      public void OpenDB()
      {
         try {
            CloseDB();

            conn = new OleDbConnection();
            comm = new OleDbCommand();
            conn.ConnectionString = conStr;

            //"Provider=Microsoft.ACE.OLEDB.12.0; " +
            //"Data Source=../../../DBFile/SCHEDULEDB.accdb; " +
            //"Persist Security Info=False";

            conn.Open();
            comm.Connection = conn;
         }
         catch (Exception e) {
            MessageBox.Show(e.Message, "OleDB");
            Environment.Exit(0);
         }
      }
      //---------------------------------------------------
      public void CloseDB()
      {
         try {
            if (conn != null) conn.Close();
            if (read != null) read.Close();
            conn = null;
            read = null;
            comm = null;
         }
         catch (Exception e) {
            MessageBox.Show(e.Message, "OleDB");
            Environment.Exit(0);
         }
      }
      //----------------------------------------------------
      public void CloseReader()
      {
         if (read == null) return;
         read.Close();
         read = null;
      }
      //--------------------------------------------------
      public void ReadDB(string query)
      {
         try {
            CloseReader();
            comm.CommandText = query;
            read = comm.ExecuteReader();
         }
         catch (Exception e) {
            MessageBox.Show(e.Message + "\n\n" + query, "OleDB");
            Environment.Exit(0);
         }
      }
      //-------------------------------------------------
      public void ExecuteDB(string query)
      {
         try {
            CloseReader();
            comm.CommandText = query;
            comm.ExecuteNonQuery();
         }
         catch (Exception e) {
            MessageBox.Show(e.Message + "\n\n" + query, "OleDB");
            Environment.Exit(0);
         }
      }
      //--------------------------------------------------
      public bool GetDBRecord()
      {
         bool result = false;

         try {
            result = read.Read();
         }
         catch (Exception e) {
            MessageBox.Show(e.Message, "OleDB");
            Environment.Exit(0);
         }

         return result;
      }

      //--------------------------------------------------
      public string GetData(string colName)
      {
         return read[colName].ToString();
      }
   }
}//namespace pjkim.xDB