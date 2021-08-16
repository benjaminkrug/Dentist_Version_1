namespace DentistBuisness.Termine
{
    using ClassLib.DBModels;
    using ClassLib.DTO;
    using DentistDB.Repositories.Arzt;
    using DentistDB.Repositories.Termine;
    using DentistDB.Repositories.User;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TermineLogic : ITermineLogic
    {
        private readonly ITermineRepository _terminRepo;
        private readonly IUserRepository _userRepo;
        private readonly IArztRepository _arztRepo;
        public TermineLogic(ITermineRepository terminRepo, IUserRepository userRepo, IArztRepository arztRepo)
        {
            _terminRepo = terminRepo;
            _userRepo = userRepo;
            _arztRepo = arztRepo;
        }
        public List<TermineTableDto> GetAllTermineByTimeRange(DateTime startDate, DateTime endDate)
        {

            var terminTyps = _terminRepo.GetAllTerminTyps();
            var termine = _terminRepo.GetAllTermineByTimeRange(startDate, endDate);
            var users = _userRepo.GetUsersByIds(termine.Select(t => t.UserId).ToList());
            var aerzte = _arztRepo.GetAerzteByIds(termine.Select(t => t.ArztId).ToList());

            return termine.Select(t => {
                var user = users.Find(u => u.Id == t.UserId);
                var arzt = aerzte.Find(a => a.Id == t.ArztId);
                var split = t.Time.Split(':');
                var time = t.Datum + new TimeSpan(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
                var termin_long = terminTyps.Find(x => x.short_name == t.Typ).name;
                return new TermineTableDto() { Id = t.Id, Status = t.Status, Typ_short = t.Typ, Raum = t.Raum, Typ_long = termin_long, Arzt = arzt.Last_Name, TerminDate = time, UserId = user.Id, First_Name = user.First_Name, Last_Name = user.Last_Name, Birthday = user.Birthday };
            }).ToList();
        }
    }
}
