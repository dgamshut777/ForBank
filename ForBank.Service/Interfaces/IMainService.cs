using ForBank.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForBank.Service.Interfaces
{
    public interface IMainService<T>
    {
        Task<IBaseResponse<List<T>>> GetObjects();
        Task<IBaseResponse<T>> CreateObject(T obj);
        Task<IBaseResponse<T>> EditObject(T obj);
        Task<IBaseResponse<T>> DeleteObject(T obj);
    }
}
