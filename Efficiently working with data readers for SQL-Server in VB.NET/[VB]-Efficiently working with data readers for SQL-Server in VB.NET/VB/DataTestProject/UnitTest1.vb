Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports DatabackEndLibrary


<TestClass()> Public Class UnitTest1
    <TestMethod> Public Sub ReadCustomerView()

        Dim expectedRowCount As Integer = 5000

        Dim ops As New DataOperations
        Dim dt As DataTable = ops.CustomerView

        Assert.IsTrue(dt.Rows.Count > 0,
                      $"Expected {expectedRowCount} rows")

    End Sub
    ''' <summary>
    ''' Make sure our get categories works as expected
    ''' </summary>
    <TestMethod()> Public Sub GetListOfCategories()

        Dim expectedCount As Integer = 16
        Dim ops As New DataOperations

        Dim results As List(Of Category) = ops.GetCategories

        Dim possibleMessage As String =
            If(ops.LastException IsNot Nothing, ops.LastException.Message, "")

        Assert.IsTrue(ops.IsSuccessFul,
                      $"Operation throw an exception: {possibleMessage}")

        Assert.IsTrue(results.Count = expectedCount,
                      $"Expected {expectedCount} category rows.")

    End Sub
    ''' <summary>
    ''' Test returning reference tables using NextResult off the 
    ''' data reader.
    ''' </summary>
    <TestMethod> Public Sub GetReferenceTables()
        Dim ops As New DataOperations
        Dim results = ops.GetReferenceTables

        Assert.IsTrue(results.Catagories.Count = 16,
                      "Expected 16 categories")

        Assert.IsTrue(results.Products.Count = 77,
                      "Expected 77 products")

    End Sub
    <TestMethod> Public Sub GetStates()

        Dim expectedCount As Integer = 50
        Dim ops As New DataOperations

        Dim count As Integer = ops.GetStates.Count

        Assert.IsTrue(count = expectedCount,
                      $"Expected {expectedCount} states")

    End Sub
    ''' <summary>
    ''' Bad test and bad code flow in GetCustomers1
    ''' </summary>
    <TestMethod> Public Sub GetSingleCustomerWhichPassesWithThrownException()

        Dim ops As New DataOperations
        Dim customer = ops.GetCustomerDoneWrong(3)

        Assert.IsTrue(customer IsNot Nothing,
                      "Expected customer to be null")

    End Sub
    ''' <summary>
    ''' This test passes because the method TypicalGetCustomers
    ''' throw an exception. There is no assertion for null values
    ''' when obtaining data.
    ''' </summary>
    <TestMethod> Public Sub TryGetAllCustomersButWillFail()
        Dim errorMsg As String =
            "Data is Null. This method or property " &
            "cannot be called on Null values."

        Dim ops As New DataOperations
        Dim custList As List(Of Customer) = ops.TypicalGetCustomersWithNullsUnChecked

        Assert.IsTrue(custList.Count < 5000,
                      "Expected less than 5000 records")

        Assert.IsTrue(ops.LastException.Message = errorMsg,
                      "Unexpected exception message")
    End Sub
    <TestMethod> Public Sub GetAllCustomersWithNullChecks()
        Dim ops As New DataOperations
        Dim custList As List(Of Customer) = ops.TypicalGetCustomersWithNullsChecks

        Assert.IsTrue(custList.Count = 5000,
                      "Expected 5000 records")

    End Sub
    ''' <summary>
    ''' For the record we fetch, there are several null values
    ''' where as coded we can check for the data having no value
    ''' </summary>
    <TestMethod> Public Sub GetSingleCustomerWithValidDataAndNullData()

        Dim ops As New DataOperations
        Dim customer = ops.GetCustomerWithNullCheckes(3)

        Assert.IsTrue(customer.JoinDate = DateTime.MinValue,
                      "Expected JoinDate to be MinValue")

    End Sub
    ''' <summary>
    ''' Vaidate language extension method for double functions properly
    ''' and returns a value we supplied
    ''' </summary>
    <TestMethod> Public Sub GetSingleCustomerWithBuilderVerifyBalanceIsNegative()

        Dim ops As New DataOperations
        Dim customer = ops.GetCustomerWithNullCheckesWithAlternateBuilder(45)

        Assert.IsTrue(customer.Balance = -1,
                      "Expected -1 balance")

    End Sub
    ''' <summary>
    ''' Vaidate language extension method for DateTime functions properly
    ''' and returns a value we supplied
    ''' </summary>
    <TestMethod> Public Sub GetSingleCustomerWithBuilderAndVerifyNullDateIsToday()

        Dim ops As New DataOperations
        Dim customer = ops.GetCustomerWithNullCheckesWithAlternateBuilder(7)

        Assert.IsTrue(customer.JoinDate.Date = Now.Date,
                      "Expected JoinDate.Date to be Now.Date")

    End Sub
    ''' <summary>
    ''' Valid we could read the customer pin
    ''' </summary>
    <TestMethod> Public Sub GetSingleCustomerCheckPinValue()

        Dim pin As Integer = 269008

        Dim ops As New DataOperations
        Dim customer = ops.GetCustomerWithNullCheckes(4987)

        Assert.IsTrue(customer.Pin = pin,
                      $"Expected pin to be {pin}")

    End Sub
    ''' <summary>
    ''' Validate language exensions worked for null strings
    ''' </summary>
    <TestMethod> Public Sub GetSingleCustomerWithNullStringValues()
        Dim ops As New DataOperations
        Dim customer = ops.GetCustomerWithNullCheckesWithAlternateBuilder(806)

        Assert.IsTrue(customer.FirstName Is Nothing,
                      "Expected first name to be null")

        Assert.IsTrue(customer.LastName Is Nothing,
                      "Expected last name to be null")

        Assert.IsTrue(customer.Address Is Nothing,
                      "Expected address to be null")

    End Sub
    ''' <summary>
    ''' Validate the language extension for int works as we assign
    ''' a default value of 999 when Pin is null
    ''' </summary>
    <TestMethod> Public Sub GetSingleCustomerNullPin()

        Dim pin As Integer = 999
        Dim ops As New DataOperations
        Dim customer = ops.GetCustomerWithNullCheckesWithAlternateBuilder(859)

        Assert.IsTrue(customer.Pin = pin,
                      $"Expected Pin to be {pin}")

    End Sub
    ''' <summary>
    ''' Determine we are properly handling passing in an
    ''' invalid catalog
    ''' </summary>
    <TestMethod> Public Sub BadConnection()

        Dim ops As New DataOperations
        ops.SetConnectionString("KARENS-PC", "NonExistingCatalog")
        Dim results As List(Of Category) = ops.GetCategories

        Assert.IsFalse(Not ops.IsSuccessFul,
                       "Expected failure with non existing catalog")

    End Sub

End Class