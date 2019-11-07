
Namespace LightSwitchApplication

    Public Class Invoice

        Private Sub Invoice_Created()
            InvoiceDate = Date.Today
            InvoiceDue = Date.Today.AddDays(30)
            ShipDate = Date.Today.AddDays(3)
        End Sub

        Private Sub InvoiceDate_Changed()
            InvoiceDue = InvoiceDate.AddDays(30)
            ' If the ShipDate is earlier than the new InvoiceDate, update it.
            If ShipDate < InvoiceDate Then
                ShipDate = InvoiceDate.AddDays(2)
            End If
        End Sub

        Private Sub Tax_Compute(ByRef result As Decimal)
            Result = GetSubTotal() * 0.095
        End Sub
        Protected Function GetSubTotal() As Decimal
            GetSubtotal = 0
            For Each item In InvoiceDetails
                GetSubTotal = GetSubTotal + item.SubTotal
            Next
        End Function

        Private Sub Total_Compute(ByRef result As Decimal)
            ' Set result to the desired field value
            result = GetSubTotal() + Tax
        End Sub
    End Class

End Namespace
