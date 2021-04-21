<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crearequipo.aspx.cs" Inherits="WebManejaTableros.Crearequipo" %>

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
<title>Registrar Equipo</title>
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
                <br/>
                <center><h1>¡Registra un nuevo equipo!</h1>
                <label class="subtitulo">Completa los campos para el registro del nuevo equipo</label></center>
                <div class="form-group">
                    <label class="etiqueta" for="nameEquipo">Nombre del equipo</label>
                    <asp:TextBox ID="TB1" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="etiqueta" for="imgEquipo">Selecciona la Imagén para tu equipo</label>
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="form-control"
                        Width="301px"
                        >
                        <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                        <asp:ListItem Value="team-work_88989.png">Avatar 01</asp:ListItem>
                        <asp:ListItem Value="teamfemale_119531.png">Avatar 02</asp:ListItem>
                        <asp:ListItem Value="team_people_work_icon_176863.png">Avatar 03</asp:ListItem>
                        <asp:ListItem Value="team_people_icon_176892.png">Avatar 04</asp:ListItem>
                        <asp:ListItem Value="hearthand_119577.png">Avatar 05</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Image ID="Image1" runat="server"  Height="114px" Width="168px"
                        style="margin-left:50px; margin-bottom:50px auto"
                        />
                    <asp:TextBox ID="TB2" runat="server" class="form-control" Visible="False" ></asp:TextBox>
                </div>
                <br />
                <br />
                <div class="form-group">
                    <center>                        
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Registrar y continuar" class="btn"/>                       
                    </center>
                </div>
                <br />
                <div class="form-group">
                    <center>
                        <asp:Button ID="Button2" runat="server" CssClass="btnCancelar" Text="Cancelar registro" OnClick="Button2_Click"></asp:Button>
                    </center>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
