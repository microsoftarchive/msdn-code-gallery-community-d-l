Imports System.Web.Mvc

Public Class RequestTimingFilterProvider
	Implements IFilterProvider


	Private ReadOnly _conditions As New List(Of Func(Of ControllerContext, Object))()
	Public Sub Add(ByVal condition As Func(Of ControllerContext, Object))
		_conditions.Add(condition)
	End Sub
    Public Function GetFilters(ByVal controllerContext As ControllerContext, ByVal actionDescriptor As ActionDescriptor) As IEnumerable(Of Filter) Implements IFilterProvider.GetFilters
        Return From condition In _conditions
                 Select filter1 = condition(controllerContext)
                 Where filter1 IsNot Nothing
                 Select New Filter(filter1, FilterScope.Global, 1)

    End Function


End Class