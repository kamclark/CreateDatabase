using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

class clsFriend
{
    private int recordsInFriends;
    private int id;
    private string firstName;
    private string lastName;
    private string addr1;
    private string addr2;
    private string city;
    private string state;
    private string zip;
    private string lastContact;
    private int status;

    private string connectString;

    //============================== Constructor ==============================
    public clsFriend()
    {
        firstName = "";             // strings are empty not null value
        lastName = "";
        addr1 = "";
        addr2 = "";
        city = "";
        state = "";
        zip = "";
        lastContact = DateTime.Now.ToString(); // today is default time
    }

    public clsFriend(string conn) : this()
    {
        connectString = conn;
    }
    

    //============================ Property Methods ============================

    public int ID
    {
        get
        {
            return id;
        }
        set
        {
            if (value > 0)
                id = value; 
        }
    }

    public string FirstName
    { 
        get
        {
            return firstName;
        }
        set
        {
            if (value.Length > 0)
                firstName = value; 
        }
    }

    public string LastName
    {
        get
        {
            return lastName;
        }
        set
        {
            if (value.Length > 0)
                lastName = value;
        }
    }

    public string Address1
    {
        get
        {
            return addr1;
        }
        set
        {
            if (value.Length > 0)
                addr1 = value;
        }
    }

    public string Address2
    {
        get
        {
            return addr2;
        }
        set
        {
            if (value.Length > 0)
                addr2 = value;
        }
    }

    public string City
    {
        get
        {
            return city;
        }
        set
        {
            if (value.Length > 0)
                city = value;
        }
    }

    public string State
    {
        get
        {
            return state;
        }
        set
        {
            if (value.Length > 0)
                state = value;
        }
    }

    public string Zip
    {
        get
        {
            return zip;
        }
        set
        {
            if (value.Length > 0)
                zip = value;
        }
    }

    public string LastContact
    {
        get
        {
            return lastContact;
        }
        set
        {
            if (value != null)
                lastContact = value;
        }
    }

    public int Status
    {
        get
        {
            return status;
        }
        set
        {
            status = value;
        }
    }

   
   public int CountOfFriendRecords
    {
        get
        {
            return recordsInFriends;
        }
        set
        {
            recordsInFriends = value;
        }
    }


    // copy Friends data to class property members
   public int ReadOneRecord(string sql, string connectStr)
    {
        try
        {
            SqlConnection myConnection = new SqlConnection(connectStr);           // Open connection
            try
            {
                myConnection.Open();
            }
            catch
            {

                return -1;
            }

            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand(sql, myConnection);
            myReader = myCommand.ExecuteReader();
            myReader.Read();

            id = (int)myReader[0];
            firstName = (string)myReader[1];
            lastName = (string)myReader[2];
            addr1 = (string)myReader[3];
            addr2 = (string)myReader[4];
            city = (string)myReader[5];
            state = (string)myReader[6];
            zip = (string)myReader[7];
            lastContact = (string)myReader[8];
            status = (int)myReader[9];

            myReader.Close();
        }
        catch
        {
            return -2;
        }
        return 1;
    }

    // get number of friends in friends table
    public Int32 RecordCount(string connectStr)
    {   
        try
        {
            SqlConnection conn = new SqlConnection(connectStr);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(LastName) FROM Friends", conn);
            recordsInFriends = (Int32)cmd.ExecuteScalar();

        } catch
        {
            return -1;
        }
        return recordsInFriends;
    }

    // update array with friends data
    public int PopulatListWithFriend(ArrayList friends, string connectStr)
    {
        string sql = "SELECT * FROM Friends";
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
                    temp = myReader[2].ToString();
                    friends.Add(temp);
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

    // process sql command
    public int ProcessCommand(string sqlCommand)
    {
        int flag = 1;

        try
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(sqlCommand, conn);
                flag = command.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch
        {
            flag = 0;
        }

        return flag;
    }
}
