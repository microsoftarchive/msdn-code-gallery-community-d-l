Imports System.Text
Public Class DataAccess

    Private Builder As New OleDb.OleDbConnectionStringBuilder With
        {
            .Provider = "Microsoft.ACE.OLEDB.12.0",
            .DataSource = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")
        }
    Public Sub New()

        mAllCustomersDataTable = New DataTable
        mDuplicatesCustomersDataTableFromDatabase = New DataTable
        GetAllRows()
        GetOnlyDuplicatesFromDatabase()

    End Sub

    Private mAllCustomersDataTable As DataTable
    Public ReadOnly Property AllCustomersDataDataTable As DataTable
        Get
            Return mAllCustomersDataTable
        End Get
    End Property
    ''' <summary>
    ''' Get all rows including duplicates
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetAllRows()
        Using cn As New OleDb.OleDbConnection With
                {
                    .ConnectionString = Builder.ConnectionString
                }

            Using cmd As New OleDb.OleDbCommand With {.Connection = cn}

                cmd.CommandText =
                    <SQL>
                        SELECT Identifier, 
                            CompanyName, 
                            ContactName, 
                            ContactTitle, 
                            Address, 
                            City, 
                            PostalCode
                        FROM Customers;

                    </SQL>.Value

                cn.Open()
                mAllCustomersDataTable.Load(cmd.ExecuteReader)

            End Using
        End Using
    End Sub
    Private mDuplicatesCustomersDataTableFromDatabase As DataTable
    Public ReadOnly Property DuplicatesDataDataTable As DataTable
        Get
            Return mDuplicatesCustomersDataTableFromDatabase
        End Get
    End Property
    ''' <summary>
    ''' Get only duplicates
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetOnlyDuplicatesFromDatabase()
        Using cn As New OleDb.OleDbConnection With
                {
                    .ConnectionString = Builder.ConnectionString
                }


            Using cmd As New OleDb.OleDbCommand With {.Connection = cn}

                cmd.CommandText =
                    <SQL>
                    SELECT A.*
                    FROM Customers A
                    INNER JOIN
                        (
                        SELECT 
                            CompanyName,
                            ContactName,
                            ContactTitle,
                            Address,
                            City,
                            PostalCode
                        FROM 
                            Customers
                        GROUP BY 
                            CompanyName,
                            ContactName,
                            ContactTitle,
                            Address,City,
                            PostalCode
                        HAVING COUNT(*) > 1
                        ) B
                    ON
                    A.CompanyName = B.CompanyName AND
                    A.ContactName = B.ContactName AND
                    A.ContactTitle = B.ContactTitle AND
                    A.Address = B.Address AND
                    A.City = B.City AND
                    A.PostalCode = B.PostalCode
                    ORDER BY 
                        A.CompanyName
                    </SQL>.Value

                cn.Open()

                mDuplicatesCustomersDataTableFromDatabase.Load(cmd.ExecuteReader)

            End Using
        End Using
    End Sub
    ''' <summary>
    ''' When you want to add a new record to a database table and want to not allow
    ''' duplicate records generally you would first collect data from the user perhaps
    ''' in a add dialog, validate each field has data according to business rules then
    ''' see if the record exists. In this code I am fully bypassing business rules i.e.
    ''' a field can not be empty etc.
    ''' 
    ''' So here one set of data exists while the other does not. A property in the class
    ''' Customer Exist will be set via cmd.ExecuteScalar, if there are matches (in this case
    ''' one and should not be more) ExecuteScalar will return a value greater than zero
    ''' which equates to True while if the data was not found to be a duplicate Exist
    ''' property is set to false.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' 
    ''' </remarks>
    Public Function DoesRowExistsTest() As IList(Of Customer)

        Dim Customers As New List(Of Customer) From
            {
                New Customer With
                    {
                        .CompanyName = "Bon app",
                        .ContactName = "Laurence Lebihan",
                        .ContactTitle = "Owner",
                        .Address = "C/ Araquil, 67",
                        .City = "Madrid", .PostalCode = "28023"
                    },
                New Customer With
                    {
                        .CompanyName = "ABC Wrenches",
                        .ContactName = "Laurence Lebihan",
                        .ContactTitle = "Owner",
                        .Address = "123 Gran Via",
                        .City = "Madrid",
                        .PostalCode = "28023"
                    }
            }

        For Each Customer In Customers
            DoesRowExists(Customer)
        Next

        Return Customers

    End Function
    Public Sub DoesRowExists(ByVal customer As Customer)

        Using cn As New OleDb.OleDbConnection With
                {
                    .ConnectionString = Builder.ConnectionString
                }

            Using cmd As New OleDb.OleDbCommand With {.Connection = cn}

                cmd.CommandText =
                    <SQL>
                    SELECT COUNT(Identifier) 
                    FROM Customers
                    WHERE 
                        CompanyName=@CompanyName AND
                        ContactName=@ContactName AND
                        ContactTitle=@ContactTitle AND
                        Address=@Address AND
                        City=@City AND
                        PostalCode=@PostalCode
                    </SQL>.Value

                cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName)
                cmd.Parameters.AddWithValue("@ContactName", customer.ContactName)
                cmd.Parameters.AddWithValue("@ContactTitle", customer.ContactTitle)
                cmd.Parameters.AddWithValue("@Address", customer.Address)
                cmd.Parameters.AddWithValue("@City", customer.City)
                cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode)

                cn.Open()
                customer.Exists = CInt(cmd.ExecuteScalar) > 0


            End Using
        End Using

    End Sub

End Class
