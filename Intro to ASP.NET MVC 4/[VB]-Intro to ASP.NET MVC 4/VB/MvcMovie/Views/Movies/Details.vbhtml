@ModelType MvcMovie.Movie

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>Movie</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Title)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Title)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.ReleaseDate)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.ReleaseDate)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Genre)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Genre)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Price)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Price)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
