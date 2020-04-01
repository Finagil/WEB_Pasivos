<%@ Page Title="Detalle de Garatías" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMasterFinagil.Master" CodeBehind="FOND_SaldoGaratiaDet.aspx.vb" Inherits="WEB_Finagil.FOND_SaldoGaratiaDet" %>
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
        <table style="width: 100%;" >
    <tr>
        <td align="center" colspan="2">
                <br />
                <span style="font-family: Verdana; font-weight: bold; color: #f58220">Detalle de Garatías</span><br />
        </td>
            </tr>
    <tr>
        <td align="center" colspan="2">
                &nbsp;</td>
            </tr>
    <tr>
        <td align="center" colspan="2">
            
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="GaratiasDS" Font-Names="Verdana" Font-Size="Smaller"
                    ForeColor="#333333" GridLines="None" ShowFooter="True" DataKeyNames="id_Garantia" EnableModelValidation="True">
                    <RowStyle BackColor="#FFE0C0" />
                    <Columns>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="Concepto" HeaderText="Concepto" SortExpression="Concepto">
                        </asp:BoundField>
                        <asp:BoundField DataField="Capital" HeaderText="Capital" SortExpression="Capital" DataFormatString="{0:n2}" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#f58220" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <br />
                        <span style="font-weight: bold; color: #f58220">Sin Datos </span>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#f58220" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            
                <asp:ObjectDataSource ID="GaratiasDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.FOND_SaldoGarantiasTableAdapter">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="id_Fondeador" QueryStringField="id_fondeador" Type="Decimal" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            
                <br />
            
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            
                <span style="font-family: Verdana; font-weight: bold; color: #f58220">Alta de pago de Garatías</span></td>
    </tr>
    <tr>
        <td align="right" width="40%" style="font-family: Verdana; color: #f58220">
            
                <span style="font-weight: bold">Concepto</span></td>
        <td align="left" style="width: 524px">
            <asp:TextBox ID="TxtConcepto" runat="server" MaxLength="43" Width="342px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtConcepto" ErrorMessage="Campo Requerido" Font-Names="Arial"></asp:RequiredFieldValidator>
             </td>
    </tr>
    <tr>
        <td align="right" width="40%" style="font-family: Verdana; color: #f58220">
            
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#f58220"
                    Text="Fecha"></asp:Label>
                </td>
        <td align="left" style="width: 524px">
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly = "true"></asp:TextBox><img src="IMG/calender.png" /><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox1" ErrorMessage="Campo Requerido" Font-Names="Arial"></asp:RequiredFieldValidator>
             </td>
    </tr>
    <tr>
        <td align="right" width="40%" style="font-family: Verdana; color: #f58220">
            
                <span style="font-weight: bold">Importe del Pago</span></td>
        <td align="left" style="width: 524px">
            <asp:TextBox ID="TxtImporte" runat="server" MaxLength="50" Width="342px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtImporte" ErrorMessage="Campo Requerido" Font-Names="Arial"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtImporte" ErrorMessage="Error en Importe" Font-Names="Arial" ValidationExpression="^\d{1,12}(?:,\s?\d{3})*(?:\.\d*)?$"></asp:RegularExpressionValidator>
             </td>
    </tr>
    <tr>
        <td align="center" width="40%" style="font-family: Verdana; color: #f58220" colspan="2">
                            <cc1:BotonEnviar ID="BotonEnviar1" runat="server" BackColor="#f58220" Font-Bold="True"
                    ForeColor="White" Text="Guardar Pago" TextoEnviando="Confirmando..." Width="182px" CausesValidation="True" />
                            <br />
                <asp:Label ID="LberrorGlobal" runat="server" Font-Bold="False" Font-Names="Arial" ForeColor="Red"
                    Text="Retención" Visible="False"></asp:Label>
                </td>       
    </tr>
    </table>

</asp:Content>
