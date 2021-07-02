namespace ClassLib.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class TermineTableDto
    {
        public Guid Id { get; set; }
        public DateTime TerminDate { get; set; }
        public Guid UserId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Arzt { get; set; }
        public string Status { get; set; }
        public string Raum { get; set; }
        public string Typ_short { get; set; }
        public string Typ_long { get; set; }
    }
}
