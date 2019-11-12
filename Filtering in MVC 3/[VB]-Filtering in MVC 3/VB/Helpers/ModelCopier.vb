Imports System.ComponentModel

Namespace Mvc3Filter.Helpers
	Public Class ModelCopier
		Public Shared Sub CopyCollection(Of T)(ByVal [from] As IEnumerable(Of T), ByVal [to] As ICollection(Of T))
			If [from] Is Nothing OrElse [to] Is Nothing OrElse [to].IsReadOnly Then
				Return
			End If

			[to].Clear()
			For Each element As T In [from]
				[to].Add(element)
			Next element
		End Sub

		Public Shared Sub CopyModel(ByVal [from] As Object, ByVal [to] As Object)
			If [from] Is Nothing OrElse [to] Is Nothing Then
				Return
			End If

			Dim fromProperties As PropertyDescriptorCollection = TypeDescriptor.GetProperties([from])
			Dim toProperties As PropertyDescriptorCollection = TypeDescriptor.GetProperties([to])

			For Each fromProperty As PropertyDescriptor In fromProperties
				Dim toProperty As PropertyDescriptor = toProperties.Find(fromProperty.Name, True) ' ignoreCase
				If toProperty IsNot Nothing AndAlso (Not toProperty.IsReadOnly) Then
					' Can from.Property reference just be assigned directly to to.Property reference?
					Dim isDirectlyAssignable As Boolean = toProperty.PropertyType.IsAssignableFrom(fromProperty.PropertyType)
					' Is from.Property just the nullable form of to.Property?
					Dim liftedValueType As Boolean = If(isDirectlyAssignable, False, (Nullable.GetUnderlyingType(fromProperty.PropertyType) Is toProperty.PropertyType))

					If isDirectlyAssignable OrElse liftedValueType Then
						Dim fromValue As Object = fromProperty.GetValue([from])
						If isDirectlyAssignable OrElse (fromValue IsNot Nothing AndAlso liftedValueType) Then
							toProperty.SetValue([to], fromValue)
						End If
					End If
				End If
			Next fromProperty
		End Sub
	End Class
End Namespace