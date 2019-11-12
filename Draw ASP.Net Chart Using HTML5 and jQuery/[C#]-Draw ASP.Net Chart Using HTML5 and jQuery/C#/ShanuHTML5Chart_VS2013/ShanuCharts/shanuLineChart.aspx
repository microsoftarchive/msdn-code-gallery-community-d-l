<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shanuLineChart.aspx.cs" Inherits="ShanuHTML5Chart_VS2013.ShanuCharts.shanuLineChart"  MasterPageFile="~/Site.Master"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="cphHead">
   
<script type="text/javascript">


        //Variable Declarations.
    //this variable will be used to check for the result of Alert Image display
    var alertCheckValue = 300;

        //Adding the Pic Chart Colors to array .Here i have fixed to 12 colors and 12 datas to add as Pic Chart.if you want you can add more from here.
        var pirChartColor = ["#6CBB3C", "#F87217", "#EAC117", "#EDDA74", "#CD7F32", "#CCFB5D", "#FDD017", "#9DC209", "#E67451", "#728C00", "#617C58", "#64E986"]; // green Color Combinations
        // var pirChartColor = ["#3090C7", "#BDEDFF", "#78C7C7", "#736AFF", "#7FFFD4", "#3EA99F", "#EBF4FA", "#F9B7FF", "#8BB381", "#BDEDFF", "#B048B5", "#4E387E"]; // Blue Color Combinations
        var lineColor = "#6CBB3C";
        var lineOuterCircleColor = "#3090C7";
        var lineInnerCircleColor = "#FFFFFF";

        //declare the 
        var canvas;
        var chartCTX;

        // declare the Border Space,Chart Start X and Y Position;
        var xSpace = 80;
        var ySpace = 80;
        //declare the Chart DrawWidth and Hegith
        var chartWidth, chartHeight;

        // declared the Chart Legend Width and Hegit
        var legendWidth, legendHeight;

        //declared the Chart data Minimum Value,maximum Value and Noofplots(Bars/Arc and Line points)
        var minDataVal, maxDataVal, noOfPlots;

        //here we declare the Image for the Chart legend alert status display.
        var greenImage = new Image();
        var redImage = new Image();
        //Alert Image Size widht and hegith
        var imagesize = 20;
        var maxValdivValue;
        //Here we declare the X,YAxis Font size and Color
        var fotnColor = "#000000";
        var axisfontSize = 10;

        var LogoImage = new Image();
        var LogoImgWidth = 120;
        var LogoImgHeight = 70;
        //

        //This method will be used to check for user selected Color Theme and Change the color
        function ChangeChartColor() {

            if ($('#cphBody_rdoColorGreen:checked').val() == "rdoColorGreen") {
                pirChartColor = ["#6CBB3C", "#F87217", "#EAC117", "#EDDA74", "#CD7F32", "#CCFB5D", "#FDD017", "#9DC209", "#E67451", "#728C00", "#617C58", "#64E986"]; // green Color Combinations
                lineColor = "#3090C7"; // Blue Color for Line
                lineOuterCircleColor = "#6CBB3C"; // Green Color for Outer Circle
            }
            else {
                pirChartColor = ["#3090C7", "#BDEDFF", "#78C7C7", "#736AFF", "#7FFFD4", "#3EA99F", "#EBF4FA", "#F9B7FF", "#8BB381", "#BDEDFF", "#B048B5", "#4E387E"]; // Blue Color Combinations
                lineColor = "#F87217";  // Orange Color for the Line
                lineOuterCircleColor = "#F70D1A "; // Red Color for the outer circle
            }
        }


        function getXPlotvalue(val) {

            return (Math.round((chartWidth - xSpace) / noOfPlots)) * val + (xSpace * 1.5);
        }

        // Return the y pixel for a graph point
        function getYPlotVale(val) {
            return chartHeight - (((chartHeight - xSpace) / maxDataVal) * val);
        }

        // This is the main function to darw the Charts
        function drawChart() {
            ChangeChartColor();
            // asign the images path for both Alert images
            greenImage.src = '../images/Green.png';
            redImage.src = '../images/Red.png';

            LogoImage.src = '../images/shanu.jpg';

            // Get the minumum and maximum value.here i have used the hidden filed from code behind wich will stored the Maximum and Minimum value of the Drop down list box.
            minDataVal = $('#cphBody_hidListMin').val();
            maxDataVal = $('#cphBody_hidListMax').val();
            // Total no of plots we are going to draw.
            noOfPlots = $("#cphBody_DropDownList1 option").length;
            maxValdivValue = Math.round((maxDataVal / noOfPlots));
           
            //storing the Canvas Context to local variable ctx.This variable will be used to draw the Pie Chart
            canvas = document.getElementById("canvas");
            ctx = canvas.getContext("2d");
            //globalAlpha - > is used to display the 100% opoacity of chart .because at the bottom of the code I have used the opacity to 0.1 to display the water mark text with fade effect.
            ctx.globalAlpha = 1;
            ctx.fillStyle = "#000000";
            ctx.strokeStyle = '#000000';
            //Every time we clear the canvas and draw the chart 
            ctx.clearRect(0, 0, canvas.width, canvas.height);

            //If need to draw with out legend for the Line Chart
            chartWidth = canvas.width - xSpace;
            chartHeight = canvas.height - ySpace;

            var chartMidPosition = chartWidth / 2 - 60;

            ////        //If need to draw with legend
            ////        chartWidth = canvas.width - ((canvas.width / 3) - (xSpace / 2));
            ////        chartHeight = canvas.height - ySpace - 10;


            // Step 0 ) +++++++++++++ To Add Chart Titel and  Company Logo
            //To Add Logo to Chart



            var logoXVal = canvas.width - LogoImgWidth - 10;
            var logolYVal = 0;

            //here we draw the Logo for teh chart and i have used the alpha to fade and display the Logo.
            ctx.globalAlpha = 0.6;

            ctx.drawImage(LogoImage, logoXVal, logolYVal, LogoImgWidth, LogoImgHeight);

            ctx.globalAlpha = 1;

            ctx.font = '22pt Calibri';
            ctx.fillStyle = "#15317E";
            ctx.fillText($('#cphBody_txtTitle').val(), chartMidPosition, chartHeight + 60);


            ctx.fillStyle = "#000000";
            ctx.font = '10pt Calibri';



            // +++++++++++ End of Title and Company Logo Add

            // Step 1 ) +++++++++++++ toDraw the X-Axis and Y-Axis

            //  >>>>>>>>> Draw Y-Axis and X-Axis Line(Horizontal Line)
            // Draw the axises
            ctx.beginPath();
            ctx.moveTo(xSpace, ySpace);
            // first Draw Y Axis
            ctx.lineTo(xSpace, chartHeight);

            // Next draw the X-Axis
            ctx.lineTo(chartWidth, chartHeight);
            ctx.stroke();
            //  >>>>>>>>>>>>> End of X-Axis Line Draw
            //+++++++++++++++++++++++


            // Step 2) <<<<<<<<<<<<<<<<<<<<<<< To Draw X - Axis Plot Values <<<<<<<<<<<<< }}}}}}
            // Draw the X value texts
            var ival = 0;
            $('#cphBody_DropDownList1 option').each(function () {
                ////            ctx.fillStyle = fotnColor;
                ////            ctx.font = axisfontSize + 'pt Calibri';
                ctx.fillText("Line" + parseInt(ival + 1), getXPlotvalue(ival) - 14, chartHeight + 20);

                //Here we draw the X-Axis point line
                ctx.beginPath();
                ctx.moveTo(getXPlotvalue(ival), chartHeight);

                ctx.lineTo(getXPlotvalue(ival), chartHeight + 12);
                ctx.stroke();
                ival = ival + 1;
            });

            //  <<<<<<<<<<<<<<<<<<<<<<< End of X Axis Draw

            // Step 3) ++++++++++++++


            // {{{{{{{{{{{{{To Draw the Y Axis Plot Values}}}}}}}}}}}}}}
            var vAxisPoints = 0;
            var max = maxDataVal;
            max += 10 - max % 10;
            for (var i = 0; i <= maxDataVal; i += maxValdivValue) {

                ctx.fillStyle = fotnColor;
                ctx.font = axisfontSize + 'pt Calibri';
                ctx.fillText(i, xSpace - 40, getYPlotVale(i));

                //Here we draw the Y-Axis point line
                ctx.beginPath();
                ctx.moveTo(xSpace, getYPlotVale(i));

                ctx.lineTo(xSpace - 10, getYPlotVale(i));
                ctx.stroke();
                vAxisPoints = vAxisPoints + maxValdivValue;


            }

            //{{{{{{{{{{{{{{ End of Y- Axis Plot Values

            //+++++++++++++++++++++++


            //Step 4) *********************************************************
            //Function to Draw our Chart here we can Call/Bar Chart/Line Chart or Pie Chart

            drawLineChart();

            // **************

            //Step 5)  :::::::::::::::::::: to add the Water mark Text

            // Here add the Water mark text at center of the chart
            ctx.globalAlpha = 0.1;
            ctx.font = '86pt Calibri';
            ctx.fillStyle = "#000000";
            ctx.fillText($('#cphBody_txtWatermark').val(), chartMidPosition - 40, chartHeight / 2);

            ctx.font = '10pt Calibri';
            ctx.globalAlpha = 1;
            /// ::::::::::::::::::::::::::::::::::::::
        }
        function drawLineChart() {

            // For Drawing Line
            ctx.lineWidth = 3;
            var value = $('select#cphBody_DropDownList1 option:selected').val();
            // alert(value);
            ctx.beginPath();

            // *************** To Draw the Line and Plot Value in Line
            ctx.fillStyle = "#FFFFFF";
            ctx.strokeStyle = '#FFFFFF';
            ctx.moveTo(getXPlotvalue(0), getYPlotVale(value));

            ctx.fillStyle = "#000000";
            ctx.font = '12pt Calibri';
            ctx.fillText(value, getXPlotvalue(0), getYPlotVale(value) - 12);

            var ival = 0;
            $('#cphBody_DropDownList1 option').each(function () {

                if (ival > 0) {
                    ctx.lineTo(getXPlotvalue(ival), getYPlotVale($(this).val()));
                    ctx.stroke();

                    ctx.fillStyle = "#000000";
                    ctx.font = '12pt Calibri';
                    ctx.fillText($(this).val(), getXPlotvalue(ival), getYPlotVale($(this).val()) - 16);
                }
                ival = ival + 1;
                ctx.fillStyle = lineColor;
                ctx.strokeStyle = lineColor;
            });



            // *************** To Draw the Line Dot Cericle

            //For Outer Blue Dot

            ival = 0;
            $('#cphBody_DropDownList1 option').each(function () {
                ctx.fillStyle = lineOuterCircleColor;
                ctx.strokeStyle = lineOuterCircleColor;
                ctx.beginPath();
                ctx.arc(getXPlotvalue(ival), getYPlotVale($(this).val()), 7, 0, Math.PI * 2, true);
                ctx.fill();

                ctx.fillStyle = lineInnerCircleColor;
                ctx.strokeStyle = lineInnerCircleColor;
                ctx.beginPath();
                ctx.arc(getXPlotvalue(ival), getYPlotVale($(this).val()), 4, 0, Math.PI * 2, true);
                ctx.fill();
                ival = ival + 1;
            });

            ctx.lineWidth = 1;
        }


        //Save as Image file
        function ShanuSaveImage() {

            var m = confirm("Are you sure to Save ");
            if (m) {
                if (navigator.appName == 'Microsoft Internet Explorer') {

                    var image_NEW = document.getElementById("canvas").toDataURL("image/png");
                    image_NEW = image_NEW.replace('data:image/png;base64,', '');

                    $.ajax({
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        url: 'shanuLineChart.aspx/SaveImage',
                        data: '{ "imageData" : "' + image_NEW + '" }',
                        async: false,
                        success: function (msg) {
                            alert(msg.d);
                        },
                        error: function () {
                            alert("Pie Chart Not Saved");
                        }

                    });
                }
                else {
                    // save image without file type
                    var canvas = document.getElementById("canvas");
                    document.location.href = canvas.toDataURL("image/png").replace("image/png", "image/octet-stream");

                    var ImageSave = document.createElement('a');
                    ImageSave.download = "shanuPIEImage.png";
                    ImageSave.href = canvas.toDataURL("image/png").replace("image/png", "image/octet-stream");
                    ImageSave.click();
                    alert("Image Saved");
                }
            }

        }


</script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="cphBody">
    <table   style='width: 99%;table-layout:fixed;'>
             <tr>
                 <td >
                    <table  width="100%" >
                     <tr>
                        <td class="style1" align=left>
                         <table  width="100%" style=" background-color: #ECF3F4; border-bottom:3px solid #3273d5;">
                         <tr>
                         <td   >
                         <h2 style="color:#465c71;"><b>Line Chart</b></h2>
                         </td>
                         </tr>
                         </table>
                        </td>
                    </tr>    
                    <tr >
                    <td>
                    <img src="~/Images/blank.gif" alt="" width="1" height="10" />
           <table   style="  padding: 5px;width: 99%;table-layout:fixed; border-bottom:3px solid #3273d5;">
             <tr>
                 <td >
                    <table  width="100%"  style="border:1px solid #C7C7C7;padding:3px 9px 2px 9px;">
                     <tr>        
  
             <td  style="background-color:#ECF3F4; border-right:1px solid #C7C7C7;" width="180" >
                 Enter Line Chart Draw Count:

             </td>
             <td width="150">

          
        <asp:TextBox ID="txtChartCount" runat="server" Height="26px" MaxLength="2" Width="90"
onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;" >7</asp:TextBox><br />
                 <asp:RangeValidator ID="RangeValidator1" Type="Integer" MinimumValue="1" MaximumValue="12" ControlToValidate="txtChartCount" runat="server" ErrorMessage="No <= 12"></asp:RangeValidator> 
                    </td>
             <td  style="background-color:#ECF3F4; border-right:1px solid #C7C7C7;" >
                 Click Button to fill Line Chart Data:

             </td>
             <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="140px" Height="36px">
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Populate List" BackColor="#336699" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="#CCFFFF" Height="37px" />
                  </td>
       <td style="background-color:#ECF3F4; border-right:1px solid #C7C7C7;">
        Select Color /Legend display 
           </td>
                <td   >
                <asp:RadioButton ID="rdoColorGreen" runat="server" Checked="True" 
                     GroupName="Colors" Text="Blue Theme" />
                 <asp:RadioButton ID="rdoColorBlue" runat="server" GroupName="Colors" 
                     Text="Red Theme" />
          <b>&nbsp; / </b>
                 &nbsp;<asp:CheckBox ID="chkLegend" runat="server" 
                        Text="Show Legend" Enabled="False" />

             </td>
             <td rowspan="2" style="background-color:#ebebeb;border-right:1px solid #C7C7C7;"">
             Click to Draw Chart:
             </td>
             <td rowspan="2">

           
   <img src="../images/line.png"  onClick="drawChart()" alt="Click to Draw PIE Chart" />
                   </td>
                  <td  style="background-color:#ebebeb;border-right:1px solid #C7C7C7;" rowspan="2">
               Save Chart:

             </td>
             <td rowspan="2">
     <img src="../images/Save.png"  onClick="ShanuSaveImage()" alt="Click to Save PIE Chart" />
                 </td>
                 
                      </tr>
                        

                            <tr>        
  
             <td  style="background-color:#ECF3F4;border-right:1px solid #C7C7C7;" width="180" >
                 Enter Chart Title:

             </td>
             <td >

          
        <asp:TextBox ID="txtTitle" runat="server" Height="26px" MaxLength="40" Width="140px" >SHANU Line Chart</asp:TextBox><br />
                 </td>
                                 <td  style="background-color:#ECF3F4;border-right:1px solid #C7C7C7;" >
                                     Chart WaterMark:

             </td>
             <td >

          
        <asp:TextBox ID="txtWatermark" runat="server" Height="26px" MaxLength="40" Width="120px" >SHANU</asp:TextBox><br />
                 </td>
                                 <td  style="background-color:#ECF3F4;border-right:1px solid #C7C7C7;" >
                                     Alert Status </td>
             <td >

           <asp:RadioButton ID="rdoAlaramOn" runat="server" Checked="True" GroupName="Alaram" 
                     Text="Alert On" Enabled="False" />
                 <asp:RadioButton ID="rdoAlaramOff" runat="server" GroupName="Alaram" 
                     Text="Alert Off" Enabled="False" />

                 
          
                 </td>
                        </tr>
        </table>
                     </td>
                 </tr>
               </table>
                 <img src="~/Images/blank.gif" alt="" width="1" height="10" />
                   <table width="99%" class="search">          
    <table style=" solid 2px #3273d5; padding: 5px;width: 99%;table-layout:fixed; "> 
         <tr>
             <td align="center">
<SECTION style="border-style: solid; border-width: 2px; width: 800px;">

<CANVAS HEIGHT="600px" WIDTH="800px" ID="canvas">
Your browser is not supporting HTML5 Canvas .Upgrade Browser to view this program or check with Chrome or in Firefox.
</CANVAS>

</SECTION>
                 </td>
             </tr>
        </table>
         <asp:HiddenField ID="hidFirstVal" runat="server" />
          <asp:HiddenField ID="hidListMax" runat="server" />
                       <asp:HiddenField ID="hidListMin" runat="server" />
                    </td>

                   </tr>
                   </table>
           
          
            </td>
        </tr>
    </table>
   
</asp:Content>
