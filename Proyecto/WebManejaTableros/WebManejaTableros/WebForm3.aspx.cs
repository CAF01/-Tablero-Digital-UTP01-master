using Businesslayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebManejaTableros
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        Negocio DB = null;
        string msg = "";
        string nam = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["user"] == null && (string)Session["pass"] == null)
            {
                Response.Redirect("WebForm2.aspx");
            }
            else
            {
                if (IsPostBack)
                {
                    DB = (Negocio)Session["Datab"];
                    imgAvatar.ImageUrl = (string)Session["url"];
                    nam = (string)Session["nom"];
                    GridView1.DataSource = (DataSet)Session["Tab"];
                    GridView1.DataBind();
                    //Response.Write(nam);
                    //msg = "Post";
                }
                else
                {
                    DB = new Negocio(ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
                    Session["Datab"] = DB;
                    object[] toma=DB.RecuperaDatosIniciados((string)Session["user"], (string)Session["pass"]);
                    Session["nom"] = (string)toma[0];
                    Session["url"] = (string)toma[1];
                    lblNombre.Text = (string)toma[0];
                    imgAvatar.ImageUrl = @"/paginaweb/Perfiles/" + (string)Session["url"];
                    DataSet tabla = (DataSet)toma[2];
                    Session["Tab"] = tabla;
                    GridView1.DataSource = tabla.Tables[0];
                    GridView1.DataBind();
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
            int tablero=Convert.ToInt32((GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text));
            Session["numtablero"] = tablero;
            Response.Redirect("Tablero.aspx");
            //Session["numtablero"]
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Misequipos.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["Datab"] = null;
            Session["numtablero"] = -1;
            Session["nom"] = null;
            Session["url"] = null;
            Session["Tab"] = null;
            Session["user"] = null;
            Session["pass"] = null;
            Session["idus"] = -1;
            Response.Redirect("WebForm2.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Crearequipo.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Unirsetablero.aspx");
        }
    }
}