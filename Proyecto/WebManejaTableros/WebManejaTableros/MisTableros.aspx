<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisTableros.aspx.cs" Inherits="WebManejaTableros.MisTableros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Mis Tableros - Profesor</title>
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
                        <asp:ImageButton ID="btnAtras" runat="server" src="img/flechaatras.png" CssClass="btnAtras" OnClick="btnAtras_Click"/>
                    <br/>
                    <center><h1>Mis tableros</h1></center>                 
                    <div class="form-row">
                        <asp:Label ID="Label1" runat="server" Text="Label" CssClass="etiqueta" style="font-size:large"></asp:Label>
                    </div>
                    <div class="form-row">
                        <h2>PROFESOR</h2>
                    </div>
                    <div><br /></div>
                    <center><div class="form-row">
                        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="table table-striped table-hover" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
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
                        </asp:GridView></center>
                    </div>
                </div>
            </section>
        </div>
    </form>
</body>
</html>
