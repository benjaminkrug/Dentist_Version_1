namespace ClassLib.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class BehandlungsRaumMainDto
    {
        public Guid UserId { get; set; }
        public int Raum { get; set; }
        public GebissDto Gebiss { get; set; }
        public List<ZahnDto> ZahnList { get; set; } = new List<ZahnDto>();
    }


    public class ZahnDto
    {
        public Guid Id { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public string Position { get; set; }

    }
}
