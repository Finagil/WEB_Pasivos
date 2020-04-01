<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMasterFinagil.Master" CodeBehind="FOND_AltaContrato.aspx.vb" Inherits="WEB_Finagil.AltaContrato" 
    title="Alta de Fondeos" %>
<%@ Register assembly="RoderoLib" namespace="RoderoLib" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    
<table width=100% causesvalidation="True">
<tr>
<td align=center style="height: 302px"> 
    <table style="width:100%;">
        <tr>
            <td colspan="2" align="center">
                <br />
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#f58220"
        Text="ALTA DE CONTRATO"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 29px; width: 25%;" colspan="2">
                <asp:ObjectDataSource ID="FondeosDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.Vw_FondeosTableAdapter">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="Id_Fondeo" QueryStringField="id_fondeo" Type="Decimal" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="id_Fondeo,No_Movimientos" DataSourceID="FondeosDS" Height="50px" Width="70%" CellPadding="4" Font-Names="Arial" Font-Size="Smaller" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
                    <FieldHeaderStyle BackColor="#f58220" Font-Bold="True" ForeColor="White" Width="30%" />
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
                        <asp:BoundField DataField="SaldoInsoluto" DataFormatString="{0:n2}" HeaderText="Saldo Insoluto" HtmlEncode="False" ReadOnly="True" SortExpression="SaldoInsoluto" />
                        <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" SortExpression="Sucursal" />
                        <asp:BoundField DataField="id_Fondeo" HeaderText="Fondeo" ReadOnly="True" SortExpression="id_Fondeo" />
                    </Fields>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" Font-Names="Arial" ForeColor="White" HorizontalAlign="Center" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFE0C0" Font-Names="Arial" ForeColor="#333333" />
                </asp:DetailsView>
                </td>
            
        </tr>
        <tr>
            <td align="right" style="width: 50%">
    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#f58220"
        Text="Contrato"></asp:Label></td>
            <td align="left"  style="width: 50%">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="320px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileUpload1" ErrorMessage="solo archivos PDF" Font-Names="Arial" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.pdf)$">solo archivos PDF</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="center" width="50%" colspan="2">
                <cc1:BotonEnviar ID="BotonEnviar1" runat="server" BackColor="#f58220" Font-Bold="True"
                    ForeColor="White" Text="Guardar Fondeo" TextoEnviando="Confirmando..." Width="182px" CausesValidation="True" />
                <br />
                <asp:Label ID="LberrorGlobal" runat="server" Font-Bold="False" Font-Names="Arial" ForeColor="Red"
                    Text="Retención" Visible="False"></asp:Label>
                <br />
            </td>
        </tr>
        </table>

</td>
</tr>
</table>
</asp:Content>
