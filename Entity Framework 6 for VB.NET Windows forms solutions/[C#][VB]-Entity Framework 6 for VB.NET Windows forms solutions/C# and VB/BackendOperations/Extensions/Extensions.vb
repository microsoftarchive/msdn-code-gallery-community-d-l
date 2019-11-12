Public Module Extensions
    ''' <summary>
    ''' Maps CustomerDTO to Customer
    ''' </summary>
    ''' <param name="CustomerDto"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' For complex mapping, our team uses AutoMapper which
    ''' is a complete overkill for here.
    ''' </remarks>
    <Runtime.CompilerServices.Extension()>
    Public Function ToCustomer(ByVal CustomerDto As CustomerDTO) As Customer
        Dim Customer As New Customer With
                {
                    .id = CustomerDto.id,
                    .FirstName = CustomerDto.FirstName,
                    .LastName = CustomerDto.LastName,
                    .Address = CustomerDto.Address,
                    .City = CustomerDto.City,
                    .State = CustomerDto.State,
                    .ZipCode = CustomerDto.ZipCode
                }

        Return Customer

    End Function
    <Runtime.CompilerServices.Extension()>
    Public Function ToCustomerDTO(ByVal Customer As Customer) As CustomerDTO
        Dim CustomerDto As New CustomerDTO With
            {
                .id = Customer.id,
                .FirstName = Customer.FirstName,
                .LastName = Customer.LastName,
                .Address = Customer.Address,
                .City = Customer.City,
                .State = Customer.State,
                .ZipCode = Customer.ZipCode
            }

        Return CustomerDto

    End Function

    ''' <summary>
    ''' Used to filter data via a generic object using lambda
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="list"></param>
    ''' <param name="filterParam"></param>
    ''' <returns></returns>
    <Runtime.CompilerServices.Extension>
    Public Function Filter(Of T)(ByVal list As IEnumerable(Of T), ByVal filterParam As Func(Of T, Boolean)) As IEnumerable(Of T)
        Return list.Where(filterParam)
    End Function
    ''' <summary>
    ''' Converts string value to a member of an Enum
    ''' </summary>
    ''' <typeparam name="T">Valid Enum structure</typeparam>
    ''' <param name="sender">String to convert</param>
    ''' <returns>A member of the enum</returns>
    ''' <example>
    ''' <code source="CodeExamples\EnumExamples.vb" language="vbnet" title="VB.NET Examples"/>
    ''' </example>
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEnum(Of T)(ByVal sender As String) As T
        Dim senderType As Type = GetType(T)

        If System.Enum.IsDefined(GetType(T), sender) Then
            Return CType(System.Enum.Parse(senderType, sender, True), T)
        Else
            Dim baseType As String = senderType.ToString()
            Dim position As Integer = baseType.IndexOf("+"c)
            Dim errorMessage As String = ""

            If position > -1 Then
                Dim EnumName As String = baseType.Substring(position + 1)
                errorMessage = String.Format("'{0}' not a member of '{1}'", sender, EnumName)
            Else
                errorMessage = String.Format("{0} not a member of {1}", sender, senderType)
            End If

            Throw New Exception(errorMessage)

        End If
    End Function

End Module
