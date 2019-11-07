<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DynamicsStoredProcedure.index" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">





        <div class="container-fluid">
            <br />
            <div class="row">
                <div class="col-md-4">
                    <div class="page-header" style="margin: 10px 0 20px">
                        <h5>Configuration </h5>
                    </div>
              
                   
                    <div class="form-group">

                        <asp:DropDownList ID="ddlTableName" runat="server" CssClass="form-control" required OnSelectedIndexChanged="ddlTableName_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>

                    </div>

                    <div class="form-group">
                        <asp:DropDownList ID="ddlAutoidentity" runat="server" CssClass="form-control" required>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:DropDownList ID="ddlGetdate" runat="server" CssClass="form-control" required>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:DropDownList ID="ddluniqecolumn" runat="server" CssClass="form-control" required>
                        </asp:DropDownList>
                    </div>
                    <div style="text-align: center;">
                        <asp:Button ID="Button1" runat="server" Text="Run" CssClass="btn btn-warning" OnClick="Button1_Click" />
                    </div>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtQuery" TextMode="MultiLine" runat="server" Height="627px" Width="100%"></asp:TextBox>
                </div>
            </div>
        </div>




    </form>
</body>
</html>
