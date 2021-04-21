<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Misequipos.aspx.cs" Inherits="WebManejaTableros.Misequipos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Mis Equipos</title>
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
                        <asp:ImageButton ID="btnAtras" runat="server" src="img/flechaatras.png" CssClass="btnAtras" OnClick="btnAtras_Click"/>
                    <br/>
                    <center><h1>Mis equipos</h1></center>
                    <center><label class="subtitulo">Selecciona el equipo para poder consultar el tablero en que se encuentra participando o para unirte a un nuevo tablero con ese equipo.</label>
                    <div><br /></div>
                    <center><div class="form-group">
                        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="table table-striped table-hover" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField HeaderText="Selecciona" ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="btn">
<ControlStyle CssClass="btnMini"></ControlStyle>
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
                        </asp:GridView>
                        <br />
                        <br />
                    </div></center>
                    <center><div class ="form-group">
                            <h3 CssClass="datospersonales" Style="font-size:18pt">Consultar Tablero</h3>
                            <asp:Button ID="Button2" runat="server" Text="Ver Tablero" OnClick="Button2_Click1" CssClass="btn" />
                    </div></center>
                    <div><br /></div>
                    <center><div class="form-group">
                            <h3 CssClass="datospersonales" Style="font-size:18pt">Unirse a un Tablero</h3>
                            <asp:Button ID="Button3" runat="server" Text="Unirse a un Tablero" OnClick="Button3_Click" CssClass="btn" />
                    </div></center>
                    <div class="form-group">
                        <br />
                        <br />
                        <center><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Regresar" CssClass="btnsecundario" /></center>
                    </div>
                    <br />
                    <br />
                </div>
            </section>
        </div>
    </form>
</body>
</html>
