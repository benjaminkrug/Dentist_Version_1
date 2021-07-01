namespace ClassLib.DBModels
{
    using System;

    public class UserDBModel
    {
        public Guid Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
