Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text
Imports System.Threading

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindGridDetails(GridView1)
        End If
    End Sub
    Protected Function BindGridDetails(ByVal GridView1 As GridView) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Student_ID", GetType(Int32))
        dt.Columns.Add("Student_Name", GetType(String))
        dt.Columns.Add("Education", GetType(String))
        dt.Columns.Add("City", GetType(String))
        Dim dtrow As DataRow = dt.NewRow()
        dtrow("Student_ID") = 1
        dtrow("Student_Name") = "Musakkhir"
        dtrow("Education") = "MCA"
        dtrow("City") = "Pune"
        dt.Rows.Add(dtrow)
        dtrow = dt.NewRow()
        dtrow("Student_ID") = 2
        dtrow("Student_Name") = "Azhar"
        dtrow("Education") = "M.E"
        dtrow("City") = "Mumbai"
        dt.Rows.Add(dtrow)
        dtrow = dt.NewRow()
        dtrow("Student_ID") = 3
        dtrow("Student_Name") = "Pervaiz"
        dtrow("Education") = "M.Tech"
        dtrow("City") = "Pune"
        dt.Rows.Add(dtrow)
        dtrow = dt.NewRow()
        dtrow("Student_ID") = 4
        dtrow("Student_Name") = "Mustaheer"
        dtrow("Education") = "M.S."
        dtrow("City") = "Pune"
        dt.Rows.Add(dtrow)
        GridView1.DataSource = dt
        GridView1.DataBind()
        Return dt
    End Function

    Protected Sub btnWord_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnWord.Click
        Dim form As New HtmlForm()
        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", "Student.doc"))
        Response.ContentType = "application/ms-msword"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        GridView1.AllowPaging = False
        BindGridDetails(GridView1)
        form.Attributes("runat") = "server"
        form.Controls.Add(GridView1)
        Me.Controls.Add(form)
        form.RenderControl(hw)
        Dim style As String = "<style> .textmode { mso-number-format:\@;}</style>"
        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.[End]()
    End Sub

    Protected Sub btnAccess_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAccess.Click

        Dim form__1 As New HtmlForm()
        GridView1.AllowPaging = False
        BindGridDetails(GridView1)
        Response.ClearContent()
        Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Customers.accdb"))
        Response.Charset = ""
        Response.ContentType = "application/ms-access"
        Dim sw As New StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        form__1.Attributes("runat") = "server"
        form__1.Controls.Add(GridView1)
        Me.Controls.Add(form__1)
        Form.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.Flush()
        Response.[End]()
    End Sub

    Protected Sub btnExportImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExportImage.Click

        ConvertDG2BMP(GridView1, "c:/myscreen.bmp")
    End Sub

    Public Shared Sub ConvertDG2BMP(ByVal gdview As GridView, ByVal sFilePath As String)
        Dim bitmap As New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)

        Dim graphics__1 As Graphics = Graphics.FromImage(TryCast(bitmap, System.Drawing.Image))
        graphics__1.CopyFromScreen(25, 25, 25, 25, bitmap.Size)
        bitmap.Save("c:/myscreenshot.bmp", ImageFormat.Bmp)
    End Sub

    Protected Sub btnExportCSV_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExportCSV.Click
        BindGridDetails(GridView1)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=Student.csv")
        Response.Charset = ""
        Response.ContentType = "application/text"
        GridView1.AllowPaging = False
        GridView1.DataBind()
        Dim sb As New StringBuilder()
        For k As Integer = 0 To GridView1.Columns.Count - 1
            'add separator
            sb.Append(GridView1.Columns(k).HeaderText + ","c)
        Next
        'append new line
        sb.Append(vbCr & vbLf)
        For i As Integer = 0 To GridView1.Rows.Count - 1
            For k As Integer = 0 To GridView1.Columns.Count - 1
                'add separator
                sb.Append(GridView1.Rows(i).Cells(k).Text + ","c)
            Next
            'append new line
            sb.Append(vbCr & vbLf)
        Next
        Response.Output.Write(sb.ToString())
        Response.Flush()
        Response.[End]()

    End Sub

    Protected Sub btnExcelExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExcelExport.Click
        Dim form As New HtmlForm()
        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", "Student.xls"))
        Response.ContentType = "application/ms-excel"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        GridView1.AllowPaging = False
        BindGridDetails(GridView1)
        form.Attributes("runat") = "server"
        form.Controls.Add(GridView1)
        Me.Controls.Add(form)
        form.RenderControl(hw)
        Dim style As String = "<style> .textmode { mso-number-format:\@;}</style>"
        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.[End]()
    End Sub

    Protected Sub btnExportPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExportPDF.Click
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=Student.pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        GridView1.AllowPaging = False
        Dim frm As New HtmlForm()
        GridView1.Parent.Controls.Add(frm)
        frm.Attributes("runat") = "server"
        frm.Controls.Add(GridView1)
        frm.RenderControl(hw)
        GridView1.DataBind()
        Dim sr As New StringReader(sw.ToString())
        Dim pdfDoc As New iTextSharp.text.Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)
        Dim htmlparser As New HTMLWorker(pdfDoc)
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        pdfDoc.Open()
        htmlparser.Parse(sr)
        pdfDoc.Close()
        Response.Write(pdfDoc)
        Response.[End]()
    End Sub

    Protected Sub btnXML_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnXML.Click
        Dim staThread As New Thread(New ThreadStart(AddressOf XMLExport))
        staThread.ApartmentState = ApartmentState.STA
        staThread.Start()
    End Sub
    Public Sub XMLExport()
        Dim saveDialog As New SaveFileDialog()
        saveDialog.Filter = "Xml files (*.xml)|*.xml"
        saveDialog.FilterIndex = 2
        saveDialog.RestoreDirectory = True
        saveDialog.InitialDirectory = "c:\"
        saveDialog.FileName = "Student"
        saveDialog.Title = "XML Export"
        If saveDialog.ShowDialog() = DialogResult.OK Then
            BindGridDetails(GridView1)
            Dim ds As New DataSet()
            Dim dt As DataTable = DirectCast(GridView1.DataSource, DataTable)
            ' ds.WriteXml(File.OpenWrite(saveDialog.FileName));
            ds.Tables.Add(dt)
        End If
    End Sub

    Protected Sub btnHTML_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHTML.Click
        Dim form__1 As New HtmlForm()
        GridView1.AllowPaging = False
        BindGridDetails(GridView1)
        Response.ClearContent()
        Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Student.html"))
        Response.Charset = ""
        Response.ContentType = "text/html"
        Dim sw As New StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        form__1.Attributes("runat") = "server"
        form__1.Controls.Add(GridView1)
        Me.Controls.Add(form__1)
        Form.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.Flush()
        Response.[End]()
    End Sub

    Protected Sub btnText_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnText.Click

        BindGridDetails(GridView1)
        GridView1.DataBind()
        Response.ClearContent()
        Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Student.txt"))
        Response.ContentType = "application/text"
        Dim str As New StringBuilder()
        For i As Integer = 0 To GridView1.Columns.Count - 1
            str.Append(GridView1.Columns(i).HeaderText + " "c)
        Next
        str.Append(vbCr & vbLf)
        For j As Integer = 0 To GridView1.Rows.Count - 1
            For k As Integer = 0 To GridView1.Columns.Count - 1
                str.Append(GridView1.Rows(j).Cells(k).Text + " "c)
            Next
            str.Append(vbCr & vbLf)
        Next
        Response.Write(str.ToString())
        Response.[End]()
    End Sub
End Class