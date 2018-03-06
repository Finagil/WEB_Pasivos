<%@ Page Title="Detalle de Fondeo" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMasterFinagil.Master" CodeBehind="FOND_EdoCtaDET.aspx.vb" Inherits="WEB_Finagil.FOND_EdoCtaDET" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="width: 100%;" >
    <tr>
        <td align="center">
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
                    Text="Detalle de Fondeo"></asp:Label>
                <br />
                <br />
        </td>
            </tr>
    <tr>
        <td align="center">
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
                <asp:ObjectDataSource ID="FondeosDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.Vw_FondeosTableAdapter">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="Id_Fondeo" QueryStringField="id_fondeo" Type="Decimal" />
                    </SelectParameters>
                </asp:ObjectDataSource>
        </td>
            </tr>
    <tr>
        <td align="center">
                &nbsp;</td>
            </tr>
    <tr>
        <td align="center">
            
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="VWFondeosDS" Font-Names="Verdana" Font-Size="Smaller"
                    ForeColor="#333333" GridLines="None" ShowFooter="True" DataKeyNames="id_Movimiento" EnableModelValidation="True">
                    <RowStyle BackColor="#FFE0C0" />
                    <Columns>
                        <asp:BoundField DataField="id_Movimiento" HeaderText="id_Movimiento" SortExpression="id_Movimiento" InsertVisible="False" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="id_Fondeo" HeaderText="id_Fondeo" SortExpression="id_Fondeo" Visible="False" />
                        <asp:BoundField DataField="FechaInicio" DataFormatString="{0:d}" HeaderText="Fecha Ini." HtmlEncode="False" SortExpression="FechaInicio" />
                        <asp:BoundField DataField="FechaFin" DataFormatString="{0:d}" HeaderText="Fecha Fin." HtmlEncode="False" SortExpression="FechaFin" />
                        <asp:BoundField DataField="Concepto" HeaderText="Concepto" SortExpression="Concepto" />
                        <asp:BoundField DataField="TasaRetencion" DataFormatString="{0:n6}" HeaderText="Tasa Rete." HtmlEncode="False" SortExpression="TasaRetencion">
                        </asp:BoundField>
                        <asp:BoundField DataField="SaldoInicial" DataFormatString="{0:n}" HeaderText="Saldo Ini." HtmlEncode="False" SortExpression="SaldoInicial">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Importe" DataFormatString="{0:n2}" HeaderText="Capital"
                            HtmlEncode="False" SortExpression="Importe" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Interes" DataFormatString="{0:n2}" HeaderText="Interés"
                            HtmlEncode="False" SortExpression="Interes" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Retención" DataField="Retencion" SortExpression="Retencion" DataFormatString="{0:n2}" HtmlEncode="False" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SaldoFinal" DataFormatString="{0:n}" HeaderText="Soldo Fin." SortExpression="SaldoFinal">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#FF6600" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <br />
                        <span style="font-weight: bold; color: #FF6600">Sin Datos </span>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#FF6600" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            
                <asp:ObjectDataSource ID="VWFondeosDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.FOND_EstadoCuentaTableAdapter" DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_id_Movimiento" Type="Decimal" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="id_Fondeo" Type="Decimal" />
                        <asp:Parameter Name="Concepto" Type="String" />
                        <asp:Parameter Name="Importe" Type="Decimal" />
                        <asp:Parameter Name="Interes" Type="Decimal" />
                        <asp:Parameter Name="Retencion" Type="Decimal" />
                        <asp:Parameter Name="TasaRetencion" Type="Decimal" />
                        <asp:Parameter Name="FechaInicio" Type="DateTime" />
                        <asp:Parameter Name="FechaFin" Type="DateTime" />
                        <asp:Parameter Name="SaldoInicial" Type="Decimal" />
                        <asp:Parameter Name="SaldoFinal" Type="Decimal" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="id_Fondeo" QueryStringField="ID_Fondeo" Type="Decimal" />
                        <asp:QueryStringParameter DefaultValue="" Name="Fecha" QueryStringField="Fec" Type="DateTime" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="id_Fondeo" Type="Decimal" />
                        <asp:Parameter Name="Concepto" Type="String" />
                        <asp:Parameter Name="Importe" Type="Decimal" />
                        <asp:Parameter Name="Interes" Type="Decimal" />
                        <asp:Parameter Name="Retencion" Type="Decimal" />
                        <asp:Parameter Name="TasaRetencion" Type="Decimal" />
                        <asp:Parameter Name="FechaInicio" Type="DateTime" />
                        <asp:Parameter Name="FechaFin" Type="DateTime" />
                        <asp:Parameter Name="SaldoInicial" Type="Decimal" />
                        <asp:Parameter Name="SaldoFinal" Type="Decimal" />
                        <asp:Parameter Name="Original_id_Movimiento" Type="Decimal" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            
                <br />
            
        </td>
    </tr>
    <tr>
        <td align="center">
            
                &nbsp;</td>
    </tr>
    </table>

</asp:Content>
