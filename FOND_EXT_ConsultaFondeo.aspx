﻿<%@ Page Title="Fondeos Vigentes" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMasterFilial.Master" CodeBehind="FOND_EXT_ConsultaFondeo.aspx.vb" Inherits="WEB_Finagil.FOND_EXT_ConsultaFondeo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="width: 100%;" >
    <tr>
        <td align="center">
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#f58220"
                    Text="Saldo de Fondeos"></asp:Label>
                <br />
                <br />
        </td>
            </tr>
    <tr>
        <td align="center">
            
                <asp:ObjectDataSource ID="VWFondeosDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByFondeador" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.FOND_SaldosTableAdapter">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="Fondeador" SessionField="id_fondeo" Type="Decimal" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="VWFondeosDS" Font-Names="Verdana" Font-Size="Smaller"
                    ForeColor="#333333" GridLines="None" ShowFooter="True" EnableModelValidation="True">
                    <RowStyle BackColor="#FFE0C0" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="id_Fondeo" DataNavigateUrlFormatString="FOND_EXT_EdoCta.aspx?ID_Fondeo={0}" DataTextField="Fondeador" HeaderText="Fondeador" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                        <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" ReadOnly="True" SortExpression="Sucursal" />
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
                        <asp:BoundField DataField="Total" DataFormatString="{0:n2}" HeaderText="Total" HtmlEncode="False" ReadOnly="True" SortExpression="Total">
                        <ItemStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#f58220" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <br />
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#f58220"
                            Text="Sin Datos"></asp:Label>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#f58220" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            
                <br />
            
        </td>
    </tr>
    </table>

</asp:Content>
