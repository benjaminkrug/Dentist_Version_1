namespace DentistBuisness.Repositories.Gebiss
{
    using DentistDB.Repositories.Gebiss;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GebissLogic: IGebissLogic
    {
        private IGebissRepository _gebissRepository;
        public GebissLogic(IGebissRepository gebissRepository)
        {
            _gebissRepository = gebissRepository;
        }

        public void AddGebiss(Guid user)
        {
            _gebissRepository.AddGebiss(user);
        }
    }
}
