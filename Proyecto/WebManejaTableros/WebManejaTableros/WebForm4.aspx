<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="WebManejaTableros.WebForm4" %>

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
<title>Pantalla Inicio | PROFESOR</title>
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
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="barrita"></div>         
            <div class="container">
                <br />
                <div class="ac">
                    <asp:Image ID="Image1" runat="server" class="imgg"/>
                    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="datospersonales" Style="font-size:18pt"></asp:Label>
                    <h2>PROFESOR</h2>
                </div>
                <div><br /></div>
                <center><h2><b>Acciones disponibles</b></h2></center>
                <center><div class="form-group">
                    <asp:Button ID="Button1" runat="server" Text="Crear nuevo tablero" OnClick="Button1_Click1" class="btn-primary btnnaranja"/>
                    <br />
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="Consultar mis tableros" OnClick="Button2_Click" class="btn-primary btnnaranja"/>
                </div></center>
                <div><br/></div>
                <div><br/></div>
                <center><div class="form-group">
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cerrar Sesión" class="btn"/>
                </div></center>
        </div>
    </form>
</body>
</html>
