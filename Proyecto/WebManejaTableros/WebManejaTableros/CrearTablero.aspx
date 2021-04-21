<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearTablero.aspx.cs" Inherits="WebManejaTableros.CrearTablero" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Crear Tablero - Datos</title>
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
        <div>
           <section>
                <div class="barrita"></div>
                <div class="container">
                    <br />            
                    <center><h1>Crear Tablero</h1></center>
                    <center><label class="subtitulo">Introduce los datos del nuevo tablero</label></center>
                    <div class="form-group">
                        <label class="etiqueta" for="titulo">Título del Tablero</label>
                        <asp:TextBox ID="TB1" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="etiqueta" for="curso"> Nombre del Curso/Materia</label>
                        <asp:TextBox ID="TB2" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div><br /></div>
                    <div class="form-group">
                        <center><asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Crear Tablero" CssClass="btn"/></center>
                    </div>
                    <br />
                    <div class="form-group">
                        <center>
                            <asp:Button ID="Button4" runat="server" CssClass="btnCancelar" OnClick="Button4_Click" Text="Cancelar registro de tablero" />
                        </center>
                    </div>
                    <div><br /></div>
                    <div class="form-group">
                        <h2><b>Actividades del tablero</b></h2>
                        <label class="subtitulo">Si ya has creado el tablero, agrega las actividades que lo conformarán y presiona <b>Continuar</b>. Si necesitas agregar más actividades presiona <b>+Actividades</b>.</label> </div>
                    <br/>
                    <div class="form-group">
                        <label class="etiqueta" for="act1"> Actividad</label>
                        <asp:TextBox ID="TB3" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="etiqueta" for="act2"> Actividad</label>
                        <asp:TextBox ID="TB4" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="etiqueta" for="act3"> Actividad</label>
                        <asp:TextBox ID="TB5" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div><br /></div>
                    <div class="form-row">
                        <div class="col-lg-6 col-sm">
                            <center><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Continuar" CssClass="btn"/></center>
                        </div>
                        <div><br /></div>
                        <div class="col-lg-6 col-sm">
                            <center><asp:Button ID="Button2" runat="server" Text=" + Actividades" OnClick="Button2_Click" CssClass="btnverde"/></center>
                        </div>
                    </div>
                </div>
            </section>
    </form>
</body>
</html>
