Imports System.Collections.Generic
Imports System.Dynamic

Namespace CSharpDynamicUnitTest

    Public Module BasicDynamicSamples
        ''' <summary>
        ''' dynamic will automtically check whether the generic type supports operators such as +,-,*,/. If Not, exceptions will be thrown out.
        ''' So for dynamic, if we are sure that something has supported some methods¡­¡­ect. We'RE SURE to directly use that without any intellisenses.
        ''' And it's not an easy task to cope with a generic type with operators, because we don't know whether they have implemented these operators or not. So we have to SUPPOSE they've implemented them.
        ''' </summary>
        Public Function Add(Of T As {Structure})(ByVal num1 As T, ByVal num2 As T) As T

            Dim dnum1 As Object = num1
            Dim dnum2 As Object = num2
            Return dnum1 + dnum2
        End Function
        ''' <summary>
        ''' Dynamically attaching Properties, Events, Functions into an ExpandoObject
        ''' </summary>
        Public Function DynamicObjectCreator(ByVal propertyValuesMapping As IDictionary(Of String, Object)) As Object

            Dim dynamicObj As IDictionary(Of String, Object) = New ExpandoObject()

            For Each item As KeyValuePair(Of String, Object) In propertyValuesMapping
                dynamicObj(item.Key) = item.Value
            Next
            Return dynamicObj

        End Function
    End Module
End Namespace