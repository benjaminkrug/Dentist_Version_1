namespace Webapp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using ClassLib.DBModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Npgsql;
    using Services;

    public class UserController : Controller
    {
        private readonly IDapper _dp;

        public UserController(IDapper dp)
        {
            _dp = dp;
        }

        [HttpGet("Users")]
        public async Task<List<object>> Test()
        {
            var g = _dp.GetAll<object>("test.sql", null, CommandType.Text);

            Console.WriteLine(g);

            return g;
        }

        [HttpGet("getUser")]
        public async Task<Guid> getUser()
        {
            var g = _dp.Get<Guid>("getUser.sql", null, CommandType.Text);

            Console.WriteLine(g);

            return g;
        }

        [HttpGet("getAllUser")]
        public async Task<List<UserDBModel>> GetAllUser()
        {
            var g = _dp.GetAll<UserDBModel>("getAllUser.sql", null, CommandType.Text);

            Console.WriteLine(g);

            return g;
        }

        [HttpGet("Test")]
        public async Task<string> Test1()
        {
            return "hallo";
        }

    }
}
