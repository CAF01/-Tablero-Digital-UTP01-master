<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearTablero1.aspx.cs" Inherits="WebManejaTableros.CrearTablero1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Crear tablero - Insignias</title>
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
                    <div class="form-group">
                         <h2><b>Insignias del tablero</b></h2>
                         <label class="subtitulo">Registra el valor y la URL perteneciente a la insignia que deseas registrar en el tablero para así poder otorgarla.<br />
                         Recuerda que el valor de la insignia debe ser numérico. </label>
                    </div>
                    <div><br /></div>
                    <div class="form-group">
                        <label class="etiqueta" for="Url1">URL Imagen</label><br />
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                            CssClass="form-control" Width="301"
                            >
                            <asp:ListItem>--Seleccionar--</asp:ListItem>
                            <asp:ListItem Value="1490877817-sport-badges07_82422.png">Insignia 01</asp:ListItem>
                            <asp:ListItem Value="1490877818-sport-badges05_82419.png">Insignia 02</asp:ListItem>
                            <asp:ListItem Value="1490877822-sport-badges08_82413.png">Insignia 03</asp:ListItem>
                            <asp:ListItem Value="1490877823-sport-badges06_82415.png">Insignia 04</asp:ListItem>
                            <asp:ListItem Value="1490877846-sport-badges11_82417.png">Insignia 05</asp:ListItem>
                            <asp:ListItem Value="1490877848-sport-badges04_82412.png">Insignia 06</asp:ListItem>
                            <asp:ListItem Value="award_badge_medal_position_icon_127208.png">Insignia 07</asp:ListItem>
                            <asp:ListItem Value="giftbox_106607.png">Insignia 08</asp:ListItem>
                            <asp:ListItem Value="procentbadge_106597.png">Insignia 09</asp:ListItem>
                            <asp:ListItem Value="st_patricks_day_badge_clover_irish_ireland_icon_132818.png">Insignia 10</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Image ID="Image1" runat="server" Height="114px" Width="168px"
                                    style="margin-left:50px; margin-bottom:50px auto;" />
                        <asp:TextBox ID="TB1" runat="server" CssClass="form-control" Visible="False" OnTextChanged="TB1_TextChanged"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="etiqueta" for="Valor1s">Valor</label>
                        <asp:TextBox ID="TB2" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                    <div class="">
                        <label class="etiqueta" for="Url2">URL Imagen</label><br />
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                            CssClass="form-control" Width="301"
                            >
                            <asp:ListItem>--Seleccionar--</asp:ListItem>
                            <asp:ListItem Value="1490877817-sport-badges07_82422.png">Insignia 01</asp:ListItem>
                            <asp:ListItem Value="1490877818-sport-badges05_82419.png">Insignia 02</asp:ListItem>
                            <asp:ListItem Value="1490877822-sport-badges08_82413.png">Insignia 03</asp:ListItem>
                            <asp:ListItem Value="1490877823-sport-badges06_82415.png">Insignia 04</asp:ListItem>
                            <asp:ListItem Value="1490877846-sport-badges11_82417.png">Insignia 05</asp:ListItem>
                            <asp:ListItem Value="1490877848-sport-badges04_82412.png">Insignia 06</asp:ListItem>
                            <asp:ListItem Value="award_badge_medal_position_icon_127208.png">Insignia 07</asp:ListItem>
                            <asp:ListItem Value="giftbox_106607.png">Insignia 08</asp:ListItem>
                            <asp:ListItem Value="procentbadge_106597.png">Insignia 09</asp:ListItem>
                            <asp:ListItem Value="st_patricks_day_badge_clover_irish_ireland_icon_132818.png">Insignia 10</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Image ID="Image2" runat="server" Height="114px" Width="168px"
                                    style="margin-left:50px; margin-bottom:50px auto;" />
                        <asp:TextBox ID="TB3" runat="server" CssClass="form-control" Visible="False"></asp:TextBox>
                    </div>
                    <div class="">
                        <label class="etiqueta" for="Valor2s">Valor</label>
                        <asp:TextBox ID="TB4" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="">
                        <label class="etiqueta" for="Url3">URL Imagen</label><br />
                        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"
                            CssClass="form-control" Width="301"
                            >
                            <asp:ListItem>--Seleccionar--</asp:ListItem>
                            <asp:ListItem Value="1490877817-sport-badges07_82422.png">Insignia 01</asp:ListItem>
                            <asp:ListItem Value="1490877818-sport-badges05_82419.png">Insignia 02</asp:ListItem>
                            <asp:ListItem Value="1490877822-sport-badges08_82413.png">Insignia 03</asp:ListItem>
                            <asp:ListItem Value="1490877823-sport-badges06_82415.png">Insignia 04</asp:ListItem>
                            <asp:ListItem Value="1490877846-sport-badges11_82417.png">Insignia 05</asp:ListItem>
                            <asp:ListItem Value="1490877848-sport-badges04_82412.png">Insignia 06</asp:ListItem>
                            <asp:ListItem Value="award_badge_medal_position_icon_127208.png">Insignia 07</asp:ListItem>
                            <asp:ListItem Value="giftbox_106607.png">Insignia 08</asp:ListItem>
                            <asp:ListItem Value="procentbadge_106597.png">Insignia 09</asp:ListItem>
                            <asp:ListItem Value="st_patricks_day_badge_clover_irish_ireland_icon_132818.png">Insignia 10</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Image ID="Image3" runat="server" Height="114px" Width="168px"
                                    style="margin-left:50px; margin-bottom:50px auto;" />
                        <asp:TextBox ID="TB5" runat="server" CssClass="form-control" Visible="False"></asp:TextBox>
                    </div>
                    <div class="">
                        <label class="etiqueta" for="Valor3s">Valor</label>
                        <asp:TextBox ID="TB6" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div><br /></div>
                    <div class="form-row">
                        <div class="col-lg-12 col-sm-2">
                             <center><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Agregar Insignias" CssClass="btn" /></center>
                        </div>
                    </div>
                    <br />
                    <div class="form-row">
                        <div class="col-lg-12 col-sm-2">
                            <center><asp:Button ID="Button2" runat="server" class="btnCancelar" OnClick="Button2_Click" Text="Cancelar registro de Tablero" /></center>
                         </div>
                    </div>
                </div>
            </section>
       </div>
    </form>
</body>
</html>
