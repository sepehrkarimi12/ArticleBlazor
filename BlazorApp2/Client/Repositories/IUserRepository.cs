using BlazorApp2.Shared.DTO;
using BlazorApp2.Shared.Entities;
using BlazorApp2.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Client.Repositories
{
    public interface IUserRepository
    {
        Task<ResponseDataHelper<bool>> CreateUser(User user);
        Task<ResponseDataHelper<bool>> RegisterUser(RegisterDTO user);
        Task<ResponseDataHelper<bool>> DeleteUser(User user);
        Task<ResponseDataHelper<List<User>>> GetAllUsers();
        Task<ResponseDataHelper<User>> GetUserById(long Id);
        Task<ResponseDataHelper<List<Role>>> Roles();
        Task<ResponseDataHelper<bool>> UpdateUser(User user);
    }
}
