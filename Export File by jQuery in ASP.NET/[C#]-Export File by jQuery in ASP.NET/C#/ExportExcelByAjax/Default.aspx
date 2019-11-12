<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExportExcelByAjax.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Demo Export Excel By Ajax Technique</title>
</head>
<body>
	<form id="frm" class="mainForm" runat="server">
		<div>
			<h2>Export Excel By jQuery Unified Export File</h2>
			<asp:GridView ID="grdView" DataKeyNames="PersonID" AllowPaging="true" OnPageIndexChanging="grdView_PageIndexChanging" AutoGenerateColumns="false" runat="server">
				<Columns>
					<asp:BoundField DataField="FirstName" HeaderText="First Name"/>
					<asp:BoundField DataField="LastName" HeaderText="Last Name"/>
					<asp:BoundField DataField="Birthday" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Birthday"/>
					<asp:BoundField DataField="BirthPlace" HeaderText="Birth place"/>
				</Columns>
			</asp:GridView>
			<div>
				<img id="loading" src="Images/301.gif" width="30" height="30" style="display: none"/>
			</div>
			<input type="button" class="export-excel" value="Export Excel"/>
		</div>
	</form>
	<script src="<%= Page.ResolveUrl("~/Scripts/jquery-1.7.2.min.js") %>"></script>
	<script src="<%= Page.ResolveUrl("~/Scripts/jquery-unified-export-file-1.0.js") %>"></script>
	<script type="text/javascript">
		$(function () {
			$('input.export-excel').bind('click', function () {
				/*
					$.UnifiedExportFile({
						action: '/Default.aspx',
						data: { IsExportExcel: true },
						downloadType: 'Normal',
						ajaxLoadingSelector: '#loading'
					});

					$.UnifiedExportFile({
						action: '/Default.aspx',
						data: { IsExportExcel: true },
						downloadType: 'ProgressBar',
						ajaxLoadingSelector: '#loading'
					});
				});
				*/
				$.UnifiedExportFile({
					action: '/Default.aspx',
					data: { IsExportExcel: true },
					downloadType: 'Progress',
					ajaxLoadingSelector: '#loading'
				});
			});
		});
	</script>
</body>
</html>
