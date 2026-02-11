<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma1.aspx.cs" Inherits="PirmasWeb.Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Vardas"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Vardas yra privalomas" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <br />


            <asp:Label ID="Label2" runat="server" Text="Pavardė"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Pavardė yra privaloma" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <br />


            <asp:Label ID="Label5" runat="server" Text="Amžius"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Neteisinga metų reikšmė" ForeColor="Red" MaximumValue="25" MinimumValue="14" Type="Integer">*</asp:RangeValidator>
            <br />



            <br />
            <asp:Label ID="Label6" runat="server" Text="Mokamos programavimo kalbos"></asp:Label>
            <br />
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="XmlDataSource2" DataTextField="title" DataValueField="title">
            </asp:CheckBoxList>
            <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/App_Data/kalbos.xml"></asp:XmlDataSource>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <br />

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Pateikti" Width="109px" />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Registracijų sąrašas"></asp:Label>
            <br />
            <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="172px" Width="688px" GridLines="Both" HorizontalAlign="Justify">
            </asp:Table>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Valyti sąrašą" Width="113px" CausesValidation="False" OnClick="Button2_Click" />
            <br />

        </div>
    </form>
</body>
</html>
