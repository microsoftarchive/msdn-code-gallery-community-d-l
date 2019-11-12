Imports System.Net.Mail
Imports System.Text

Module Module1

    Sub Main()
        Dim mail As New MailMessage()
        mail.From = New MailAddress("koopakiller@live.de")
        'Absender
        mail.[To].Add("koopakiller@live.de")
        'Empfänger
        mail.Subject = "Das ist der Betreff"
        mail.Body = "Der Inhalt"
        'mail.IsBodyHTML = true; //Nur wenn Body HTML Quellcode ist 

        'Dim html As AlternateView = AlternateView.CreateAlternateViewFromString("HTML Inhalt", Encoding.UTF8, "text/html")
        'Dim img As LinkedResource = New LinkedResource("C:\\image.jpg") 'Kopieren Sie die Datei aus dem Projektmappenordner
        'img.ContentId = "imgID"
        'html.LinkedResources.Add(img) 'Bild zu den Resourcen des HTML hinzufügen
        'mail.AlternateViews.Add(html) 'HTML zur E-Mail hinzufügen

        'Anlage hinzufügen
        mail.Attachments.Add(New Attachment("C:\attachment.jpg")) 'Kopieren Sie die Datei aus dem Projektmappenordner

        Dim client As SmtpClient = New SmtpClient("smtp.live.com", 25)
        'SMTP Server von Hotmail und Outlook.
        Try
            'Anmeldedaten für den SMTP Server
            client.Credentials = New System.Net.NetworkCredential("koopakiller@live.de", "Passwort")

            client.EnableSsl = True
            'Die meisten Anbieter verlangen eine SSL-Verschlüsselung
            client.Send(mail)
            'Senden
            Console.WriteLine("E-Mai wurde versendet")
        Catch ex As Exception
            Console.WriteLine("Fehler beim Senden der E-Mail" & vbLf & vbLf, ex.Message)
        End Try
        Console.ReadKey()

    End Sub

End Module
