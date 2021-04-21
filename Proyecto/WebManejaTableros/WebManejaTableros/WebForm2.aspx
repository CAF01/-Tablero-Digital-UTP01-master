<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebManejaTableros.WebForm2" %>

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
<title>Iniciar Sesión</title>
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
                <center><h1>¡Bienvenido de nuevo!</h1>
                <label class="subtitulo">Ingresa tus credenciales para iniciar sesión</label></center>
                <br />
                <div class="form-group">
                    <label for="nombreUs">Nombre de Usuario</label>
                    <asp:TextBox ID="TB1" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="password">Contraseña</label>
                    <asp:TextBox ID="TB2" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <br />
                <center><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Iniciar Sesión" class="btn btn-primary"/></center>
                <br />
                <center><label for="" class="subtitulo">¿Aún no tienes cuenta?</label>
                    <br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="¡REGISTRATE!" class="btn btn-primary"/></center>
            </div>
        </div>
    </form>
</body>
</html>
