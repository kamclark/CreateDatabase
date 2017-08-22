using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections;


public class frmCardExchange : Form
{

    ArrayList myList = new ArrayList();

    Int32 countOfFriends;
    Int32 countOfCardTypes;
    Int32 countOfExchanges;

    private frmMain mdiParent;
    private string serverName;
    private string databaseName;
 

    clsCardsExchanged myExchange;
    clsFriend myData;
    clsCardTypes myTypes;

    private string connectStr;
    private TextBox txtDateSent;
    private Label label9;
    private TextBox txtDateReceived;
    private Label label11;
    private ComboBox cmbList;
    private Label label10;


    #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFindRecord = new System.Windows.Forms.Button();
            this.txtFindRecordNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.txtLastContact = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddr2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddr1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtDateSent = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDateReceived = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbList = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(556, 405);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 28);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(256, 175);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(141, 28);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear &Fields";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(556, 313);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 28);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFindRecord
            // 
            this.btnFindRecord.Location = new System.Drawing.Point(556, 11);
            this.btnFindRecord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFindRecord.Name = "btnFindRecord";
            this.btnFindRecord.Size = new System.Drawing.Size(141, 28);
            this.btnFindRecord.TabIndex = 19;
            this.btnFindRecord.Text = "&Find Friend";
            this.btnFindRecord.UseVisualStyleBackColor = true;
            this.btnFindRecord.Click += new System.EventHandler(this.btnFindRecord_Click);
            // 
            // txtFindRecordNumber
            // 
            this.txtFindRecordNumber.Location = new System.Drawing.Point(153, 15);
            this.txtFindRecordNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFindRecordNumber.Name = "txtFindRecordNumber";
            this.txtFindRecordNumber.Size = new System.Drawing.Size(132, 22);
            this.txtFindRecordNumber.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Record to find:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkStatus);
            this.groupBox1.Controls.Add(this.txtLastContact);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtZip);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtState);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.txtCity);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAddr2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAddr1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Location = new System.Drawing.Point(15, 70);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(683, 235);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Information:";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Checked = true;
            this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatus.Location = new System.Drawing.Point(587, 133);
            this.chkStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(68, 21);
            this.chkStatus.TabIndex = 28;
            this.chkStatus.Text = "Active";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // txtLastContact
            // 
            this.txtLastContact.Location = new System.Drawing.Point(120, 126);
            this.txtLastContact.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLastContact.Name = "txtLastContact";
            this.txtLastContact.Size = new System.Drawing.Size(109, 22);
            this.txtLastContact.TabIndex = 25;
            this.txtLastContact.Text = "1/28/1990";
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Location = new System.Drawing.Point(8, 126);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 25);
            this.label13.TabIndex = 24;
            this.label13.Text = "Last Contact:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(453, 102);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Zip Code:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(551, 101);
            this.txtZip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(109, 22);
            this.txtZip.TabIndex = 14;
            this.txtZip.Text = "12345";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(349, 101);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "State:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(408, 101);
            this.txtState.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(41, 22);
            this.txtState.TabIndex = 12;
            this.txtState.Text = "IL";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(8, 101);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "City:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(120, 101);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(225, 22);
            this.txtCity.TabIndex = 10;
            this.txtCity.Text = "Springfield";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(8, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Address2:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddr2
            // 
            this.txtAddr2.Location = new System.Drawing.Point(120, 75);
            this.txtAddr2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddr2.Name = "txtAddr2";
            this.txtAddr2.Size = new System.Drawing.Size(540, 22);
            this.txtAddr2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(8, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Address1:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddr1
            // 
            this.txtAddr1.Location = new System.Drawing.Point(120, 49);
            this.txtAddr1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddr1.Name = "txtAddr1";
            this.txtAddr1.Size = new System.Drawing.Size(540, 22);
            this.txtAddr1.TabIndex = 6;
            this.txtAddr1.Text = "123 Fake Street";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(256, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Last Name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(359, 22);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(301, 22);
            this.txtLastName.TabIndex = 4;
            this.txtLastName.Text = "Clark";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(120, 23);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(132, 22);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Text = "Kamari";
            // 
            // txtDateSent
            // 
            this.txtDateSent.Location = new System.Drawing.Point(392, 313);
            this.txtDateSent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDateSent.Name = "txtDateSent";
            this.txtDateSent.Size = new System.Drawing.Size(132, 22);
            this.txtDateSent.TabIndex = 24;
            this.txtDateSent.Text = "12/25/2016";
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(249, 311);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 25);
            this.label9.TabIndex = 23;
            this.label9.Text = "Date Sent:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDateReceived
            // 
            this.txtDateReceived.Location = new System.Drawing.Point(392, 345);
            this.txtDateReceived.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDateReceived.Name = "txtDateReceived";
            this.txtDateReceived.Size = new System.Drawing.Size(131, 22);
            this.txtDateReceived.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(249, 345);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 25);
            this.label10.TabIndex = 25;
            this.label10.Text = "Date Received:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(16, 313);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(229, 25);
            this.label11.TabIndex = 28;
            this.label11.Text = "Card Types:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbList
            // 
            this.cmbList.FormattingEnabled = true;
            this.cmbList.Location = new System.Drawing.Point(16, 341);
            this.cmbList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbList.Name = "cmbList";
            this.cmbList.Size = new System.Drawing.Size(228, 24);
            this.cmbList.TabIndex = 31;
            // 
            // frmCardExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 447);
            this.Controls.Add(this.cmbList);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDateReceived);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDateSent);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFindRecord);
            this.Controls.Add(this.txtFindRecordNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmCardExchange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exchange Card";
            this.Load += new System.EventHandler(this.frmCardExchange_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnFindRecord;
    private System.Windows.Forms.TextBox txtFindRecordNumber;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox chkStatus;
    private System.Windows.Forms.TextBox txtLastContact;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtZip;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtState;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtCity;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtAddr2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtAddr1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtLastName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtFirstName;
    
    //=============================== Constructors =============================
    public frmCardExchange()
    {
        InitializeComponent();
   }
    public frmCardExchange(frmMain me) : this()
    {
 
        this.mdiParent = me;
        serverName = me.getServerName;
        databaseName = me.getDatabaseName;
        connectStr = me.getConnectString;

        myData = new clsFriend();                        // num of friends in DB
        countOfFriends = myData.RecordCount(connectStr);


        myExchange = new clsCardsExchanged(connectStr);         
        countOfExchanges = myExchange.RecordCount(connectStr);

        myTypes = new clsCardTypes(connectStr);                
        countOfCardTypes = myTypes.GetCardTypesCount();
 
        myExchange.PopulateListboxWithCardTypes(myList);
        for (int i = 0; i < myList.Count; i++)
        {
            cmbList.Items.Add(myList[i]);
        }
        cmbList.SelectedIndex = 0;
        txtFindRecordNumber.Focus();
 
    }

    private void frmCardExchange_Load(object sender, EventArgs e)
    {
    }

    // find a friend receord
    private void btnFindRecord_Click(object sender, EventArgs e)
    {
        int retValue;
        string sql;

        myData = new clsFriend();
        if (txtLastName.Text.Length == 0)
            sql = "SELECT * FROM Friends WHERE ID = " + txtFindRecordNumber.Text;           // searching by ID
        else
            sql = "SELECT * FROM Friends WHERE LastName = '" + txtLastName.Text + "'";      // searching by name

        myData = new clsFriend();
        retValue = myData.ReadOneRecord(sql, connectStr);
        if (retValue > 0)
            ShowOneRecord();
        else
            MessageBox.Show("Could not read friend record");
    }

    #region Reading-Displaying data

    /*****
     * Purpose: Move the record data into the textboxes
     * 
     * Parameter list:
     *  n/a
     *  
     * Return value:
     *  void
     ******/
    private void ShowOneRecord()
    {
        txtFindRecordNumber.Text = myData.ID.ToString();
        txtFirstName.Text = myData.FirstName;
        txtLastName.Text = myData.LastName;
        txtAddr1.Text = myData.Address1;
        txtAddr2.Text = myData.Address2;
        txtCity.Text = myData.City;
        txtState.Text = myData.State;
        txtZip.Text = myData.Zip;
        txtLastContact.Text = myData.LastContact;
        int status = myData.Status;
        if (status == 1)
            chkStatus.Checked = true;
        else
            chkStatus.Checked = false;

    }

    /*****
     * Purpose: Copies data from textboxes to class members.
     * 
     * Parameter list:
     *  n/a
     *  
     * Return value:
     *  void
     ******/

    private void CopyData()
    {
        int rec;
        bool flag = int.TryParse(txtFindRecordNumber.Text, out rec);

        myExchange = new clsCardsExchanged(connectStr);         // Number of cards in DB

        if (flag == false)
        {
            MessageBox.Show("Must have integer value for record number.");
            return;
        }
        myExchange.ID = rec;                    // Who is the card tied to?

        myExchange.CardType = cmbList.SelectedIndex;       // What type of card?

        if (txtDateReceived.Text.Length != 0)
        {
            myExchange.CardReceived = txtDateReceived.Text;
            myExchange.CardSent = "";
       }
        else
        {
            myExchange.CardSent = txtDateSent.Text;
            myExchange.CardReceived = "";
        }
        
    }



    private void ClearFields()
    {
        txtFindRecordNumber.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtAddr1.Text = "";
        txtAddr2.Text = "";
        txtCity.Text = "";
        txtState.Text = "";
        txtZip.Text = "";
        txtLastContact.Text = "";

        txtDateReceived.Text = "";
        txtDateSent.Text = "";

        txtLastName.Focus();
    }
    #endregion

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    // Save card exchange
    private void btnSave_Click(object sender, EventArgs e)
    {
        int flag;

        CopyData();             // Move data into class
        flag = myExchange.WriteOneRecord();
        switch (flag)
        {
            case 1:
                MessageBox.Show("Data written to database");
                break;
            case 2:
                MessageBox.Show("Error writting data to database");
                break;
            case 3:
                MessageBox.Show("Error closing database");
                break;
            default:
                MessageBox.Show("Unknown error");
                break;
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
    }

}

