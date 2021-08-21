namespace ClassLib.DBModels
{
    using ClassLib.DTO;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TerminDbModel
    {

        public Guid Id { get; set; }
        public DateTime Datum { get; set; }
        public Guid UserId { get; set; }
        public Guid? ArztId { get; set; }
        public string Status { get; set; }
        public string Typ { get; set; }
        public string Raum { get; set; }

        public TerminDbModel() { }

        public TerminDbModel(TermineTableDto t)
        {
            Id = t.Id;
            Datum = t.TerminDate;
            UserId = t.UserId;
            ArztId = t.ArztId;
            Status = t.Status;
            Typ = t.Typ_short;
            Raum = t.Raum;
        }

    }
}
