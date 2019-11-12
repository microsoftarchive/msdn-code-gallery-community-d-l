Imports System
Imports System.ComponentModel.DataAnnotations

Public Module GenderValidator
    Public Function IsGenderValid(ByVal gender As String, ByVal context As ValidationContext) As ValidationResult
        If gender = "M" OrElse gender = "m" OrElse gender = "F" OrElse gender = "f" Then
            Return ValidationResult.Success
        Else
            Return New ValidationResult("The Gender field only has two valid values 'M'/'F'", New String() {"Gender"})
        End If
    End Function
End Module
