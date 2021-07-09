using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.Admin
{
    public interface IAdminService
    {
        public GrocerioModels.Users.Admin Insert(GrocerioModels.Requests.User.InsertAdminRequest request);
        public List<GrocerioModels.Users.Admin> GatAllAdmins();
    }
}
