using ForBank.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForBank.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }//текст

        public StatusCode StatusCode { get; set; }//статус запроса

        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        T Data { get; set; }

        StatusCode StatusCode { get; set; }//статус запроса

        string Description { get; set; }//текст

    }
}
