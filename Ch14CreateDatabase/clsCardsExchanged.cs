using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

class clsCardsExchanged
{

    private Int32 records;
    private string connectStr;
    clsDB myDB;

    private int id;
    private int cardType;
    private string dateSent;
    private string dateReceived;

    //=================================== Constructors =========================

    public clsCardsExchanged() 
    {
        dateSent = "";
        dateReceived = "";
    }

    public clsCardsExchanged(string connect) : this()
    {
        connectStr = connect;
        myDB = new clsDB(connectStr);
        records = myDB.ReadRecordCount(connectStr);

    }

    //=================================== Property Methods ======================

    public int ID
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }
   public int CardType
    {
        get
        {
            return cardType;
        }

        set
        {
            cardType = value;
        }
    }
   public string CardSent
    {
        get
        {
            return dateSent;
        }

        set
        {
            if (value.Length > 0)
                dateSent = value;
        }
    }

   public string CardReceived
    {
        get
        {
            return dateReceived;
        }

        set
        {
            if (value.Length > 0)
                dateReceived = value;
        }
    }

   /*****
   Get record count for CardsExchanged */
   public Int32 RecordCount(string connectStr)
   {
       try
       {
           SqlConnection conn = new SqlConnection(connectStr);
           conn.Open();

           SqlCommand cmd = new SqlCommand("SELECT COUNT(LastName) FROM CardsExchanged", conn);
           records = (Int32)cmd.ExecuteScalar();

       }
       catch
       {
           return -1;
       }
       return records;
   }


    /*****
    copy to class property members */
    public int ReadOneRecord(string sql, SqlConnection myConnection)
    {
        try
        {
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand(sql, myConnection);
            myReader = myCommand.ExecuteReader();
            myReader.Read();

            id = (int)myReader[0];
            cardType = (int)myReader[1];
            dateSent = (string)myReader[2];
            dateReceived = (string)myReader[3];
            myReader.Close();

        }
        catch
        {
            return -1;
        }
        return 1;
    }

       /*****
   *Fill array with cards */
   public int PopulateListboxWithCardTypes(ArrayList myList)
   {
       string sql = "SELECT * FROM CardTypes";
       string temp;
       int i = 0;

       try
       {
           using (SqlConnection conn = new SqlConnection(connectStr))
           {
               conn.Open();
               SqlDataReader myReader = null;
               SqlCommand myCommand = new SqlCommand(sql, conn);
               myReader = myCommand.ExecuteReader();
               i++;
               while (myReader.Read())
               {
                   temp = i.ToString() + "   " + myReader[1].ToString(); 
                   myList.Add(temp);
                   i++;
               }
               myReader.Close();
               conn.Close();
           }
       }
       catch
       {
           return -1;
       }
       return 1;
   }


    /*****
    write one record */
    public int WriteOneRecord()
   {
       int flag = 1;
       string sqlCommand;
       string date;
       
       if (dateReceived.Length > 0)
           date = dateReceived;
       else
           date = dateSent;
 
       sqlCommand = "UPDATE Friends SET LastContact = '" + date + 
                    "' WHERE ID = " + id.ToString();

        try
        {
            clsFriend myData = new clsFriend(connectStr);
            flag = myData.ProcessCommand(sqlCommand);
        }
        catch
        {
            return flag;
        }

        sqlCommand = "INSERT INTO CardsExchanged" +
                     " (ID,TypeOfCard, Sent, Received) VALUES (";
        sqlCommand += id + "," + cardType + ",'" + dateSent + "','" + dateReceived + "')";

       try
       {
           using (SqlConnection myConnection = new SqlConnection(connectStr))
           {
               myConnection.Open();
               using (SqlCommand myCommand = new SqlCommand(sqlCommand, myConnection))
               {
                   myCommand.ExecuteNonQuery();
               }
               myConnection.Close();
           }
       }
       catch
       {
           return -1; 
       }

       return 1;
   }

}

