' Classe Delete
Public Class Delete
    ' Dichiaro una variabile di tipo stringa dove viene memorizzato il valore
    ' del parametro passato dal metodo setName
    Private name As String = String.Empty
    ' Dichiaro una variabile di tipo stringa dove viene memorizzato il valore
    ' del parametro passato dal metodo setSurName
    Private surName As String = String.Empty
    ' Dichiaro una variabile di tipo stringa dove viene memorizzato il valore
    ' del parametro passato dal metodo setAge
    Private age As String = String.Empty

    ' Metodo pubblico setName
    Public Sub setName(name As String)
        ' Assegno alla variabile a livello di classe name il valore del parametro 
        ' del metodo setName
        Me.name = name
    End Sub

    ' Metodo pubblico getName
    Public Function getName() As String
        ' Restituisco il valore della variabile a livello di classe name
        Return Me.name
    End Function

    ' Metodo pubblico setSurName
    Public Sub setSurName(surName As String)
        ' Assegno alla variabile a livello di classe surName il valore del parametro 
        ' del metodo setSurName
        Me.surName = surName
    End Sub

    ' Metodo pubblico getSurName
    Public Function getSurName() As String
        ' Restituisco il valore della variabile a livello di classe surName
        Return Me.surName
    End Function

    ' Metodo pubblico setAge
    Public Sub setAge(age As String)
        ' Assegno alla variabile a livello di classe age il valore del parametro 
        ' del metodo setAge
        Me.age = age
    End Sub

    ' Metodo pubblico getAge
    Public Function getAge() As String
        ' Restituisco il valore della variabile a livello di classe age
        Return Me.age
    End Function
End Class
