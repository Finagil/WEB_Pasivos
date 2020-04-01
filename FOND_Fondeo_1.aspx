<%@ Page Title="Fondeos" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMasterFinagil.Master" CodeBehind="FOND_Fondeo_1.aspx.vb" Inherits="WEB_Finagil.FOND_Fondeo_1" %>
<%@ Register assembly="RoderoLib" namespace="RoderoLib" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="js/calendar-en.min.js" type="text/javascript"></script>
    <link href="css/calendar-blue.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtFechaBusqueda.ClientID %>").dynDateTime({
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
        <table style="width: 100%;" >
    <tr>
        <td align="center">
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#f58220"
                    Text="Fondeos"></asp:Label>
                <br />
                <br />
                <asp:CheckBox ID="CheckBox1" runat="server" Font-Names="Arial" Font-Size="Small" Text="VIGENTE" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtFechaBusqueda" runat="server" ReadOnly = "true"></asp:TextBox><img src="IMG/calender.png" /><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFechaBusqueda" ErrorMessage="Campo Requerido" Font-Names="Arial"></asp:RequiredFieldValidator>
                <br />
                <br />
                <cc1:BotonEnviar ID="btnProcesar" runat="server" BackColor="#f58220" Font-Bold="True"
                    ForeColor="White" Text="PDF Fondeo" TextoEnviando="Procesando..." Width="182px" />
                &nbsp;&nbsp;
                <cc1:BotonEnviar ID="btnProcesar0" runat="server" BackColor="#f58220" Font-Bold="True"
                    ForeColor="White" Text="XLS Fondeo" TextoEnviando="Procesando..." Width="182px" />
                &nbsp;&nbsp;
                <cc1:BotonEnviar ID="btnProcesar1" runat="server" BackColor="#f58220" Font-Bold="True"
                    ForeColor="White" Text="PDF Fondeador" TextoEnviando="Procesando..." Width="182px" />
                &nbsp;&nbsp;
                <cc1:BotonEnviar ID="btnProcesar2" runat="server" BackColor="#f58220" Font-Bold="True"
                    ForeColor="White" Text="XLS Fondeador" TextoEnviando="Procesando..." Width="182px" />
                <br />
                <br />
        </td>
            </tr>
    <tr>
        <td align="center">
            
                <br />
                <br />
            
                <br />
            
        </td>
    </tr>
    </table>

</asp:Content>
