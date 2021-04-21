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
    public partial class CrearTablero1 : System.Web.UI.Page
    {
        Negocio DB = null;
        string msg = "";
        int id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((int)Session["idus"] == -1) || (string)Session["tipo"] == "ALUMNO" || (int)Session["idtablero"]<=0)
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
            if(!string.IsNullOrEmpty(TB1.Text)&&!string.IsNullOrEmpty(TB2.Text) && !string.IsNullOrEmpty(TB3.Text)
                && !string.IsNullOrEmpty(TB4.Text) && !string.IsNullOrEmpty(TB5.Text) && !string.IsNullOrEmpty(TB6.Text))
            {
                string[] cads = new string[3];
                cads[0] = TB1.Text; cads[1] = TB3.Text; cads[2] = TB5.Text;
                int[] nums = new int[3];
                nums[0] = Convert.ToInt32(TB2.Text); nums[1] = Convert.ToInt32(TB4.Text); nums[2] = Convert.ToInt32(TB6.Text);
                if(DB.Insertarinsigniastablero(cads, nums, (int)Session["idtablero"]))
                {
                    Session["idtablero"] = -1;
                    Response.Redirect("MisTableros.aspx");
                }
                else
                {
                    MimessageBox("ERROR", "Error al intentar adjuntar las insignias, intenta de nuevo", 4);
                }
            }
            else
            {
                MimessageBox("ERROR", "Debes completar los campos para todas las insignias", 2);
            } 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if ((int)Session["idtablero"] < 0)
            {
                Response.Redirect("WebForm4.aspx");
            }
            else
            {
                DB.CancelarRegistroTablero((int)Session["idtablero"]);
                Session["idtablero"] = -1;
                Response.Redirect("WebForm4.aspx");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedIndex>0)
            {
                Image1.ImageUrl = @"/paginaweb/badges/" + DropDownList1.SelectedValue;
                TB1.Text = DropDownList1.SelectedValue;
            }
            else
            {
                Image1.ImageUrl = null;
                TB1.Text = "";
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedIndex > 0)
            {
                Image2.ImageUrl = @"/paginaweb/badges/" + DropDownList2.SelectedValue;
                TB3.Text = DropDownList2.SelectedValue;
            }
            else
            {
                Image2.ImageUrl = null;
                TB3.Text = "";
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedIndex > 0)
            {
                Image3.ImageUrl = @"/paginaweb/badges/" + DropDownList3.SelectedValue;
                TB5.Text = DropDownList3.SelectedValue;
            }
            else
            {
                Image3.ImageUrl = null;
                TB5.Text = "";
            }
        }

        protected void TB1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}