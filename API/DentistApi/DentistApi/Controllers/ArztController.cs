namespace Webapp.Controllers
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using ClassLib.DBModels;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    public class ArztController : Controller
    {
        private readonly IDapper _dp;

        public ArztController(IDapper dp)
        {
            _dp = dp;
        }


        [HttpGet("getAllAerzte")]
        public async Task<List<ArztDbModel>> GetAllAerzte()
        {
            var aerzte = _dp.GetAll<ArztDbModel>("getAllAerzte.sql", null, CommandType.Text);

            return aerzte;
        }
    }
}
