
Namespace LightSwitchApplication

    Public Class InvoiceDetail

        Private Sub Product_Changed()
            UnitPrice = Product.CurrentPrice
            Quantity = 1
        End Sub

        Private Sub SubTotal_Compute(ByRef result As Decimal)
            ' Set result to the desired field value
            result = Quantity * UnitPrice
        End Sub
    End Class

End Namespace
