/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Description;
using System.Web.Services;
using System.Web;
using System.Net;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Security.Permissions;
using System.IO;

namespace WSDLToWebService
{
    public static class WebServiceGenerator
    {
        public static void Generate(string wsdlPath, string outputFilePath)
        {
            if (File.Exists(wsdlPath) == false)
            {
                return;
            }

            ServiceDescription wsdlDescription = ServiceDescription.Read(wsdlPath);
            ServiceDescriptionImporter wsdlImporter = new ServiceDescriptionImporter();

            wsdlImporter.ProtocolName = "Soap12";
            wsdlImporter.AddServiceDescription(wsdlDescription, null, null);
            wsdlImporter.Style = ServiceDescriptionImportStyle.Server;

            wsdlImporter.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties;

            CodeNamespace codeNamespace = new CodeNamespace();
            CodeCompileUnit codeUnit = new CodeCompileUnit();
            codeUnit.Namespaces.Add(codeNamespace);

            ServiceDescriptionImportWarnings importWarning = wsdlImporter.Import(codeNamespace, codeUnit);

            if (importWarning == 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                StringWriter stringWriter = new StringWriter(stringBuilder);

                CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
                codeProvider.GenerateCodeFromCompileUnit(codeUnit, stringWriter, new CodeGeneratorOptions());

                stringWriter.Close();

                File.WriteAllText(outputFilePath, stringBuilder.ToString(), Encoding.UTF8);
            }
            else
            {
                Console.WriteLine(importWarning);
            }
        }
    }
}
