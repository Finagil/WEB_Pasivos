<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMasterFinagil.Master" CodeBehind="SaldosFondeo.aspx.vb" Inherits="WEB_Finagil.SaldosFondeo" 
    title="Saldo Fondeo Finagil" %>

<%@ Register Assembly="RoderoLib" Namespace="RoderoLib" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td align="center" style="height: 363px">
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
                    Text="Auxiliar Fondeo"></asp:Label><br />
                <br />
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
                    Text="totalFAC"></asp:Label><br />
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="Detalle_DS" Font-Names="Verdana" Font-Size="Smaller"
                    ForeColor="#333333" GridLines="None" ShowFooter="True">
                    <RowStyle BackColor="#FFE0C0" />
                    <Columns>
                        <asp:BoundField DataField="Fecha" DataFormatString="{0:d}" HeaderText="Fecha" HtmlEncode="False"
                            ReadOnly="True" SortExpression="Fecha" />
                        <asp:BoundField DataField="Fondeo" DataFormatString="{0:n2}" HeaderText="Fondeo"
                            HtmlEncode="False" ReadOnly="True" SortExpression="Fondeo" />
                        <asp:BoundField DataField="Pago" DataFormatString="{0:n2}" HeaderText="Pago" HtmlEncode="False"
                            ReadOnly="True" SortExpression="Pago" />
                        <asp:BoundField DataField="Interes" DataFormatString="{0:n2}" HeaderText="Interes"
                            HtmlEncode="False" ReadOnly="True" SortExpression="Interes" />
                        <asp:BoundField DataField="Retencion" DataFormatString="{0:n2}" HeaderText="Retencion"
                            HtmlEncode="False" ReadOnly="True" SortExpression="Retencion" />
                        <asp:BoundField DataField="PagoNeto" DataFormatString="{0:n2}" HeaderText="PagoNeto"
                            HtmlEncode="False" ReadOnly="True" SortExpression="PagoNeto" />
                        <asp:BoundField DataFormatString="{0:n2}" HeaderText="Saldo" HtmlEncode="False" ReadOnly="True" />
                    </Columns>
                    <FooterStyle BackColor="#FF6600" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <br />
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
                            Text="Sin Cuentas Bancarias"></asp:Label>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#FF6600" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:ObjectDataSource ID="Detalle_DS" runat="server"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.SaldosFondeoTableAdapter">
                </asp:ObjectDataSource>
                <br />
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
