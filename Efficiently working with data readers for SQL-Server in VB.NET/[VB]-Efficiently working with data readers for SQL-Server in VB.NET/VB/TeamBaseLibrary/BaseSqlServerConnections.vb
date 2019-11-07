Imports ExceptionsLibrary
''' <summary>
''' Pre-configure connection string using a default server 
''' and catalog. In a normal solution this is all that should
''' be required but if at run time the connection needs to
''' change you can change the server and catalog in the class
''' which inherits from this class.
''' 
''' BaseExceptionsHandler provides properties which any
''' class inherits from BaseSqlServerConnections can set
''' a property then when the caller method throws an exception
''' you can mark a property that an exception occured
''' then in the high level caller (e.g. in a form) can
''' ask "was there an exception" and if so get the exception
''' via LastException property in BaseExceptionsHandler.
''' </summary>
Public Class BaseSqlServerConnections
    Inherits BaseExceptionsHandler

    ''' <summary>
    ''' This points to your database server
    ''' </summary>
    Protected DatabaseServer As String = "KARENS-PC"
    ''' <summary>
    ''' Name of database containing required tables
    ''' </summary>
    Protected DefaultCatalog As String = ""
    Public ReadOnly Property ConnectionString As String
        Get
            Return $"Data Source={DatabaseServer};" &
                   $"Initial Catalog={DefaultCatalog};Integrated Security=True"
        End Get
    End Property


End Class
