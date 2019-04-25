<%@ Page Title="Saldo de Fondeos" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMasterFinagil.Master" CodeBehind="FOND_SaldosAll.aspx.vb" Inherits="WEB_Finagil.FOND_Saldos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="width: 100%;" >
    <tr>
        <td align="center">
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
                    Text="Saldo de Fondeos (Todos)"></asp:Label>
                <br />
                <br />
        </td>
            </tr>
    <tr>
        <td align="center">
            
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="VWFondeosDS" Font-Names="Verdana" Font-Size="Smaller"
                    ForeColor="#333333" GridLines="None" ShowFooter="True" EnableModelValidation="True">
                    <RowStyle BackColor="#FFE0C0" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="id_Fondeo,id_Fondeador" DataNavigateUrlFormatString="FOND_EdoCta.aspx?ID_Fondeo={0}&amp;id_fondeador={1}" DataTextField="Fondeador" HeaderText="Fondeador" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                        <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" SortExpression="Sucursal" />
                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" SortExpression="FechaInicio" DataFormatString="{0:d}" HtmlEncode="False" Visible="False" />
                        <asp:BoundField DataField="FechaVencimiento" DataFormatString="{0:d}" HeaderText="Fecha Venc."
                            HtmlEncode="False" SortExpression="FechaVencimiento" />
                        <asp:BoundField DataField="FechaPago" DataFormatString="{0:d}" HeaderText="Fecha Pago" HtmlEncode="False" SortExpression="FechaPago" />
                        <asp:BoundField DataField="TipoTasa" HeaderText="Tipo Tasa" SortExpression="TipoTasa" />
                        <asp:BoundField HeaderText="Tasa ó Diff." DataField="TasaDiferencial" SortExpression="TasaDiferencial" DataFormatString="{0:n6}" HtmlEncode="False" />
                        <asp:BoundField DataField="Capital" DataFormatString="{0:n2}" HeaderText="Capital" HtmlEncode="False" SortExpression="Capital" ReadOnly="True">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Interes" DataFormatString="{0:n2}" HeaderText="Interés" HtmlEncode="False" ReadOnly="True" SortExpression="Interes" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Retencion" DataFormatString="{0:n2}" HeaderText="Retención" HtmlEncode="False" ReadOnly="True" SortExpression="Retencion" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataFormatString="{0:n2}" HeaderText="Saldo Garantia">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total" DataFormatString="{0:n2}" HeaderText="Total" HtmlEncode="False" ReadOnly="True" SortExpression="Total">
                        <ItemStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="id_Fondeo" HeaderText="Fondeo" HtmlEncode="False" ReadOnly="True" SortExpression="id_Fondeo">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#FF6600" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <br />
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
                            Text="Sin Datos"></asp:Label>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#FF6600" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            
                <asp:ObjectDataSource ID="VWFondeosDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="All_GetDataBy" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.FOND_SaldosTableAdapter"></asp:ObjectDataSource>
            
                <br />
            
        </td>
    </tr>
    </table>

</asp:Content>
