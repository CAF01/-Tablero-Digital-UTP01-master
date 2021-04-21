using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using Businesslayer;
using System.Configuration;

namespace WebManejaTableros
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Negocio DB = null;
        string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["user"] != null && (string)Session["pass"] != null)
            {
                if ((string)Session["tipo"] == "ALUMNO")
                    Response.Redirect("WebForm3.aspx");
                else
                    Response.Redirect("WebForm4.aspx");
            }
            else
            {
                if (IsPostBack)
                {
                    DB = (Negocio)Session["Datab"];
                    //msg = "Post";
                }
                else
                {
                    DB = new Negocio(ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
                    Session["Datab"] = DB;
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
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(TB1.Text)) || (string.IsNullOrEmpty(TB2.Text)))
            {
                MimessageBox("CAMPOS VACIOS", "NECESITA COMPLETAR AMBOS CAMPOS PARA INCIAR SESIÓN", 2);
            }
            else
            {
                object[] resp = DB.IniciarSesion(TB1.Text, TB2.Text);
                if (resp!=null)
                {
                    Session["user"] = (string)resp[0];
                    Session["pass"] = (string)resp[1];
                    Session["tipo"] = (string)resp[2];
                    Session["idus"] = (int)resp[3];
                    if((string)resp[2]=="ALUMNO")
                        Response.Redirect("WebForm3.aspx");
                    else
                        Response.Redirect("WebForm4.aspx");
                }
                else
                {
                    MimessageBox("ERROR", "CREDENCIALES INCORRECTAS, INTENTA DE NUEVO", 4);
                    TB1.Text = "";TB2.Text = "";
                }
                    //Response.Redirect("WebForm2.aspx");
            }
        }

    }
}