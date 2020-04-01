<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMasterFinagil.Master" CodeBehind="ConfReembolso.aspx.vb" Inherits="WEB_Finagil.ConfReembolso" 
    title="Reembolsos Pendientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width=100%>
<tr>
<td align=center style="height: 302px"> 
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#f58220"
        Text="Fondeos Pendietes de Procesar"></asp:Label><br />
    <br />
    <asp:GridView ID="GridView1" runat="server"
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Lote,Fecha" DataSourceID="Lotes_DS"
            Font-Names="Verdana" Font-Size="Smaller" ForeColor="#333333" GridLines="None">
            <RowStyle BackColor="#FFE0C0" />
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/IMG/check1.JPG" ShowSelectButton="True" />
                <asp:BoundField DataField="Id_Lote" HeaderText="Num. Lote" InsertVisible="False" ReadOnly="True" SortExpression="Id_Lote"
                    Visible="False" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha Reembolso" SortExpression="Fecha" DataFormatString="{0:d}" HtmlEncode="False" />
                <asp:BoundField DataField="Cesion" DataFormatString="{0:n2}" HeaderText="Importe Reembolso"
                    HtmlEncode="False" SortExpression="Cesion" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                <br />
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#f58220"
                    Text="Sin Lotes"></asp:Label>
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#f58220" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    <asp:ObjectDataSource ID="Lotes_DS" runat="server" DeleteMethod="Delete"
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByReembolso" TypeName="WEB_Finagil.WEB_FinagilDSTableAdapters.WEB_LotesTableAdapter" InsertMethod="Insert" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_Id_Lote" Type="Decimal" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Fecha" Type="DateTime" />
            <asp:Parameter Name="Usuario" Type="String" />
            <asp:Parameter Name="Estatus" Type="String" />
            <asp:Parameter Name="TipoDocumento" Type="String" />
            <asp:Parameter Name="Cesion" Type="Decimal" />
            <asp:Parameter Name="Original_Id_Lote" Type="Decimal" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Fecha" Type="DateTime" />
            <asp:Parameter Name="Usuario" Type="String" />
            <asp:Parameter Name="Estatus" Type="String" />
            <asp:Parameter Name="TipoDocumento" Type="String" />
            <asp:Parameter Name="Cesion" Type="Decimal" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <br />
    <br />
    <br />

</td>
</tr>
</table>
</asp:Content>
