using MIS442Store.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS442Store.DataLayer.Interfaces
{
    interface IRegistrationRepository
    {
        List<Registration> GetUserRegistrations(string username);
        List<Registration> GetRegistrations();
        Registration GetRegistration(int id);
        void SaveRegistration(Registration registration);

    }
}
