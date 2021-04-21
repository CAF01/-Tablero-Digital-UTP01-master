<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebManejaTableros.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="estilos.css" rel="stylesheet" />
<!-- Required meta tags -->
<meta charset="utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
<!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
<!--Propio-->
<link rel="stylesheet" type="text/css" href="estilos.css"/>
<title>Registro</title>
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
                    <div><br /></div>
                   <div class="form-group">                      
                            <h1>Regístrate</h1>
                            <label class="subtitulo">Llena los campos para completar tu registro</label>
                    </div>
            <div class="form-group">
                <label for="TB1" class="etiqueta">Nombre</label>
                <asp:TextBox ID="TB1" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="TB2" class="etiqueta">Apellido Paterno</label>
                <asp:TextBox ID="TB2" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="TB3" class="etiqueta">Apellido Materno</label>
                <asp:TextBox ID="TB3" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="TB4" class="etiqueta">Nombre de Usuario</label>
                <asp:TextBox ID="TB4" runat="server" class="form-control" MaxLength="99" placeholder="El nombre debe estar conformado por al menos 6 caracteres alfanuméricos"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="TBPASS" class="etiqueta">Contraseña</label>
                <asp:TextBox ID="TBPASS"  class="form-control" runat="server" MaxLength="50" ToolTip="Contraseña de al menos 5 caracteres"></asp:TextBox>
            </div>
            <div class="form-group">
            <label for="tipoUs" class="etiqueta">Tipo de Usuario</label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem>ALUMNO(A)</asp:ListItem>
                    <asp:ListItem>PROFESOR(A)</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <label for="DropDownList1" class="lblcampo">Avatar</label>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="215px" CssClass="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" AutoPostBack="True">
                    <asp:ListItem Text="Predeterminado" Value="1486564400-account_81513.png" />
                    <asp:ListItem Text="Avatar 01" Value="ar-6_111407.png" />
                    <asp:ListItem Text="Avatar 02" Value="ar-5_111403.png"/>
                    <asp:ListItem Text="Avatar 03" Value="156womanofficeworker2_100687.png" />
                    <asp:ListItem Text="Avatar 04" Value="132womanstudent2_100407.png"/>
                    <asp:ListItem Text="Avatar 05" Value="diversity_avatar_people_chinese_woman_lgbt_lesbian_smiling_icon_159081.png"/>
                    <asp:ListItem Text="Avatar 06" Value="diversity_avatar_woman_girl_people_black_smiling_icon_159088.png"/>
                    <asp:ListItem Text="Avatar 07" Value="diversity_avatar_woman_girl_sunglasses_blonde_people_smiling_icon_159097.png"/>
                    <asp:ListItem Text="Avatar 08" Value="woman_user_avatar_account_female_icon_153149.png"/>
                    <asp:ListItem Text="Avatar 09" Value="woman_user_account_gamer_virtual_reality_glasses_icon_153128.png"/>
                    <asp:ListItem Text="Avatar 10" Value="augmentedreality-48_111377.png"/>
                    <asp:ListItem Text="Avatar 11" Value="augmentedreality-24_111356.png"/>
                    <asp:ListItem Text="Avatar 12" Value="man14_117996.png"/>
                    <asp:ListItem Text="Avatar 13" Value="man_people_boy_avatar_glasses_boy_icon_159124.png"/>
                    <asp:ListItem Text="Avatar 14" Value="diversity_avatars_avatar_person_man_people_lgbt_gay_homosexual_smiling_icon_159077.png"/>
                    <asp:ListItem Text="Avatar 15" Value="student3_118006.png"/>
                    <asp:ListItem Text="Avatar 16" Value="130manstudent2_100617.png"/>
                    <asp:ListItem Text="Avatar 17" Value="ar-7_111402.png"/>
                    <asp:ListItem Text="Unicornio" Value="454unicornface_100914.png"/>
                </asp:DropDownList>
                <asp:Image ID="Image1" runat="server" ImageUrl="" Height="114px" Width="168px" />
            <div class="form-group">
                <asp:TextBox ID="TB6" runat="server" class="form-control" Visible="False" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="form-group">
                <center><asp:Button ID="BTN1" runat="server" OnClick="BTN1_Click" Text="Registrarme" class="btn"/></center>
            </div>
            <center><label for="BTNF2" class="subtitulo">¿Ya tienes una cuenta?</label></center>
            <center><asp:Button ID="BTNF2" runat="server" OnClick="BTNF2_Click" Text="¡Inicia Sesión!" class="btn"/></center>
            <br />
        </div>
                </div>
    </form>
</body>
</html>
