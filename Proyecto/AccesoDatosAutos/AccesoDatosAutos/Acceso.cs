using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using AccesoDatosAutos;
//Espacio de nombres, "direcciones" para los recursos necesarios en el acceso a los datos
//A
namespace AcessoDatosAutos
{
    public class Acceso//Clase para conectarse a nuestra base de datos en SQL
    {
        private string Cadconex;
        SqlConnection Conexion = null;
        public Acceso(string cad)//Solicita la cadena de conexión a la base de datos
        {
            Cadconex = cad;
        }
        //Metodo para simplificar "abrir" nuestra conexión
        public SqlConnection Abrirconexion(ref string msg)
        {
            SqlConnection Conexion = new SqlConnection();
            Conexion.ConnectionString = Cadconex;
            try
            {
                Conexion.Open();
                msg = "Conexión Exitosa";
            }
            catch (Exception h)
            {
                msg = h.Message;
                Conexion = null;
            }
            return Conexion;
        }
        public void Cerrarconexion()
        {
            Conexion.Close();
            Conexion.Dispose();
        }
        //Método para realizar una inserción|modificación|eliminación
        //depende de la instrucción SQL que se pase en los parametros.
        public GenericResponse<bool> ModificarBD(string Sentsql,ref string msg)
        {
            GenericResponse<bool> respuesta = new GenericResponse<bool>(false,string.Empty,false);
            SqlConnection abc = Abrirconexion(ref msg);
            bool r = false;
            SqlCommand carrito = null;
            if (abc != null)
            {
                msg = "Conexión Abierta";
                using (carrito = new SqlCommand())
                {
                    carrito.CommandText = Sentsql;
                    carrito.Connection = abc;
                    try
                    {
                        carrito.ExecuteNonQuery();
                        msg = "Modificación Realizada";
                        respuesta=new GenericResponse<bool>(true, msg, true);
                    }
                    catch (Exception s)
                    {
                        respuesta=new GenericResponse<bool>(false, s.Message, false);
                    }
                }
            }
            else
                msg = "Conexión no procesada";
            abc.Close();
            abc.Dispose();
            return respuesta;
        }
        //Metodo para realizar una consulta rapida en alguna tabla de nuestra base de datos.
        public SqlDataReader ConsultaDR(string querySql,ref string msg)
        {
            SqlConnection abc = Abrirconexion(ref msg);
            SqlCommand vocho = null;
            SqlDataReader caja;
            if(abc==null)
            {
                caja = null;
                msg = "Conexión no procesada";
            }
            else
            {
                using(vocho=new SqlCommand(querySql,abc))
                {
                    try
                    {
                        caja = vocho.ExecuteReader();
                        msg = "Consulta correcta";
                    }
                    catch(Exception s)
                    {
                        msg = "ERROR +" + s.Message;
                        caja = null;
                    }
                }
            }
            return caja;
        }
        //Consulta que devuelve un solo resultado "fila", necesario para las consultas de sesión
        //devuelve una cadena "Nombre", "tipo de usuario", etc.
        public string Consultatipous(string querySql, ref string msg)
        {
            SqlConnection abc = Abrirconexion(ref msg);
            SqlCommand vocho = null;
            //SqlDataReader caja;
            string tipo = "";
            if (abc == null)
            {
                //caja = null;
                msg = "Conexión no procesada";
            }
            else
            {
                using (vocho = new SqlCommand(querySql, abc))
                {
                    try
                    {
                        tipo = (string)vocho.ExecuteScalar();
                        msg = "Consulta correcta";
                    }
                    catch (Exception s)
                    {
                        msg = "ERROR +" + s.Message;
                        //caja = null;
                    }
                }
            }
            return tipo;
        }
        //Consulta que devuelve un solo resultado, el resultado es de tipo entero,
        //especial para consultas que requieren retornar un id por ejemplo
        public int Consultanumerito(string querySql, ref string msg)
        {
            SqlConnection abc = Abrirconexion(ref msg);
            SqlCommand vocho = null;
            //SqlDataReader caja;
            int tipo = -1;
            if (abc == null)
            {
                //caja = null;
                msg = "Conexión no procesada";
            }
            else
            {
                using (vocho = new SqlCommand(querySql, abc))
                {
                    try
                    {
                        if(vocho.ExecuteScalar()!=null)
                        {
                            tipo = (int)vocho.ExecuteScalar();
                        }
                        else
                        {
                            tipo = -1;
                        }
                        msg = "Consulta correcta";
                    }
                    catch (Exception s)
                    {
                        msg = "ERROR +" + s.Message;
                        //caja = null;
                    }
                }
            }
            return tipo;
        }
        //Método para realizar una consulta que contiene un flujo de filas en el resultado
        //Este método se lleva de forma segura, puesto que se utilizan parametros SQL para la integridad
        //de la base de datos.
        public GenericResponse<bool> ConsultaDRseguro(string querySql, ref string msg, SqlParameter[] parametros)
        {
            GenericResponse<bool> resp = new GenericResponse<bool>(false, string.Empty, false); ;
            SqlConnection abc = Abrirconexion(ref msg);
            SqlCommand vocho = null;
            SqlDataReader caja;
            if (abc == null)
            {
                caja = null;
                msg = "Conexión no procesada";
                resp.Message= "Conexión no procesada";
            }
            else
            {
                using (vocho = new SqlCommand(querySql, abc))
                {
                    try
                    {
                        foreach (SqlParameter x in parametros)
                        {
                            vocho.Parameters.Add(x);
                        }
                        caja = vocho.ExecuteReader();
                        if (caja.Read())
                        {
                            resp.Data = true;
                            resp.Result = true;
                        }
                        else
                            resp.Data = false;
                        msg = "Consulta correcta";
                    }
                    catch (Exception s)
                    {
                        resp.Data = false;
                        resp.Message= "ERROR +" + s.Message;
                        resp.Result = false;
                        msg = "ERROR +" + s.Message;
                        caja = null;
                    }
                }
            }
            return resp;
        }
        //Consulta que devuelve un DataSet, una estructura de datos que permite retornarnos una tabla
        //como resultado de una consulta.
        public DataSet ConsultaDataSet(string sql,ref string msg)
        {
            SqlConnection abc = Abrirconexion(ref msg);
            SqlCommand vocho = null;
            DataSet cajagrande = null;
            SqlDataAdapter trailer = null;
            if(abc==null)
            {
                cajagrande = null;
                msg = "Conexión no procesada";
            }
            else
            {
                using(vocho=new SqlCommand(sql,abc))
                {
                    using(trailer=new SqlDataAdapter())
                    {
                        trailer.SelectCommand = vocho;
                        try
                        {
                            cajagrande = new DataSet();
                            trailer.Fill(cajagrande);
                            msg = "Consulta Realizada";
                        }
                        catch(Exception s)
                        {
                            msg = "ERROR " + s.Message;
                            cajagrande = null;
                        }
                    }
                }
                abc.Close();
                abc.Dispose();
            }
            return cajagrande;
        }
        //Mismo metodo para insertar|modificar|eliminar, pero con uso de parametros, mas seguros.
        public GenericResponse<bool> modregistrosmaseguro(string sentencia, ref string mensaje, SqlParameter[] parametros)
        {
            GenericResponse<bool> resp = new GenericResponse<bool>(false, string.Empty, false); ;
            SqlConnection abc = Abrirconexion(ref mensaje);
            SqlCommand instruc = null;
            if (abc != null)
            {
                using (instruc = new SqlCommand())
                {
                    instruc.CommandText = sentencia;
                    instruc.Connection = abc;
                    foreach (SqlParameter x in parametros)
                    {
                        instruc.Parameters.Add(x);
                    }
                    //se asignan los parametros al sqlcommand
                    try
                    {
                        instruc.ExecuteNonQuery();
                        mensaje = "Exito al añadir";
                        resp.Data = true;
                        resp.Result = true;
                        resp.Message = mensaje;
                    }
                    catch (Exception h)
                    {
                        resp.Message = h.Message;
                        resp.Data = false;
                        resp.Result = false;
                    }
                }
            }
            //else
            abc.Close();
            abc.Dispose();
            return resp;
        }

    }

}

