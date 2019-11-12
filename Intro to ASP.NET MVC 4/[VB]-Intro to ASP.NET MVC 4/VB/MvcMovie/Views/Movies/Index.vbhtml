@ModelType IEnumerable(Of MvcMovie.Movie)

@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Title)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ReleaseDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Genre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Price)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Rating)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Title)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.ReleaseDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Genre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Price)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Rating)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.ID})
        </td>
    </tr>
Next

</table>
