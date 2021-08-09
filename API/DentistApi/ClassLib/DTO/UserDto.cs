namespace ClassLib.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserDto
    {
        public Guid? Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Birthday { get; set; }
        public UserDto()
        {

        }
    }
}
