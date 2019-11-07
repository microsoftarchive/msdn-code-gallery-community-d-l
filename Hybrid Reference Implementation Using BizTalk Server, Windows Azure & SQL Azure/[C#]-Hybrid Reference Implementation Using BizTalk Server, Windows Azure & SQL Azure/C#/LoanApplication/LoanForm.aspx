<%@ Page Title="Loan Application Form" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="LoanForm.aspx.cs" Inherits="Contoso.Cloud.Integration.Demo.LoanApplication.LoanForm" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 387px;
        }
        .style2
        {
            width: 632px;
        }
        .style3
        {
            width: 389px;
        }
    </style>
</asp:Content>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <table cellpadding="10">
    <caption>TELL US A LITTLE ABOUT YOURSELF AND YOUR REFINANCE LOAN NEEDS</caption> 
        <tr>
            <td class="style2">
                <div class="board-content-data">
                    <div class="dropdown-item">
                        <div>
                            <asp:Label ID="lblPropertyType" runat="server">What type of property do you have?</asp:Label></div>
                        <asp:DropDownList ID="ddlPropertyType" runat="server">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem>Single family home</asp:ListItem>
                            <asp:ListItem>Townhome</asp:ListItem>
                            <asp:ListItem>Condo</asp:ListItem>
                            <asp:ListItem>Multi family dwelling</asp:ListItem>
                            <asp:ListItem>Mobile/Manufactured Home</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div>
                        <div>
                            <asp:Label ID="lblPropertyUse" runat="server">How is the property used?</asp:Label>
                        </div>
                        <asp:DropDownList ID="ddlPropertyUse" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem>Primary Residence</asp:ListItem>
                            <asp:ListItem>Secondary Home</asp:ListItem>
                            <asp:ListItem>Investment Property</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <!--End .dropdown-item-->
                    <br />
                    <div class="dropdown-item">
                        <div>
                            <asp:Label ID="lblCredit" runat="server">How would you describe your credit?   </asp:Label></div>
                        <asp:DropDownList ID="ddlCredit" runat="server">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem>Excellent</asp:ListItem>
                            <asp:ListItem>Good</asp:ListItem>
                            <asp:ListItem>Fair</asp:ListItem>
                            <asp:ListItem>Poor</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <hr />
    <table cellpadding="10">
    <caption >
                    TELL US ABOUT YOUR PROPERTY & CURRENT MORTGAGE</caption>
        <tr>
            <td class="style1" align="left" valign="top">
                <div>
                    <div>
                        <asp:Label ID="lblPropertyZip" runat="server">What is your property ZIP Code?</asp:Label></div>
                    <asp:TextBox ID="tbPropertyZip" runat="server"></asp:TextBox>
                </div>
                <br />
                <div>
                    <div>
                        What is your estimated home value?
                    </div>
                    <asp:DropDownList ID="ddlEstimatedHomeValue" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="100000">$90,001 - $100,000</asp:ListItem>
                        <asp:ListItem Value="110000">$100,001 - $110,000</asp:ListItem>
                        <asp:ListItem Value="120000">$110,001 - $120,000</asp:ListItem>
                        <asp:ListItem Value="130000">$120,001 - $130,000</asp:ListItem>
                        <asp:ListItem Value="140000">$130,001 - $140,000</asp:ListItem>
                        <asp:ListItem Value="150000">$140,001 - $150,000</asp:ListItem>
                        <asp:ListItem Value="160000">$150,001 - $160,000</asp:ListItem>
                        <asp:ListItem Value="170000">$160,001 - $170,000</asp:ListItem>
                        <asp:ListItem Value="180000">$170,001 - $180,000</asp:ListItem>
                        <asp:ListItem Value="190000">$180,001 - $190,000</asp:ListItem>
                        <asp:ListItem Value="200000">$190,001 - $200,000</asp:ListItem>
                        <asp:ListItem Value="225000">$200,001 - $225,000</asp:ListItem>
                        <asp:ListItem Value="250000">$225,001 - $250,000</asp:ListItem>
                        <asp:ListItem Value="275000">$250,001 - $275,000</asp:ListItem>
                        <asp:ListItem Value="300000">$275,001 - $300,000</asp:ListItem>
                        <asp:ListItem Value="325000">$300,001 - $325,000</asp:ListItem>
                        <asp:ListItem Value="350000">$325,001 - $350,000</asp:ListItem>
                        <asp:ListItem Value="375000">$350,001 - $375,000</asp:ListItem>
                        <asp:ListItem Value="400000">$375,001 - $400,000</asp:ListItem>
                        <asp:ListItem Value="425000">$400,001 - $425,000</asp:ListItem>
                        <asp:ListItem Value="450000">$425,001 - $450,000</asp:ListItem>
                        <asp:ListItem Value="475000">$450,001 - $475,000</asp:ListItem>
                        <asp:ListItem Value="500000">$475,001 - $500,000</asp:ListItem>
                        <asp:ListItem Value="550000">$500,001 - $550,000</asp:ListItem>
                        <asp:ListItem Value="600000">$550,001 - $600,000</asp:ListItem>
                        <asp:ListItem Value="650000">$600,001 - $650,000</asp:ListItem>
                        <asp:ListItem Value="700000">$650,001 - $700,000</asp:ListItem>
                        <asp:ListItem Value="750000">$700,001 - $750,000</asp:ListItem>
                        <asp:ListItem Value="800000">$750,001 - $800,000</asp:ListItem>
                        <asp:ListItem Value="850000">$800,001 - $850,000</asp:ListItem>
                        <asp:ListItem Value="900000">$850,001 - $900,000</asp:ListItem>
                        <asp:ListItem Value="950000">$900,001 - $950,000</asp:ListItem>
                        <asp:ListItem Value="1000000">$950,001 - $1,000,000</asp:ListItem>
                        <asp:ListItem Value="1000001">Over $1,000,000</asp:ListItem>
                    </asp:DropDownList>
                    <div>
                    <br />
                        <div>
                            What is your monthly mortgage payment?</div>
                        <asp:DropDownList ID="ddlCurrentMortgagePayment" runat="server">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="450">$401 - $500</asp:ListItem>
                            <asp:ListItem Value="550">$501 - $600</asp:ListItem>
                            <asp:ListItem Value="650">$601 - $700</asp:ListItem>
                            <asp:ListItem Value="750">$701 - $800</asp:ListItem>
                            <asp:ListItem Value="850">$801 - $900</asp:ListItem>
                            <asp:ListItem Value="950">$901 - $1,000</asp:ListItem>
                            <asp:ListItem Value="1250">$1,001 - $1,500</asp:ListItem>
                            <asp:ListItem Value="1750">$1,501 - $3,000</asp:ListItem>
                            <asp:ListItem Value="3250">$3,001 - $4,500</asp:ListItem>
                            <asp:ListItem Value="4750">$4,501 - $6,000</asp:ListItem>
                            <asp:ListItem Value="6250">$6,001 - $7,500</asp:ListItem>
                            <asp:ListItem Value="7501">Over $7,501</asp:ListItem>
                        </asp:DropDownList>
                    </div>
            </td>
            <td align="left" valign="top">
                <div>
                    <div>
                        <asp:Label ID="Label2" runat="server">What is balance of your 1st mortgage?</asp:Label></div>
                    <asp:DropDownList ID="ddlBalanceFirstMortgage" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="9000">Less than $10,000</asp:ListItem>
                        <asp:ListItem Value="10000">$10,001 - $20,000</asp:ListItem>
                        <asp:ListItem Value="20001">$20,001 - $30,000</asp:ListItem>
                        <asp:ListItem Value="30001">$30,001 - $40,000</asp:ListItem>
                        <asp:ListItem Value="40001">$40,001 - $50,000</asp:ListItem>
                        <asp:ListItem Value="50001">$50,001 - $60,000</asp:ListItem>
                        <asp:ListItem Value="60001">$60,001 - $70,000</asp:ListItem>
                        <asp:ListItem Value="70001">$70,001 - $80,000</asp:ListItem>
                        <asp:ListItem Value="80001">$80,001 - $90,000</asp:ListItem>
                        <asp:ListItem Value="90001">$90,001 - $100,000</asp:ListItem>
                        <asp:ListItem Value="100001">$100,001 - $110,000</asp:ListItem>
                        <asp:ListItem Value="110001">$110,001 - $120,000</asp:ListItem>
                        <asp:ListItem Value="120001">$120,001 - $130,000</asp:ListItem>
                        <asp:ListItem Value="130001">$130,001 - $140,000</asp:ListItem>
                        <asp:ListItem Value="140001">$140,001 - $150,000</asp:ListItem>
                        <asp:ListItem Value="150001">$150,001 - $160,000</asp:ListItem>
                        <asp:ListItem Value="160001">$160,001 - $170,000</asp:ListItem>
                        <asp:ListItem Value="170001">$170,001 - $180,000</asp:ListItem>
                        <asp:ListItem Value="180001">$180,001 - $190,000</asp:ListItem>
                        <asp:ListItem Value="190001">$190,001 - $200,000</asp:ListItem>
                        <asp:ListItem Value="200001">$200,001 - $225,000</asp:ListItem>
                        <asp:ListItem Value="225001">$225,001 - $250,000</asp:ListItem>
                        <asp:ListItem Value="250001">$250,001 - $275,000</asp:ListItem>
                        <asp:ListItem Value="275001">$275,001 - $300,000</asp:ListItem>
                        <asp:ListItem Value="300001">$300,001 - $325,000</asp:ListItem>
                        <asp:ListItem Value="325001">$325,001 - $350,000</asp:ListItem>
                        <asp:ListItem Value="350001">$350,001 - $375,000</asp:ListItem>
                        <asp:ListItem Value="375001">$375,001 - $400,000</asp:ListItem>
                        <asp:ListItem Value="400001">$400,001 - $425,000</asp:ListItem>
                        <asp:ListItem Value="425001">$425,001 - $450,000</asp:ListItem>
                        <asp:ListItem Value="450001">$450,001 - $475,000</asp:ListItem>
                        <asp:ListItem Value="475001">$475,001 - $500,000</asp:ListItem>
                        <asp:ListItem Value="500001">$500,001 - $550,000</asp:ListItem>
                        <asp:ListItem Value="550001">$550,001 - $600,000</asp:ListItem>
                        <asp:ListItem Value="600001">$600,001 - $650,000</asp:ListItem>
                        <asp:ListItem Value="650001">$650,001 - $700,000</asp:ListItem>
                        <asp:ListItem Value="700001">$700,001 - $750,000</asp:ListItem>
                        <asp:ListItem Value="750001">$750,001 - $800,000</asp:ListItem>
                        <asp:ListItem Value="800001">$800,001 - $850,000</asp:ListItem>
                        <asp:ListItem Value="850001">$850,001 - $900,000</asp:ListItem>
                        <asp:ListItem Value="900001">$900,001 - $950,000</asp:ListItem>
                        <asp:ListItem Value="950001">$950,001 - $1,000,000</asp:ListItem>
                    </asp:DropDownList>
                </div>
                </div>
                <br />
                <div>
                    <asp:Label ID="Label3" runat="server">What is the interest rate of your 1st mortgage?</asp:Label></div>
                <asp:DropDownList ID="ddlFirstMortgageInterest" runat="server">
                    <asp:ListItem Value=""> </asp:ListItem>
                    <asp:ListItem Value="2.00">2.00%</asp:ListItem>
                    <asp:ListItem Value="2.25">2.25%</asp:ListItem>
                    <asp:ListItem Value="2.50">2.50%</asp:ListItem>
                    <asp:ListItem Value="2.75">2.75%</asp:ListItem>
                    <asp:ListItem Value="3.00">3.00%</asp:ListItem>
                    <asp:ListItem Value="3.25">3.25%</asp:ListItem>
                    <asp:ListItem Value="3.50">3.50%</asp:ListItem>
                    <asp:ListItem Value="3.75">3.75%</asp:ListItem>
                    <asp:ListItem Value="4.00">4.00%</asp:ListItem>
                    <asp:ListItem Value="4.25">4.25%</asp:ListItem>
                    <asp:ListItem Value="4.50">4.50%</asp:ListItem>
                    <asp:ListItem Value="4.75">4.75%</asp:ListItem>
                    <asp:ListItem Value="5.00">5.00%</asp:ListItem>
                    <asp:ListItem Value="5.25">5.25%</asp:ListItem>
                    <asp:ListItem Value="5.50">5.50%</asp:ListItem>
                    <asp:ListItem Value="5.75">5.75%</asp:ListItem>
                    <asp:ListItem Value="6.00">6.00%</asp:ListItem>
                    <asp:ListItem Value="6.25">6.25%</asp:ListItem>
                    <asp:ListItem Value="6.50">6.50%</asp:ListItem>
                    <asp:ListItem Value="6.75">6.75%</asp:ListItem>
                    <asp:ListItem Value="7.00">7.00%</asp:ListItem>
                    <asp:ListItem Value="7.25">7.25%</asp:ListItem>
                    <asp:ListItem Value="7.50">7.50%</asp:ListItem>
                    <asp:ListItem Value="7.75">7.75%</asp:ListItem>
                    <asp:ListItem Value="8.00">8.00%</asp:ListItem>
                    <asp:ListItem Value="8.25">8.25%</asp:ListItem>
                    <asp:ListItem Value="8.50">8.50%</asp:ListItem>
                    <asp:ListItem Value="8.75">8.75%</asp:ListItem>
                    <asp:ListItem Value="9.00">9.00%</asp:ListItem>
                    <asp:ListItem Value="9.25">9.25%</asp:ListItem>
                    <asp:ListItem Value="9.50">9.50%</asp:ListItem>
                    <asp:ListItem Value="9.75">9.75%</asp:ListItem>
                    <asp:ListItem Value="10.00">10.00%</asp:ListItem>
                    <asp:ListItem Value="10.25">10.25%</asp:ListItem>
                    <asp:ListItem Value="10.50">10.50%</asp:ListItem>
                    <asp:ListItem Value="10.75">10.75%</asp:ListItem>
                    <asp:ListItem Value="11+">11+%</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <hr />
    <table cellpadding="10">
        <caption>
            LAST FEW QUESTIONS PERSONAL QUESTIONS
        </caption>
        <tr>
            <td class="style3">
                <div>
                    <div>
                        <asp:Label runat="server">What is your Social Security Number?
                        </asp:Label></div>
                    <asp:TextBox ID="tbSsn" runat="server" ToolTip="enter you ssn"></asp:TextBox>
                </div>
                <br />
                <div>
                    <div>
                        <asp:Label ID="Label4" runat="server">What is your first name?
                        </asp:Label></div>
                    <asp:TextBox ID="tbFirstName" runat="server" ToolTip="enter first name"></asp:TextBox>
                </div>
                <div>
                    <div>
                        <asp:Label ID="Label5" runat="server">What is your last name?
                        </asp:Label></div>
                    <asp:TextBox ID="tbLastName" runat="server" ToolTip="enter last name"></asp:TextBox>
                </div>
                <br />
                <div>
                    <div>
                        <asp:Label ID="Label6" runat="server">What is your date of birth?
                        </asp:Label></div>
                    <asp:DropDownList ID="ddlMonth" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="01">01</asp:ListItem>
                        <asp:ListItem Value="02">02</asp:ListItem>
                        <asp:ListItem Value="03">03</asp:ListItem>
                        <asp:ListItem Value="04">04</asp:ListItem>
                        <asp:ListItem Value="05">05</asp:ListItem>
                        <asp:ListItem Value="06">06</asp:ListItem>
                        <asp:ListItem Value="07">07</asp:ListItem>
                        <asp:ListItem Value="08">08</asp:ListItem>
                        <asp:ListItem Value="09">09</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlDay" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="01">01</asp:ListItem>
                        <asp:ListItem Value="02">02</asp:ListItem>
                        <asp:ListItem Value="03">03</asp:ListItem>
                        <asp:ListItem Value="04">04</asp:ListItem>
                        <asp:ListItem Value="05">05</asp:ListItem>
                        <asp:ListItem Value="06">06</asp:ListItem>
                        <asp:ListItem Value="07">07</asp:ListItem>
                        <asp:ListItem Value="08">08</asp:ListItem>
                        <asp:ListItem Value="09">09</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="16">16</asp:ListItem>
                        <asp:ListItem Value="17">17</asp:ListItem>
                        <asp:ListItem Value="18">18</asp:ListItem>
                        <asp:ListItem Value="19">19</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="21">21</asp:ListItem>
                        <asp:ListItem Value="22">22</asp:ListItem>
                        <asp:ListItem Value="23">23</asp:ListItem>
                        <asp:ListItem Value="24">24</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        <asp:ListItem Value="26">26</asp:ListItem>
                        <asp:ListItem Value="27">27</asp:ListItem>
                        <asp:ListItem Value="28">28</asp:ListItem>
                        <asp:ListItem Value="29">29</asp:ListItem>
                        <asp:ListItem Value="30">30</asp:ListItem>
                        <asp:ListItem Value="31">31</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlYear" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="1990">1990</asp:ListItem>
                        <asp:ListItem Value="1989">1989</asp:ListItem>
                        <asp:ListItem Value="1988">1988</asp:ListItem>
                        <asp:ListItem Value="1987">1987</asp:ListItem>
                        <asp:ListItem Value="1986">1986</asp:ListItem>
                        <asp:ListItem Value="1985">1985</asp:ListItem>
                        <asp:ListItem Value="1984">1984</asp:ListItem>
                        <asp:ListItem Value="1983">1983</asp:ListItem>
                        <asp:ListItem Value="1982">1982</asp:ListItem>
                        <asp:ListItem Value="1981">1981</asp:ListItem>
                        <asp:ListItem Value="1980">1980</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
            </td>
            <td>
                <div>
                    <div>
                        <asp:Label ID="Label7" runat="server">What is your email address?</asp:Label></div>
                    <asp:TextBox ID="tbEmail" runat="server" ToolTip="enter email address"></asp:TextBox>
                </div>
                <br />
                <div>
                    <div>
                        <asp:Label runat="server">What is your phone number</asp:Label></div>
                    <asp:TextBox ID="tbPhone" runat="server" ToolTip="enter your phone number"></asp:TextBox>
                </div>
                <br />
                <div>
                    <asp:Label ID="Label8" runat="server">What is your mailing address?</asp:Label></div>
                <div>
                    <asp:Label ID="Label9" runat="server" Width="50">Street:</asp:Label>
                    <asp:TextBox
                        ID="tbStreet" runat="server"></asp:TextBox></div>
                <div>
                    <asp:Label ID="Label10" runat="server" Width="50">City:</asp:Label><asp:TextBox ID="tbCity"
                        runat="server"></asp:TextBox></div>
                <div>
                    <asp:Label ID="Label11" runat="server" Width="50">State:</asp:Label>
                    <asp:DropDownList ID="ddlState" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="AL">Alabama</asp:ListItem>
                        <asp:ListItem Value="AK">Alaska</asp:ListItem>
                        <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                        <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                        <asp:ListItem Value="CA">California</asp:ListItem>
                        <asp:ListItem Value="CO">Colorado</asp:ListItem>
                        <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                        <asp:ListItem Value="DE">Delaware</asp:ListItem>
                        <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                        <asp:ListItem Value="FL">Florida</asp:ListItem>
                        <asp:ListItem Value="GA">Georgia</asp:ListItem>
                        <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                        <asp:ListItem Value="ID">Idaho</asp:ListItem>
                        <asp:ListItem Value="IL">Illinois</asp:ListItem>
                        <asp:ListItem Value="IN">Indiana</asp:ListItem>
                        <asp:ListItem Value="IA">Iowa</asp:ListItem>
                        <asp:ListItem Value="KS">Kansas</asp:ListItem>
                        <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                        <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                        <asp:ListItem Value="ME">Maine</asp:ListItem>
                        <asp:ListItem Value="MD">Maryland</asp:ListItem>
                        <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                        <asp:ListItem Value="MI">Michigan</asp:ListItem>
                        <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                        <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                        <asp:ListItem Value="MO">Missouri</asp:ListItem>
                        <asp:ListItem Value="MT">Montana</asp:ListItem>
                        <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                        <asp:ListItem Value="NV">Nevada</asp:ListItem>
                        <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                        <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                        <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                        <asp:ListItem Value="NY">New York</asp:ListItem>
                        <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                        <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                        <asp:ListItem Value="OH">Ohio</asp:ListItem>
                        <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                        <asp:ListItem Value="OR">Oregon</asp:ListItem>
                        <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                        <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                        <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                        <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                        <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                        <asp:ListItem Value="TX">Texas</asp:ListItem>
                        <asp:ListItem Value="UT">Utah</asp:ListItem>
                        <asp:ListItem Value="VT">Vermont</asp:ListItem>
                        <asp:ListItem Value="VA">Virginia</asp:ListItem>
                        <asp:ListItem Value="WA">Washington</asp:ListItem>
                        <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                        <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                        <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
    </table>
    <div>
    <hr />
    <table cellpadding="10">
    <tr><td>
        <h3>
            Submit when Ready</h3>
            </td></tr>
            <tr><td>
        <div>
            <asp:Button ID="btSubmit" runat="server" Text="Submit" OnClick="btSubmit_Click" />
        </div>
        </td>
        <td>
        <asp:Image ID="imgResult" runat="server" Height="25px" ImageAlign="AbsMiddle" ImageUrl="~/Data/Images/ThumbUp.png" Width="25px" Visible="False" />
        <asp:TextBox ID="tbResult" runat="server" ReadOnly="True" BorderStyle="None" Visible="False" Width="200px"></asp:TextBox>
        </td>
        
        </tr>
        
        </table>
    </div>
</asp:Content>
