Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Dynamic
Imports System.Runtime.InteropServices
Imports System.Text

Namespace CSharpDynamicUnitTest
    Public Class CustomizedDynamicObject
        Inherits DynamicObject
        ''' <summary>
        ''' Allowed simple types to be called directly with "ToString()" in the "GetRealString".
        ''' </summary>
        Private Shared ReadOnly _allowedTypes As Type()
        ''' <summary>
        ''' We use a Name-Value collection so that we can mock an object in javascript.
        ''' </summary>
        Private _propertyValuesCollection As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()

        Shared Sub New()
            CustomizedDynamicObject._allowedTypes = New Type() {GetType(Integer), GetType(UInteger), GetType(Long), GetType(ULong), GetType(Single), GetType(Double), GetType(Decimal)}
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides Function GetDynamicMemberNames() As IEnumerable(Of String)
            Return Me._propertyValuesCollection.Keys
        End Function
        ''' <summary>
        ''' This method will check whether the current looped value Is of simple type, an IEnumerable value Or something else.
        ''' 1) For simple types such as string, numeric types, directly call ToString.
        ''' 2) For any array type that implements IEnumerable, we can just use "[]" to output each value. Considering that each value in the array may vary, so a recursive Is a MUST here.
        ''' </summary>
        Private Function GetRealString(ByVal value As Object) As String
            Dim str As String
            If (value.[GetType]() = GetType(String)) Then
                str = String.Concat("'", value.ToString(), "'")
            ElseIf (Array.IndexOf(Of Type)(CustomizedDynamicObject._allowedTypes, value.[GetType]()) = -1) Then
                Dim p As IEnumerable = TryCast(value, IEnumerable)
                If (p Is Nothing) Then
                    str = value.ToString()
                Else
                    Dim sbu As StringBuilder = New StringBuilder()
                    Dim accessor As IEnumerator = p.GetEnumerator()
                    sbu.Append("[")
                    If (accessor.MoveNext()) Then
                        sbu.Append(Me.GetRealString(accessor.Current))
                    End If
                    While accessor.MoveNext()
                        sbu.Append(",")
                        sbu.Append(Me.GetRealString(accessor.Current))
                    End While
                    sbu.Append("]")
                    str = sbu.ToString()
                End If
            Else
                str = value.ToString()
            End If
            Return str
        End Function
        ''' <summary>
        ''' This method will output a string value as a simple json formation.
        ''' Notice the algorithm will call GetRealString, And GetRealString will call the method by exchange recursive.
        ''' </summary>
        ''' <returns>
        ''' A simple js-based object.
        ''' </returns>
        Public Overrides Function ToString() As String
            Dim current As KeyValuePair(Of String, Object)
            Dim sbu As StringBuilder = New StringBuilder(Me._propertyValuesCollection.Count)
            sbu.Append("{")
            If (Me._propertyValuesCollection.Count > 0) Then
                Dim pointer As IEnumerator(Of KeyValuePair(Of String, Object)) = Me._propertyValuesCollection.GetEnumerator()
                If (pointer.MoveNext()) Then
                    current = pointer.Current
                    Dim key As String = current.Key
                    current = pointer.Current
                    sbu.Append(String.Concat(key, ":", Me.GetRealString(current.Value)))
                End If
                While pointer.MoveNext()
                    sbu.Append(",")
                    current = pointer.Current
                    Dim str As String = current.Key
                    current = pointer.Current
                    sbu.Append(String.Concat(str, ":", Me.GetRealString(current.Value)))
                End While
            End If
            sbu.Append("}")
            Return sbu.ToString()
        End Function
        ''' <summary>
        ''' This method means you can exclipitly convert the dynamic value to a string by assigning it.
        ''' Notice that this only supports converted to string.
        ''' </summary>
        Public Overrides Function TryConvert(ByVal binder As ConvertBinder, <Out> ByRef result As Object) As Boolean
            Dim flag As Boolean
            If (binder.Type = GetType(String)) Then
                result = Me.ToString()
                flag = True
            Else
                result = Nothing
                flag = False
            End If
            Return flag
        End Function

        Public Overrides Function TryDeleteIndex(ByVal binder As DeleteIndexBinder, ByVal indexes As Object()) As Boolean
            Dim flag As Boolean = Me._propertyValuesCollection.Remove(indexes(0).ToString())
            Return flag
        End Function

        Public Overrides Function TryDeleteMember(ByVal binder As DeleteMemberBinder) As Boolean
            Return Me._propertyValuesCollection.Remove(binder.Name)
        End Function

        Public Overrides Function TryGetIndex(ByVal binder As GetIndexBinder, ByVal indexes As Object(), <Out> ByRef result As Object) As Boolean
            Dim flag As Boolean = Me.TryGetValueByKey(indexes(0).ToString(), result)
            Return flag
        End Function
        ''' <summary>
        ''' Fetch the existing member.
        ''' </summary>
        ''' <param name="binder">
        ''' The contenxt binder where we can get the inputted properties names.
        ''' </param>
        ''' <param name="result">
        ''' The result as a return type for the assigned property value.
        ''' </param>
        ''' <returns>
        ''' true: Successfully assigned.
        ''' false: exception will be thrown out.
        ''' </returns>
        Public Overrides Function TryGetMember(ByVal binder As GetMemberBinder, <Out> ByRef result As Object) As Boolean
            Return Me.TryGetValueByKey(binder.Name, result)
        End Function

        Private Function TryGetValueByKey(ByVal keyName As String, <Out> ByRef result As Object) As Boolean
            Dim isSuccess As Boolean = True
            If (Me._propertyValuesCollection.ContainsKey(keyName)) Then
                result = Me._propertyValuesCollection(keyName)
            Else
                result = Nothing
                isSuccess = False
            End If
            Return isSuccess
        End Function

        Public Overrides Function TrySetIndex(ByVal binder As SetIndexBinder, ByVal indexes As Object(), ByVal value As Object) As Boolean
            Dim flag As Boolean = Me.TrySetValueByKey(indexes(0).ToString(), value)
            Return flag
        End Function

        Public Overrides Function TrySetMember(ByVal binder As SetMemberBinder, ByVal value As Object) As Boolean
            Return Me.TrySetValueByKey(binder.Name, value)
        End Function

        Private Function TrySetValueByKey(ByVal keyName As String, ByVal result As Object) As Boolean
            Me._propertyValuesCollection(keyName) = result
            Return True
        End Function
    End Class
End Namespace