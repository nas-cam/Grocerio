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
            CreateMap<Database.Entities.User, GrocerioModels.Users.User>().ReverseMap();
            CreateMap<Database.Entities.User, GrocerioModels.Requests.User.InsertUserRequest>().ReverseMap();
            CreateMap<Database.Entities.Category, GrocerioModels.Requests.Category.InsertCategoryRequest>().ReverseMap();
            CreateMap<Database.Entities.Category, GrocerioModels.Category.Category>().ReverseMap();
            CreateMap<Database.Entities.Product, GrocerioModels.Requests.Product.InsertProductRequest>().ReverseMap();
            CreateMap<Database.Entities.Product, GrocerioModels.Product.Product>().ReverseMap();
        }

    }
}
