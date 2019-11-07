Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Public Class Operations
    ''' <summary>
    ''' Used to assist with filtering strings
    ''' </summary>
    Public Enum FilterOptions
        StartsWith
        Contains
        EndsWith
        Equals
    End Enum
    Public Enum ColumnFilterName
        FirstName
        LastName
    End Enum
    Public Function CustomerIdentifierList() As List(Of CustNameIdItem)
        Using entity As New DataEntities

            Return entity.Customers.Select(Function(cust) New CustNameIdItem With
                {
                    .Name = String.Concat(cust.FirstName, ", ", cust.LastName),
                    .LastName = cust.LastName,
                    .Id = cust.id.ToString
                }
            ).OrderBy(Function(cust) cust.LastName).ToList

        End Using
    End Function

    ''' <summary>
    ''' Load Customers, no Orders attached as we are using a 
    ''' DTO (Data Transfer Object) commonly used in web development.
    ''' </summary>
    ''' <returns></returns>
    Public Function LoadCustomersDTO() As List(Of CustomerDTO)
        Using entity As New DataEntities

            Dim ListOfCustomersDTO = entity.Customers.Select(Function(cust) _
                New CustomerDTO With
                {
                    .id = cust.id,
                    .FirstName = cust.FirstName,
                    .LastName = cust.LastName,
                    .Address = cust.Address,
                    .City = cust.City,
                    .State = cust.State,
                    .ZipCode = cust.ZipCode
                }
            ).ToList

            Return ListOfCustomersDTO

        End Using
    End Function
    ''' <summary>
    ''' See if Customer exist, if not return false, if exists
    ''' then update it.
    ''' </summary>
    ''' <param name="CustomerDto"></param>
    Public Sub UpdateCustomer(ByVal CustomerDto As CustomerDTO)

        Try

            Using entity As New DataEntities
                entity.Entry(CustomerDto.ToCustomer).State = EntityState.Modified
                entity.SaveChanges()
            End Using

        Catch ex As DbUpdateConcurrencyException
            ' handle Optimistic Concurrency exception
        End Try

    End Sub
    ''' <summary>
    ''' Add a new customer, return the new primary key
    ''' </summary>
    ''' <param name="CustomerDto"></param>
    ''' <returns></returns>
    Public Function AddCustomer(ByVal CustomerDto As CustomerDTO) As Integer
        Using entity As New DataEntities

            Dim Customer As Customer = CustomerDto.ToCustomer
            entity.Entry(Customer).State = EntityState.Added

            '
            ' The save will bring back the new primary key
            '
            entity.SaveChanges()
            '
            ' After saving the new primary key is contained in Customer
            ' The caller in this case creates a new record in the DataGridView
            ' DataSource, a BindingSource.
            Return Customer.id

        End Using
    End Function
    Public Sub RemoveCustomer(ByVal CustomerDto As CustomerDTO)

        Using entity As New DataEntities
            entity.Entry(CustomerDto.ToCustomer).State = EntityState.Deleted
            entity.SaveChanges()
        End Using

    End Sub

#Region "For use in First and Second attempt projects for demoing only"

    ''' <summary>
    ''' By default when there are relations to the table we want data from
    ''' they are also loaded. Place a break-point on the Console.WriteLine()
    ''' when hit examine results, note each Customer has the relation (navigation)
    ''' Orders attached.
    ''' 
    ''' Lazy loading does not help with displaying in a DataGridView
    ''' </summary>
    Public Sub LoadCustomersWithOrdersDemo()
        Using entity As New DataEntities
            Dim results = entity.Customers.ToList
            Console.WriteLine("Put break point here and examine results")
        End Using
    End Sub
    ''' <summary>
    ''' Same code as above except indicate we don't want
    ''' the relations to be attached to our Customers.
    ''' Place a break-point on the Console.WriteLine() when hit examine results,
    ''' note that the relations are not attached. But they sure are, not good
    ''' for displaying in a DataGridView unless you hide the column Order in this
    ''' case which is ICollection and will blow up when attempting to access it.
    ''' 
    ''' Lazy loading does not help with displaying in a DataGridView
    ''' </summary>
    Public Sub LoadCustomersWithoutOrdersDemo()
        Using entity As New DataEntities
            entity.Configuration.ProxyCreationEnabled = False
            Dim results = entity.Customers.ToList
            Console.WriteLine("Put break point here and examine results")
        End Using
    End Sub
    ''' <summary>
    ''' Load Customers which will have Orders attached
    ''' </summary>
    ''' <returns></returns>
    Public Function LoadCustomers() As List(Of Customer)
        Using entity As New DataEntities
            Return entity.Customers.ToList
        End Using
    End Function

#End Region

    ''' <summary>
    ''' Provides a search for first name
    ''' </summary>
    ''' <param name="value">text to use for filter</param>
    ''' <param name="options">Type of search</param>
    ''' <remarks>
    ''' By default EF is case sensitive. Here we use ToLower to allow
    ''' case insensitive search but a fragile method is modifying the underlying table
    ''' https://milinaudara.wordpress.com/2015/02/04/case-sensitive-search-using-entity-framework-with-custom-annotation/
    ''' </remarks>
    Public Function NameFilter(ByVal ColumnName As String, ByVal value As String, ByVal options As String) As List(Of CustomerDTO)
        Dim DataSource As List(Of Customer) = New List(Of Customer)

        Dim ColumnNameSelection As ColumnFilterName = ColumnName.ToEnum(Of ColumnFilterName)
        Dim FilterOption As FilterOptions = options.ToEnum(Of FilterOptions)

        Using context As New DataEntities
            Select Case FilterOption
                Case FilterOptions.StartsWith
                    If ColumnNameSelection = ColumnFilterName.FirstName Then
                        DataSource = context.Customers.Filter(Function(cust) cust.FirstName.ToLower().StartsWith(value.ToLower(), StringComparison.CurrentCulture)).ToList()
                    Else
                        DataSource = context.Customers.Filter(Function(cust) cust.LastName.ToLower().StartsWith(value.ToLower(), StringComparison.CurrentCulture)).ToList()
                    End If

                Case FilterOptions.Contains
                    If ColumnNameSelection = ColumnFilterName.FirstName Then
                        DataSource = context.Customers.Filter(Function(cust) cust.FirstName.ToLower().Contains(value.ToLower())).ToList()
                    Else
                        DataSource = context.Customers.Filter(Function(cust) cust.LastName.ToLower().Contains(value.ToLower())).ToList()
                    End If

                Case FilterOptions.EndsWith
                    If ColumnNameSelection = ColumnFilterName.FirstName Then
                        DataSource = context.Customers.Filter(Function(cust) cust.FirstName.ToLower().EndsWith(value.ToLower(), StringComparison.CurrentCulture)).ToList()
                    Else
                        DataSource = context.Customers.Filter(Function(cust) cust.LastName.ToLower().EndsWith(value.ToLower(), StringComparison.CurrentCulture)).ToList()
                    End If

                Case FilterOptions.Equals
                    If ColumnNameSelection = ColumnFilterName.FirstName Then
                        DataSource = context.Customers.Filter(Function(cust) cust.FirstName.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList()
                    Else
                        DataSource = context.Customers.Filter(Function(cust) cust.LastName.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList()
                    End If

                Case Else
            End Select
        End Using

        Return DataSource.Select(Function(cust) cust.ToCustomerDTO).ToList

    End Function
End Class
