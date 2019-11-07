<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LinkScraper.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.0.3.min.js"></script>
    <link href="Styles/Site.css" rel="stylesheet" />
    <style>
        img {
            border: none;
        }

        .container {
            height: 360px;
            width: 910px;
            margin: -180px 0 0 -450px;
            top: 50%;
            left: 50%;
            position: absolute;
        }

        ul.thumb {
            float: left;
            list-style: none;
            margin: 0;
            padding: 10px;
            border-color: Green;
        }

            ul.thumb li {
                margin: 0;
                padding: 5px;
                float: left;
                position: relative;
                width: 110px;
                height: 110px;
            }

                ul.thumb li img {
                    width: 100px;
                    height: 100px;
                    border: 1px solid #ddd;
                    padding: 5px;
                    background: #f0f0f0;
                    position: absolute;
                    left: 0;
                    top: 0;
                    -ms-interpolation-mode: bicubic;
                }

                    ul.thumb li img.hover {
                        background: url(thumb_bg.png) no-repeat center center;
                        border: none;
                    }

        #main_view {
            float: left;
            padding: 9px 0;
            margin-left: -10px;
        }

        .addressBox {
            width: 300px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page">
            <div class="header">
                <div class="title">
                    <h1>Link scraper - like Facebook and G+
                    </h1>
                </div>
            </div>
            <div class="main">
                <div>
                    <label>Enter url Address</label>
                    <input id="url" type="text" class="addressBox" />
                    <input id="Scrape" type="button" value="Scrap" />
                </div>
                <br />


                <ul class="thumb">
                </ul>


                <div style="margin-left: auto; margin-right: auto; width: 120px; display: none" id="Loader">
                    <img src="ProgressBar/ajax-loader.gif" />
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="footer">
        </div>
        <script>
            $("#Scrape").click(function () {
                $('#Loader').show();
                $('.thumb').empty();

                var uri = 'api/Scrape';

                //Send an AJAX request
                var url = $("#url").val();

                $.post(uri, { '': url }) //Please check this link to know why http://encosia.com/using-jquery-to-post-frombody-parameters-to-web-api/
            .done(function (data) {
                $('.thumb').append(data);
                $('#Loader').hide();
            });

            });
        </script>
    </form>
</body>
</html>
