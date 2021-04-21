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
    public partial class MisTableros : System.Web.UI.Page
    {
        Negocio DB = null;
        string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["user"] == null && (string)Session["pass"] == null || (string)Session["tipo"]=="ALUMNO")
            {
                Response.Redirect("WebForm2.aspx");
            }
            else
            {
                if (IsPostBack)
                {
                    DB = (Negocio)Session["Datab"];
                    DataTable tab = (DataTable)Session["tablero"];
                    GridView1.DataSource = tab;
                    GridView1.DataBind();
                }
                else
                {
                    DB = new Negocio(ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
                    Session["Datab"] = DB;
                    DataTable tab = DB.ConsultaTablerosProfesor((int)Session["idus"]);
                    Label1.Text = (string)Session["nom"];
                    Session["tablero"] = tab;
                    GridView1.DataSource=tab;
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
            Session["numtablero"] = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);
            Response.Redirect("Tableroprofesor");
            //Session["numtablero"]
        }

        protected void btnAtras_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WebForm4.aspx");
        }
    }
}