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
Imports System.Reflection
Imports System.Windows
Imports System.Windows.Navigation
Imports FuelTracker.Model
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell

Namespace Views

    Public Class SummaryPage
        Inherits PhoneApplicationPage

        Private Const PIVOT_INDEX_KEY As String = "PivotIndex"

        ''' <summary>
        ''' Initializes a new instance of the SummaryPage class.
        ''' </summary>
        Public Sub New()
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Called when navigating to this page; loads the car data from storage 
        ''' on the first navigation (that is, at application launch and
        ''' reactivation) and initializes the page state.
        ''' </summary>
        ''' <param name="e">The event data.</param>
        Protected Overrides Sub OnNavigatedTo(ByVal e As NavigationEventArgs)
            MyBase.OnNavigatedTo(e)

            ' Initialize the page state only if it is not already initialized,
            ' and not when the application was deactivated but not tombstoned (returning from being dormant).
            If DataContext Is Nothing Then
                InitializePageState()
            End If

            ' Determine whether the Car object is empty by checking for an 
            ' initial odometer reading of zero (invalid for a non-empty car). 
            Dim isCarObjectEmpty As Boolean =
                (CarDataStore.Car.InitialOdometerReading = 0)

            ' Display the instruction panel only if the Car object is empty.
            InstructionPanel.Visibility =
                If(isCarObjectEmpty, Visibility.Visible, Visibility.Collapsed)

            ' Display the pivot control only if the Car object is not empty.
            SummaryPivot.Visibility =
                If(isCarObjectEmpty, Visibility.Collapsed, Visibility.Visible)

            ' Enable the fill-up button only if the Car object is not empty. 
            CType(ApplicationBar.Buttons(0), ApplicationBarIconButton).IsEnabled =
                Not isCarObjectEmpty
        End Sub

        ''' <summary>
        ''' Called when navigating away from this page; stores the index of the 
        ''' current pivot item.
        ''' </summary>
        ''' <param name="e">The event data.</param>
        Protected Overrides Sub OnNavigatedFrom(ByVal e As NavigationEventArgs)
            MyBase.OnNavigatedFrom(e)
            State(PIVOT_INDEX_KEY) = SummaryPivot.SelectedIndex
        End Sub

        ''' <summary>
        ''' Initializes the view. 
        ''' </summary>
        Private Sub InitializePageState()

            AddHandler CarDataStore.CarUpdated, AddressOf CarDataStore_CarUpdated
            DataContext = CarDataStore.Car

            ' If a fill-up has just been added, display the first pivot item
            ' (index 0). If reactivation has just occurred, restore the pivot 
            ' item showing at the time of deactivation. If neither condition
            ' is true, then the application has just been launched, so the 
            ' Pivot control will show the first item by default. 
            If PhoneApplicationService.Current.State.ContainsKey(Constants.FILLUP_SAVED_KEY) Then
                SummaryPivot.SelectedIndex = 0
                PhoneApplicationService.Current.State.Remove(Constants.FILLUP_SAVED_KEY)
            ElseIf State.ContainsKey(PIVOT_INDEX_KEY) Then
                SummaryPivot.SelectedIndex = State(PIVOT_INDEX_KEY)
            End If

        End Sub

        ''' <summary>
        ''' Navigates to the fill-up page.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The event data.</param>
        Private Sub FillupButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            NavigationService.Navigate(
                New Uri("//Views/FillupPage.xaml", UriKind.Relative))
        End Sub

        ''' <summary>
        ''' Navigates to the car details page.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The event data.</param>
        Private Sub CarButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            NavigationService.Navigate(
                New Uri("//Views/CarDetailsPage.xaml", UriKind.Relative))
        End Sub

        ''' <summary>
        ''' Displays the Fuel Tracker version number and support URL.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The event data.</param>
        Private Sub AboutMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim fullName As String = Assembly.GetExecutingAssembly().FullName
            Dim assemblyName As AssemblyName = New AssemblyName(fullName)
            Dim productTitle As String = Nothing

            Dim customAttributes() As Object = Assembly.GetExecutingAssembly().GetCustomAttributes(GetType(AssemblyTitleAttribute), False)

            If ((customAttributes.Length > 0)) Then
                productTitle = DirectCast(customAttributes(0), AssemblyTitleAttribute).Title
            End If

            MessageBox.Show(productTitle & " sample application" &
                Environment.NewLine & "version " & assemblyName.Version.ToString() &
                Environment.NewLine & "http://dgwp7.codeplex.com",
                "About Fuel Tracker", MessageBoxButton.OK)
        End Sub

        Private Sub CarDataStore_CarUpdated()
            DataContext = CarDataStore.Car
        End Sub

    End Class

End Namespace
