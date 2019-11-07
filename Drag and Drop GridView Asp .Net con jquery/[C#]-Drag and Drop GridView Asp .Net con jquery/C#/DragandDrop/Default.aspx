<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DragandDrop.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="style.css" />
        <script type="text/javascript" src="Scripts/jquery-2.1.3.min.js"></script>
        <script type="text/javascript" src="Scripts/jquery-ui-1.11.2.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="Table">
            <div class="Title">
                <p>Drag and Drop Grid Asp</p>
            </div>
            <div class="Heading">
                <div class="Cell">
                    <p>Grid 1</p>
                </div>
                <div class="Cell">
                    <p>Grid 2</p>
                </div>
            </div>
            <div class="Row">
                <div class="Cell">
                    <asp:GridView ID="gvSource" runat="server" CssClass="drag_drop_grid GridSrc" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" />
                            <asp:BoundField DataField="Value" HeaderText="Value" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="Cell">
                    <asp:GridView ID="gvDest" runat="server" CssClass="drag_drop_grid GridDest" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" />
                            <asp:BoundField DataField="Value" HeaderText="Value" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

        <script type="text/javascript" src="DragandDropGridAsp.js"></script>
    </form>
</body>
</html>
