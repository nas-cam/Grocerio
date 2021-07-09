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

            #region SeedStoreData
            if (!context.Categories.Any())
            {
                var foodCategory = new Category()
                {
                    Name = "Food",
                    Description = "Everything you can eat and consume",
                    ImageLink = "https://static01.nyt.com/images/2021/01/26/well/well-foods-microbiome/well-foods-microbiome-superJumbo.jpg"
                };
                var drinksCategory = new Category()
                {
                    Name = "Drinks",
                    Description = "Everything you can drink",
                    ImageLink = "https://nigeria-consulate-atl.org/wp-content/uploads/2020/04/soft-drinks-1024x768-1.png"
                };
                var candyCategory = new Category()
                {
                    Name = "Candy",
                    Description = "All sweet adn sour candy",
                    ImageLink = "https://d2dzik4ii1e1u6.cloudfront.net/images/lexology/static/473a7ca8-fb54-45d3-b09e-1b6c1855c273.jpg"
                };
                var hygieneCategory = new Category()
                {
                    Name = "Hygiene",
                    Description = "Everything for your body",
                    ImageLink = "https://images-na.ssl-images-amazon.com/images/I/71f32PLolcL._AC_SL1500_.jpg"
                };
                var furnitureCategory = new Category()
                {
                    Name = "Furniture",
                    Description = "Furniture for your home",
                    ImageLink = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/amazon-rivet-furniture-1533048038.jpg"
                };
                var clothingCategory = new Category()
                {
                    Name = "Clothing",
                    Description = "Everything you can wear",
                    ImageLink = "https://www.teachingenglish.org.uk/sites/teacheng/files/images/RS5803_160879793-low.jpg"
                };
                context.Categories.AddRange(new List<Category>() { foodCategory, drinksCategory, candyCategory, hygieneCategory, furnitureCategory, clothingCategory });
                context.SaveChanges();

                if (!context.Products.Any())
                {
                    var cola = new Product()
                    {
                        Name = "CocaCola",
                        CategoryId = drinksCategory.Id,
                        Description = "Most popular soft drink",
                        ImageLink = "https://www.cokesolutions.com/content/dam/cokesolutions/us/images/Products/Coca-Cola-glass.jpg", 
                        ProductType = GrocerioModels.Enums.Product.Type.GlassBottle
                    };
                    var fanta = new Product()
                    {
                        Name = "Fanta",
                        CategoryId = drinksCategory.Id,
                        Description = "Most popular yellow soft drink",
                        ImageLink = "https://assets.sainsburys-groceries.co.uk/gol/3300510/1/640x640.jpg",
                        ProductType = GrocerioModels.Enums.Product.Type.PlasticBottle
                    };
                    var bread = new Product()
                    {
                        Name = "Bread",
                        CategoryId = foodCategory.Id,
                        Description = "Essential food appetizer",
                        ImageLink = "https://www.joyofbaking.com/images/facebook/whitesandwichbread.jpg",
                        ProductType = GrocerioModels.Enums.Product.Type.Bag
                    };
                    var chicken = new Product()
                    {
                        Name = "Chicken",
                        CategoryId = foodCategory.Id,
                        Description = "Most eaten meat type",
                        ImageLink = "https://universitymeat.com.au/ts1584395382/attachments/Product/8074/Chicken%20whole%204001.003.jpg",
                        ProductType = GrocerioModels.Enums.Product.Type.FrozenItem
                    };
                    var mars = new Product()
                    {
                        Name = "Mars",
                        CategoryId = candyCategory.Id,
                        Description = "A bar of chocolate",
                        ImageLink = "https://images-na.ssl-images-amazon.com/images/I/41AeTKhQ8vL.jpg",
                        ProductType = GrocerioModels.Enums.Product.Type.Bar
                    };
                    var haribo = new Product()
                    {
                        Name = "Haribo",
                        CategoryId = candyCategory.Id,
                        Description = "A bag of gummy bears",
                        ImageLink = "https://images-na.ssl-images-amazon.com/images/I/91745c3%2BLFL._SL1500_.jpg",
                        ProductType = GrocerioModels.Enums.Product.Type.Bag
                    };
                    var soap = new Product()
                    {
                        Name = "Soap",
                        CategoryId = hygieneCategory.Id,
                        Description = "A bar of soap",
                        ImageLink = "https://dkstore.online/wp-content/uploads/2016/03/41.jpg",
                        ProductType = GrocerioModels.Enums.Product.Type.Bar
                    };
                    var toothbrush = new Product()
                    {
                        Name = "Toothbrush",
                        CategoryId = hygieneCategory.Id,
                        Description = "For celaning your teeth",
                        ImageLink = "https://www.collinsdictionary.com/images/thumb/toothbrush_121250959_250.jpg",
                        ProductType = GrocerioModels.Enums.Product.Type.PlasticItem
                    };
                    var table = new Product()
                    {
                        Name = "Table",
                        CategoryId = furnitureCategory.Id,
                        Description = "For sitting down",
                        ImageLink = "https://www.circlefurniture.com/userfiles/images/Products/copeland/audrey-dining/audrey-cherry-table.jpg",
                        ProductType = GrocerioModels.Enums.Product.Type.WoodenItem
                    };
                    var closet = new Product()
                    {
                        Name = "Closet",
                        CategoryId = furnitureCategory.Id,
                        Description = "To hang your clothes",
                        ImageLink = "https://s3.envato.com/files/269045552/Front%20view%20of%20empty%20wardrobe.jpg",
                        ProductType = GrocerioModels.Enums.Product.Type.WoodenItem
                    };
                    var shirt = new Product()
                    {
                        Name = "Shirt",
                        CategoryId = clothingCategory.Id,
                        Description = "Trasher shirt",
                        ImageLink = "https://s3.gsxtr.com/i/p/t-shirt-thrasher-flame-logo-t-shirt-charcoal-grey-61979-2500-1.jpg",
                        ProductType = GrocerioModels.Enums.Product.Type.ClothItem
                    };
                    var pants = new Product()
                    {
                        Name = "Pants",
                        CategoryId = clothingCategory.Id,
                        Description = "A pair of Levis pants",
                        ImageLink = "https://images.houseoffraser.co.uk/images/imgzoom/64/64008619_xxl.jpg",
                        ProductType = GrocerioModels.Enums.Product.Type.ClothItem
                    };
                    context.Products.AddRange(new List<Product>()
                    {
                        bread, chicken, 
                        cola, fanta, 
                        soap, toothbrush, 
                        shirt, pants, 
                        table, closet, 
                        mars, haribo
                    });
                    context.SaveChanges();

                    if (!context.Stores.Any())
                    {
                        var wallmart = new Store()
                        {
                            Address = "WallmartAddress",
                            City = "New York",
                            Description = "All what a Wallmart has",
                            ImageLink = "https://cdn.britannica.com/16/204716-050-8BB76BE8/Walmart-store-Mountain-View-California.jpg",
                            Membership = GrocerioModels.Enums.Store.Membership.Basic,
                            Name = "Wallmart",
                            UniqueStoreNumber = 123                           
                        };
                        var target = new Store()
                        {
                            Address = "TargetAddress",
                            City = "Chicago",
                            Description = "All what a Target has",
                            ImageLink = "https://saferchemicals.org/wp-content/uploads/2015/09/14363002257_3add6d25f9_k.jpg",
                            Membership = GrocerioModels.Enums.Store.Membership.Premium,
                            Name = "Target",
                            UniqueStoreNumber = 456
                        };
                        var ikea = new Store()
                        {
                            Address = "IkeaAddress",
                            City = "Hampton",
                            Description = "All what an Ikea has",
                            ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/Ikea_logo.svg/1200px-Ikea_logo.svg.png",
                            Membership = GrocerioModels.Enums.Store.Membership.Premium,
                            Name = "Ikea",
                            UniqueStoreNumber = 789                           
                        };

                        context.Stores.AddRange(new List<Store>(){wallmart, target, ikea});
                        context.SaveChanges();

                        context.StoreProducts.AddRange(new List<StoreProducts>()
                        {
                            new StoreProducts()
                            {
                                Registered = Get.CurrentDate(), 
                                StoreId = wallmart.Id, 
                                ProductId = bread.Id, 
                                Price = 1.5
                            },
                            new StoreProducts()
                            {
                                Registered = Get.CurrentDate(),
                                StoreId = wallmart.Id,
                                ProductId = chicken.Id, 
                                Price = 3.5
                            },
                            new StoreProducts()
                            {
                                Registered = Get.CurrentDate(),
                                StoreId = wallmart.Id,
                                ProductId = haribo.Id, 
                                Price = 3,
                            },
                            new StoreProducts()
                            {
                                Registered = Get.CurrentDate(),
                                StoreId = wallmart.Id,
                                ProductId = mars.Id,
                                Price = 2,
                            },
                            new StoreProducts()
                            {
                                Registered = Get.CurrentDate(),
                                StoreId = wallmart.Id,
                                ProductId = soap.Id,
                                Price = 1.5,
                            },
                            new StoreProducts()
                            {
                                Registered = Get.CurrentDate(),
                                StoreId = wallmart.Id,
                                ProductId = toothbrush.Id,
                                Price = 3,
                            },
                            new StoreProducts()
                            {
                                Registered = Get.CurrentDate(),
                                StoreId = target.Id,
                                ProductId = shirt.Id,
                                Price = 30,
                            },
                            new StoreProducts()
                            {
                                Registered = Get.CurrentDate(),
                                StoreId = target.Id,
                                ProductId = pants.Id,
                                Price = 25,
                            },
                            new StoreProducts()
                            {
                                Registered = Get.CurrentDate(),
                                StoreId = target.Id,
                                ProductId = haribo.Id,
                                Price = 3,
                            },
                            new StoreProducts()
                            {
                                Registered = Get.CurrentDate(),
                                StoreId = target.Id,
                                ProductId = mars.Id,
                                Price = 2,
                            },
                            new StoreProducts()
                            {
                                Registered = Get.CurrentDate(),
                                StoreId = ikea.Id,
                                ProductId = haribo.Id,
                                Price = 3,
                            },
                            new StoreProducts()
                            {
                                Registered = Get.CurrentDate(),
                                StoreId = ikea.Id,
                                ProductId = mars.Id,
                                Price = 2,
                            },
                            new StoreProducts()
                            {
                                Registered = Get.CurrentDate(),
                                StoreId = ikea.Id,
                                ProductId = table.Id,
                                Price = 35,
                            },
                            new StoreProducts()
                            {
                                Registered = Get.CurrentDate(),
                                StoreId = ikea.Id,
                                ProductId = closet.Id,
                                Price = 25,
                            },
                        });
                        context.SaveChanges();
                    }
                }


            }
            #endregion

            #region SeedReturnReasons
            context.ReturnReasons.AddRange(new List<ReturnReason>()
            {
                new ReturnReason(){Reason = "Item was broken", Seriousness = GrocerioModels.Enums.General.Priority.High},
                new ReturnReason(){Reason = "Item was malfunctioning", Seriousness = GrocerioModels.Enums.General.Priority.High},
                new ReturnReason(){Reason = "Different than advertised", Seriousness = GrocerioModels.Enums.General.Priority.High},
                new ReturnReason(){Reason = "Insufficient client funds", Seriousness = GrocerioModels.Enums.General.Priority.Medium},
                new ReturnReason(){Reason = "Client changed his mind", Seriousness = GrocerioModels.Enums.General.Priority.Medium},
                new ReturnReason(){Reason = "Ordered by mistake", Seriousness = GrocerioModels.Enums.General.Priority.Low},
                new ReturnReason(){Reason = "Will replace the item with a new one", Seriousness = GrocerioModels.Enums.General.Priority.Low},
                new ReturnReason(){Reason = "Did not like the product", Seriousness = GrocerioModels.Enums.General.Priority.Insignificant},
            });
            context.SaveChanges();
            #endregion

        }
    }
}
