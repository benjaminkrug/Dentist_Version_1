namespace ClassLib.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TasksInformationDbModel
    {
        public Guid Id { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public string Position { get; set; }

    }
}
