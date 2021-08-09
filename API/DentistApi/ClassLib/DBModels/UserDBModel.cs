namespace ClassLib.DBModels
{
    using ClassLib.DTO;
    using System;

    public class UserDBModel
    {
        public Guid Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Birthday { get; set; }

        public UserDBModel() { }
        public UserDBModel(UserDto u)
        {
            Id = (Guid)u.Id;
            First_Name = u.First_Name;
            Last_Name = u.Last_Name;
            Birthday = u.Birthday;

        }
    }
}
