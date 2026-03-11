<%@ Page Title="" Language="C#" MasterPageFile="~/CSM.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="OPTIMIZATION_OF_PUMPING_MAIN_SEWAGE.aspx.cs" Inherits="Water_wastewater.OPTIMIZATION_OF_PUMPING_MAIN_SEWAGE.OPTIMIZATION_OF_PUMPING_MAIN_SEWAGE" %>

<asp:Content ID="Content5" runat="server" contentplaceholderid="Head">
    <title>Optimisation of Pumping Main Sewage</title>
    <style type="text/css">
        .auto-style2 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 26px;
            text-align: center;
            font-size: medium;
            background-color: #99CCFF;
        }
        .auto-style3 {
            width: 1627px;
        }
        .auto-style5 {
            border: 1px ridge #000000;
            padding: 1px 4px;
        }
        .newStyle1 {
            border: 3px solid #000000;
            padding: 1px 4px;
            font-family: Arial;
            font-size: small;
            font-weight: normal;
        }
        .newStyle2 {
            font-family: Arial;
            font-size: small;
        }
        .newStyle3 {
            font-family: Arial;
            font-size: small;
        }
        .newStyle4 {
            font-family: Arial;
            font-size: small;
        }
        .auto-style6 {
            width: 40px;
        }
        .auto-style8 {
            text-align: center;
            font-size: medium;
            border: 1px ridge #000000;
            padding: 1px 4px;
            background-color: #FFCCFF;
        }
        .auto-style9 {
            text-align: center;
            background-color: #FFCCFF;
        }
        .auto-style10 {
            font-weight: 700;
            font-size: medium;
            height: 29px;
        }
        .auto-style11 {
            height: 26px;
            border: 1px ridge #000000;
            padding: 1px 4px;
            margin-left: 40px;
        }
        .auto-style12 {
            height: 26px;
            width: 144px;
            border: 1px ridge #000000;
            padding: 1px 4px;
        }
        .auto-style13 {
            width: 40px;
            border: 1px ridge #000000;
            padding: 1px 4px;
        }
        .auto-style15 {
            height: 26px;
            width: 40px;
            border: 1px ridge #000000;
            padding: 1px 4px;
        }
        .auto-style16 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            font-family: Arial;
            font-size: small;
        }
        .auto-style17 {}
        .auto-style18 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            font-family: Arial;
            font-size: small;
            height: 30px;
            width: 305px;
        }
        .auto-style19 {
            width: 1627px;
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 30px;
        }
        .auto-style20 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 30px;
        }
        .auto-style21 {
            width: 40px;
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 30px;
        }
        .auto-style23 {
            text-align: center;
            background-color: #99CCFF;
        }
        .auto-style24 {
            text-align: center;
        }
        .auto-style25 {
            margin-bottom: 0px;
        }
        .auto-style27 {
            text-align: center;
            height: 33px;
            background-color: #99CCFF;
        }
        .auto-style29 {
            text-align: center;
        }
        .auto-style30 {
            width: 100%;
        }
        .auto-style31 {
            font-weight: 700;
            font-size: medium;
            background-color: #99CCFF;
        }
        .auto-style32 {
            text-align: left;
        }
        .auto-style34 {
            height: 30px;
        }
        .auto-style35 {
            width: 1627px;
            height: 30px;
        }
        .auto-style36 {
            width: 40px;
            height: 30px;
        }
        .auto-style37 {}
        .auto-style38 {}
        .auto-style39 {
            text-align: left;
            height: 25px;
        }
        .auto-style40 {
            color: #0033CC;
        }
        .newStyle5 {
            font-family: Arial;
            font-size: small;
        }
        .newStyle6 {
            font-family: Arial;
            font-size: small;
        }
        .auto-style41 {}
        .auto-style42 {
            text-align: center;
            font-weight: 700;
            font-size: medium;
        }
        .auto-style44 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 22px;
        }
        .auto-style46 {
            width: 40px;
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 22px;
        }
        .auto-style47 {
            color: #0000FF;
        }
        .auto-style48 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 51px;
        }
        .auto-style49 {
            width: 1627px;
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 51px;
        }
        .auto-style50 {
            width: 40px;
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 51px;
        }
        .auto-style51 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 34px;
        }
        .auto-style52 {
            width: 1627px;
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 34px;
        }
        .auto-style53 {
            width: 40px;
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 34px;
        }
        .auto-style122 {
            width: 410px;
            height: 26px;
        }
        .auto-style124 {
            width: 410px;
        }
        .auto-style125 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 51px;
            width: 305px;
        }
        .auto-style126 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            width: 305px;
        }
        .auto-style127 {
            height: 26px;
            border: 1px ridge #000000;
            padding: 1px 4px;
            margin-left: 40px;
            width: 305px;
        }
        .auto-style128 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 34px;
            width: 305px;
        }
        .auto-style129 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            font-family: Arial;
            font-size: small;
            width: 305px;
        }
        .auto-style130 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 30px;
            width: 305px;
        }
        .auto-style131 {
            height: 30px;
            width: 305px;
        }
        .auto-style132 {
            width: 305px;
        }
        .auto-style133 {
            width: 1627px;
            border: 1px ridge #000000;
            padding: 1px 4px;
        }
        .auto-style134 {
            height: 26px;
            border: 1px ridge #000000;
            padding: 1px 4px;
            margin-left: 40px;
            width: 1627px;
        }
        .auto-style135 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 51px;
            width: 104px;
        }
        .auto-style136 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            width: 104px;
        }
        .auto-style137 {
            height: 26px;
            width: 104px;
            border: 1px ridge #000000;
            padding: 1px 4px;
        }
        .auto-style138 {
            height: 26px;
            border: 1px ridge #000000;
            padding: 1px 4px;
            margin-left: 40px;
            width: 104px;
        }
        .auto-style139 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 22px;
            width: 104px;
        }
        .auto-style140 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 34px;
            width: 104px;
        }
        .auto-style141 {
            border: 1px ridge #000000;
            padding: 1px 4px;
            height: 30px;
            width: 104px;
        }
        .auto-style142 {
            height: 30px;
            width: 104px;
        }
        .auto-style143 {
            width: 104px;
        }
        .auto-style144 {
            width: 664px;
        }
        </style>
</asp:Content>

<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4">
       <div>
    
           s<table class="newStyle1">
            <tr>
                <td class="auto-style42" colspan="7">Optimization of pumping main diameter for sewage system considering least lifecycle cost</td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="7"><strong>INPUT DATA</strong></td>
            </tr>
            <tr>
                <td class="auto-style125">
                    <asp:Label ID="Label267" runat="server" Text="Population for Stage 1"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator198" runat="server" ControlToValidate="txt_pop1" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Vg1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator32" runat="server" ControlToValidate="txt_pop1" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="Vg1"></asp:CompareValidator>
                </td>
                <td class="auto-style49">
                    <asp:TextBox ID="txt_pop1" runat="server">322061</asp:TextBox>
                </td>
                <td class="auto-style48">&nbsp;</td>
                <td class="auto-style48">&nbsp;</td>
                <td class="auto-style48">
                    <asp:Label ID="Label268" runat="server" Text="Population for Stage 2"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator199" runat="server" ControlToValidate="txt_pop2" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Vg1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator33" runat="server" ControlToValidate="txt_pop2" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="Vg1"></asp:CompareValidator>
                </td>
                <td class="auto-style135">
                    <asp:TextBox ID="txt_pop2" runat="server">431561</asp:TextBox>
                </td>
                <td class="auto-style50">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style125">Flow for Stage 1(Intermediate Flow- 1st 15 years)(<span class="auto-style47"> 80% of Water supplied + Infiltration ) or (100% water consumed for Black Water+ 80% of Water consumed for Grey Water + Ground water infiltration)</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Vg1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="Vg1"></asp:CompareValidator>
                </td>
                <td class="auto-style49">
                    <asp:TextBox ID="TextBox1" runat="server">50</asp:TextBox>
                </td>
                <td class="auto-style48">MLD</td>
                <td class="auto-style48"></td>
                <td class="auto-style48">
                    <asp:Label ID="Label254" runat="server" Text="Flow for Stage 2 (Ultimate Flow -&nbsp; 15 to 30 years)" Width="300px"></asp:Label>
                    <br />
                    <span class="auto-style47">( 80% of Water supplied + Infiltration ) or (100% water consumed for Black Water+ 80% of Water consumed for Grey Water + Ground water infiltration)</span><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBox2" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Vg1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="Vg1"></asp:CompareValidator>
                </td>
                <td class="auto-style135">
                    <asp:TextBox ID="TextBox2" runat="server">70</asp:TextBox>
                </td>
                <td class="auto-style50">MLD</td>
            </tr>
            <tr>
                <td class="auto-style126">Pumping Hours per day<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Vg1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="Vg1"></asp:CompareValidator>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="TextBox3" runat="server">22</asp:TextBox>
                </td>
                <td class="auto-style5">hr</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Length of pumping main<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBox4" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="TextBox4" runat="server">40000</asp:TextBox>
                </td>
                <td class="auto-style13">m</td>
            </tr>
            <tr>
                <td class="auto-style126">
                    <asp:Label ID="Label269" runat="server" Text="Peak flow hours per day"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator200" runat="server" ControlToValidate="txt_peakflowtime" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Vg1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator34" runat="server" ControlToValidate="txt_peakflowtime" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="Vg1"></asp:CompareValidator>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txt_peakflowtime" runat="server">2</asp:TextBox>
                </td>
                <td class="auto-style5">hr</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Label ID="Label270" runat="server" Text="Non Peak flow hours per day"></asp:Label>
                </td>

                <td class="auto-style136">
                    <asp:TextBox ID="txt_nonpeakflowtime" runat="server" BackColor="#FFFFCC" Enabled="False"></asp:TextBox>
                </td>
               
                <td class="auto-style13">hr</td>
            </tr>
            <tr>
                <td class="auto-style126">
                    <asp:Label ID="Label271" runat="server" Text="Peak factor for Stage 1"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txt_peakfac1" runat="server" BackColor="#FFFFCC" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Label ID="Label272" runat="server" Text="Peak factor for Stage 2"></asp:Label>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="txt_peakfac2" runat="server" BackColor="#FFFFCC" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style126">Maximum Water Level (MWL) at delivery reservior<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox5" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="TextBox5" runat="server">200</asp:TextBox>
                </td>
                <td class="auto-style5">m</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Low water level(LWL)/FVL at source<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TextBox6" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="TextBox6" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="TextBox6" runat="server">140</asp:TextBox>
                </td>
                <td class="auto-style13">m</td>
            </tr>
            <tr>
                <td class="auto-style126">Minimum Residual Head at discharge point<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox7" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="TextBox7" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="TextBox7" runat="server">2</asp:TextBox>
                </td>
                <td class="auto-style5">m</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Pumping Station Losses (including losses in suction, delivery piping upto manifold, valves etc.)<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TextBox8" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="TextBox8" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="TextBox8" runat="server">2</asp:TextBox>
                </td>
                <td class="auto-style13">m</td>
            </tr>
            <tr>
                <td class="auto-style126">Power Tariff or Energy charge<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox9" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="TextBox9" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="TextBox9" runat="server">5</asp:TextBox>
                </td>
                <td class="auto-style5">Rs/kWhr</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Escalation of power tariff per annum<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="TextBox10" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToValidate="TextBox10" ErrorMessage="Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="TextBox10" runat="server">5</asp:TextBox>
                </td>
                <td class="auto-style13">%</td>
            </tr>
            <tr>
                <td class="auto-style126">Annual interest rate/ Discount rate<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox11" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="TextBox11" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="TextBox11" runat="server">12</asp:TextBox>
                </td>
                <td class="auto-style5">%</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Escalated rate/Rate of inflation<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="TextBox12" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="TextBox12" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="TextBox12" runat="server">5</asp:TextBox>
                </td>
                <td class="auto-style13">%</td>
            </tr>
            <tr>
                <td class="auto-style130">Pipe Material considered
                    <asp:CompareValidator ID="CompareValidator13" runat="server" ControlToValidate="ddlm" ErrorMessage="Select a value!" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="VV" ValueToCompare="Select">Select a value !</asp:CompareValidator>
                </td>
                <td class="auto-style19">
                    <asp:DropDownList ID="ddlm" runat="server" AutoPostBack="True" CssClass="auto-style41" Height="20px" Width="124px" Font-Bold="True" OnSelectedIndexChanged="ddlm_SelectedIndexChanged">
                        <asp:ListItem Value="Select">Select</asp:ListItem>
                        <asp:ListItem>DI</asp:ListItem>
                        <asp:ListItem>CI</asp:ListItem>
                        <asp:ListItem>HDPE</asp:ListItem>
                        <asp:ListItem>MS</asp:ListItem>
                        <asp:ListItem>GRP</asp:ListItem>
                        <asp:ListItem>PSC</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style20"></td>
                <td class="auto-style20"></td>
                <td class="auto-style20">Class of pipe<asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="TextBox97" ErrorMessage="Value !" ForeColor="Red" style="font-weight: 700" ValidationGroup="Vg1"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style141">
                    <asp:TextBox ID="TextBox97" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style21"></td>
            </tr>
            <tr>
                <td class="auto-style126">No of years to be considered for Stage 1<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TextBox13" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator14" runat="server" ControlToValidate="TextBox13" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="TextBox13" runat="server">15</asp:TextBox>
                </td>
                <td class="auto-style13">year</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">No of years to be considered for Stage 2</td>
                <td class="auto-style136">
                    <asp:TextBox ID="TextBox96" runat="server">15</asp:TextBox>
                </td>
                <td class="auto-style13">year</td>
            </tr>
            <tr>
                <td class="auto-style126">Design period of pipeline<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox14" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator15" runat="server" ControlToValidate="TextBox14" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="TextBox14" runat="server">30</asp:TextBox>
                </td>
                <td class="auto-style5">year</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Design period of pumpsets<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TextBox15" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator16" runat="server" ControlToValidate="TextBox15" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="TextBox15" runat="server">15</asp:TextBox>
                </td>
                <td class="auto-style13">year</td>
            </tr>
            <tr>
                <td class="auto-style126">Pump efficiency<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox18" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator19" runat="server" ControlToValidate="TextBox18" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="TextBox18" runat="server">85</asp:TextBox>
                </td>
                <td class="auto-style5">%</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Motor efficiency<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="TextBox19" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator20" runat="server" ControlToValidate="TextBox19" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="TextBox19" runat="server">95</asp:TextBox>
                </td>
                <td class="auto-style13">%</td>
            </tr>
            <tr>
                <td class="auto-style126">Cost of Pumpsets <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox20" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator21" runat="server" ControlToValidate="TextBox20" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="TextBox20" runat="server">25000</asp:TextBox>
                </td>
                <td class="auto-style5">Rs/kW</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">O &amp; M Cost Factor for Pumpsets per year<span style="font-size: 11.0pt; font-family: Calibri; mso-ascii-font-family: Calibri; mso-fareast-font-family: +mn-ea; mso-bidi-font-family: Arial; mso-color-index: 13; language: en-IN"><span style="mso-spacerun:yes"> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="TextBox21" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator22" runat="server" ControlToValidate="TextBox21" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                    </span></span></td>
                <td class="auto-style136">
                    <asp:TextBox ID="TextBox21" runat="server">1.5</asp:TextBox>
                </td>
                <td class="auto-style13">%</td>
            </tr>
            <tr>
                <td class="auto-style126">O &amp; M Cost Factor for Pipeline per year<span style="font-size: 11.0pt; font-family: Calibri; mso-ascii-font-family: Calibri; mso-fareast-font-family: +mn-ea; mso-bidi-font-family: Arial; mso-color-index: 13; language: en-IN"><span style="mso-spacerun:yes"> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox22" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator23" runat="server" ControlToValidate="TextBox22" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                    </span></span></td>
                <td class="auto-style133">
                    <asp:TextBox ID="TextBox22" runat="server">0.25</asp:TextBox>
                </td>
                <td class="auto-style5">%</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Hazen Williams Roughness Coefficient (C value)<asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="TextBox23" ErrorMessage="Value !" ForeColor="#FF3300" ValidationGroup="VV"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="TextBox23" runat="server" CssClass="auto-style17" Height="16px">0</asp:TextBox>
                    </td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style126">
                    <asp:Label ID="Label258" runat="server" Text="Proposed Standby"></asp:Label>
                    <span style="font-size: 11.0pt; font-family: Calibri; mso-ascii-font-family: Calibri; mso-fareast-font-family: +mn-ea; mso-bidi-font-family: Arial; mso-color-index: 13; language: en-IN"><span style="mso-spacerun:yes"> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator197" runat="server" ControlToValidate="txt_proposedstand" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator31" runat="server" ControlToValidate="txt_proposedstand" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                    </span></span>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txt_proposedstand" runat="server">50</asp:TextBox>
                </td>
                <td class="auto-style5">%</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style136">
                    &nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style126">
                    <asp:Label ID="Label278" runat="server" Text="Average hourly flow to be consider for Stage 1"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txt_avgflo1" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label280" runat="server" Text="m&lt;sup&gt;3&lt;/sup&gt;/hr"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Label ID="Label282" runat="server" Text="Average hourly flow to be consider for Stage 2"></asp:Label>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="txt_avgflo2" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style13">m3/hr</td>
            </tr>
            <tr>
                <td class="auto-style126">
                    <asp:Label ID="Label274" runat="server" Text="Flow  considered for Stage 1 in Peak flow hours"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txt_peakflo1" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label300" runat="server" Text="m&lt;sup&gt;3&lt;/sup&gt;"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">
                    Flow&nbsp; considered for Stage 2 in Peak flow hours</td>
                <td class="auto-style136">
                    <asp:TextBox ID="txt_peakflo2" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style13">m3</td>
            </tr>
            <tr>
                <td class="auto-style126">
                    <asp:Label ID="Label302" runat="server" Text="Hourly peak flow for Stage 1"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txt_hrpeak1" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label304" runat="server" Text="m&lt;sup&gt;3&lt;/sup&gt;/hr"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Label ID="Label303" runat="server" Text="Hourly peak flow for Stage 2"></asp:Label>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="txt_hrpeak2" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style13">m3/hr</td>
            </tr>
            <tr>
                <td class="auto-style126">
                    <asp:Label ID="Label284" runat="server" Text="Balance flow during non peak flow hours for Stage 1"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txt_balflow1" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label288" runat="server" Text="m&lt;sup&gt;3&lt;/sup&gt;"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Label ID="Label290" runat="server" Text="Balance flow during non peak flow hours for Stage 2"></asp:Label>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="txt_balflow2" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style13">m3</td>
            </tr>
            <tr>
                <td class="auto-style126">
                    <asp:Label ID="Label286" runat="server" Text="Non peak flow hourly demand for stage 1"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txt_nonpeakflw1" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label289" runat="server" Text="m&lt;sup&gt;3&lt;/sup&gt;/hr"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Label ID="Label287" runat="server" Text="Non peak flow hourly demand for stage 2"></asp:Label>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="txt_nonpeakflw2" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style13">m3/hr</td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="6">
                    <span class="auto-style47">The maximum velocity considered = 3 m/sec and The minimum velocity considered =1.2 m/sec.</span><br class="auto-style47" />
                    <span class="auto-style47">These velocity ranges are fixed in order to find the range of the optimum diameters of the pipe for economic pumping mains.</span></td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style126">
                    <asp:Button ID="btn_maxmin" runat="server" CssClass="auto-style10" Text="MAX. &amp; MIN. DIAMETER" Width="200px" Font-Bold="True" ValidationGroup="Vg1" OnClick="btn_maxmin_Click" />
                &nbsp;<strong>Max. diameter</strong></td>
                <td class="auto-style133">
                    <asp:TextBox ID="TextBox94" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">
                    <strong>Minimum diameter</strong></td>
                <td class="auto-style136">
                    <asp:TextBox ID="TextBox95" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                    </td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style126">Nominal Diameter considered <span class="auto-style47">(Select the diameter between the calculated minimum and maximum diameters)<asp:CompareValidator ID="cv4" runat="server" ControlToValidate="ddld4" ErrorMessage="Select a value!" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="VV" ValueToCompare="Select">Select a value !</asp:CompareValidator>
                    <asp:CompareValidator ID="cv1" runat="server" ControlToValidate="ddld1" ErrorMessage="Select a value!" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="VV" ValueToCompare="Select">Select a value !</asp:CompareValidator>
                    <asp:CompareValidator ID="cv2" runat="server" ControlToValidate="ddld2" ErrorMessage="Select a value!" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="VV" ValueToCompare="Select">Select a value !</asp:CompareValidator>
                    <asp:CompareValidator ID="cv3" runat="server" ControlToValidate="ddld3" ErrorMessage="Select a value!" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="VV" ValueToCompare="Select">Select a value !</asp:CompareValidator>
                    <asp:CompareValidator ID="cv5" runat="server" ControlToValidate="ddld5" ErrorMessage="Select a value!" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="VV" ValueToCompare="Select">Select a value !</asp:CompareValidator>
                    <asp:CompareValidator ID="cv6" runat="server" ControlToValidate="ddld6" ErrorMessage="Select a value!" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="VV" ValueToCompare="Select">Select a value !</asp:CompareValidator>
                    <br />
                    </span></td>
                <td class="auto-style133">
                    <asp:Panel ID="paneld1" runat="server" CssClass="auto-style5" Height="18px" Visible="False" Width="110px">
                        <asp:DropDownList ID="ddld1" runat="server" AutoPostBack="True" Visible="False" Font-Bold="True" Width="100px">
                            <asp:ListItem Value="Select">Select</asp:ListItem>
                            <asp:ListItem>200</asp:ListItem>
                            <asp:ListItem>300</asp:ListItem>
                            <asp:ListItem>400</asp:ListItem>
                            <asp:ListItem>500</asp:ListItem>
                            <asp:ListItem>600</asp:ListItem>
                            <asp:ListItem>700</asp:ListItem>
                            <asp:ListItem>800</asp:ListItem>
                            <asp:ListItem>900</asp:ListItem>
                            <asp:ListItem>1000</asp:ListItem>
                            <asp:ListItem>1100</asp:ListItem>
                            <asp:ListItem>1200</asp:ListItem>
                            <asp:ListItem>1300</asp:ListItem>
                            <asp:ListItem>1400</asp:ListItem>
                            <asp:ListItem>1500</asp:ListItem>
                            <asp:ListItem>1600</asp:ListItem>
                            <asp:ListItem>1700</asp:ListItem>
                            <asp:ListItem>1800</asp:ListItem>
                            <asp:ListItem>1900</asp:ListItem>
                            <asp:ListItem>2000</asp:ListItem>
                            <asp:ListItem>2100</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                    </asp:Panel>
&nbsp;<asp:Panel ID="paneld2" runat="server" CssClass="auto-style5" Height="18px" Visible="False" Width="110px">
                        <asp:DropDownList ID="ddld2" runat="server" AutoPostBack="True" Visible="False" Font-Bold="True" Width="100px">
                            <asp:ListItem Value="Select">Select</asp:ListItem>
                            <asp:ListItem>300</asp:ListItem>
                            <asp:ListItem>400</asp:ListItem>
                            <asp:ListItem>500</asp:ListItem>
                            <asp:ListItem>600</asp:ListItem>
                            <asp:ListItem>700</asp:ListItem>
                            <asp:ListItem>800</asp:ListItem>
                            <asp:ListItem>900</asp:ListItem>
                            <asp:ListItem>1000</asp:ListItem>
                            <asp:ListItem>1100</asp:ListItem>
                            <asp:ListItem>1200</asp:ListItem>
                            <asp:ListItem>1300</asp:ListItem>
                            <asp:ListItem>1400</asp:ListItem>
                            <asp:ListItem>1500</asp:ListItem>
                            <asp:ListItem>1600</asp:ListItem>
                            <asp:ListItem>1700</asp:ListItem>
                            <asp:ListItem>1800</asp:ListItem>
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="paneld3" runat="server" CssClass="auto-style5" Height="18px" Visible="False" Width="110px">
                        <asp:DropDownList ID="ddld3" runat="server" AutoPostBack="True" Visible="False" Font-Bold="True" Width="100px">
                            <asp:ListItem Value="Select">Select</asp:ListItem>
                            <asp:ListItem>160</asp:ListItem>
                            <asp:ListItem>200</asp:ListItem>
                            <asp:ListItem>250</asp:ListItem>
                            <asp:ListItem>315</asp:ListItem>
                            <asp:ListItem>400</asp:ListItem>
                            <asp:ListItem>450</asp:ListItem>
                            <asp:ListItem>500</asp:ListItem>
                            <asp:ListItem>560</asp:ListItem>
                            <asp:ListItem>630</asp:ListItem>
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="paneld4" runat="server" CssClass="auto-style5" Height="18px" Visible="False" Width="110px">
                        <asp:DropDownList ID="ddld4" runat="server" AutoPostBack="True" Visible="False" Font-Bold="True" Width="100px">
                            <asp:ListItem Value="Select">Select</asp:ListItem>
                            <asp:ListItem>600</asp:ListItem>
                            <asp:ListItem>700</asp:ListItem>
                            <asp:ListItem>800</asp:ListItem>
                            <asp:ListItem>900</asp:ListItem>
                            <asp:ListItem>1000</asp:ListItem>
                            <asp:ListItem>1100</asp:ListItem>
                            <asp:ListItem>1200</asp:ListItem>
                            <asp:ListItem>1300</asp:ListItem>
                            <asp:ListItem>1400</asp:ListItem>
                            <asp:ListItem>1500</asp:ListItem>
                            <asp:ListItem>1600</asp:ListItem>
                            <asp:ListItem>1700</asp:ListItem>
                            <asp:ListItem>1800</asp:ListItem>
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="paneld5" runat="server" CssClass="auto-style5" Height="18px" Visible="False" Width="110px">
                        <asp:DropDownList ID="ddld5" runat="server" AutoPostBack="True" Visible="False" Font-Bold="True" Width="100px">
                            <asp:ListItem Value="Select">Select</asp:ListItem>
                            <asp:ListItem>300</asp:ListItem>
                            <asp:ListItem>400</asp:ListItem>
                            <asp:ListItem>500</asp:ListItem>
                            <asp:ListItem>600</asp:ListItem>
                            <asp:ListItem>700</asp:ListItem>
                            <asp:ListItem>800</asp:ListItem>
                            <asp:ListItem>900</asp:ListItem>
                            <asp:ListItem>1000</asp:ListItem>
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="paneld6" runat="server" CssClass="auto-style5" Height="18px" Visible="False" Width="110px">
                        <asp:DropDownList ID="ddld6" runat="server" AutoPostBack="True" Visible="False" Font-Bold="True" Width="100px">
                            <asp:ListItem Value="Select">Select</asp:ListItem>
                            <asp:ListItem>350</asp:ListItem>
                            <asp:ListItem>400</asp:ListItem>
                            <asp:ListItem>500</asp:ListItem>
                            <asp:ListItem>600</asp:ListItem>
                            <asp:ListItem>700</asp:ListItem>
                            <asp:ListItem>800</asp:ListItem>
                            <asp:ListItem>900</asp:ListItem>
                            <asp:ListItem>1000</asp:ListItem>
                        </asp:DropDownList>
                    </asp:Panel>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label256" runat="server" Text="mm"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style11">
                    <asp:Label ID="Label257" runat="server" Text="Material Unit Rate"></asp:Label>
&nbsp;<span class="auto-style47">(including complete laying and jointing , excavation, bedding,refilling)n, bedding,refilling)</span><br />
                </td>
                <td class="auto-style137">
                    <asp:TextBox ID="TextBox38" runat="server"></asp:TextBox>
                    <br />
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="TextBox38" ErrorMessage="Value!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VV"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator25" runat="server" ControlToValidate="TextBox38" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                   
                   
                </td>
                <td class="auto-style13">Rs/Rm</td>
            </tr>
            <tr>
                <td class="auto-style126">Pipe internal diameter.<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txt_di" ErrorMessage="Value !" ForeColor="Red" style="font-weight: 700" ValidationGroup="VV"></asp:RequiredFieldValidator>
                  
                    <asp:CompareValidator ID="CompareValidator26" runat="server" ControlToValidate="txt_di" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                   
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txt_di" runat="server"></asp:TextBox>
                    </td>
                <td class="auto-style5">mm</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style11">&nbsp;Wall thickness of pipe<asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txt_tw" ErrorMessage="Value !" ForeColor="Red" style="font-weight: 700" ValidationGroup="VV"></asp:RequiredFieldValidator>
                   
                    <asp:CompareValidator ID="CompareValidator27" runat="server" ControlToValidate="txt_tw" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                   
                </td>
                <td class="auto-style137">
                    <asp:TextBox ID="txt_tw" runat="server">25</asp:TextBox>
                    </td>
                <td class="auto-style13">mm</td>
            </tr>
            <tr>
                <td class="auto-style126">Bulk modulus of water<asp:RequiredFieldValidator ID="RequiredFieldValidator195" runat="server" ControlToValidate="txt_k" ErrorMessage="Value !" ForeColor="Red" style="font-weight: 700" ValidationGroup="VV"></asp:RequiredFieldValidator>
                  
                    <asp:CompareValidator ID="CompareValidator29" runat="server" ControlToValidate="txt_k" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                   
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txt_k" runat="server">207000000</asp:TextBox>
                    </td>
                <td class="auto-style5">kg/m2</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style11">Modulus of elasticity of pipe material<asp:RequiredFieldValidator ID="RequiredFieldValidator194" runat="server" ControlToValidate="txt_E" ErrorMessage="Value !" ForeColor="Red" style="font-weight: 700" ValidationGroup="VV"></asp:RequiredFieldValidator>
                   
                    <asp:CompareValidator ID="CompareValidator28" runat="server" ControlToValidate="txt_E" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                   
                </td>
                <td class="auto-style137">
                    <asp:TextBox ID="txt_E" runat="server">21000000000</asp:TextBox>
                    </td>
                <td class="auto-style13">kg/m2</td>
            </tr>
            <tr>
                <td class="auto-style126">Allowable withstanding pressure of selected pipe <span class="auto-style47"><em>(from IS Code)<asp:RequiredFieldValidator ID="RequiredFieldValidator196" runat="server" ControlToValidate="txt_pr1" ErrorMessage="Value !" ForeColor="Red" style="font-weight: 700" ValidationGroup="VV"></asp:RequiredFieldValidator>
                   
                    <asp:CompareValidator ID="CompareValidator30" runat="server" ControlToValidate="txt_pr1" ErrorMessage="Enter Number!" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="VV"></asp:CompareValidator>
                  
                    </em></span></td>
                <td class="auto-style133">
                    <asp:TextBox ID="txt_pr1" runat="server">450</asp:TextBox>
                    </td>
                <td class="auto-style5">mwc</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style136">
                    &nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style126">
                    <asp:Button ID="btn_waterhammer" runat="server" style="font-weight: 700" Text="WATER HAMMER CHECK FOR STAGES" Width="310px" Font-Bold="True" ValidationGroup="VV" Enabled="False" CssClass="auto-style10" OnClick="btn_waterhammer_Click" />
                    <br />
                    <asp:Label ID="Label253" runat="server" Text="(Click the button to have the water hammer check)" Width="300px" ForeColor="#3333FF"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:Label ID="Label1" runat="server" Text="Select a higher class of pipe" Visible="False" ForeColor="Red" Width="200px"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Use a water hammer controlling device" Visible="False" ForeColor="#FF9900" Width="250px"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="No changes recommended" Visible="False" ForeColor="#009900" Width="250px"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style11">
                    <br />
                    <br />
                </td>
                <td class="auto-style137">
                    <asp:Label ID="Label4" runat="server" Text="Select a higher class of pipe" Visible="False" ForeColor="Red" Width="250px"></asp:Label>
                    <asp:Label ID="Label5" runat="server" Text="Use a water hammer controlling device" Visible="False" ForeColor="#FF9900" Width="250px"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Text="No changes recommended" Visible="False" ForeColor="#009900" Width="250px"></asp:Label>
                </td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9" colspan="7">
                    <asp:Button ID="button_calc" runat="server" CssClass="auto-style10" Text="CALCULATE" Width="150px" ValidationGroup="VV" Font-Bold="True" Enabled="False" OnClick="button_calc_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="7"><strong>Calculated Results</strong></td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style127">Actual velocity for Stage 1</td>
                <td class="auto-style134">
                    <asp:TextBox ID="txtact_vel" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style15">m/sec</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Actual velocity for Stage 2</td>
                <td class="auto-style136">
                    <asp:TextBox ID="txtact_vel2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style13">m/sec</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style127">
                    <asp:Label ID="Label291" runat="server" Text="Frictional loss corresponding to Peak flow for Stage 1"></asp:Label>
                </td>
                <td class="auto-style134">
                    <asp:TextBox ID="txt_fripeak1" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                    </td>
                <td class="auto-style15">m</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style11">
                    <asp:Label ID="Label293" runat="server" Text="Frictional loss corresponding to Peak flow for Stage 2"></asp:Label>
                </td>
                <td class="auto-style138">
                    <asp:TextBox ID="txt_fripeak2" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                    </td>
                <td class="auto-style13">m</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style127">
                    <asp:Label ID="Label292" runat="server" Text="Frictional loss corresponding to Non Peak flow for Stage 1"></asp:Label>
                </td>
                <td class="auto-style134">
                    <asp:TextBox ID="TextBox78" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                    </td>
                <td class="auto-style15">m</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style11">
                    <asp:Label ID="Label294" runat="server" Text="Frictional loss corresponding to Non Peak flow for Stage 2"></asp:Label>
                </td>
                <td class="auto-style138">
                    <asp:TextBox ID="TextBox98" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                    </td>
                <td class="auto-style13">m</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style126">
                    <asp:Label ID="Label295" runat="server" Text="Total head on pump during peak flow for stage 1"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txtpump_headpeak1" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style13">m</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Total head on pump during peak flow for stage 2</td>
                <td class="auto-style136">
                    <asp:TextBox ID="txtpump_headpeak2" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style13">m</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style126">Total head on pump during non peak flow for Stage 1</td>
                <td class="auto-style133">
                    <asp:TextBox ID="txtpump_head" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style13">m</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Total head on pump during non peak flow for Stage 2</td>
                <td class="auto-style136">
                    <asp:TextBox ID="txtpump_head2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style13">m</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style126">
                    <asp:Label ID="Label296" runat="server" Text="Pump kW during peak flow for Stage 1"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txtpump_kwpeak1" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style44">kW</td>
                <td class="auto-style44">&nbsp;</td>
                <td class="auto-style44">
                    <asp:Label ID="Label297" runat="server" Text="Pump kW during peak flow for Stage 2"></asp:Label>
                </td>
                <td class="auto-style139">
                    <asp:TextBox ID="txtpump_kwpeak2" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style46">kW</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style126">Pump kW during non peak flow for Stage 1</td>
                <td class="auto-style133">
                    <asp:TextBox ID="txtpump_kw" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style44">kW</td>
                <td class="auto-style44"></td>
                <td class="auto-style44">Pump kW&nbsp; during non peak flow for Stage 2</td>
                <td class="auto-style139">
                    <asp:TextBox ID="txtpump_kw2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style46">kW</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style126">
                    <asp:Label ID="Label301" runat="server" Text="Total pump kW for stage 1"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txttotpump_kw1" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style44">kW</td>
                <td class="auto-style44">&nbsp;</td>
                <td class="auto-style44">Total pump kW for stage 2</td>
                <td class="auto-style139">
                    <asp:TextBox ID="txttotpump_kw2" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style46">kW</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style126">Water hammer head for Stage 1</td>
                <td class="auto-style133">
                    <asp:TextBox ID="txt_waterhammer_1" runat="server" Enabled="False" Font-Bold="True" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style5">m</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Water hammer head for Stage 2</td>
                <td class="auto-style136">
                    <asp:TextBox ID="txt_waterhammer_2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style13">m</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style128">Capital cost of pumpsets for Stage 1</td>
                <td class="auto-style52">
                    <asp:TextBox ID="txtcost_pumpset" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style51">Lakhs</td>
                <td class="auto-style51"></td>
                <td class="auto-style51">
                    <asp:Label ID="Label255" runat="server" Text="Net Present value of Replacement costs(Capital cost of pumpsets for Stage 2)" Width="350px"></asp:Label>
                </td>
                <td class="auto-style140">
                    <asp:TextBox ID="txtpw_replace" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style53">Lakhs</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style126">X factor</td>
                <td class="auto-style133">
                    <asp:TextBox ID="txtXf" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style44"></td>
                <td class="auto-style44"></td>
                <td class="auto-style44"></td>
                <td class="auto-style139">
                </td>
                <td class="auto-style46"></td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style126">
                    <asp:Label ID="Label298" runat="server" Text="Power required in one year during peak flow for Stage 1"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txtpow_pypeak1" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style5">kW</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Power required in one year during peak flow for Stage 2</td>
                <td class="auto-style136">
                    <asp:TextBox ID="txtpow_pypeak2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style5">kW</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style126">Power required in one year during non peak flow<br />
&nbsp;for Stage 1</td>
                <td class="auto-style133">
                    <asp:TextBox ID="txtpow_nonpeak1" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style5">kW</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Power required in one year during non peak flow for Stage 2</td>
                <td class="auto-style136">
                    <asp:TextBox ID="txtpow_nonpeak2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style5">kW</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style129">
                    <asp:Label ID="Label299" runat="server" Text="Total power required in one year for Stage 1"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="txtpow_py" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style13">kW</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Total power required in one year for Stage 2</td>
                <td class="auto-style136">
                    <asp:TextBox ID="txtpow_py2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style13">kW</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style129">
                    <asp:Label ID="Label305" runat="server" Text="Power cost in Stage I  per year"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="TXT_POWCSTPERYR1" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style13">Lakhs</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Label ID="Label306" runat="server" Text="Power cost in Stage II  per year"></asp:Label>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="TXT_POWCSTPERYR2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style13">Lakhs</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style129">Net present value of Capital Cost for Pipeline</td>
                <td class="auto-style133">
                    <asp:TextBox ID="txtpw_pipe" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style13">Lakhs</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">Cost of Pipeline</td>
                <td class="auto-style136">
                    <asp:TextBox ID="txtunitrate" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style13">Rs/Rm</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style126">Net Present Value of O &amp; M cost for Pipeline</td>
                <td class="auto-style133">
                    <asp:TextBox ID="txtpw_pipeline_om" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style13">Lakhs</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style16">
                    <asp:Label ID="Label307" runat="server" Text="Cost of pumpsets after 15 years for replacement i.e this is the cost of pumps for second stage."></asp:Label>
                </td>
                <td class="auto-style136">
                    <asp:TextBox ID="TXT_PUMPSETCOST15" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style13">Lakhs</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style129">
                    <asp:Label ID="Label308" runat="server" Text="O&amp;M Cost for pumpsets per year for stage I"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="TXT_OMCOSTPERYR1" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style5">Lakhs</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style16">O&amp;M Cost for pumpsets per year for stage II</td>
                <td class="auto-style136">
                    <asp:TextBox ID="TXT_OMCOSTPERYR2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style5">Lakhs</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style129">
                    <asp:Label ID="Label309" runat="server" Text="O&amp;M Cost for pipeline per year for stage I"></asp:Label>
                </td>
                <td class="auto-style133">
                    <asp:TextBox ID="TXT_OMPIPECOSTPERYR1" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style5">Lakhs</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style16">O&amp;M Cost for pipeline per year for stage II</td>
                <td class="auto-style136">
                    <asp:TextBox ID="TXT_OMPIPECOSTPERYR2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style5">Lakhs</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style129">Net present value of Capital Cost for Pumpsets for Stage 1</td>
                <td class="auto-style133">
                    <asp:TextBox ID="txtpw_pumpset" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style5">Lakhs</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style16">Net present value of Capital Cost for Pumpsets for Stage 2</td>
                <td class="auto-style136">
                    <asp:TextBox ID="txtpw_pumpset2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style5">Lakhs</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style129">&nbsp;</td>
                <td class="auto-style133">
                    &nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style16">Replacement Cost of Pumpsets - Present Worth i.e for stage II</td>
                <td class="auto-style136">
                    <asp:TextBox ID="TXT_PWREP_PUMPSET2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style5">Lakhs</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style129">Net Present Value of O &amp; M cost for Pumpsets for Stage 1</td>
                <td class="auto-style133">
                    <asp:TextBox ID="txtpw_pumpset_om" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style5">Lakhs</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style16">Net Present Value of O &amp; M cost for Pumpsets for Stage 2</td>
                <td class="auto-style136">
                    <asp:TextBox ID="txtpw_pumpset_om2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style5">Lakhs</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style18">Net Present value of Power cost for Stage 1</td>
                <td class="auto-style19">
                    <asp:TextBox ID="txtpw_pow_cost" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style20">Lakhs</td>
                <td class="auto-style20"></td>
                <td class="auto-style20">Net Present value of Power cost for Stage 2 </td>
                <td class="auto-style141">
                    <asp:TextBox ID="txtpw_pow_cost2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style21">Lakhs</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style18">Total Net Present Value for Stage 1 (excluding pipe)</td>
                <td class="auto-style19">
                    <asp:TextBox ID="txttotal_pw1" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style20">Lakhs</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style20">Total Net Present Value for Stage 2 (excluding pipe)</td>
                <td class="auto-style141">
                    <asp:TextBox ID="txttotal_pw2" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style21">Lakhs</td>
            </tr>
            <tr class="newStyle5">
                <td class="auto-style130">&nbsp;Net total power cost</td>
                <td class="auto-style19">
                    <asp:TextBox ID="TextBox99" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style21">Lakhs</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style20">Total Net Present Value</td>
                <td class="auto-style141">
                    <asp:TextBox ID="txttotal_pw" runat="server" Enabled="False" BackColor="#FFFFCC" Font-Bold="True"></asp:TextBox>
                </td>
                <td class="auto-style21">Lakhs</td>
            </tr>
            <tr>
                <td class="auto-style23" colspan="7">
                    <asp:Button ID="btn_add" runat="server" CssClass="auto-style10" Text="ADD THE RESULT" Width="160px" Enabled="False" Font-Bold="True" ValidationGroup="VV" OnClick="btn_add_Click" />
                    <br />
                    <asp:Label ID="Label262" runat="server" ForeColor="#000099" Text="(User to Click the &quot;Add the result&quot; button to add the calculated results in a tabular format.Repeat this step until you have sufficient numbers of diameter values to find the Optimum Diameter)" Width="600px"></asp:Label>
                    <br />
                    </td>
            </tr>
            <tr>
                <td class="auto-style23" colspan="7">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <table class="auto-style30">
                        <tr>
                            <td class="auto-style144">
                    <asp:Button ID="btn_refresh" runat="server" CssClass="auto-style10"  Text="REFRESH" Width="160px" Enabled="False" Font-Bold="True" ValidationGroup="VV" OnClick="btn_refresh_Click" />
                                <br />
                                <asp:Label ID="Label260" runat="server" ForeColor="#000099" Text="(User to click Refresh button to select another diameter from the input data section)" Width="400px"></asp:Label>
                            </td>
                            <td>
                    <asp:Button ID="btn_cont" runat="server" CssClass="auto-style10" Text="CONTINUE" Width="160px" Enabled="False" Font-Bold="True" ValidationGroup="VV3" OnClick="btn_cont_Click"/>
                                &nbsp; &nbsp;<br />
                                <asp:Label ID="Label261" runat="server" ForeColor="#000099" Text="(User to click Continue button to go for optimum diameter calculation)" Width="400px"></asp:Label>
                                <br />
                            </td>
                        </tr>
                    </table>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr>
                <td class="auto-style24" colspan="7">
                        &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style34" colspan="6">
                    &nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Panel ID="paninp_output" runat="server" ScrollBars="Both" Visible="False" Width="1000px">
                        <table class="auto-style30">
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gv2" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style38" ForeColor="Black" GridLines="Vertical" Width="975px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <FooterStyle BackColor="#CCCC99" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                        <SortedAscendingHeaderStyle BackColor="#848384" />
                                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                        <SortedDescendingHeaderStyle BackColor="#575357" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gv3" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="967px">
                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#000065" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gv1" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" CssClass="auto-style25" GridLines="None" Width="968px">
                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#33276A" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td class="auto-style36">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style131">
                    <asp:Button ID="btn_optdia" runat="server" CssClass="auto-style10" Text="OPTIMUM DIAMETER" Width="217px" Enabled="False" ValidationGroup="VV3" OnClick="btn_optdia_Click" />
                    <br />
                    <span class="auto-style40"><em>&nbsp;(Click the button to view the optimum diameter)</em></span></td>
                <td class="auto-style35">
                    <asp:TextBox ID="txtdia_opt" runat="server" Font-Bold="True" Enabled="False" BackColor="#FFFFCC"></asp:TextBox>
                </td>
                <td class="auto-style34">mm</td>
                <td class="auto-style34"></td>
                <td class="auto-style34">
                    <asp:TextBox ID="TextBox50" runat="server" CssClass="auto-style37" Width="42px" Visible="False" Enabled="False"></asp:TextBox>
                    <asp:TextBox ID="TextBox51" runat="server" CssClass="auto-style37" Width="42px" Visible="False" Enabled="False"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="TextBox52" runat="server" CssClass="auto-style37" Width="42px" Visible="False" Enabled="False"></asp:TextBox>
                    <asp:TextBox ID="TextBox53" runat="server" CssClass="auto-style37" Width="42px" Visible="False" Enabled="False"></asp:TextBox>
                    <asp:TextBox ID="TextBox16" runat="server" Visible="False" Enabled="False">1.8</asp:TextBox>
                    <asp:TextBox ID="TextBox17" runat="server" Visible="False" Enabled="False">0.6</asp:TextBox>
                    <br />
                    <asp:TextBox ID="TextBox54" runat="server" CssClass="auto-style37" Width="42px" Visible="False" Enabled="False"></asp:TextBox>
                    <asp:TextBox ID="TextBox55" runat="server" CssClass="auto-style37" Width="42px" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style142">
                    <asp:TextBox ID="TextBox39" runat="server" Visible="False" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style36"></td>
            </tr>
            <tr>
                <td class="auto-style27" colspan="7">
                    <asp:Button ID="btn_detresult" runat="server" CssClass="auto-style10" Text="DETAILED RESULTS" Width="170px" Enabled="False" ValidationGroup="V" OnClick="btn_detresult_Click" />
                    <br />
                                <asp:Label ID="Label263" runat="server" ForeColor="#000099" Text="(User to click  button to take print of the detailed result)" Width="400px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style27" colspan="7">
                    <asp:Panel ID="Panel2" runat="server">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <asp:Panel ID="Panel1" runat="server" CssClass="auto-style29" Visible="False">
                        <table class="auto-style30">
                            <tr>
                                <td class="auto-style31" colspan="6">PROJECT DETAILS</td>
                            </tr>
                            <tr>
                                <td class="auto-style39">Job No</td>
                                <td class="auto-style39">
                                    <asp:TextBox ID="TextBox40" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validtjobno" runat="server" ControlToValidate="TextBox40" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="vg2"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style39">Project Name</td>
                                <td class="auto-style39">
                                    <asp:TextBox ID="TextBox41" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validtproject" runat="server" ControlToValidate="TextBox41" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="vg2"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style39">Client Name</td>
                                <td class="auto-style39">
                                    <asp:TextBox ID="TextBox42" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validtclient" runat="server" ControlToValidate="TextBox42" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="vg2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style32">Design Developer</td>
                                <td class="auto-style32">
                                    <asp:TextBox ID="TextBox43" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validtdesdev" runat="server" ControlToValidate="TextBox43" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="vg2"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style32">Employee Code</td>
                                <td class="auto-style32">
                                    <asp:TextBox ID="TextBox46" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="validtempcode" runat="server" ControlToValidate="TextBox46" ErrorMessage="*" Font-Bold="True" ForeColor="Red" SetFocusOnError="true" ValidationExpression="^[\s\S]{6,7}$" ValidationGroup="vg2"></asp:RegularExpressionValidator>
                                </td>
                                <td class="auto-style32">Discipline</td>
                                <td class="auto-style32">
                                    <asp:DropDownList ID="ddldiscipline" runat="server" AppendDataBoundItems="true" AutoPostBack="true" Height="22px" Width="200px">
                                        <asp:ListItem Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="AC">AC-Architecture &amp; Town Planning</asp:ListItem>
                                        <asp:ListItem Value="CH">CH-Chemical &amp; Environment</asp:ListItem>
                                        <asp:ListItem Value="CV">CV- Civil</asp:ListItem>
                                        <asp:ListItem Value="EL">EL-Electrical</asp:ListItem>
                                        <asp:ListItem Value="IC">IC- Instrumentation &amp; Control</asp:ListItem>
                                        <asp:ListItem Value="ME">ME-Mechanical</asp:ListItem>
                                        <asp:ListItem Value="MN">MN-Mining &amp; Geology</asp:ListItem>
                                        <asp:ListItem Value="MT">MT-Metallurgy</asp:ListItem>
                                        <asp:ListItem Value="OT">OT-Others</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="validtdisc" runat="server" ControlToValidate="ddldiscipline" ErrorMessage="*" Font-Bold="True" ForeColor="Red" InitialValue="-1" ValidationGroup="vg2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style32">Delivery Centre</td>
                                <td class="auto-style32">
                                    <asp:DropDownList ID="ddllocation" runat="server" AppendDataBoundItems="true" AutoPostBack="true" Height="22px" Width="200px">
                                        <asp:ListItem Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="BLR">BLR-Bangalore- Sheriff Centre and Janardhan Towers</asp:ListItem>
                                        <asp:ListItem Value="CHN">CHN- Chennai</asp:ListItem>
                                        <asp:ListItem Value="DEL">DEL- Delhi NCR</asp:ListItem>
                                        <asp:ListItem Value="JSR">JSR -Jamshedpur</asp:ListItem>
                                        <asp:ListItem Value="KOL">KOL- Kolkata</asp:ListItem>
                                        <asp:ListItem Value="MUM - 247 Park">MUM- Mumbai - 247 Park</asp:ListItem>
                                        <asp:ListItem Value="PUN">PUN- Pune</asp:ListItem>
                                        <asp:ListItem Value=" MUM-SEZ">SEZ-Mumbai-SEZ</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="validtlocation" runat="server" ControlToValidate="ddllocation" ErrorMessage="*" Font-Bold="True" ForeColor="Red" InitialValue="-1" ValidationGroup="vg2"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style32">Business unit</td>
                                <td class="auto-style32">
                                    <asp:DropDownList ID="ddlbusinessunit" runat="server" AppendDataBoundItems="true" AutoPostBack="true" Height="22px" Width="200px">
                                        <asp:ListItem Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="CHBU">CHBU - Chemical</asp:ListItem>
                                        <asp:ListItem Value="CNBU">CNBU - Construction</asp:ListItem>
                                        <asp:ListItem Value="INFBU">INFBU -Infrastructure</asp:ListItem>
                                        <asp:ListItem Value="NBU">NBU -Nuclear &amp; Advanced Technology</asp:ListItem>
                                        <asp:ListItem Value="PBU">PBU- Power</asp:ListItem>
                                        <asp:ListItem Value="SMMBU">SMMBU - Steel,Metal and Mining</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="validtbuisness" runat="server" ControlToValidate="ddlbusinessunit" ErrorMessage="*" Font-Bold="True" ForeColor="Red" InitialValue="-1" ValidationGroup="vg2"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style32">Design Verifier</td>
                                <td class="auto-style32">
                                    <asp:TextBox ID="TextBox57" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style32">
                                    <asp:Label ID="Label264" runat="server" Text="Subject"></asp:Label>
                                </td>
                                <td class="auto-style32">
                                    <asp:TextBox ID="txt_subj" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validsubj" runat="server" ControlToValidate="txt_subj" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="vg2"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style32">
                                    <asp:Label ID="Label265" runat="server" Text="Doc No."></asp:Label>
                                </td>
                                <td class="auto-style32">
                                    <asp:TextBox ID="txt_docno" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validtdoc" runat="server" ControlToValidate="txt_docno" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="vg2"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style32">
                                    <asp:Label ID="Label266" runat="server" Text="Revision No."></asp:Label>
                                </td>
                                <td class="auto-style32">
                                    <asp:TextBox ID="txt_revno" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validtrevno" runat="server" ControlToValidate="txt_revno" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="vg2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style32">&nbsp;</td>
                                <td class="auto-style32">&nbsp;</td>
                                <td class="auto-style32">&nbsp;</td>
                                <td class="auto-style32">&nbsp;</td>
                                <td class="auto-style32">&nbsp;</td>
                                <td class="auto-style32">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style32" colspan="6">&nbsp;&nbsp;<asp:Label ID="Label259" runat="server" ForeColor="Red" Text="* - Mandatory"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBox56" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                                    </td>
                            </tr>
                        </table>
                        <br />
                        <table style="width: 1191px">
                            <tr>
                                <td class="auto-style222" colspan="3" style="background-color: skyblue; text-align: center;">
                                    <asp:Label ID="lbloutput1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#663300" Text="USER FEEDBACK"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style122" style="background-color: #FFFFFF">&nbsp;</td>
                                <td  colspan="2" style="background-color: #FFFFFF; margin-left: 40px; text-align: left;">
                                    <asp:Label ID="Label248" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Text="Excellent"></asp:Label>
                                    &nbsp;&nbsp;
                                    <asp:Label ID="Label249" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Text="Very Good"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label250" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Text="Good"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label251" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Text="Average"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label252" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Text="Below Average"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style124" style="text-align: left">
                                    <asp:Label ID="lbl_area32" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="Small" Text="Is this software program useful"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td class="auto-style12" style="background-color: #FFFFFF">
                                    <asp:RadioButtonList ID="useful" runat="server" Font-Bold="True" Height="19px" RepeatDirection="Horizontal" Width="350px">
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td class="auto-style256" style="background-color: #FFFFFF">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator190" runat="server" ControlToValidate="useful" ErrorMessage="??" Font-Bold="True" ForeColor="#FF3300" ValidationGroup="vg2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style124" style="text-align: left">
                                    <asp:Label ID="lbl_area33" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="Small" Text="Is it User friendly"></asp:Label>
                                </td>
                                <td class="auto-style12" style="background-color: #FFFFFF">
                                    <asp:RadioButtonList ID="friendly" runat="server" Font-Bold="True" Height="16px" RepeatDirection="Horizontal" Width="350px">
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td class="auto-style256" style="background-color: #FFFFFF">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator191" runat="server" ControlToValidate="friendly" ErrorMessage="??" Font-Bold="True" ForeColor="#FF3300" ValidationGroup="vg2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style124" style="text-align: left">
                                    <asp:Label ID="lbl_area34" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="Small" Text="Has it reduced your effort"></asp:Label>
                                </td>
                                <td class="auto-style12" style="background-color: #FFFFFF">
                                    <asp:RadioButtonList ID="mhsave" runat="server" Font-Bold="True" Height="16px" RepeatDirection="Horizontal" Width="350px">
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td class="auto-style256" style="background-color: #FFFFFF">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator192" runat="server" ControlToValidate="mhsave" ErrorMessage="??" Font-Bold="True" ForeColor="#FF3300" ValidationGroup="vg2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style124" style="text-align: left">
                                    <asp:Label ID="lbl_area35" runat="server" Font-Bold="False" Font-Names="Arial Narrow" Font-Size="Medium" Text="What is the MH saving if otherwise done manually"></asp:Label>
                                </td>
                                <td class="auto-style12" style="background-color: #FFFFFF">
                                    <asp:TextBox ID="mh" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False" Width="70px"></asp:TextBox>
                                    <asp:RangeValidator ID="RangeValidator_corsn_allownc1" runat="server" ControlToValidate="mh" ErrorMessage="Invalid value" ForeColor="#CC0000" MaximumValue="1000" MinimumValue="0.5" SetFocusOnError="True" Type="Double" ValidationGroup="vg2"></asp:RangeValidator>
                                </td>
                                <td class="auto-style256" style="background-color: #FFFFFF">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator193" runat="server" ControlToValidate="mh" ErrorMessage="??" Font-Bold="True" ForeColor="#FF3300" ValidationGroup="vg2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style124" style="text-align: left">
                                    <asp:Label ID="lbl_area36" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="Small" Text="Suggestions/Feedback"></asp:Label>
                                </td>
                                <td class="auto-style12" colspan="2" style="background-color: #FFFFFF">
                                    <asp:TextBox ID="fb" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False" Width="335px"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style93" colspan="3" style="text-align: center; ">
                                    <asp:Button ID="btn_downld" runat="server" CssClass="auto-style10" Text="DOWNLOAD" ValidationGroup="vg2" Width="150px" OnClick="btn_downld_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="auto-style132">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style143">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
    
</asp:Content>

