// EMail versenden CppCli.cpp: Hauptprojektdatei.

#include "stdafx.h"

using namespace System;
using namespace System::Net::Mail;
using namespace System::Text;

int main(array<System::String ^> ^args)
{
	MailMessage^ mail  = gcnew MailMessage();
    mail->From = gcnew MailAddress("koopakiller@live.de"); //Absender
    mail->To->Add("koopakiller@live.de"); //Empfänger
    mail->Subject = "Das ist der Betreff";
    mail->Body = "Der Inhalt";
    //mail->IsBodyHTML = true; //Nur wenn Body HTML Quellcode ist 

    /*
	AlternateView^ html = AlternateView::CreateAlternateViewFromString("HTML Inhalt", Encoding::UTF8, "text/html");
    LinkedResource^ img = gcnew LinkedResource("C:\\image.jpg");//Kopieren Sie die Datei aus dem Projektmappenordner
    img->ContentId = "imgID";
    html->LinkedResources->Add(img); //Bild zu den Resourcen des HTML hinzufügen
    mail->AlternateViews->Add(html); //HTML zur E-Mail hinzufügen
	*/

	//Anlage hinzufügen
    mail->Attachments->Add(gcnew Attachment("C:\\attachment.jpg")); //Kopieren Sie die Datei aus dem Projektmappenordner

    SmtpClient^ client = gcnew SmtpClient("smtp.live.com", 25); //SMTP Server von Hotmail und Outlook.

    try
    {
        client->Credentials = gcnew System::Net::NetworkCredential("koopakiller@live.de", "Hello&World");//Anmeldedaten für den SMTP Server

        client->EnableSsl = true; //Die meisten Anbieter verlangen eine SSL-Verschlüsselung

        client->Send(mail); //Senden

        Console::WriteLine("E-Mai wurde versendet");
    }
    catch (Exception^ ex)
    {
        Console::WriteLine("Fehler beim Senden der E-Mail\n\n%s", ex->Message);
    }
    Console::ReadKey();

    return 0;
}
