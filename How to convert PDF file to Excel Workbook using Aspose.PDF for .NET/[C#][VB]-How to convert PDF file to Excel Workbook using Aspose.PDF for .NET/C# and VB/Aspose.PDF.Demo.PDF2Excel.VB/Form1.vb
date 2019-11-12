Public Class Form1
    ReadOnly _license As License = New License()
    Dim pdfFileName As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog1.FileName = "Aspose-PDF2Excel-Demo.pdf"
        If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
            AddInvoiceData(SaveFileDialog1.FileName)
            Label2.Text = "Demo file generated"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        
        Dim xlsFileName As String
        
        If (String.IsNullOrWhiteSpace(pdfFileName))
            MessageBox.Show("Please, choose a file!", "Missing file!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
            
            
        Dim excelSaveOption = new ExcelSaveOptions With
        {
            .ScaleFactor = trackBar1.Value/100.0,
            .InsertBlankColumnAtFirst = checkBox1.Checked,
            .MinimizeTheNumberOfWorksheets = checkBox2.Checked                
        }
            
        if (radioButton1.Checked)
            xlsFileName = System.IO.Path.ChangeExtension(pdfFileName, "xml")
            excelSaveOption.Format = ExcelSaveOptions.ExcelFormat.XMLSpreadSheet2003
        else        
            xlsFileName = System.IO.Path.ChangeExtension(pdfFileName, "xlsx")
            excelSaveOption.Format = ExcelSaveOptions.ExcelFormat.XLSX
        End If
        SaveToExcel(asposeFilePdf:= pdfFileName, asposeFileXls:= xlsFileName, excelSaveOption:= excelSaveOption)
        label2.Text = $"File converted to {xlsFileName}"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LinkLabel1.Text = "To get a temporary license, please go to Aspose website."
        LinkLabel1.Links.Add(41, 6, "https://purchase.aspose.com/temporary-license")
        Label2.Text = String.Empty
    End Sub
    Private Shared Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal _
                                          e As LinkLabelLinkClickedEventArgs) Handles _
                                               LinkLabel1.LinkClicked
        Process.Start(e.Link.LinkData.ToString())
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog1.FileName = "Aspose.PDF.lic"
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            _license.SetLicense(OpenFileDialog1.FileName)
            Label1.Text = "Mode: Licensed version"
            Button2.Enabled = True
        End If
        OpenFileDialog1.FileName = String.Empty
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        openFileDialog1.Filter = "PDF files (*.pdf)|*.pdf"
        If ((openFileDialog1.ShowDialog() = DialogResult.OK))
                pdfFileName = openFileDialog1.FileName
                label2.Text = $"File to export: {pdfFileName}"
        End if                        
    End Sub
End Class
