<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FOND_Tabla.aspx.vb" Inherits="WEB_Finagil.FOND_Tabla" Title="Tabla de Pagos de Capital" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;" >
                <tr>
                    <td align="center">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="TablaDS" Font-Names="Verdana" Font-Size="Smaller"
                    ForeColor="#333333" GridLines="None" ShowFooter="True" EnableModelValidation="True" DataKeyNames="id_pago">
                    <RowStyle BackColor="#FFE0C0" />
                    <FooterStyle BackColor="#FF6600" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <br />
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
                            Text="Sin Datos"></asp:Label>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#FF6600" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="id_pago" HeaderText="id_pago" InsertVisible="False" ReadOnly="True" SortExpression="id_pago" Visible="False" />
                                <asp:BoundField DataField="id_fondeo" HeaderText="id_fondeo" SortExpression="id_fondeo" Visible="False" />
                                <asp:BoundField DataField="FechaPago" DataFormatString="{0:d}" HeaderText="Fecha Pago" HtmlEncode="False" SortExpression="FechaPago" />
                                <asp:BoundField DataField="Capital" DataFormatString="{0:n2}" HeaderText="Capital" HtmlEncode="False" SortExpression="Capital" />
                            </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                        <asp:ObjectDataSource ID="TablaDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.FOND_FechasPagoCapitalTableAdapter" UpdateMethod="Update">
                            <DeleteParameters>
                                <asp:Parameter Name="Original_id_pago" Type="Decimal" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="id_fondeo" Type="Decimal" />
                                <asp:Parameter Name="FechaPago" Type="DateTime" />
                                <asp:Parameter Name="Capital" Type="Decimal" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:QueryStringParameter Name="id_Fondeo" QueryStringField="id" Type="Decimal" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="id_fondeo" Type="Decimal" />
                                <asp:Parameter Name="FechaPago" Type="DateTime" />
                                <asp:Parameter Name="Capital" Type="Decimal" />
                                <asp:Parameter Name="Original_id_pago" Type="Decimal" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>
                    </td>
                    </tr>
                </table>
                
            
        </div>
    </form>
</body>
</html>
