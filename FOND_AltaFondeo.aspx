<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMasterFinagil.Master" CodeBehind="FOND_AltaFondeo.aspx.vb" Inherits="WEB_Finagil.AltaFondeo" 
    title="Alta de Fondeos" %>
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
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=TextBox2.ClientID %>").dynDateTime({
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
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=TextBox3.ClientID %>").dynDateTime({
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
<table width=100% causesvalidation="True">
<tr>
<td align=center style="height: 302px"> 
    <table style="width:100%;">
        <tr>
            <td colspan="2" align="center">
                <br />
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
        Text="ALTA DE FONDEOS"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td align="right" width="50%">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
        Text="Fondeadores"></asp:Label></td>
            <td align="left">
                <asp:DropDownList ID="cmbFondeador" runat="server" DataSourceID="FondeadorDS" DataTextField="Fondeador" DataValueField="id_Fondeador" Height="30px" Width="269px">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="FondeadorDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.FOND_FondeadoresTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_id_Fondeador" Type="Decimal" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Fondeador" Type="String" />
                        <asp:Parameter Name="Retencion" Type="Boolean" />
                        <asp:Parameter Name="TasaRetencion" Type="Decimal" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Fondeador" Type="String" />
                        <asp:Parameter Name="Retencion" Type="Boolean" />
                        <asp:Parameter Name="TasaRetencion" Type="Decimal" />
                        <asp:Parameter Name="Original_id_Fondeador" Type="Decimal" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%">
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
        Text="Tipo de Fondeo"></asp:Label></td>
            <td align="left">
                <asp:DropDownList ID="cmbTipoFondeo" runat="server" DataSourceID="TipoFondeoDS" DataTextField="Tipo_Fondeo" DataValueField="id_TipoFondeo" Height="30px" Width="269px">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="TipoFondeoDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.FOND_TiposFondeosTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_id_TipoFondeo" Type="Decimal" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Tipo_Fondeo" Type="String" />
                        <asp:Parameter Name="No_Movimientos" Type="Decimal" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Tipo_Fondeo" Type="String" />
                        <asp:Parameter Name="No_Movimientos" Type="Decimal" />
                        <asp:Parameter Name="Original_id_TipoFondeo" Type="Decimal" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" style="font-family: Verdana; color: #FF6600">
                <span style="font-weight: bold">Moneda</span></td>
            <td align="left">
                <asp:DropDownList ID="cmbMoneda" runat="server" DataSourceID="TipoFondeoDS0" DataTextField="Moneda" DataValueField="id_moneda" Height="30px" Width="269px">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="TipoFondeoDS0" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.FOND_MonedasTableAdapter">
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" style="font-family: Verdana; color: #FF6600">
                <span style="font-weight: bold">Sucursal</span></td>
            <td align="left">
                <asp:DropDownList ID="cmbSuc" runat="server" DataSourceID="SucDS" DataTextField="Sucursal" DataValueField="Sucursal" Height="30px" Width="269px">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="SucDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.FOND_SucursalesTableAdapter" DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_id_sucursal" Type="Decimal" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Sucursal" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Sucursal" Type="String" />
                        <asp:Parameter Name="Original_id_sucursal" Type="Decimal" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%">
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
        Text="Descripción"></asp:Label></td>
            <td align="left">
                <asp:TextBox ID="TxtDesc" runat="server" MaxLength="50" Width="365px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtDesc" ErrorMessage="Campo Requerido" Font-Names="Arial">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%">
    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
        Text="Fecha de Inicio"></asp:Label></td>
            <td align="left">
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly = "true"></asp:TextBox><img src="IMG/calender.png" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Campo Requerido" Font-Names="Arial">*</asp:RequiredFieldValidator>
             </td>
        </tr>
        <tr>
            <td align="right" width="50%">
    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
        Text="Fecha de Vencimiento"></asp:Label></td>
            <td align="left">
                <asp:TextBox ID="TextBox2" runat="server" ReadOnly = "true"></asp:TextBox><img src="IMG/calender.png" /><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="Campo Requerido" Font-Names="Arial">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%">
    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
        Text="Fecha de Pago"></asp:Label></td>
            <td align="left">
                <asp:TextBox ID="TextBox3" runat="server" ReadOnly = "true"></asp:TextBox><img src="IMG/calender.png" /><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox3" ErrorMessage="Campo Requerido" Font-Names="Arial">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%">
    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
        Text="Tipo de Tasa"></asp:Label></td>
            <td align="left">
                <asp:DropDownList ID="CmbTasas" runat="server" Height="30px" Width="259px">
                    <asp:ListItem Value="Tasa Fija">Tasa Fija</asp:ListItem>
                    <asp:ListItem>Tasa TIIE 28</asp:ListItem>
                    <asp:ListItem>Tasa Libor</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" style="height: 29px">
    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
        Text="Tasa o Diferencial"></asp:Label></td>
            <td align="left" style="height: 29px">
                <asp:TextBox ID="TxtDiff" runat="server" Width="112px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtDiff" ErrorMessage="Campo Requerido" Font-Names="Arial">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtDiff" ErrorMessage="Error en Tasa o diferencial" Font-Names="Arial" ValidationExpression="^\d{1,2}(?:,\s?\d{3})*(?:\.\d{1,6})?$">Error en Tasa o diferencial</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%">
    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
        Text="Contrato"></asp:Label></td>
            <td align="left">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="320px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileUpload1" ErrorMessage="solo archivos PDF" Font-Names="Arial" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.pdf)$">solo archivos PDF</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%">
    <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
        Text="Fechas de Pago de Capital"></asp:Label></td>
            <td align="left">
                <asp:FileUpload ID="FileUpload2" runat="server" Width="320px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="FileUpload2" ErrorMessage="solo archivos csv" Font-Names="Arial" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.txt|csv)$">solo archivos csv</asp:RegularExpressionValidator>
                <asp:Label ID="Lberror" runat="server" Font-Names="Arial" ForeColor="Red" Text="Archivo Inválido" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%">
    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
        Text="Factoraje"></asp:Label></td>
            <td align="left">
                <asp:CheckBox ID="CkFactoraje" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" width="50%" colspan="2">
                <cc1:BotonEnviar ID="BotonEnviar1" runat="server" BackColor="#FF6600" Font-Bold="True"
                    ForeColor="White" Text="Guardar Fondeo" TextoEnviando="Confirmando..." Width="182px" CausesValidation="True" />
                <br />
    <asp:Label ID="LbErrorGlobal" runat="server" Font-Bold="False" Font-Names="Arial" ForeColor="Red"
        Text="Fechas de Pago de Capital" Visible="False"></asp:Label></td>
        </tr>
        </table>

</td>
</tr>
</table>
</asp:Content>
