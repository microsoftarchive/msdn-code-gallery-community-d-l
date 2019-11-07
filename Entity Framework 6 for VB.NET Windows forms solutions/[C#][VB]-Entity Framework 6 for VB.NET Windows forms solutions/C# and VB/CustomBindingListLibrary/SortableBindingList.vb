' Author    : Michel Posseth 
' Company   : VBDotNetCoder
' E-Mail    : info@VBDotNetCoder.com
Imports System.ComponentModel
Imports System.Reflection
Public Class SortableBindingList(Of T)
    Inherits BindingList(Of T)
    Private Property IsSorted As Boolean
    Private Property SortDirection As ListSortDirection
    Private Property SortProperty As PropertyDescriptor
    Protected Overrides ReadOnly Property SupportsSortingCore() As Boolean
        Get
            Return True
        End Get
    End Property
    Protected Overrides ReadOnly Property SortDirectionCore() As ListSortDirection
        Get
            Return _SortDirection
        End Get
    End Property
    Protected Overloads Overrides ReadOnly Property SortPropertyCore() As PropertyDescriptor
        Get
            Return _SortProperty
        End Get
    End Property
    Protected Overloads Overrides Sub ApplySortCore(ByVal PDsc As PropertyDescriptor, ByVal Direction As ListSortDirection)
        Dim items As List(Of T) = TryCast(Me.Items, List(Of T))
        If items Is Nothing Then
            IsSorted = False
        Else
            Dim PCom As New PCompare(Of T)(PDsc.Name, Direction)
            items.Sort(PCom)
            IsSorted = True
            SortDirection = Direction
            SortProperty = PDsc
        End If
        OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, -1))
    End Sub
    Protected Overloads Overrides ReadOnly Property IsSortedCore() As Boolean
        Get
            Return _IsSorted
        End Get
    End Property
    Protected Overrides Sub RemoveSortCore()
        _IsSorted = False
    End Sub
#Region " Constructors "
    Sub New(ByVal list As ICollection(Of T))
        MyBase.New(CType(list, Global.System.Collections.Generic.IList(Of T)))
    End Sub
    Sub New()
        MyBase.New()
    End Sub
#End Region
#Region " Property comparer "
    Private Class PCompare(Of T)
        Implements IComparer(Of T)
        Private Property PropInfo As PropertyInfo
        Private Property SortDir As ListSortDirection
        Friend Sub New(ByVal SortProperty As String, ByVal SortDirection As ListSortDirection)
            PropInfo = GetType(T).GetProperty(SortProperty)
            SortDir = SortDirection
        End Sub
        Friend Function Compare(ByVal x As T, ByVal y As T) As Integer Implements IComparer(Of T).Compare
            Return If(SortDir = ListSortDirection.Ascending, Comparer.[Default].Compare(PropInfo.GetValue(x, Nothing),
                    PropInfo.GetValue(y, Nothing)), Comparer.[Default].Compare(PropInfo.GetValue(y, Nothing),
                                                                               PropInfo.GetValue(x, Nothing)))
        End Function
    End Class
#End Region

End Class
