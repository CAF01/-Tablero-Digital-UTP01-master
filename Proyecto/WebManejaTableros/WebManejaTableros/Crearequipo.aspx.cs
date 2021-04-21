using Businesslayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebManejaTableros
{
    public partial class Crearequipo : System.Web.UI.Page
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
            if ((string.IsNullOrEmpty(TB1.Text)) || (string.IsNullOrEmpty(TB2.Text)))
            {
                MimessageBox("ERROR", "Deben completarse ambos campos", 4);
            }
            else
            {
                if(DB.ValidaExistenciaEquipo(TB1.Text))
                {
                    MimessageBox("Error", "El nombre de equipo ya esta en uso, seleccione otro", 2);
                }
                else
                {
                    int res = DB.Insertarunequipo(TB1.Text, TB2.Text, (int)Session["idus"]);
                    if (res > 0)
                    {
                        Session["idequipo"] = res;
                        Response.Redirect("Crearequipo1.aspx");
                    }
                    else
                    {
                        Session["idequipo"] = -1;
                        MimessageBox("ERROR", "Algo fallo por ahí", 4);
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["idequipo"] = -1;
            Response.Redirect("WebForm3.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedIndex>0)
            {
                Image1.ImageUrl = @"/paginaweb/Teams/" + DropDownList1.SelectedValue;
                TB2.Text = DropDownList1.SelectedValue;
            }
            else
            {
                Image1.ImageUrl = null;
                TB2.Text = "";
            }
        }
    }
}