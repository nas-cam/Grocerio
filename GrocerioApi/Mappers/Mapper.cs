using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace GrocerioApi.Mappers
{   
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Entities.Admin, GrocerioModels.Requests.User.InsertAdminRequest>().ReverseMap();
            CreateMap<Database.Entities.Account, GrocerioModels.Requests.User.InsertAccountRequest>().ReverseMap();
            CreateMap<Database.Entities.Account, GrocerioModels.Users.Account>().ReverseMap();
        }

    }
}
