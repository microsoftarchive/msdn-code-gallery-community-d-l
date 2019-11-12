Imports BackendOperations
Imports CustomBindingListLibrary

''' <summary>
''' Helper extension methods to keep form code clean
''' </summary>
Public Module SortableBindingListExtensions

    ''' <summary>
    ''' Locate a customer by customer primary key
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="id"></param>
    ''' <returns></returns>
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function FindByCustomerIdentifier(ByVal sender As SortableBindingList(Of CustomerDTO), ByVal id As Integer) As CustomerDTO
        Return sender.Where(Function(cust) cust.id = id).FirstOrDefault
    End Function
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function FindByLastName(ByVal sender As SortableBindingList(Of CustomerDTO), ByVal LastName As String) As CustomerDTO
        Return sender.Where(Function(cust) cust.LastName = LastName).FirstOrDefault
    End Function
    ''' <summary>
    ''' Find first customer in sender
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="StateName">Exact state name to locate</param>
    ''' <returns></returns>
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function FindByState(ByVal sender As SortableBindingList(Of CustomerDTO), ByVal StateName As String) As CustomerDTO
        Return sender.Where(Function(cust) cust.State = StateName).FirstOrDefault
    End Function
    ''' <summary>
    ''' Get all customers in a specific state
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="StateName"></param>
    ''' <returns></returns>
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function FindByStateList(ByVal sender As SortableBindingList(Of CustomerDTO), ByVal StateName As String) As List(Of CustomerDTO)
        Return sender.Where(Function(cust) cust.State = StateName).ToList
    End Function
End Module
