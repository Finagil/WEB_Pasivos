<%@ Page Title="Detalle de Garatías" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMasterFilial.Master" CodeBehind="FOND_EXT_SaldoGaratiaDet.aspx.vb" Inherits="WEB_Finagil.FOND_EXT_SaldoGaratiaDet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="width: 100%;" >
    <tr>
        <td align="center">
                <br />
                <span style="font-family: Verdana; font-weight: bold; color: #FF6600">Detalle de Garatías</span><br />
        </td>
            </tr>
    <tr>
        <td align="center">
                &nbsp;</td>
            </tr>
    <tr>
        <td align="center">
            
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
            
                <asp:ObjectDataSource ID="GaratiasDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.FOND_SaldoGarantiasTableAdapter">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="id_Fondeador" QueryStringField="id_fondeador" Type="Decimal" />
                    </SelectParameters>
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
