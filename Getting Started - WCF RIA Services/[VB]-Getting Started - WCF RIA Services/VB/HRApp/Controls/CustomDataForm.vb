Imports System
Imports System.Collections.Generic
Imports System.Reflection
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports HRApp.Web
Namespace Controls

    ''' <summary>
    '''     Enhances <see cref="DataForm" /> functionality by using a <see cref="PasswordBox" /> 
    '''     control for password fields and exposing a <see cref="CustomDataForm.Fields"/> collection
    '''     to allow runtime access to <see cref="DataForm" /> fields.
    ''' </summary>
    Public Class CustomDataForm

        Inherits DataForm
        Private _fields As New Dictionary(Of String, DataField)()

        ''' <summary>
        '''     Returns a <see cref="Dictionary" /> containing all the <see cref="DataForm" />
        '''     <see cref="DataField" /> controls being displayed keyed by the
        '''     property name to which each field is bound
        ''' </summary>
        Public ReadOnly Property Fields() As Dictionary(Of String, DataField)
            Get
                Return Me._fields
            End Get
        End Property

        ''' <summary>
        '''     Extends <see cref="DataForm.OnAutoGeneratingField" /> by replacing <see cref="TextBox"/>es with <see cref="PasswordBox"/>es
        '''     whenever applicable
        ''' </summary>
        Protected Overrides Sub OnAutoGeneratingField(ByVal e As DataFormAutoGeneratingFieldEventArgs)
            If e Is Nothing Then
                Throw New ArgumentNullException("e")
            End If

            ' Get metadata about the property being defined
            Dim propertyInfo As PropertyInfo = Me.CurrentItem.GetType().GetProperty(e.PropertyName)

            ' Do the password field replacement if that is the case
            If TypeOf e.Field.Content Is TextBox AndAlso Me.IsPasswordProperty(propertyInfo) Then
                e.Field.ReplaceTextBox(New PasswordBox(), PasswordBox.PasswordProperty)
            End If

            ' Keep this newly generated field accessible through the Fields property
            Me._fields(e.PropertyName) = e.Field

            ' Call base implementation (which will call other event listeners)
            MyBase.OnAutoGeneratingField(e)
        End Sub

        ''' <param name="propertyInfo">The entity property being analyzed</param>
        ''' <summary>
        '''     Returns whether the given property should be represented by a <see cref="PasswordBox" /> or not.
        '''     The default implementation will simply use a naming convention and returns true if the
        '''     property contains the word "Password"
        ''' </summary>
        Protected Overridable Function IsPasswordProperty(ByVal propertyInfo As PropertyInfo) As Boolean
            If propertyInfo Is Nothing Then
                Throw New ArgumentNullException("propertyInfo")
            End If

            ' Suggestion: to handle more complex scenarios, allow an entity to override
            ' this mechanism by using the System.ComponentModel.DataAnnotations.UIHintAttribute 
            Return propertyInfo.Name.IndexOf("Password", StringComparison.OrdinalIgnoreCase) <> -1
        End Function
    End Class
End Namespace
