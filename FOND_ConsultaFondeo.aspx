<%@ Page Title="Fondeos Vigentes" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMasterFinagil.Master" CodeBehind="FOND_ConsultaFondeo.aspx.vb" Inherits="WEB_Finagil.ConsultaFondeo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="width: 100%;" >
    <tr>
        <td align="center">
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#FF6600"
                    Text="Fondeos Vigentes"></asp:Label>
                <br />
                <br />
        </td>
            </tr>
    <tr>
        <td align="center">
            
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="VWFondeosDS" Font-Names="Verdana" Font-Size="Smaller"
                    ForeColor="#333333" GridLines="None" ShowFooter="True" DataKeyNames="id_Fondeo" EnableModelValidation="True">
                    <RowStyle BackColor="#FFE0C0" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="id_Fondeo" DataNavigateUrlFormatString="FOND_AltaCapital.aspx?ID_fondeo={0}" Text="Alta Capital" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField DataNavigateUrlFields="id_Fondeo" DataNavigateUrlFormatString="FOND_AltaPago.aspx?ID_Fondeo={0}" Text="Alta Pago" />
                        <asp:TemplateField HeaderText="No Fondeo" InsertVisible="False" SortExpression="id_Fondeo" Visible="False">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("id_Fondeo", "{0:n0}") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("id_Fondeo", "{0:n0}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Fondeador" HeaderText="Fondeador" SortExpression="Fondeador" />
                        <asp:BoundField DataField="Tipo_Fondeo" HeaderText="Tipo Fondeo" SortExpression="Tipo_Fondeo" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                        <asp:BoundField DataField="FechaInicio" DataFormatString="{0:d}" HeaderText="Fecha Inicio"
                            HtmlEncode="False" SortExpression="FechaInicio" />
                        <asp:BoundField DataField="FechaVencimiento" DataFormatString="{0:d}" HeaderText="Fecha Venc."
                            HtmlEncode="False" SortExpression="FechaVencimiento" />
                        <asp:BoundField DataField="FechaPago" DataFormatString="{0:d}" HeaderText="Fecha Pago" HtmlEncode="False" ReadOnly="True" SortExpression="FechaPago" />
                        <asp:BoundField HeaderText="Tipo Tasa" DataField="TipoTasa" SortExpression="TipoTasa" />
                        <asp:BoundField DataField="TasaDiferencial" DataFormatString="{0:n6}" HeaderText="Tasa o Dif." HtmlEncode="False" SortExpression="TasaDiferencial">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
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
            
                <asp:ObjectDataSource ID="VWFondeosDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByVigentes" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.Vw_FondeosTableAdapter"></asp:ObjectDataSource>
            
                <br />
            
        </td>
    </tr>
    </table>

</asp:Content>
