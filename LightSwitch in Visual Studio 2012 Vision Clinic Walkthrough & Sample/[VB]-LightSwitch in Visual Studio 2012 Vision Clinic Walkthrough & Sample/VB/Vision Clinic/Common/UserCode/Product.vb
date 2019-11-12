
Namespace LightSwitchApplication

    Public Class Product

        Private Sub CurrentPrice_Compute(ByRef result As Decimal)
            ' Set result to the desired field value
            Dim rebates As Decimal
            For Each item In ProductRebates
                If item.RebateStart <= Date.Today And item.RebateEnd >= Date.Today Then
                    rebates = rebates + If(item.Rebate, 0)
                End If
            Next

            result = Me.MSRP - rebates
        End Sub
    End Class

End Namespace
