using BlazorApp2.Client.Services;
using BlazorApp2.Shared.DTO;
using BlazorApp2.Shared.Entities;
using BlazorApp2.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Client.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpService _http;
        private readonly string _URL = "api/users";
        public UserRepository(IHttpService http)
        {
            _http = http;
        }
        public async Task<ResponseDataHelper<List<Role>>> Roles()
        {
            var result = await _http.Get<List<Role>>($"{_URL}/roles");

            return result;
        }

        public async Task<ResponseDataHelper<bool>> CreateUser(User user)
        {
            Console.WriteLine("#user.password " + user.Password);
            var result = await _http.PostAsync<User, bool>($"{_URL}/createUser", user);

            return result;
        }

        public async Task<ResponseDataHelper<List<User>>> GetAllUsers()
        {
            var result = await _http.Get<List<User>>($"{_URL}/userList");

            return result;
        }

        public async Task<ResponseDataHelper<User>> GetUserById(long Id)
        {
            var result = await _http.PostAsync<long, User>($"{_URL}/getUserById", Id);

            return result;
        }

        public async Task<ResponseDataHelper<bool>> UpdateUser(User user)
        {
            var result = await _http.PostAsync<User, bool>($"{_URL}/updateUser", user);

            return result;
        }

        public async Task<ResponseDataHelper<bool>> DeleteUser(User user)
        {
            var result = await _http.PostAsync<User, bool>($"{_URL}/deleteUser", user);

            return result;
        }

        public async Task<ResponseDataHelper<bool>> RegisterUser(RegisterDTO user)
        {
            var result = await _http.PostAsync<RegisterDTO, bool>($"{_URL}/registerUser", user);

            return result;
        }
    }
}
