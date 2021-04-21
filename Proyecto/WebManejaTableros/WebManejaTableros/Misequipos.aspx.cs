using Businesslayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace WebManejaTableros
{
    public partial class Misequipos : System.Web.UI.Page
    {
        Negocio DB = null;
        string msg = "";
        int id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["idus"] == -1)
            {
                Response.Redirect("WebForm2.aspx");
            }
            else
            {
                if (IsPostBack)
                {
                    DB = (Negocio)Session["Datab"];
                    id = (int)Session["idus"];
                    //msg = "Post";
                }
                else
                {
                    DB = new Negocio(ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
                    Session["Datab"] = DB;
                    id = (int)Session["idus"];
                    GridView1.DataSource = DB.ConsultaEquiposdeunusuario(id);
                    GridView1.DataBind();
                    Button2.Enabled = false;
                    Button3.Enabled = false;
                }
            }
        }
        public void MimessageBox(string titulo, string msg, short tipo)
        {
            string icono = "";
            switch (tipo)
            {
                case 1:
                    icono = "info";
                    break;
                case 2:
                    icono = "warning";
                    break;
                case 3:
                    icono = "success";
                    break;
                case 4:
                    icono = "error";
                    break;
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "clave" + tipo, "sweetm('" + titulo + "','" + msg + "','" + icono + "')", true);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(GridView1.SelectedIndex>=0)
            {
                int equipo = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);
                Session["numequipotablero"] = equipo;
                SqlDataReader resp = DB.Consultaintegrantesdeequipo(equipo);
                if(resp.HasRows)
                {
                    List<string> lista = new List<string>();
                    lista.Clear();
                    while(resp.Read())
                    {
                        lista.Add(" | Usuario:" + resp.GetString(0) + ", Nombre:" + resp.GetString(1)+" | ");
                    }
                    int a = 0;
                    string b = "";
                    while(a<lista.Count)
                    {
                        b = b + lista[a];
                        a++;
                    }
                    MimessageBox("INTEGRANTES DEL EQUIPO", b, 1);
                }
                int idtablero = DB.idtableroequipo(equipo);
                if ( idtablero>0)
                {
                    Session["numtablero"] = idtablero;//Var de Sesión para id de tablero
                    Button2.Enabled = true;
                    Button3.Enabled = false;
                }
                else
                {
                    Session["numtablero"] = -1;
                    Button3.Enabled = true;
                    Button2.Enabled = false;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm3.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Tableroequipos.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Unirsetableroequipo.aspx");
        }

        protected void btnAtras_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WebForm3.aspx");
        }
    }
}