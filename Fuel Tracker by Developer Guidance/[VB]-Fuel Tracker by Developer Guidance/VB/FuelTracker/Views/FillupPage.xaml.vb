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
Imports System.Windows.Navigation
Imports FuelTracker.Model
Imports Microsoft.Phone.Controls

Namespace Views

    Public Class FillupPage
        Inherits PhoneApplicationPage

        Private Const CURRENT_FILLUP_KEY As String = "CurrentFillup"
        Private Const HAS_UNSAVED_CHANGES_KEY As String = "HasUnsavedChanges"
        Private _currentFillup As Fillup
        Private _hasUnsavedChanges As Boolean
        Private _textboxWithFocus As TextBox

        ''' <summary>
        ''' Initializes a new instance of the FillupPage class.
        ''' </summary>
        Public Sub New()
            InitializeComponent()
            AddHandler OdometerTextBox.KeyDown, Sub() _hasUnsavedChanges = True
            AddHandler FuelQuantityTextBox.KeyDown, Sub() _hasUnsavedChanges = True
            AddHandler PricePerUnitTextBox.KeyDown, Sub() _hasUnsavedChanges = True
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

            ' Delete temporary storage to avoid unnecessary storage costs.
            State.Clear()

        End Sub

        ''' <summary>
        ''' Called when navigating away from this page; stores the fill-up data
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
            State(CURRENT_FILLUP_KEY) = _currentFillup
            State(HAS_UNSAVED_CHANGES_KEY) = _hasUnsavedChanges

        End Sub

        ''' <summary>
        ''' Initializes the view and its data context. 
        ''' </summary>
        Private Sub InitializePageState()
            CarHeader.DataContext = CarDataStore.Car

            _currentFillup =
                If(State.ContainsKey(CURRENT_FILLUP_KEY),
                State(CURRENT_FILLUP_KEY),
                New Fillup() With {.Date = DateTime.Now})

            DataContext = _currentFillup

            _hasUnsavedChanges =
                If(State.ContainsKey(HAS_UNSAVED_CHANGES_KEY),
                State(HAS_UNSAVED_CHANGES_KEY), False)

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
            e.Cancel = (result = MessageBoxResult.Cancel)

        End Sub

        ''' <summary>
        ''' Validates the entered fill-up data and, if validation is successful, 
        ''' saves the data and navigates back to the SummaryPage. 
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The event data.</param>
        Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As EventArgs)

            ' Commit any uncommitted changes. Changes in a bound text box are 
            ' normally committed to the data source only when the text box 
            ' loses focus. However, application bar buttons do not receive or 
            ' change focus because they are not Silverlight controls. 
            CommitTextBoxWithFocus()

            If String.IsNullOrWhiteSpace(OdometerTextBox.Text) Then
                MessageBox.Show("The odometer reading is required.")
                Return
            End If

            If String.IsNullOrWhiteSpace(FuelQuantityTextBox.Text) Then
                MessageBox.Show("The gallons value is required.")
                Return
            End If

            If String.IsNullOrWhiteSpace(PricePerUnitTextBox.Text) Then
                MessageBox.Show("The price per gallon value is required.")
                Return
            End If

            Dim val As Single
            If Not Single.TryParse(OdometerTextBox.Text, val) Then
                MessageBox.Show("The odometer reading could not be converted to a number.")
                Return
            End If

            If Not Single.TryParse(FuelQuantityTextBox.Text, val) Then
                MessageBox.Show("The gallons value could not be converted to a number.")
                Return
            End If

            If Not Single.TryParse(PricePerUnitTextBox.Text, val) Then
                MessageBox.Show("The price per gallon value could not be converted to a number.")
                Return
            End If


            Dim result As SaveResult = CarDataStore.SaveFillup(_currentFillup,
                Sub()
                    MessageBox.Show("There is not enough space on your phone " &
                    "to save your fill-up data. Free some space and try again.")
                End Sub)

            If result.SaveSuccessful Then

                Microsoft.Phone.Shell.PhoneApplicationService.Current _
                    .State(Constants.FILLUP_SAVED_KEY) = True
                NavigationService.GoBack()

            Else

                Dim errorMessages = String.Join(
                    Environment.NewLine & Environment.NewLine,
                    result.ErrorMessages.ToArray())
                If Not String.IsNullOrEmpty(errorMessages) Then
                    MessageBox.Show(errorMessages,
                        "Warning: Invalid Values", MessageBoxButton.OK)
                End If

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

        Private Sub FillupPage_GotFocus(sender As Object, e As System.Windows.RoutedEventArgs) Handles MyBase.GotFocus
            _textboxWithFocus = TryCast(e.OriginalSource, TextBox)
        End Sub

    End Class

End Namespace

