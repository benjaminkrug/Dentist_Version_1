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
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Npgsql;
    using Services;
    using static Webapp.Controllers.UserController;

    public class BehandlungsraumController : Controller
    {
        private readonly IDapper _dp;

        public BehandlungsraumController(IDapper dp)
        {
            _dp = dp;
        }


        [HttpGet("getBehandlungsRaumMain")]
        public async Task<List<BehandlungsRaumMainDto>> GetBehandlungsRaumMain()
        {
            var patients = _dp.GetAll<UserInBehandlungsraumDbModel>("getPatientsInBehandlungsraum.sql", null, CommandType.Text);
            var gebiss = _dp.GetAll<GebissDbModel>("getGebissForPatientIds.sql", new DynamicParameters(new { ids = patients.Select(x => x.UserId).ToList() }), CommandType.Text);
            var zaehne = _dp.GetAll<TasksInformationDbModel>("getZaehneStateById.sql", new DynamicParameters(new { id = gebiss[0]._11 }), CommandType.Text);
            var dic = patients?.Select(x =>
            {
                var list = new List<ZahnDto>();
                var hisGebiss = gebiss.FirstOrDefault(p => p.UserId == x.UserId);
                zaehne.Where(x => x.Id == hisGebiss?._11).ToList().ForEach(z =>
                {
                    list.Add(new ZahnDto
                    {
                        Id = z.Id,
                        type = z.type,
                        date = z.date,
                        Position = z.Position
                    });
                });
                var g = gebiss.Find(gebiss => gebiss.UserId == x.UserId);
                return new BehandlungsRaumMainDto()
                {
                    UserId = x.UserId,
                    Raum = x.Raum,
                    Gebiss = g != null ?
                        new GebissDto(g)
                        : null,
                    ZahnList = list
                };
            }).ToList();
            return dic;

        }
    }
}
