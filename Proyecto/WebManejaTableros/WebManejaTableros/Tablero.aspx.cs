using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Businesslayer;

namespace WebManejaTableros
{
    public partial class Tablero : System.Web.UI.Page
    {
        Negocio DB = null;
        string msg = "";
        int id = -1;
        int tablero = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["idus"] == -1|| (int)Session["numtablero"]<=0)
            {
                Response.Redirect("WebForm2.aspx");
            }
            else
            {
                if (IsPostBack)
                {
                    DB = (Negocio)Session["Datab"];
                    id = (int)Session["idus"];
                    tablero = (int)Session["numtablero"];
                    //msg = "Post";
                }
                else
                {
                    DB = new Negocio(ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
                    Session["Datab"] = DB;
                    tablero = (int)Session["numtablero"];
                    string[] datos=DB.recuperardatostablero(tablero);
                    Label3.Text = datos[0];
                    Label1.Text = datos[1];
                    Label2.Text = datos[2];
                    GridView1.DataSource = DB.Construirtablero(tablero);
                    GridView1.DataBind();
                    //Select para tablero
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

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void btnAtras_Click(object sender, ImageClickEventArgs e)
        {
            Session["numtablero"] = -1;
            Response.Redirect("WebForm3.aspx");
        }
    }
}