using CustomerInformationLibrary;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace Demo1_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            string FileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File1.xlsx");
            OleDbHelper.Connections Connection = new OleDbHelper.Connections();

            using (OleDbConnection cn = new OleDbConnection { ConnectionString = Connection.HeaderConnectionString(FileName, 0) })
            {
                using (OleDbCommand cmd = new OleDbCommand { Connection = cn })
                {
                    cn.Open();
                    cmd.CommandText = 
                        @"
                            CREATE TABLE Members
                            (
                                FirstName CHAR(255),
                                LastName CHAR(255),
                                JoinedYear INT
                            )";

                    cmd.ExecuteNonQuery();

                    cmd.Parameters.AddRange(new OleDbParameter[] {
					new OleDbParameter {ParameterName = "@FirstName", DbType = DbType.String},
					new OleDbParameter {ParameterName = "@LastName", DbType = DbType.String},
					new OleDbParameter {ParameterName = "@JoinedYear", DbType = DbType.String}
				});

                    int Result = 0;
                    Customers CustomersToAdd = new Customers();

                    foreach (Customer cust in CustomersToAdd.List)
                    {
                        Console.WriteLine(cust.ToString());   
                    }

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();



                    cmd.CommandText = @"
                        INSERT INTO Members
                        (
                            FirstName,
                            LastName,
                            JoinedYear
                        )
                        VALUES
                        (
                            @FirstName,
                            @LastName,
                            @JoinedYear
                        )
                    ";

                    foreach (var cust in CustomersToAdd.List)
                    {
                        cmd.Parameters["@FirstName"].Value = cust.FirstName;
                        cmd.Parameters["@LastName"].Value = cust.LastName;
                        cmd.Parameters["@JoinedYear"].Value = cust.JoinedYear;

                        Result = cmd.ExecuteNonQuery();
                        if (Result != 1)
                        {
                            sb.AppendLine("Insert failed");
                        }
                        else
                        {
                            sb.AppendLine("Success");
                        }
                    }

                    TextBox1.Text = sb.ToString();
                    TextBox1.Select(0, 0);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CopyFileToDebugFolder();
        }

        private void CopyFileToDebugFolder()
        {
            try
            {
                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files\\File1.xlsx"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File1.xlsx"), true);
            }
            catch (Exception ex)
            {
                //
                // Drop here if the file is open via Excel or code. We could create a loop and
                // keep retrying which I have done but here let's keep it simple.
                //
                if (ex.Message.Contains("cannot access"))
                {
                    MessageBox.Show("I believe someone has the file open because I can not open" + Environment.NewLine + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File1.xlsx"));
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}