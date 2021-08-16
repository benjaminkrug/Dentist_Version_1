namespace Webapp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using ClassLib.DBModels;
    using ClassLib.DTO;
    using Dapper;
    using DentistBuisness.Repositories.Gebiss;
    using DentistDB.Repositories.Gebiss;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Npgsql;
    using Services;

    public class UserController : Controller
    {
        private readonly IDapper _dp;
        private IGebissLogic _gebissLogic;

        public UserController(IDapper dp, IGebissLogic gebissLogic)
        {
            _dp = dp;
            _gebissLogic = gebissLogic;
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
            var g = new List<UserDBModel>();
            try
            {
                g = _dp.GetAll<UserDBModel>("getAllUser.sql", null, CommandType.Text);

                Console.WriteLine(g);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return g;
        }

        [HttpGet("Test")]
        public async Task<string> Test1()
        {
            return "hallo";
        }

        [HttpPost("addPatient")]
        public async void AddPatient([FromBody] UserDto dto)
        {
            dto.Id = Guid.NewGuid();
            _dp.Insert<UserDBModel>("addPatient.sql", new DynamicParameters(new UserDBModel(dto)), CommandType.Text);
            _gebissLogic.AddGebiss((Guid)dto.Id);
        }

        [HttpPost("removePatientById/{patientId:Guid}")]
        public async void RemovePatientById([FromRoute] Guid patientId)
        {
            _dp.Execute("removeUserById.sql", new DynamicParameters(new { id = patientId }), CommandType.Text);

        }

    }
}
