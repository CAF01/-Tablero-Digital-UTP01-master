using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using AcessoDatosAutos;
using Businesslayer;
using System.Configuration;

namespace WebManejaTableros
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Negocio DB = null;
        //Acceso DB = null;
        //string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            TB6.Text = DropDownList1.SelectedValue;
            Image1.ImageUrl = @"/paginaweb/Perfiles/" + DropDownList1.SelectedValue;
            TBPASS.Attributes.Add("value", TBPASS.Text);
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
                    TBPASS.Attributes["type"] = "password";
                    //msg = "New";
                }
                //Response.Write(msg);
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

        protected void BTN1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(TB1.Text)) || (string.IsNullOrEmpty(TB2.Text))||
                (string.IsNullOrEmpty(TB3.Text)) || (string.IsNullOrEmpty(TB4.Text))||
                (string.IsNullOrEmpty(TBPASS.Text)) || (string.IsNullOrEmpty(TB6.Text))||
                RadioButtonList1.SelectedIndex<0)
            {
                MimessageBox("ERROR", "¡AÚN HAY CAMPOS VACIOS!", 4);
            }
            else
            {
                if(TB4.Text.Length<6 || TBPASS.Text.Length<5 || TB4.Text.Contains(" "))
                {
                    if (TB4.Text.Contains(" "))
                        MimessageBox("ERROR", "EL NOMBRE DE USUARIO NO PUEDE CONTENER ESPACIOS EN BLANCO", 2);
                    else
                    {
                        if (TB4.Text.Length < 6)
                            MimessageBox("ERROR", "El nombre de usuario debe contener al menos 6 caracteres", 2);
                        else
                            MimessageBox("ERROR", "La contraseña debe contener al menos 5 caracteres", 2);
                    }
                }
                else
                {
                    if (DB.ValidaExistenciaUsuario(TB4.Text))
                    {
                        MimessageBox("ERROR", "EL NOMBRE DE USUARIO INGRESADO YA EXISTE, SELECCIONE UNO DIFERENTE", 4);
                    }
                    else
                    {
                        string tip = "";
                        if (RadioButtonList1.SelectedValue == "ALUMNO(A)")
                        {
                            tip = "ALUMNO";
                        }
                        else
                        {
                            tip = "PROFESOR";
                        }
                        string[] cad = new string[7];
                        cad[0] = TB1.Text.ToUpper();
                        cad[1] = TB2.Text.ToUpper();
                        cad[2] = TB3.Text.ToUpper();
                        cad[3] = TB4.Text.ToUpper();
                        cad[4] = TBPASS.Text.ToUpper();
                        cad[5] = tip;
                        cad[6] = TB6.Text;
                        DB.InsertarUsuario(cad);
                        TB1.Text = ""; TB2.Text = ""; TB3.Text = ""; TB4.Text = ""; TBPASS.Text = ""; TB6.Text = ""; RadioButtonList1.SelectedIndex = -1;
                        TBPASS.Attributes.Add("value", "");
                        DropDownList1.SelectedIndex = 0;
                        TB6.Text = DropDownList1.SelectedValue;
                        Image1.ImageUrl = @"/paginaweb/Perfiles/" + DropDownList1.SelectedValue;
                        MimessageBox("CORRECTO", "REGISTRO COMPLETADO", 3);
                    }
                }
            }
        }

        protected void BTNF2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Image1.ImageUrl = @"/paginaweb/Perfiles/" + DropDownList1.SelectedValue;
            TB6.Text = DropDownList1.SelectedValue;
        }
    }
}