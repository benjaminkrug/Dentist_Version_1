namespace ClassLib.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TerminDbModel
    {
        public Guid Id { get; set; }
        public DateTime Datum { get; set; }
        public string Time { get; set; }
        public Guid UserId { get; set; }
        public Guid ArztId { get; set; }
        public string Status { get; set; }

    }
}
