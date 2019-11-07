Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System
Imports System.Collections.Generic

Namespace CSharpDynamicUnitTest
    <TestClass>
    Public Class DynamicKeyWordUnitTest

        Public Sub New()
            MyBase.New()
        End Sub

        <TestMethod>
        Public Sub DynamicallyAddPropertiesMethodsAndEvents()
            Dim strs As Dictionary(Of String, Object) = New Dictionary(Of String, Object)() From
            {
                {"NumberOne", 1},
                {"StringValue", "Hello World!"},
                {"Add", New Func(Of Double, Double, Double)(Function(n1, n2) n1 + n2)}
            }

            Dim nums As List(Of Integer) = New List(Of Integer)(5)
            strs.Add("EventDelegate", New Action(Of Integer)(Sub(num As Integer) nums.Add(num)))


            Dim d As Object = DynamicObjectCreator(strs)

            '''Do late binding
            d.NumberCheckingLoop = New Action(Of Integer, Integer)(Sub(num1, num2)

                                                                       For i As Integer = num1 To num2
                                                                           If (i Mod 2 = 0) Then
                                                                               d.EventDelegate.DynamicInvoke(i)
                                                                           End If
                                                                       Next
                                                                   End Sub)

            Assert.AreEqual(1, d.NumberOne)
            Assert.AreEqual("Hello World!", d.StringValue)

            ''' Here we must use DynamicInvoke, because in VB.NET
            ''' we cannot directly call a Function or an Action by adding a pair of "()" with parameters in C#, because this will be reguarded as an expression
            Assert.AreEqual(3.0, d.Add.DynamicInvoke(1.0, 2.0))
            d.NumberCheckingLoop.DynamicInvoke(1, 10)
            Assert.AreEqual(5, nums.Count)

        End Sub

        <TestMethod>
        Public Sub DynamicallyTestForDynamicObject()
            '''Define a basic simple object
            Dim d As Object = New CustomizedDynamicObject()
            d.a = "a"
            d.b = 1

            '''Define a nest object
            Dim nestObj As Object = New CustomizedDynamicObject()
            nestObj.d = 1
            nestObj.e = 2
            nestObj.array = New Integer() {1, 2, 3, 4, 5, 6}

            '''Define an obj array
            Dim dArrayObj As New List(Of Object)
            For i As Integer = 1 To 5
                Dim dObj As Object = New CustomizedDynamicObject()
                dObj.f = i
                dObj.g = i.ToString()
                dArrayObj.Add(dObj)
            Next
            nestObj.objArray = dArrayObj
            d.c = nestObj

            '''Do an implicit conversion
            Dim result As String = CTypeDynamic(d, GetType(String))
            Assert.AreEqual(Of String)("{a:'a',b:1,c:{d:1,e:2,array:[1,2,3,4,5,6],objArray:[{f:1,g:'1'},{f:2,g:'2'},{f:3,g:'3'},{f:4,g:'4'},{f:5,g:'5'}]}}", result)
        End Sub
    End Class
End Namespace