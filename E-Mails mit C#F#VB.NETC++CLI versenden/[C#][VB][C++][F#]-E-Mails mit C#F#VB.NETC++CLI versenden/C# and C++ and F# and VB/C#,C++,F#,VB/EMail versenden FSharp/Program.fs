open System.Net.Mail;
open System.Text;
open System;

[<EntryPoint>]
let main argv = 
    let mail = new MailMessage();
    mail.From <- new MailAddress("koopakiller@live.de"); //Absender
    mail.To.Add("koopakiller@live.de"); //Empfänger
    mail.Subject <- "Das ist der Betreff";
    mail.Body <- "Der Inhalt";
    //mail.IsBodyHTML <- true; //Nur wenn Body HTML Quellcode ist 
           
//    let html = AlternateView.CreateAlternateViewFromString("HTML Inhalt", Encoding.UTF8, "text/html");
//    let img = new LinkedResource(@"C:\image.jpg");//Kopieren Sie die Datei aus dem Projektmappenordner
//    img.ContentId <- "imgID";
//    html.LinkedResources.Add(img); //Bild zu den Resourcen des HTML hinzufügen
//    mail.AlternateViews.Add(html); //HTML zur E-Mail hinzufügen
                
    //Anlage hinzufügen
    mail.Attachments.Add(new Attachment(@"C:\attachment.jpg")); //Kopieren Sie die Datei aus dem Projektmappenordner

    let client = new SmtpClient("smtp.live.com", 25); //SMTP Server von Hotmail und Outlook.

    try
    (
        client.Credentials <- new System.Net.NetworkCredential("koopakiller@live.de", "Passwort") //Anmeldedaten für den SMTP Server

        client.EnableSsl <- true //Die meisten Anbieter verlangen eine SSL-Verschlüsselung

        client.Send(mail) //Senden

        printfn "E-Mail wurde versendet"        
    )
    with
       | ex -> printfn "Fehler beim Senden der E-Mail \n\n%s" ex.Message       
    0