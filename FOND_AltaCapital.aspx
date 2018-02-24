<%@ Page Title="Agregar Capital" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMasterFinagil.Master" CodeBehind="FOND_AltaCapital.aspx.vb" Inherits="WEB_Finagil.AltaCapital" %>
<%@ Register assembly="RoderoLib" namespace="RoderoLib" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="js/calendar-en.min.js" type="text/javascript"></script>
    <link href="css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=TextBox1.ClientID %>").dynDateTime({
                showsTime: false,
                ifFormat: "%d/%m/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <table style="width: 100%;">
        <tr>
            <td align="center" colspan="2">
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600" Text="Agregar Capital a Fondeo"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td align ="center" colspan="2">
                <asp:ObjectDataSource ID="FondeosDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.Vw_FondeosTableAdapter">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="Id_Fondeo" QueryStringField="id_fondeo" Type="Decimal" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="id_Fondeo,No_Movimientos" DataSourceID="FondeosDS" EnableModelValidation="True" Height="50px" Width="70%" CellPadding="4" Font-Names="Arial" Font-Size="Smaller" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
                    <FieldHeaderStyle BackColor="#FF6600" Font-Bold="True" ForeColor="White" Width="30%" />
                    <Fields>
                        <asp:BoundField DataField="id_Fondeo" HeaderText="id_Fondeo" InsertVisible="False" ReadOnly="True" SortExpression="id_Fondeo" Visible="False" />
                        <asp:BoundField DataField="Fondeador" HeaderText="Fondeador" SortExpression="Fondeador" />
                        <asp:BoundField DataField="Tipo_Fondeo" HeaderText="Tipo Fondeo" SortExpression="Tipo_Fondeo" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                        <asp:BoundField DataField="FechaInicio" DataFormatString="{0:d}" HeaderText="Fecha Inicio" HtmlEncode="False" SortExpression="FechaInicio" />
                        <asp:BoundField DataField="FechaVencimiento" DataFormatString="{0:d}" HeaderText="Fecha Venc." HtmlEncode="False" SortExpression="FechaVencimiento" />
                        <asp:BoundField DataField="FechaPago" DataFormatString="{0:d}" HeaderText="Fecha Pago" HtmlEncode="False" ReadOnly="True" SortExpression="FechaPago" />
                        <asp:BoundField DataField="TipoTasa" HeaderText="Tipo Tasa" SortExpression="TipoTasa" />
                        <asp:BoundField DataField="TasaDiferencial" DataFormatString="{0:n6}" HeaderText="Tasa ó Diferencial" HtmlEncode="False" SortExpression="TasaDiferencial" />
                    </Fields>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" Font-Names="Arial" ForeColor="White" HorizontalAlign="Center" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFE0C0" Font-Names="Arial" ForeColor="#333333" />
                </asp:DetailsView>
            </td>
        </tr>
        <tr>
            <td align ="center" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" width="40%">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
                    Text="Fecha Inicial"></asp:Label>
                </td>
            <td align="left">
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly = "true"></asp:TextBox><img src="IMG/calender.png" /><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Campo Requerido" Font-Names="Arial"></asp:RequiredFieldValidator>
             </td>
        </tr>
        <tr>
            <td align="right" width="40%">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
                    Text="Importe Capital"></asp:Label>
                </td>
            <td align="left">
            <asp:TextBox ID="TxtImporte" runat="server" Width="171px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtImporte" ErrorMessage="Campo Requerido" Font-Names="Arial"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtImporte" ErrorMessage="Error en Importe" Font-Names="Arial" ValidationExpression="^\d{1,12}(?:,\s?\d{3})*(?:\.\d*)?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" width="40%">
                <cc1:BotonEnviar ID="BotonEnviar1" runat="server" BackColor="#FF6600" Font-Bold="True"
                    ForeColor="White" Text="Inserta Capital" TextoEnviando="Insertando..." Width="182px" EnableTheming="True" />
                <br />
                <asp:Label ID="LberrorGlobal" runat="server" Font-Bold="False" Font-Names="Arial" ForeColor="Red"
                    Text="Retención" Visible="False"></asp:Label>
                </td>
        </tr>
    </table>
</asp:Content>
