namespace ClassLib.DTO
{
    using System;

    public class TermineTableDto
    {
        public Guid Id { get; set; }
        public DateTime TerminDate { get; set; }
        public Guid UserId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Birthday { get; set; }
        public Guid? ArztId { get; set; }
        public string Arzt_Last_Name { get; set; }
        public string Status { get; set; }
        public string Raum { get; set; }
        public string Typ_short { get; set; }
        public string Typ_long { get; set; }
        public TermineTableDto()
        {
        }
    }
}
