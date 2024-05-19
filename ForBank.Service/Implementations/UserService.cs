using ForBank.DAL.Interfaces;
using ForBank.DAL.Repositories;
using ForBank.Domain.Entity;
using ForBank.Domain.Enum;
using ForBank.Domain.Response;
using ForBank.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForBank.Service.Implementations
{
    public class UserService : IMainService<User>
    {
        private readonly IBaseRepository<User> _userRepository;

        public UserService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns></returns>
        public async Task<IBaseResponse<List<User>>> GetObjects()
        {
            var baseResponse = new BaseResponse<List<User>>();
            try
            {
                var users = await _userRepository.GetAll();
                if (users.Count == 0)
                {
                    baseResponse.Data = new List<User>();
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = users;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<User>>()
                {
                    Description = $"[GetUsers] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<IBaseResponse<User>> CreateObject(User obj)
        {
            
            try
            {
                await _userRepository.Create(obj);
                return new BaseResponse<User>()
                {
                    Description = "Пользователь успешно создан!",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = $"[CreateUser] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            
        }

        /// <summary>
        /// Редактировать пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<IBaseResponse<User>> EditObject(User obj)
        {
            
            try
            {
                await _userRepository.Update(obj);
                return new BaseResponse<User>()
                {
                    Description = "Данные успешно обновлены!",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = $"[EditUser] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<IBaseResponse<User>> DeleteObject(User obj)
        {
            
            try
            {
                await _userRepository.Delete(obj);
                return new BaseResponse<User>()
                {
                    Description = "Пользователь успешно удалён!",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = $"[DeleteUser] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            
        }
    }
}
