Imports System.Collections.ObjectModel

Class MainWindow
    Private Sub ButtonClick(sender As Object, e As RoutedEventArgs)
        ' Creiamo una ObservableCollection di tipo Customer 
        ' andanDo a valorizzare le sue proprietà
        Dim customerList = New ObservableCollection(Of Customer)() From { _
            New Customer() With { _
                .Name = "Carmelo", _
                .Surname = "La Monica", _
                .Address = "Indirizzo", _
                .Email = "Email", _
                .PhoneNumber = "Telefono" _
            } _
        }

        ' Assegnamo alla proprietà ItemSource del controllo ListBox 
        'il contenuto di customerlist

        listbox1.ItemsSource = customerList
    End Sub

    ' La classe Customer con le quattro proprietà
    Private Class Customer
        Public Property Name() As String
            Get
                Return _mName
            End Get
            Set(value As String)
                _mName = value
            End Set
        End Property

        Private _mName As String

        Public Property Surname() As String
            Get
                Return _mSurname
            End Get
            Set(value As String)
                _mSurname = value
            End Set
        End Property

        Private _mSurname As String

        Public Property PhoneNumber() As String
            Get
                Return _mPhoneNumber
            End Get
            Set(value As String)
                _mPhoneNumber = value
            End Set
        End Property

        Private _mPhoneNumber As String

        Public Property Address() As String
            Get
                Return _mAddress
            End Get
            Set(value As String)
                _mAddress = value
            End Set
        End Property

        Private _mAddress As String

        Public Property Email() As String
            Get
                Return _mEmail
            End Get
            Set(value As String)
                _mEmail = value
            End Set
        End Property

        Private _mEmail As String
    End Class
End Class
