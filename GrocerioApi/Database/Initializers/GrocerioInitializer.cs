using GrocerioApi.Database.Context;
using GrocerioApi.Database.Entities;
using GrocerioModels.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Database.Initializers
{
    public class GrocerioInitializer
    {
        public static void SeedDatabase(GrocerioContext context)
        {

            #region SeedUsers
            if (!context.Accounts.Any())
            {
                //admin
                var adminAccount = new Account()
                {
                    PasswordHash = "Q3QH10MOTW/w/z9Vtn5sZpJumG0=", //test
                    PasswordSalt = "MSf4ST1zzUHSMvPNO5SsKQ==", //test 
                    Role = GrocerioModels.Enums.User.Role.Admin,
                    Username = "desktop"
                };

                context.Accounts.Add(adminAccount);
                context.SaveChanges();
                context.Admins.Add(new Admin()
                {
                    AccountId = adminAccount.AccountId
                });
                context.SaveChanges();

                //user
                var userAccount = new Account()
                {
                    PasswordHash = "Q3QH10MOTW/w/z9Vtn5sZpJumG0=", //test
                    PasswordSalt = "MSf4ST1zzUHSMvPNO5SsKQ==", //test
                    Role = GrocerioModels.Enums.User.Role.User,
                    Username = "mobile"
                };
                context.Accounts.Add(userAccount);
                context.SaveChanges();

                context.Users.Add(new User()
                {
                    AccountId = userAccount.AccountId,
                    Active = true,
                    Address = "UsersAddress",
                    BirthDate = new DateTime(1996, 08, 07),
                    City = "UsersCity",
                    FirstName = "User",
                    LastName = "Uservic",
                    ImageLink = "https://www.investnational.com.au/wp-content/uploads/2016/08/person-stock.png",
                    Locked = false,
                    Mail = "user@gmail.com",
                    PhoneNumber = "061123456",
                    CreditCards = new List<CreditCard>() {
                    new CreditCard()
                    {
                        Active= true,
                        AddedOn = Get.CurrentDate(),
                        CardHolder = "User Uservic",
                        CardNumber = "123456789",
                        CVV = "123",
                        Expiration="07/24",
                        Main = true
                    }
                }
                });
                context.SaveChanges();
            }
            #endregion

            #region SeedTrackingCities
            if (!context.TrackingCities.Any())
            {
                StreamReader locationsFile = new StreamReader("./Resources/locations.csv");
                string line = null;
                while ((line = locationsFile.ReadLine()) != null) 
                    context.TrackingCities.Add(new Entities.TrackingCity() { 
                        Name = line
                    });
                context.SaveChanges();
            }
            #endregion
        }
    }
}
