' ===================================================================================
'  Microsoft Developer Guidance
'  Application Guidance for Windows Phone 7 
' ===================================================================================
'  Copyright (c) Microsoft Corporation.  All rights reserved.
'  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
'  OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
'  LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
'  FITNESS FOR A PARTICULAR PURPOSE.
' ===================================================================================
'  The example companies, organizations, products, domain names,
'  e-mail addresses, logos, people, places, and events depicted
'  herein are fictitious.  No association with any real company,
'  organization, product, domain name, email address, logo, person,
'  places, or events is intended or should be inferred.
' ===================================================================================

Imports System
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports FuelTracker.Model
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Tasks

Namespace Views

    Public Class CarDetailsPage
        Inherits PhoneApplicationPage

        Private Const CAR_INFO_KEY As String = "CarInfo"
        Private Const HAS_UNSAVED_CHANGES_KEY As String = "HasUnsavedChanges"
        Private Const ODOMETER_READONLY_STATE As String = "OdometerReadOnlyState"
        Private _photoTask As PhotoChooserTask = New PhotoChooserTask
        Private _carImage As BitmapImage
        Private _car As Car
        Private _hasUnsavedChanges As Boolean
        Private _textboxWithFocus As TextBox

        ''' <summary>
        ''' Initializes a new instance of the CarDetailsPage class.
        ''' </summary>
        Public Sub New()
            InitializeComponent()
            AddHandler _photoTask.Completed, AddressOf PhotoTask_Completed
            AddHandler NameTextBox.KeyDown, Sub() _hasUnsavedChanges = True
            AddHandler OdometerTextBox.KeyDown, Sub() _hasUnsavedChanges = True
        End Sub

        ''' <summary>
        ''' Called when navigating to this page; loads the car data from storage 
        ''' and then initializes the page state.
        ''' </summary>
        ''' <param name="e">The event data.</param>
        Protected Overrides Sub OnNavigatedTo(ByVal e As NavigationEventArgs)

            MyBase.OnNavigatedTo(e)

            ' Initialize the page state only if it is not already initialized,
            ' and not when the application was deactivated but not tombstoned (returning from being dormant).
            If DataContext Is Nothing Then
                InitializePageState()
            End If

            ' Initialize the picture using the first available image from the 
            ' PhotoChooserTask, the temporary photo, and the saved photo. 
            _car.Picture = If(_carImage,
                If(CarDataStore.GetTempCarPhoto(), CarDataStore.Car.Picture))

        End Sub

        ''' <summary>
        ''' Called when navigating away from this page; stores the car data
        ''' values and a value that indicates whether there are unsaved changes. 
        ''' </summary>
        ''' <param name="e">The event data.</param>
        Protected Overrides Sub OnNavigatedFrom(ByVal e As NavigationEventArgs)

            MyBase.OnNavigatedFrom(e)

            ' Do not cache the page state when navigating backward 
            ' or when there are no unsaved changes.
            If e.Uri.OriginalString.Equals("//Views/SummaryPage.xaml") AndAlso
                Not _hasUnsavedChanges Then Return

            CommitTextBoxWithFocus()
            State(CAR_INFO_KEY) = _car
            State(ODOMETER_READONLY_STATE) = OdometerTextBox.IsReadOnly
            State(HAS_UNSAVED_CHANGES_KEY) = _hasUnsavedChanges

        End Sub

        ''' <summary>
        ''' Initializes the view and its data context. 
        ''' </summary>
        Private Sub InitializePageState()

            ' Retrieve data from temporary storage if present; 
            ' otherwise, copy data from CarDataStore.Car.
            If State.ContainsKey(CAR_INFO_KEY) Then

                _car = State(CAR_INFO_KEY)

                ' Restore the read-only state of the odometer text box.
                OdometerTextBox.IsReadOnly = State(ODOMETER_READONLY_STATE)

                ' Restore the change state except when the PhotoTask_Completed 
                ' method has already set the change state.
                If Not _hasUnsavedChanges Then
                    _hasUnsavedChanges = State(HAS_UNSAVED_CHANGES_KEY)
                End If

                ' Delete temporary storage to avoid unnecessary storage costs.
                State.Clear()

            Else

                _car = CarDataStore.Car

                ' Delete the temporary photo if it exists. This prevents an old
                ' temporary photo selection from reappearing after tombstoning.
                CarDataStore.DeleteTempCarPhoto()

                ' Disable the odometer text box when displaying a saved value.
                OdometerTextBox.IsReadOnly = _car.InitialOdometerReading > 0

                ' Disable the delete car button for new car
                If _car.InitialOdometerReading.Equals(0) Then
                    Dim deleteButton As ApplicationBarIconButton = ApplicationBar.Buttons(1)
                    deleteButton.IsEnabled = False
                End If

            End If

            ' Set the page data context to the car.
            DataContext = _car

        End Sub

        ''' <summary>
        ''' Displays a warning dialog box if the user presses the back button
        ''' and there are unsaved changes. 
        ''' </summary>
        ''' <param name="e"></param>
        Protected Overrides Sub OnBackKeyPress(
            ByVal e As System.ComponentModel.CancelEventArgs)

            MyBase.OnBackKeyPress(e)

            ' If there are no changes, do nothing.
            If Not _hasUnsavedChanges Then Return

            Dim result = MessageBox.Show("You are about to discard your " &
                "changes. Continue?", "Warning", MessageBoxButton.OKCancel)
            If result = MessageBoxResult.OK Then
                CarDataStore.DeleteTempCarPhoto()
            Else
                e.Cancel = True
            End If

        End Sub

        ''' <summary>
        ''' Shows the photo chooser.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The event data.</param>
        Private Sub PhotoButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Try

                _photoTask.Show()
            Catch ex As InvalidOperationException
                ' Button was tapped more than once. Do nothing.
            End Try
        End Sub

        ''' <summary>
        ''' Displays the selected photo and saves it in temporary storage. 
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The event data.</param>
        Private Sub PhotoTask_Completed(ByVal sender As Object, ByVal e As PhotoResult)

            If e.TaskResult = TaskResult.OK Then
                _carImage = New BitmapImage
                _carImage.SetSource(e.ChosenPhoto)
                CarDataStore.SaveTempCarPhoto(_carImage,
                    Sub() MessageBox.Show("There is not enough space on " &
                    "your phone to save your selection. Free some " &
                     "space and try again.", "Warning", MessageBoxButton.OK))
            End If

            _hasUnsavedChanges = True

        End Sub

        ''' <summary>
        ''' Validates the entered car data and, if validation is successful, 
        ''' saves the data and navigates back to the SummaryPage. 
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The event data.</param>
        Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As EventArgs)

            CommitTextBoxWithFocus()

            If String.IsNullOrWhiteSpace(_car.Name) Then
                MessageBox.Show("The car name is required.")
                Return
            End If

            If String.IsNullOrWhiteSpace(OdometerTextBox.Text) Then
                MessageBox.Show("The odometer reading is required.")
                Return
            End If

            Dim val As Single
            If Not Single.TryParse(OdometerTextBox.Text, val) Then
                MessageBox.Show("The odometer reading could not be converted to a number.")
                Return
            End If

            If _car.InitialOdometerReading < 1 Then

                MessageBox.Show("The odometer reading must be greater than or equal to one.")
                Return

            End If

            CarDataStore.Car.Name = _car.Name
            CarDataStore.Car.InitialOdometerReading =
                _car.InitialOdometerReading
            CarDataStore.Car.Picture = _car.Picture
            CarDataStore.SaveCar(
                Sub()
                    MessageBox.Show("There is not enough space on your phone to " &
                    "save your car data. Free some space and try again.")
                End Sub)

            NavigationService.GoBack()

        End Sub

        ''' <summary>
        ''' Displays a warning dialog box to confirm deletion of the car data. 
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The event data.</param>
        Private Sub DeleteButton_Click(ByVal sender As Object, ByVal e As EventArgs)

            ' Commit any uncommitted changes. Changes in a bound text box are 
            ' normally committed to the data source only when the text box 
            ' loses focus. However, application bar buttons do not receive or 
            ' change focus because they are not Silverlight controls. 
            CommitTextBoxWithFocus()

            Dim result = MessageBox.Show("You are about to delete the car " &
                "and its entire fill-up history. Continue?",
                "Warning", MessageBoxButton.OKCancel)
            If result = MessageBoxResult.OK Then

                ' Reset the individual properties so that the bound
                ' text boxes will update automatically.
                _car.Name = Nothing
                _car.Picture = Nothing
                _car.InitialOdometerReading = 0
                _car.FillupHistory.Clear()
                _hasUnsavedChanges = False
                OdometerTextBox.IsReadOnly = False
                CarDataStore.DeleteCar()

                Dim deleteButton As ApplicationBarIconButton = ApplicationBar.Buttons(1)
                deleteButton.IsEnabled = False
            End If

        End Sub

        ''' <summary>
        ''' Ensures that any changes to text box values are committed. 
        ''' </summary>
        Private Sub CommitTextBoxWithFocus()

            If (_textboxWithFocus Is Nothing) Then Return

            Dim expression As System.Windows.Data.BindingExpression =
                    _textboxWithFocus.GetBindingExpression(TextBox.TextProperty)
            If (expression IsNot Nothing) Then expression.UpdateSource()

        End Sub


        Private Sub CarDetailsPage_GotFocus(sender As Object, e As System.Windows.RoutedEventArgs) Handles MyBase.GotFocus
            _textboxWithFocus = TryCast(e.OriginalSource, TextBox)
        End Sub

        Private Sub CarDetailsPage_Unloaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles MyBase.Unloaded
            RemoveHandler _photoTask.Completed, AddressOf PhotoTask_Completed
        End Sub
    End Class

End Namespace
