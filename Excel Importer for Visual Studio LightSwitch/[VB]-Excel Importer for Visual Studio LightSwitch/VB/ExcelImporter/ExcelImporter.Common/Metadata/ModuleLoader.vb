Imports System.Collections.Generic
Imports System.ComponentModel.Composition
Imports System.IO
Imports System.Resources
Imports System.Reflection

Imports Microsoft.LightSwitch.Model

<Export(GetType(IModuleDefinitionLoader))>
<ModuleDefinitionLoader("ExcelImporter")>
Friend Class ModuleLoader
    Implements IModuleDefinitionLoader

    Public Function GetModelResourceManager() As ResourceManager Implements IModuleDefinitionLoader.GetModelResourceManager
        Return My.Resources.ModuleResources.ResourceManager
    End Function

    Public Function LoadModelFragments() As IEnumerable(Of Stream) Implements IModuleDefinitionLoader.LoadModelFragments
        Dim assembly As Assembly = assembly.GetExecutingAssembly()
        Dim fragmentStreams As IList(Of Stream) = New List(Of Stream)

        For Each resourceName In assembly.GetManifestResourceNames()
            If resourceName.EndsWith(".lsml", StringComparison.Ordinal) Then
                fragmentStreams.Add(assembly.GetManifestResourceStream(resourceName))
            End If
        Next

        Return fragmentStreams
    End Function

End Class