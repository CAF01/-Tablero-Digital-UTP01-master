<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tableroprofesor.aspx.cs" Inherits="WebManejaTableros.Tableroprofesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Tablero - Profesor</title>
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
                    <center><h1> T A B L E R O</h1></center>
                    <div class="centry">
                        <center><label class="centrys" for="Label4">Código de Clase</label></center>
                        <center><asp:Label ID="Label4" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large" Font-Underline="True"></asp:Label></center>
                    </div>
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
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-hover" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" CellPadding="4" ForeColor="#333333" GridLines="None"
                            style="margin-left:auto; margin-right:auto; align-items:center; text-align:center;"
                            >
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ButtonType="Button" HeaderText="SELECCIONAR" ShowSelectButton="True" >
                                <ControlStyle CssClass="btnMini" />
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
                    <br />
                </div>
            <center><h1> Otorgar insignias</h1></center>
                    <center><label class="subtitulo">Seleccione la actividad e insignia correspondiente para poder otorgarla</label></center>
            <div class="form-group">
                   <label class="etiqueta" for="">Actividad</label>
                    <br />
                   <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
            </div>          
            <br />
            <div class="form-group">
                <label class="etiqueta" for="">Valor de Insignia seleccionada</label>
                <br />
                <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <br />
            <div class="form-group">
                <center><asp:Button ID="Button1" runat="server" CssClass="btn" Text="Otorgar insignias" Enabled="False" OnClick="Button1_Click" /></center>
            </div>
            </section>
        </div>       
    </form>
</body>
</html>
