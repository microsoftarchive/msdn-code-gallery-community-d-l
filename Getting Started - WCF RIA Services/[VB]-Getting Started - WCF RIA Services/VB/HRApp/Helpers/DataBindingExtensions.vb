Imports System
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Windows
Imports System.Windows.Data

''' <summary>
'''     Provides extension methods for dealing with <see cref="Binding"/> objects
''' </summary>
Public Module DataBindingExtensions

    ''' <summary>
    '''     Creates a new <see cref="Binding"/> whose <see cref="Binding.Source"/>
    '''     is the object in which this method is being called, whose <see cref="Binding.Path"/> 
    '''     property is initialized from <see cref="propertyPath"/> and whose <see cref="Binding.Converter"/>
    '''     is optionally given by <paramref name="converter"/> 
    ''' </summary>
    <Extension()> _
    Public Function CreateOneWayBinding(ByVal bindingSource As INotifyPropertyChanged, ByVal propertyPath As String, Optional ByVal converter As IValueConverter = Nothing) As Binding

        Dim binding As New Binding()
        binding.Source = bindingSource
        binding.Path = New PropertyPath(propertyPath)
        binding.Converter = converter

        Return binding
    End Function


    ''' <summary>
    '''     Creates a new <see cref="Binding"/> object by copying all properties
    '''     from another <see cref="Binding"/> object
    ''' </summary>
    ''' <param name="binding"><see cref="Binding"/> from which property values will be copied</param>
    <Extension()> _
    Public Function CreateCopy(ByVal binding As Binding) As binding
        If binding Is Nothing Then
            Throw New ArgumentNullException("binding")
        End If

        Dim newBinding As New Binding()

        newBinding.BindsDirectlyToSource = binding.BindsDirectlyToSource
        newBinding.Converter = binding.Converter
        newBinding.ConverterParameter = binding.ConverterParameter
        newBinding.ConverterCulture = binding.ConverterCulture
        newBinding.Mode = binding.Mode
        newBinding.NotifyOnValidationError = binding.NotifyOnValidationError
        newBinding.Path = binding.Path
        newBinding.UpdateSourceTrigger = binding.UpdateSourceTrigger
        newBinding.ValidatesOnExceptions = binding.ValidatesOnExceptions

        If binding.ElementName IsNot Nothing Then
            newBinding.ElementName = binding.ElementName
        ElseIf binding.RelativeSource IsNot Nothing Then
            newBinding.RelativeSource = binding.RelativeSource
        Else
            newBinding.Source = binding.Source
        End If

        Return newBinding
    End Function
End Module


