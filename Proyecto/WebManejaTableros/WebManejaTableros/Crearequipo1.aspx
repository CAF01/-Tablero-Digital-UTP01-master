<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crearequipo1.aspx.cs" Inherits="WebManejaTableros.Crearequipo1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<!-- Required meta tags -->
<meta charset="utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
<!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
<link rel="stylesheet" type="text/css" href="estilos.css"/>
<title>Formación de equipo</title>
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
            <section>
            <div class="container">
                <br />
                    <asp:ImageButton ID="btnAtras" runat="server" src="img/flechaatras.png" CssClass="btnAtras" OnClick="btnAtras_Click"/>
                <br/>
                <center><div class="align-items-center justify-content-between">
                        <br/>
                        <br/>
                        <asp:Label ID="lblNomEquipo" runat="server" CssClass="datospersonales" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Label"></asp:Label>
                        <br />
                        <h2>¡AÑADE INTEGRANTES A TU EQUIPO!</h2>
                </div></center>
                <label class="subtitulo" for="">Escribe el nombre de usuario de quienes serán tus compañeros de equipo y agrégalos. Si deseas añadir más compañeros a tu equipo presiona <b>Agregar más compañeros</b></label>
                <div><br /></div>
                <div class="form-group">
                    <label class="etiqueta" for="">Integrante 1</label>
                    <asp:TextBox ID="TB1" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="etiqueta" for="">Integrante 2</label>
                    <asp:TextBox ID="TB2" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="etiqueta" for="">Integrante 3</label>
                    <asp:TextBox ID="TB3" runat="server" class="form-control"></asp:TextBox>
                </div>
                <br />
                <div class="form-group">
                   <center><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Finalizar registro" class="btn"/></center>
                </div>
                <div><br/></div>
                <div class="form-group">
                   <center><asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Agregar más compañeros" class="btn"/></center>
                </div>
        </div>
    </form>
</body>
</html>
