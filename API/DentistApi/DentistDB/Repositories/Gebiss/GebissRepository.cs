namespace DentistDB.Repositories.Gebiss
{
    using ClassLib.DTO;
    using Dapper;
    using DentistDB.Repositories.Zahn;
    using DentistDB.Services;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class GebissRepository : IGebissRepository
    {
        private readonly IDapper _dp;
        private readonly IZahnRepository _zahnRepo;

        public GebissRepository(IDapper dp, IZahnRepository zahnRepo)
        {
            _dp = dp;
            _zahnRepo = zahnRepo;
        }

        public void AddGebiss(Guid user)
        {
            var gebissDto = new GebissDto() {
                Id = Guid.NewGuid(),
                UserId = user,
                _11 = Guid.NewGuid(),
                _12 = Guid.NewGuid(),
                _13 = Guid.NewGuid(),
                _14 = Guid.NewGuid(),
                _15 = Guid.NewGuid(),
                _16 = Guid.NewGuid(),
                _17 = Guid.NewGuid(),
                _18 = Guid.NewGuid(),
                _21 = Guid.NewGuid(),
                _22 = Guid.NewGuid(),
                _23 = Guid.NewGuid(),
                _24 = Guid.NewGuid(),
                _25 = Guid.NewGuid(),
                _26 = Guid.NewGuid(),
                _27 = Guid.NewGuid(),
                _28 = Guid.NewGuid(),
                _31 = Guid.NewGuid(),
                _32 = Guid.NewGuid(),
                _33 = Guid.NewGuid(),
                _34 = Guid.NewGuid(),
                _35 = Guid.NewGuid(),
                _36 = Guid.NewGuid(),
                _37 = Guid.NewGuid(),
                _38 = Guid.NewGuid(),
                _41 = Guid.NewGuid(),
                _42 = Guid.NewGuid(),
                _43 = Guid.NewGuid(),
                _44 = Guid.NewGuid(),
                _45 = Guid.NewGuid(),
                _46 = Guid.NewGuid(),
                _47 = Guid.NewGuid(),
                _48 = Guid.NewGuid()
            };

            _dp.Execute("AddGebiss.sql", new DynamicParameters(new {
                //gebissDto
                Id = gebissDto.Id,
                UserId = gebissDto.UserId,
                _11 = gebissDto._11,
                _12 = gebissDto._12,
                _13 = gebissDto._13,
                _14 = gebissDto._14,
                _15 = gebissDto._15,
                _16 = gebissDto._16,
                _17 = gebissDto._17,
                _18 = gebissDto._18,
                _21 = gebissDto._21,
                _22 = gebissDto._22,
                _23 = gebissDto._23,
                _24 = gebissDto._24,
                _25 = gebissDto._25,
                _26 = gebissDto._26,
                _27 = gebissDto._27,
                _28 = gebissDto._28,
                _31 = gebissDto._31,
                _32 = gebissDto._32,
                _33 = gebissDto._33,
                _34 = gebissDto._34,
                _35 = gebissDto._35,
                _36 = gebissDto._36,
                _37 = gebissDto._37,
                _38 = gebissDto._38,
                _41 = gebissDto._41,
                _42 = gebissDto._42,
                _43 = gebissDto._43,
                _44 = gebissDto._44,
                _45 = gebissDto._45,
                _46 = gebissDto._46,
                _47 = gebissDto._47,
                _48 = gebissDto._48
            }), CommandType.Text);

            _zahnRepo.AddZaehne(new List<(Guid, string)>() 
            {
                (gebissDto._11, "_11"),
                (gebissDto._12, "_12"),
                (gebissDto._13, "_13"),
                (gebissDto._14, "_14"),
                (gebissDto._15, "_15"),
                (gebissDto._16, "_16"),
                (gebissDto._17, "_17"),
                (gebissDto._18, "_18"),
                (gebissDto._21, "_21"),
                (gebissDto._22, "_22"),
                (gebissDto._23, "_23"),
                (gebissDto._24, "_24"),
                (gebissDto._25, "_25"),
                (gebissDto._26, "_26"),
                (gebissDto._27, "_27"),
                (gebissDto._28, "_28"),
                (gebissDto._31, "_31"),
                (gebissDto._32, "_32"),
                (gebissDto._33, "_33"),
                (gebissDto._34, "_34"),
                (gebissDto._35, "_35"),
                (gebissDto._36, "_36"),
                (gebissDto._37, "_37"),
                (gebissDto._38, "_38"),
                (gebissDto._41, "_41"),
                (gebissDto._42, "_42"),
                (gebissDto._43, "_43"),
                (gebissDto._44, "_44"),
                (gebissDto._45, "_45"),
                (gebissDto._46, "_46"),
                (gebissDto._47, "_47"),
                (gebissDto._48, "_48")
            });
        }
    }
}
