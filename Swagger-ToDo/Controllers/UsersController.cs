using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swagger_ToDo.Interfaces;
using Swagger_ToDo.Models;

namespace Swagger_ToDo.Controllers
{
    [Route("[controller]/[action]")]
    public class UsersController
    {
        private readonly IUserService _userService;
        
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        public void Add([FromBody]UserModel model) => _userService.Add(model);

        [HttpDelete("{id}")]
        public void Remove(int id) => _userService.Remove(id);

        [HttpDelete("{userId}")]
        public void RemoveAll(int userId) => _userService.RemoveAll(userId);
        
        [HttpPut]
        public void Update([FromBody]UserModel model) => _userService.Update(model);
        
        [HttpGet("{userId}")]
        public UserModel Get(int userId) => _userService.Get(userId);
        
        [HttpGet]
        public IEnumerable<UserModel> GetAll() => _userService.GetAll();
        
    }
}