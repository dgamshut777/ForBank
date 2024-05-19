using Azure;
using ForBank.Domain.Entity;
using ForBank.HelpClasses;
using ForBank.Service.Implementations;
using ForBank.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using Functions = ForBank.HelpFunctions.HelpFunctions;

namespace ForBank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMainService<User> _userService;

        public UserController(ILogger<UserController> logger, IMainService<User> userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [Route("/GetUsers")]
        [HttpGet]
        public async Task<StatusForOut> GetUsers()
        {
            var responseUsers = await _userService.GetObjects();
            StatusForOut status = new StatusForOut();
            if (responseUsers.StatusCode == Domain.Enum.StatusCode.OK)
            {
                status = Functions.CreateResponseForOut(true, responseUsers.Description, responseUsers.Data);
            }
            else
            {
                status = Functions.CreateResponseForOut(true, responseUsers.Description);
            }
            return status;
        }

        [Route("/CreateUser")]
        [HttpPost]
        public async Task<StatusForOut> CreateUser([FromBody] JsonElement userJson)
        {
            User user = JsonConvert.DeserializeObject<User>(System.Text.Json.JsonSerializer.Serialize(userJson));
            StatusForOut status = new StatusForOut();
            bool flag = true;
            foreach(var card in user.Cards)
            {
                if (!Regex.IsMatch(card.FullName, @"^[a-zA-Z ]+$"))
                    flag = false;
            }
            if(flag)
            {
                var response = await _userService.CreateObject(user);
                if(response.StatusCode == Domain.Enum.StatusCode.OK)
                    status = Functions.CreateResponseForOut(true, response.Description);
                else
                    status = Functions.CreateResponseForOut(false, response.Description);
            }
            else
            {
                status = Functions.CreateResponseForOut(false, "¬ладелец карты должен быть заполнен только латинскими буквами!");
            }
            return status;
        }

        [Route("/UpdateUser")]
        [HttpPut]
        public async Task<StatusForOut> UpdateUser([FromBody] JsonElement userJson)
        {
            User user = JsonConvert.DeserializeObject<User>(System.Text.Json.JsonSerializer.Serialize(userJson));
            StatusForOut status = new StatusForOut();
            bool flag = true;
            foreach (var card in user.Cards)
            {
                if (!Regex.IsMatch(card.FullName, @"^[a-zA-Z ]+$"))
                    flag = false;
            }
            if (flag)
            {
                var response = await _userService.EditObject(user);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                    status = Functions.CreateResponseForOut(true, response.Description);
                else
                    status = Functions.CreateResponseForOut(false, response.Description);
            }
            else
            {
                status = Functions.CreateResponseForOut(false, "¬ладелец карты должен быть заполнен только латинскими буквами!");
            }
            return status;
        }

        [Route("/DeleteUser")]
        [HttpDelete]
        public async Task<StatusForOut> DeleteUser(int id)
        {
            var responseUsers = await _userService.GetObjects();
            StatusForOut status = new StatusForOut();
            if (responseUsers.StatusCode == Domain.Enum.StatusCode.OK)
            {
                var user = responseUsers.Data.FirstOrDefault(x => x.Id == id);
                var responseDelete = await _userService.DeleteObject(user);
                if (responseDelete.StatusCode == Domain.Enum.StatusCode.OK)
                    status = Functions.CreateResponseForOut(true, responseDelete.Description);
                else
                    status = Functions.CreateResponseForOut(false, responseDelete.Description);
            }
            else
            {
                status = Functions.CreateResponseForOut(false, responseUsers.Description);
            }

            return status;
        }

        [Route("/GetUser")]
        [HttpGet]
        public async Task<StatusForOut> GetUser(int id)
        {
            StatusForOut status = new StatusForOut();
            var responseUsers = await _userService.GetObjects();
            if (responseUsers.StatusCode == Domain.Enum.StatusCode.OK)
            {
                var user = responseUsers.Data.FirstOrDefault(x => x.Id == id);
                if(user != null)
                    status = Functions.CreateResponseForOut(true, "ƒанные успешно получены", user);
                else
                    status = Functions.CreateResponseForOut(false, "”казанный пользователь не найден!");
            }
            else
            {
                status = Functions.CreateResponseForOut(false, responseUsers.Description);
            }
            return status;
        }
    }
}