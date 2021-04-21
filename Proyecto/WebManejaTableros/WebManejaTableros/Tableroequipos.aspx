<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tableroequipos.aspx.cs" Inherits="WebManejaTableros.Tableroequipos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Tablero</title>
<!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
<!--Propio-->
<link rel="stylesheet" type="text/css" href="estilos.css"/>
<script src="js/sweetalert2.all.min.js"></script>
<link href="css/sweetalert2.min.css" rel="stylesheet" />
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
             <section>
                <div class="barrita"></div>
                <div class="container">
                    <br />
                        <asp:ImageButton ID="btnAtras" runat="server" src="img/flechaatras.png" CssClass="btnAtras" OnClick="btnAtras_Click"/>
                    <br/>
                    <center><h1> T A B L E R O</h1></center>
                    <br />
                    <div class="centry">
                        <label for="Titulo" class="centrys">Título: </label>
                        <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large" Font-Underline="False" ForeColor="#006600"></asp:Label>
                    </div>
                    <br />
                    <div class="centry">
                        <label "for="Curso" class="centrys">Curso: </label>
                        <asp:Label ID="Label2" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large" Font-Underline="False" ForeColor="#006600"></asp:Label>
                    </div>
                    <br />
                    <div class="centry">
                        <label for="profesor" class="centrys">Profesor: </label>
                        <asp:Label ID="Label3" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large" Font-Underline="False" ForeColor="#006600"></asp:Label>
                    </div>
                        <br />
                    <center>
                           <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-hover" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ButtonType="Button" HeaderText="VER" SelectText="Integrantes" ShowSelectButton="True">
                                <ControlStyle CssClass="btnMini" />
                                <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                <ItemStyle Font-Italic="True" Font-Names="Ebrima" />
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
                    </center>
                </div>
            </section>
    </form>
</body>
</html>
