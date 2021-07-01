﻿namespace Webapp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using ClassLib.DBModels;
    using ClassLib.DTO;
    using Dapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Npgsql;
    using Services;
    using static Webapp.Controllers.UserController;

    public class TerminController : Controller
    {
        private readonly IDapper _dp;

        public TerminController(IDapper dp)
        {
            _dp = dp;
        }


        [HttpGet("getAllTermine")]
        public async Task<List<TermineTableDto>> GetAllTermine()
        {
            var termine = _dp.GetAll<TerminDbModel>("getAllTermine.sql", null, CommandType.Text);
            var users = _dp.GetAll<UserDBModel>("getUsersByIds.sql", new DynamicParameters(new { ids = termine.Select(t => t.UserId).ToArray() }), CommandType.Text);
            var aerzte = _dp.GetAll<ArztDbModel>("getAerzteByIds.sql", new DynamicParameters(new { ids = termine.Select(t => t.ArztId).ToArray() }), CommandType.Text);

            var result = termine.Select(t => {
                var user = users.Find(u => u.Id == t.UserId);
                var arzt = aerzte.Find(a => a.Id == t.ArztId);
                var split = t.Time.Split(':');
                var time = t.Datum + new TimeSpan(int.Parse(split[0]), int.Parse(split[0]), int.Parse(split[0]));
                return new TermineTableDto() { Id = t.Id, Arzt = arzt.Last_Name, TerminDate = time, First_Name = user.First_Name, Last_Name = user.Last_Name, Birthday = user.Birthday };
            }).ToList();
            Console.WriteLine(result);
            return result;
        }

    }
}
