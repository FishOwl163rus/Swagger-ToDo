using System.Collections.Generic;
using Swagger_ToDo.Models;

namespace Swagger_ToDo.Interfaces
{
    public interface IUserService
    {
        void Add(UserModel model);
        void Remove(int id);
        void Update(UserModel model);
        void RemoveAll(int userId);
        UserModel Get(int userId);
        IEnumerable<UserModel> GetAll();
    }
}