using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using Customize_MessageBox_DLL;
public class TConnection
{

    private string ConnectString = "Data source =(local);initial catalog=DBShalikoubi;integrated security = true";
    SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
    SqlCommand cmd = new SqlCommand();
    

    private void MsgBox(object p)
    {
        throw new NotImplementedException();
    }

    protected OleDbConnection mConnet = new OleDbConnection();

    public string CommandText { get; set; }

    public TConnection()
    {
    }


    protected bool Execute()
    {
        //try
        //{
            con.Close();
            cmd.Connection = con;
            cmd.CommandText = CommandText;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            CommandText = "";
            return true;
        //}
        //catch (Exception ex)
        //{
        //    //MsgBox(ex.Message);
        //    //throw;
            
        //    return false;
        //}

    }

    public DataTable ExecuteReader()
    {
        try
        {
            DataSet myDataSet = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = CommandText;
            myDataSet.Clear();
            adp.Fill(myDataSet, CommandText);
            return myDataSet.Tables[0];
        }
        catch (Exception ex)
        {
            MsgBox((ex.Message + ("\r\n" + CommandText)));
        }

        return null;
    }

    public string ScalerExecute()
    {
        try
        {
            DataTable dt;
            DataSet myDataSet = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = CommandText;
            myDataSet.Clear();
            adp.Fill(myDataSet, CommandText);
            dt = myDataSet.Tables[0];
            return dt.DefaultView[0].Row[0].ToString();
        }
        catch (Exception ex)
        {
            return "";
        }

    }

    public DataTable RunSql(string SqlCommand)
    {
        try
        {
            DataSet myDataSet;
            myDataSet = new DataSet();
            if ((mConnet.State == ConnectionState.Closed))
            {
                mConnet.ConnectionString = ConnectString;
                mConnet.Open();
            }

            OleDbCommand myCommand = new OleDbCommand(SqlCommand, mConnet);
            myCommand.CommandTimeout = 0;
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myCommand);
            myDataSet.Clear();
            myDataAdapter.Fill(myDataSet, "myCommand");
            return myDataSet.Tables[0];
        }
        catch (Exception ex)
        {
            return null;
        }

    }
}