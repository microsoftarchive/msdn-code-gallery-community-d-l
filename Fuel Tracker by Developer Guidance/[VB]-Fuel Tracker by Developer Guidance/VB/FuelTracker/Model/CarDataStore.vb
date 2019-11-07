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
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Linq
Imports System.Windows.Media.Imaging

Namespace Model

    ''' <summary>
    ''' Represents the data-access layer of the Fuel Tracker application.
    ''' </summary>
    Public Class CarDataStore

        Private Const CAR_PHOTO_DIR_NAME As String = "FuelTracker"
        Private Const CAR_PHOTO_FILE_NAME As String = "CarPhoto.jpg"
        Private Const CAR_PHOTO_TEMP_FILE_NAME As String = "TempCarPhoto.jpg"
        Private Const CAR_KEY As String = "FuelTracker.Car"
        Private Shared appSettings As IsolatedStorageSettings =
            IsolatedStorageSettings.ApplicationSettings
        Private Shared _car As Car

        Public Shared Event CarUpdated()

        ''' <summary>
        ''' Gets or sets the _car data, loading the data from isolated storage
        ''' (if there is any saved data) on the first access. 
        ''' </summary>
        Public Shared Property Car As Car
            Get
                If _car Is Nothing Then
                    If appSettings.Contains(CAR_KEY) Then
                        _car = appSettings(CAR_KEY)
                        _car.Picture = GetCarPhoto(CAR_PHOTO_FILE_NAME)
                    Else
                        _car = New Car With {
                            .FillupHistory = New ObservableCollection(Of Fillup)
                        }
                    End If
                End If
                Return _car
            End Get
            Set(value As Car)
                _car = value
                RaiseEvent CarUpdated()
            End Set
        End Property

        ''' <summary>
        ''' Saves the _car data to isolated storage. 
        ''' </summary>
        ''' <param name="errorCallback">The action to execute if the 
        ''' storage attempt fails.</param>
        Public Shared Sub SaveCar(ByVal errorCallback As Action)
            Try
                appSettings(CAR_KEY) = Car
                appSettings.Save()
                DeleteTempCarPhoto()
                SaveCarPhoto(CAR_PHOTO_FILE_NAME, Car.Picture, errorCallback)
                RaiseEvent CarUpdated()
            Catch ex As IsolatedStorageException
                errorCallback()
            End Try
        End Sub

        ''' <summary>
        ''' Deletes the _car data from isolated storage and resets the Car property.
        ''' </summary>
        Public Shared Sub DeleteCar()
            appSettings.Remove(CAR_KEY)
            appSettings.Save()
            Car = Nothing
            DeleteCarPhoto()
            DeleteTempCarPhoto()
            RaiseEvent CarUpdated()
        End Sub

        ''' <summary>
        ''' Gets the temporary _car photo from isolated storage.
        ''' </summary>
        ''' <returns>The temporary _car photo.</returns>
        Public Shared Function GetTempCarPhoto() As BitmapImage
            Return GetCarPhoto(CAR_PHOTO_TEMP_FILE_NAME)
        End Function

        ''' <summary>
        ''' Saves the temporary car photo to isolated storage.
        ''' </summary>
        ''' <param name="carPicture">The image to save.</param>
        ''' <param name="errorCallback">The action to execute if the storage
        ''' attempt fails.</param>
        Public Shared Sub SaveTempCarPhoto(ByVal carPicture As BitmapImage,
                                           ByVal errorCallback As Action)
            SaveCarPhoto(CAR_PHOTO_TEMP_FILE_NAME, carPicture, errorCallback)
        End Sub

        ''' <summary>
        ''' Deletes the car photo from isolated storage.
        ''' </summary>
        Private Shared Sub DeleteCarPhoto()
            DeletePhoto(CAR_PHOTO_FILE_NAME)
        End Sub

        ''' <summary>
        ''' Deletes the temporary car photo from isolated storage.
        ''' </summary>
        Public Shared Sub DeleteTempCarPhoto()
            DeletePhoto(CAR_PHOTO_TEMP_FILE_NAME)
        End Sub

        ''' <summary>
        ''' Deletes the photo with the specified file name.
        ''' </summary>
        ''' <param name="fileName">The name of the photo file to delete.</param>
        Private Shared Sub DeletePhoto(ByVal fileName As String)
            Using store = IsolatedStorageFile.GetUserStoreForApplication
                Dim path = System.IO.Path.Combine(CAR_PHOTO_DIR_NAME, fileName)
                If store.FileExists(path) Then store.DeleteFile(path)
            End Using
        End Sub

        ''' <summary>
        ''' Gets the specified car photo from isolated storage.
        ''' </summary>
        ''' <param name="fileName">The filename of the photo to get.</param>
        ''' <returns>The requested photo.</returns>
        Private Shared Function GetCarPhoto(ByVal fileName As String) As BitmapImage

            Using store = IsolatedStorageFile.GetUserStoreForApplication

                Dim path As String = System.IO.Path.Combine(CAR_PHOTO_DIR_NAME, fileName)
                If Not store.FileExists(path) Then Return Nothing

                Using stream = store.OpenFile(path, FileMode.Open)
                    Dim image = New BitmapImage
                    image.SetSource(stream)
                    Return image
                End Using

            End Using

        End Function

        ''' <summary>
        ''' Saves the specified car photo to isolated storage using the 
        ''' specified filename.
        ''' </summary>
        ''' <param name="fileName">The filename to use.</param>
        ''' <param name="carPicture">The image to save.</param>
        ''' <param name="errorCallback">The action to execute if the storage
        ''' attempt fails.</param>
        Private Shared Sub SaveCarPhoto(ByVal fileName As String,
            ByVal carPicture As BitmapImage, ByVal errorCallback As Action)

            If carPicture Is Nothing Then Return

            Try
                Using store = IsolatedStorageFile.GetUserStoreForApplication

                    Dim bitmap = New WriteableBitmap(carPicture)
                    Dim path = System.IO.Path.Combine(CAR_PHOTO_DIR_NAME, fileName)

                    If Not store.DirectoryExists(CAR_PHOTO_DIR_NAME) Then
                        store.CreateDirectory(CAR_PHOTO_DIR_NAME)
                    End If

                    Using stream = store.OpenFile(path, FileMode.Create)
                        bitmap.SaveJpeg(stream, bitmap.PixelWidth, bitmap.PixelHeight, 0, 100)
                    End Using

                End Using
            Catch ex As IsolatedStorageException
                errorCallback()
            End Try

        End Sub

        ''' <summary>
        ''' Validates the specified Fillup and then, if it is valid, adds it to
        ''' Car.FillupHistory collection. 
        ''' </summary>
        ''' <param name="fillup">The fill-up to save.</param>
        ''' <param name="errorCallback">The action to execute if the storage
        ''' attempt fails.</param>
        ''' <returns>The validation results.</returns>
        Public Shared Function SaveFillup(ByVal fillup As Fillup,
            ByVal errorCallback As Action) As SaveResult

            Dim lastReading = If(
                Car.FillupHistory.Count > 0,
                Car.FillupHistory.First().OdometerReading,
                Car.InitialOdometerReading)
            fillup.DistanceDriven = fillup.OdometerReading - lastReading

            Dim saveResult = New SaveResult
            Dim validationResults = fillup.Validate
            If validationResults.Count > 0 Then
                saveResult.SaveSuccessful = False
                saveResult.ErrorMessages = validationResults
            Else
                Car.FillupHistory.Insert(0, fillup)
                saveResult.SaveSuccessful = True
                SaveCar(Sub()
                            saveResult.SaveSuccessful = False
                            errorCallback()
                        End Sub)
            End If

            Return saveResult

        End Function

    End Class

End Namespace
