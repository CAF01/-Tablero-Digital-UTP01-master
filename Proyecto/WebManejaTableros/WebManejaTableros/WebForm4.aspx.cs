using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Businesslayer;
using System.Configuration;

namespace WebManejaTableros
{
    public partial class WebForm4 : System.Web.UI.Page
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
                    Image1.ImageUrl = (string)Session["url"];
                    nam = (string)Session["nom"];
                    //Response.Write(nam);
                    //msg = "Post";
                }
                else
                {
                    DB = new Negocio(ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
                    Session["Datab"] = DB;
                    object[] resp = DB.RecuperaDatosIniciadosmaestro((string)Session["user"], (string)Session["pass"]);
                    Session["nom"] = (string)resp[0];
                    Session["url"] = (string)resp[1];
                    Label1.Text=((string)resp[0]);
                    Image1.ImageUrl = @"/paginaweb/Perfiles/" + (string)resp[1];
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["Datab"] = null;
            Session["nom"] = null;
            Session["url"] = null;
            Session["user"] = null;
            Session["pass"] = null;
            Session["idus"] = -1;
            Response.Redirect("WebForm2.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CrearTablero.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisTableros.aspx");
        }
    }
}