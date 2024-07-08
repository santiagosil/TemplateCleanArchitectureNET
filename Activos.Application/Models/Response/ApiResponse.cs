using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activos.Application.Models.Response
{
    public class ApiResult<T>
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Result { get; set; }

        public ApiResult(T? result)
        {
            Code = 200;
            Message = "SUCCESS";
            Result = result;
        }
        public ApiResult(int code, string message, T result)
        {
            Code = code;
            Message = message;
            Result = result;
        }
    }
}
