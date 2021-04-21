<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Unirsetablero.aspx.cs" Inherits="WebManejaTableros.Unirsetablero" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Unirse al tablero de un curso - Individual</title>
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
</head>
<body>
    <form id="form1" runat="server">
        <div class="barrita"></div>
        <div class="container">
            <br />
                <asp:ImageButton ID="btnAtras" runat="server" src="img/flechaatras.png" CssClass="btnAtras" OnClick="btnAtras_Click"/>
            <br/>
            <div><br /></div>
            <header>
                <center><h1>¡Unirse al tablero de un curso!</h1>
                <h3>Escribe el código que te proporcionó tu profesor y después presiona <b>Unirme</b></h3></center>
            </header>
            <div class="form-group">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
                <center><asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Unirme" /></center>
            </div>           
        </div>
    </form>
</body>
</html>
