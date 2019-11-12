using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Pdf;
using Spire.License;

namespace ConvertPdfToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            Spire.License.LicenseProvider.SetLicenseKey("iEQLj4jdOAEAIQQAz+6KYItEYQW3T7tHTFT3ARbDmRFor8+AtOQOUvOToTO/Vswq1LOiuwfPz/QVxpOJv5AL/5cRKjd8Y7rCwMwI7DRsaCT1FzVQuiVUZq+ZJ71sKcH+fhLQcPVgjfvTw4gjyFHDFxpjUB35CwGJI/eoPmWdWDqHXzVqmQeeugcw43AdBVfd+0bi5uytY4H5XnoMCiRFEamdiUhT/yFQOXqQd9F+FW9Uh1XKP3Tk529igurmjjgtI0V+tk0L6e+qQdGr8IdyOJBro3F+ZTtYF6uT1YzO6dGt75P/qrUWSRODvFhIn0JD78dOV31/PB6EmlnpPRnYtca6NacWpNkkjXO3355SnwiqdJfSC2GgVUcduCODK3Dbn6Y3wC9WyuEq5HrgzUqhMpUV03MYgKsmCHYEvWexjZ0SE2G6wXEVtEyPDRrTSE7IBDnLAdFMVGtSmmOx9Pe6N0XLoP0RnNLF2CspNboWQvSP6VjtgGrsnbgyp5V6XqeceN8HRr7MOKyC2qbyENXFsoIp6l1kcxgGJA3sMl2fUEkgT7W0sV0LepKgqFdcmGMrLt2xCr2HZhB+F8wtHso3VjngQtemAe7MAWYU8y9UzbRBSrJw8DNJkAzzmFjlZgcmKnJcoI2f5/mVewi4mioHS6qDDMZyrDMG0wWIPz9Bq4i6GPukiM6ZfloRCecYwymNtcy/kg965tDtZ7+0qkq7Zi2tS4eSoXUd5+hl7WkJ6SNqLtQbwJAhdYZtvvvxNOV4korrxqRATIJ8Km1YmjdiuAKjo9e1seqZuX7qETKH1WMrXQr8g5YEi8ed+ZYAgIngK/uAQK0KRck7Q1oJjyYu1d/swkj5mk82TTYmHqzi/q5FF71MDGGyqaC6Dg1DzLDW0KTcUav7DYsMi/AKps/ZKAr4JOpiEqH7sscdKEhvUghgqEjmh4yetQ8SqSqNsG5dPxigSzSXyA8eaoUl5lvJ42+rqjINcx8WwS8Y/CxtkNXoRTdMVfXyxg5bNb0V90HX9TJWg2pWOm5MP78IPb5jxtkYztTVad90vYwG6f3Fv0fYSW5rE0ZnVX1N8uvvbRJVmXO3iJ1tMJep3tu7xJrJQY4tQLQjaL3VkxSCMjlgE89qEkSOGyXT1WEhjB78nacB2Psuo3EX0qtXmOKiqu4LEOP/Ydq6Of0vNY8L1fRzAkTrCxL3/ty4BenLU0KLQjP64c7if7RqU+TP4eGm/7CPTg7rWMbqVkBBN2fmOWbjDPd6RXITeOfosnEXhUiCB8CFX9S23l2flVcBx0vh2vyB2ttzNP+FpbMGpdm/0Ati21IfvNAOOOrE00DZaZ2p598iznVCQ7AkMDMrcr6k94C7VvByFG+JVt9dBqFtbW+OeXoNpZIQ90WgbjBEc0K2CeBoEcxq6BvCscEtEzN2Wjz+Znkyncw/0y9QDVyjRXT1EI0=");

            //create PdfDocument instance and load file
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"../../sample.pdf");
            
            //convert to XPS file format
            doc.SaveToFile(@"../../result.xps",FileFormat.XPS);
            doc.Close();
        }
    }
}
