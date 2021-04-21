using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosAutos
{
    public class GenericResponse<T>
    {
        public T Data  { get; set; }
        public string Message { get; set; }
        public bool Result { get; set; }
        public GenericResponse()
        {

        }
        public GenericResponse(T Data,string message, bool Result)
        {
            this.Data = Data;
            this.Message = message;
            this.Result = Result;
        }
    }
}
