using GymLover.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLover.Domain.Interfaces
{
    public interface IPersonBusiness
    {
        List<Person> GetPeople();

        void EditPerson(Person person);

        Person GetPerson(int Id);

        void IsertPerson(Person person);

        void DeletePerson(Person person);
    }
}
