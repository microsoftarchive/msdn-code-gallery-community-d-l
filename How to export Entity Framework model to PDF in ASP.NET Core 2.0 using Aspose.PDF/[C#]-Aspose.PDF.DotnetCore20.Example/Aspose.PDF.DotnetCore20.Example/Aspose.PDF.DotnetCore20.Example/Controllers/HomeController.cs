using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.PDF.DotnetCore20.Example.DataLayer;
using Aspose.PDF.DotnetCore20.Example.Models;
using Aspose.PDF.DotnetCore20.Example.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Aspose.PDF.DotnetCore20.Example.Controllers
{
    public class HomeController : Controller
    {
        private const string reportTitle1 = "Report of tenant moving-in and payment";
        private const string reportTitle2 = "List of apartments";
        private readonly RentalDbContext _context;
        private IHostingEnvironment _hostingEnvironment;

        public HomeController(RentalDbContext context, IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["Report"] = reportTitle1;
            return View(_context.Tenants.ToList());
        }

        public IActionResult DemoTable()
        {
            // Create new a PDF document
            var document = new Document
            {
                PageInfo = new PageInfo { Margin = new MarginInfo(28, 28, 28, 42) }
            };

            var pdfPage = document.Pages.Add();

            // Initializes a new instance of the TextFragment for report's title 
            var textFragment = new TextFragment(reportTitle1);
            Table table = new Table
            {
                // Set column widths of the table
                ColumnWidths = "25% 25% 25% 25%",
                // Set cell padding
                DefaultCellPadding = new MarginInfo(10, 5, 10, 5), // Left Bottom Right Top
                // Set the table border color as Green
                Border = new BorderInfo(BorderSide.All, .5f, Color.Green),
                // Set the border for table cells as Black
                DefaultCellBorder = new BorderInfo(BorderSide.All, .2f, Color.Green),
            };
            for (var rowCount = 0; rowCount < 10; rowCount++)
            {
                // Add row to table
                var row = table.Rows.Add();
                // Add table cells
                for (int i = 0; i < 4; i++)
                {
                    row.Cells.Add($"Cell ({i + 1}, {rowCount + 1})");
                }
            }
            // Add table object to first page of input document
            document.Pages[1].Paragraphs.Add(table);
            using (var streamOut = new MemoryStream())
            {
                document.Save(streamOut);
                return new FileContentResult(streamOut.ToArray(), "application/pdf")
                {
                    FileDownloadName = "demotable.pdf"
                };
            }
        }
        
        public IActionResult Apartments()
        {
            ViewData["Report"] = reportTitle2;
            var appartments = _context.Apartments
                .GroupBy(apt => apt.Region, (key, group) =>
                new GroupViewModel<string, ApartmentView>
                {
                    Key = key,
                    Values = group.Select(g =>
                    new ApartmentView
                    { City = g.City, Address = g.Address, TotalArea = g.TotalArea }
                    )
                });
            return View(appartments);
        }

        public IActionResult TenantsToPDF()
        {
            var tenants = _context.Tenants.ToList();

            // Create new a PDF document
            var document = new Document
            {
                PageInfo = new PageInfo { Margin = new MarginInfo(28, 28, 28, 42) }
            };

            var pdfPage = document.Pages.Add();

            // Initializes a new instance of the TextFragment for report's title 
            var textFragment = new TextFragment(reportTitle1);

            // Set text properties
            textFragment.TextState.FontSize = 12;
            textFragment.TextState.Font = FontRepository.FindFont("TimesNewRoman");
            textFragment.TextState.FontStyle = FontStyles.Bold;

            // Initializes a new instance of the Table
            Table table = new Table
            {
                // Set column auto widths of the table
                ColumnWidths = "10 10 10 10 10 10",
                ColumnAdjustment = ColumnAdjustment.AutoFitToContent,
                // Set cell padding
                DefaultCellPadding = new MarginInfo(5, 5, 5, 5),
                // Set the table border color as Black
                Border = new BorderInfo(BorderSide.All, .5f, Color.Black),
                // Set the border for table cells as Black
                DefaultCellBorder = new BorderInfo(BorderSide.All, .2f, Color.Black),
            };

            table.DefaultCellTextState = new TextState("TimesNewRoman", 10);
            var paymentFormat = new TextState("TimesNewRoman", 10)
            {
                HorizontalAlignment = HorizontalAlignment.Right
            };
            table.SetColumnTextState(5, paymentFormat);
            table.ImportEntityList(tenants);

            //Repeat Header
            table.RepeatingRowsCount = 1;

            // Add text fragment object to first page of input document
            pdfPage.Paragraphs.Add(textFragment);
            // Add table object to first page of input document
            pdfPage.Paragraphs.Add(table);

            using (var streamOut = new MemoryStream())
            {
                document.Save(streamOut);
                return new FileContentResult(streamOut.ToArray(), "application/pdf")
                {
                    FileDownloadName = "tenants.pdf"
                };
            }
        }
        public IActionResult ApartmentsToPDF()
        {
            ViewData["Report"] = reportTitle2;
            var appartments = _context.Apartments
                .GroupBy(apt => apt.Region, (key, group) =>
                new GroupViewModel<string, ApartmentView>
                {
                    Key = key,
                    Values = group.Select(g =>
                       new ApartmentView
                       { City = g.City, Address = g.Address, TotalArea = g.TotalArea }
                    )
                });


            // Create new a PDF document
            var document = new Document
            {
                PageInfo = new PageInfo { Margin = new MarginInfo(28, 28, 28, 42) }
            };

            var pdfPage = document.Pages.Add();

            // Initializes a new instance of the TextFragment for report's title 
            var textFragment = new TextFragment(reportTitle2);

            // Set text properties
            textFragment.TextState.FontSize = 12;
            textFragment.TextState.Font = FontRepository.FindFont("TimesNewRoman");
            textFragment.TextState.FontStyle = FontStyles.Bold;

            // Initializes a new instance of the Table
            Table table = new Table
            {
                // Set column auto widths of the table
                ColumnWidths = "10 10 10",
                ColumnAdjustment = ColumnAdjustment.AutoFitToContent,
                // Set cell padding
                DefaultCellPadding = new MarginInfo(5, 5, 5, 5),
                // Set the table border color as Black
                Border = new BorderInfo(BorderSide.All, .5f, Color.Black),
                // Set the border for table cells as Black
                DefaultCellBorder = new BorderInfo(BorderSide.All, .2f, Color.Black),
            };

            table.DefaultCellTextState = new TextState("TimesNewRoman", 10);
            table.Margin.Left = 40;
            //Repeat Header
            table.RepeatingRowsCount = 1;

            table.ImportGroupedData(appartments);

            // Add text fragment object to first page of input document
            pdfPage.Paragraphs.Add(textFragment);
            // Add table object to first page of input document
            pdfPage.Paragraphs.Add(table);


            using (var streamOut = new MemoryStream())
            {
                document.Save(streamOut);
                return new FileContentResult(streamOut.ToArray(), "application/pdf")
                {
                    FileDownloadName = "tenants.pdf"
                };
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "This application demonstrate how to export data from EF model to table in PDF document using Aspose.PDF for .NET 17.12.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}



