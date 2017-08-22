using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OleDb;


class frmAddNewCardType : Form
{
    private frmMain mdiParent;
    private string serverName;
    private string databaseName;

    Int32 records;
    private string connectStr;
   clsCardTypes myCardTypes;


    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtCardDescription;
    private System.Windows.Forms.Button btnSave;
    private Button btnClear;
    private System.Windows.Forms.Button btnClose;

    #region Windows Form Designer generated code
    private void InitializeComponent()
    {
            this.label1 = new System.Windows.Forms.Label();
            this.txtCardDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Card Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCardDescription
            // 
            this.txtCardDescription.Location = new System.Drawing.Point(208, 32);
            this.txtCardDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCardDescription.Name = "txtCardDescription";
            this.txtCardDescription.Size = new System.Drawing.Size(389, 22);
            this.txtCardDescription.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 98);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(443, 98);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(233, 98);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(156, 28);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "C&lear Type";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmAddNewCardType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 215);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCardDescription);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAddNewCardType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Card Type";
            this.Load += new System.EventHandler(this.frmAddNewCardType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


    public frmAddNewCardType(frmMain me)
    {
        InitializeComponent();
        this.mdiParent = me;
        serverName = me.getServerName;
        databaseName = me.getDatabaseName;
        connectStr = me.getConnectString;

        myCardTypes = new clsCardTypes(connectStr);

        try
        {
            records = myCardTypes.GetCardTypesCount();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
        

   }

    private void frmAddNewCardType_Load(object sender, EventArgs e)
    {

    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }


    // save new card type
    private void btnSave_Click(object sender, EventArgs e)
    {
        string sqlCommand;

        myCardTypes = new clsCardTypes(connectStr);

        records++;

        SqlConnection myConnection = new SqlConnection(connectStr);
        try
        {
            myConnection.Open();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error openning database: " + ex.Message);
            return;
        }

        sqlCommand = "INSERT INTO CardTypes" + " (CardType,Description) VALUES ('";

        sqlCommand += records.ToString() + "','" + txtCardDescription.Text + "')";

        try
        {
            SqlCommand myCommand = new SqlCommand(sqlCommand, myConnection);
            myCommand.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            MessageBox.Show("Failed to add data, Error: " + ex.Message);
            return;
        }

        try
        {
            myConnection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Failed to close database, Error: " + ex.Message);
            return;
        }
        MessageBox.Show("Card type added to database");

    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        txtCardDescription.Text = "";
        txtCardDescription.Focus();
    }
}

