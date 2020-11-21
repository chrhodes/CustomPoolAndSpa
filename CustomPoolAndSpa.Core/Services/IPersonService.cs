using System.Collections.Generic;
using System;
using Common.Domain;

namespace CustomPoolAndSpa.Core
{
    public interface IPersonService
    {
        IList<Person> GetPeople();
        void GetPeopleAsync(EventHandler<ServiceResult<IList<Person>>> callback);
    }
}