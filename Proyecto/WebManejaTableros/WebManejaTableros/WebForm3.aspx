<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebManejaTableros.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<!-- Required meta tags -->
<meta charset="utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
<!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
<!--Propio-->
<link rel="stylesheet" type="text/css" href="estilos.css"/>
<script src="js/sweetalert2.all.min.js"></script>
<link href="css/sweetalert2.min.css" rel="stylesheet" />
<script type="text/javascript">
        function sweetm(t, m, tipo) {
            Swal.fire(
                t,
                m,
                tipo
            )
        }
</script>
<title>Estudiante</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="barrita"></div>
            <div class="container">
            <div class="ac">
                <asp:Image ID="imgAvatar" runat="server" ImageUrl="" CssClass="imgg" />
                <asp:Label ID="lblNombre" runat="server" Text="" CssClass="datospersonales" Style="font-size:18pt"></asp:Label>
                <h2>ESTUDIANTE</h2>
            </div>
            <div><br/></div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Mis equipos" class="btn btn-primary btn-lg btn-block btnnaranja"/>
                </div>
                <div class="col-lg-4"></div>
                <div class="col-lg-4">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Crear un nuevo equipo" class="btn btn-primary btn-lg btn-block btnnaranja"/>
                </div>
            </div>
            <div><br/></div>
            <div>
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Únirse a un nuevo Tablero" class="btn btn-primary btn-lg btn-block btnnaranja"/>
                <br/></div>
&nbsp;<br />
            <center><h1>Mis tableros</h1>
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" class="table table-striped table-hover" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ButtonType="Button" HeaderText="TABLEROS" SelectText="CONSULTAR" ShowHeader="True" ShowSelectButton="True" >
                    <ControlStyle CssClass="btnMini" />
                    </asp:CommandField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView></center>
            
            <br />
            <br />
                <center><div class="col-lg-4">
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cerrar Sesión" class="btn"/>
                </div></center>
            <br />
            
        </div>
    </form>
</body>
</html>
