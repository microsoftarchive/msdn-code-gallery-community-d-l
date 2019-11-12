using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XsPDF.Drawing;
using XsPDF.Pdf;
using XsPDF.Pdf.IO;
using XsPDF.Pdf.Security;

namespace XsPDF.Demo
{
    class DocumentProtectDemo
    {
        public static void ProtectDocument()
        {
            // Open an existing document.
            PdfDocument document = PdfReader.Open("file1.pdf");

            PdfSecuritySettings securitySettings = document.SecuritySettings;

            // Add user password and owner password 
            securitySettings.UserPassword = "user password";
            securitySettings.OwnerPassword = "owner password";

            // Set passwords security level
            securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted128Bit;

            // Restrict permission rights. Disallow all the editing rights.
            securitySettings.PermitAccessibilityExtractContent = false;
            securitySettings.PermitAnnotations = false;
            securitySettings.PermitAssembleDocument = false;
            securitySettings.PermitExtractContent = false;
            securitySettings.PermitFormsFill = false;
            securitySettings.PermitFullQualityPrint = false;
            securitySettings.PermitModifyDocument = false;
            securitySettings.PermitPrint = false;

            // Save the document...
            document.Save("Protect.pdf");
        }

        public static void UnprotectDocument()
        {
            PdfDocument document;

            string filename = "Protect.pdf";

            // Opening a document will fail with an invalid password.
            try
            {
                document = PdfReader.Open(filename, "error password");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Open the document with the user password.
            try
            {
                document = PdfReader.Open(filename, "user password", PdfDocumentOpenMode.ReadOnly);

                // Use the property HasOwnerPermissions to decide whether the used password
                // was the user or the owner password. 
                bool hasOwnerAccess = document.SecuritySettings.HasOwnerPermissions;

                // if it's the user password, not having the owner permission
                if (!hasOwnerAccess)
                {
                    // Maybe only allow user to view or print the pdf document
                    // To do...
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Open the document with the owner password.
            try
            {
                document = PdfReader.Open(filename, "owner password");

                // Use the property HasOwnerPermissions to decide whether the used password
                // was the user or the owner password. 
                bool hasOwnerAccess = document.SecuritySettings.HasOwnerPermissions;

                // if it's the owner password, having the owner permission
                if (hasOwnerAccess)
                {
                    // Allow user to make all processing and modifying to pdf file
                    // Such as adding a text in the beginning of the 1st page
                    XGraphics g = XGraphics.FromPdfPage(document.Pages[0]);
                    g.DrawString("Can be edited!", new XFont("Times New Roman", 12), XBrushes.Red, 20, 20);

                    // Save and show the document
                    document.Save("Unprotect.pdf");
                    Process.Start("Unprotect.pdf");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
