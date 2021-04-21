using Businesslayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebManejaTableros
{
    public partial class Unirsetablero : System.Web.UI.Page
    {
        Negocio DB = null;
        string msg = "";
        string nam = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["idus"] <= 0 || (string)Session["tipo"]!="ALUMNO")
            {
                Response.Redirect("WebForm2.aspx");
            }
            else
            {
                if (IsPostBack)
                {
                    DB = (Negocio)Session["Datab"];
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            AccesoDatosAutos.GenericResponse<bool> respuesta = (DB.Verificaexistenciausuariotablero((int)Session["idus"], TextBox1.Text));
            if (respuesta.Result)
            {
                Session["numtablero"] = Convert.ToInt32(respuesta.Message);
                Response.Redirect("Tablero.aspx");
            }
            else
            {
                MimessageBox("ERROR", respuesta.Message, 1);
                //Manda sweet del error (2 errores validados);
            }
        }

        protected void btnAtras_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WebForm3.aspx");
        }
    }
}