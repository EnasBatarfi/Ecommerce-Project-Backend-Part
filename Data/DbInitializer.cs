using Microsoft.AspNetCore.Identity;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Data
{
    public class DbInitializer
    {
        private readonly IPasswordHasher<Admin> _passwordHasher;

        public DbInitializer(IPasswordHasher<Admin> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public async Task InitializeAsync(AppDbContext context, IServiceProvider serviceProvider)
        {
            context.Database.EnsureCreated();

            // if no admins found add these
            if (!context.Admins.Any())
            {
                var admins = new Admin[]
                {
                    new Admin
                    {
                        AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115"),
                        FirstName = "Mohammad",
                        LastName = "Alkhamis",
                        Email = "mohammad@example.com",
                        Image = "mohammad.webp",
                        Mobile = "966554556677",
                        CreatedAt = new DateTime(2024, 4, 28, 11, 35, 0, DateTimeKind.Utc),
                        Password = _passwordHasher.HashPassword(null, "Test@123")
                    },
                    new Admin
                    {
                        AdminId = Guid.Parse("03c18f24-d667-4c07-8c4f-454dea50c115"),
                        FirstName = "Enas",
                        LastName = "Batarfi",
                        Email = "enas@example.com",
                        Image = "enas.webp",
                        Mobile = "966554556677",
                        CreatedAt = new DateTime(2024, 4, 29, 15, 44, 22, DateTimeKind.Utc),
                        Password = _passwordHasher.HashPassword(null, "Test@123")
                    },
                    new Admin
                    {
                        AdminId = Guid.Parse("04c18f24-d667-4c07-8c4f-454dea50c115"),
                        FirstName = "Ahad",
                        LastName = "Nasser",
                        Email = "ahad@example.com",
                        Image = "ahad.webp",
                        Mobile = "966554556677",
                        CreatedAt = new DateTime(2024, 4, 28, 8, 18, 32, DateTimeKind.Utc),
                        Password = _passwordHasher.HashPassword(null, "Test@123")
                    },
                    new Admin
                    {
                        AdminId = Guid.Parse("05c18f24-d667-4c07-8c4f-454dea50c115"),
                        FirstName = "Shahad",
                        LastName = "Draim",
                        Email = "shahad@example.com",
                        Image = "shahad.webp",
                        Mobile = "966554556677",
                        CreatedAt = new DateTime(2024, 4, 30, 18, 55, 55, DateTimeKind.Utc),
                        Password = _passwordHasher.HashPassword(null, "Test@123")
                    }
                };

                foreach (Admin admin in admins)
                {
                    context.Admins.Add(admin);
                }
            }

            // if no customers found add these
            if (!context.Customers.Any())
            {
                var customers = new List<Customer>();
                for (int i = 1; i <= 20; i++)
                {
                    customers.Add(new Customer
                    {
                        CustomerId = Guid.NewGuid(),
                        FirstName = $"CustomerFirstName{i}",
                        LastName = $"CustomerLastName{i}",
                        Email = $"customer{i}@example.com",
                        Image = $"customer{i}.webp",
                        Mobile = $"96655455{i:D4}",
                        CreatedAt = new DateTime(2024, 5, 1, 12, 12, 12, DateTimeKind.Utc),
                        Password = _passwordHasher.HashPassword(null, "Test@123")
                    });
                }

                foreach (Customer customer in customers)
                {
                    context.Customers.Add(customer);
                }
            }

            // if no addresses found add these
            if (!context.Addresses.Any())
            {
                var addresses = new List<Address>();
                var customerIds = context.Customers.Select(c => c.CustomerId).ToList();

                foreach (var customerId in customerIds)
                {
                    for (int i = 1; i <= 2; i++)
                    {
                        addresses.Add(new Address
                        {
                            AddressId = Guid.NewGuid(),
                            Name = i == 1 ? "Home" : "Work",
                            AddressLine1 = $"{i}00 Street Name",
                            AddressLine2 = $"Apt {i}0{i}",
                            Country = "Saudi Arabia",
                            Province = i == 1 ? "Central" : "Eastern",
                            City = i == 1 ? "Riyadh" : "Dammam",
                            ZipCode = $"{i}0000",
                            CustomerId = customerId
                        });
                    }
                }

                foreach (Address address in addresses)
                {
                    context.Addresses.Add(address);
                }
            }

            // if no categories found add these
            if (!context.Categories.Any())
            {
                var categories = new Category[]
                {
                    new Category
                    {
                        CategoryId = Guid.Parse("bca83459-e31f-4ffc-9573-9245c9cbe6b7"),
                        Name = "Skincare",
                        Slug = "skincare",
                        Description = "All things skincare",
                        CreatedAt = new DateTime(2024, 4, 28, 22, 25, 25, DateTimeKind.Utc),
                        AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115")
                    },
                    new Category
                    {
                        CategoryId = Guid.Parse("c94d673b-be8d-4b1f-8a36-cbd6ed765644"),
                        Name = "Makeup",
                        Slug = "makeup",
                        Description = "All kinds of makeup",
                        CreatedAt = new DateTime(2024, 4, 28, 22, 25, 25, DateTimeKind.Utc),
                        AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115")
                    },
                    new Category
                    {
                        CategoryId = Guid.Parse("9c506bbf-0fd7-43af-9507-40fb32d8bdbd"),
                        Name = "Haircare",
                        Slug = "haircare",
                        Description = "Haircare products",
                        CreatedAt = new DateTime(2024, 4, 28, 23, 25, 25, DateTimeKind.Utc),
                        AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115")
                    },
                    new Category
                    {
                        CategoryId = Guid.Parse("fafbdf01-de53-486b-9e4b-5b501cc8369e"),
                        Name = "Fragrance",
                        Slug = "fragrance",
                        Description = "Perfumes and fragrances",
                        CreatedAt = new DateTime(2024, 4, 28, 22, 25, 25, DateTimeKind.Utc),
                        AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115")
                    }
                };

                foreach (Category c in categories)
                {
                    context.Categories.Add(c);
                }
            }

            // if no products found add these
            if (!context.Products.Any())
            {
                var products = new List<Product>();
                var categoryIds = context.Categories.Select(c => c.CategoryId).ToList();

                foreach (var categoryId in categoryIds)
                {
                    for (int i = 1; i <= 20; i++)
                    {
                        products.Add(new Product
                        {
                            ProductId = Guid.NewGuid(),
                            Name = $"Product {i}",
                            Slug = $"product-{i}",
                            Price = 50 + i,
                            Description = $"This is the description for Product {i}.",
                            StockQuantity = 100 + i,
                            SKU = $"BB-PROD-{i:D3}",
                            ImgUrl = $"product-{i}.webp",
                            CreatedAt = new DateTime(2024, 4, 29, 15, 25, 25, DateTimeKind.Utc),
                            CategoryId = categoryId,
                            AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115")
                        });
                    }
                }

                foreach (Product p in products)
                {
                    context.Products.Add(p);
                }
            }

            // if no order products found add these
            if (!context.OrderProducts.Any())
            {
                var orderProducts = new List<OrderProduct>();
                var productIds = context.Products.Select(p => p.ProductId).ToList();
                var orderIds = context.Orders.Select(o => o.OrderId).ToList();

                foreach (var orderId in orderIds)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        orderProducts.Add(new OrderProduct
                        {
                            OrderProductId = Guid.NewGuid(),
                            ProductId = productIds[i % productIds.Count],
                            OrderId = orderId,
                            ProductPrice = 50 + (i % productIds.Count),
                            Quantity = 1 + (i % 5)
                        });
                    }
                }

                foreach (OrderProduct o in orderProducts)
                {
                    context.OrderProducts.Add(o);
                }
            }

            // if no orders found add these
            if (!context.Orders.Any())
            {
                var orders = new List<Order>();
                var customerIds = context.Customers.Select(c => c.CustomerId).ToList();
                var addressIds = context.Addresses.Select(a => a.AddressId).ToList();

                for (int i = 1; i <= 20; i++)
                {
                    orders.Add(new Order
                    {
                        OrderId = Guid.NewGuid(),
                        AddressId = addressIds[i % addressIds.Count],
                        CreatedAt = DateTime.UtcNow,
                        CustomerId = customerIds[i % customerIds.Count],
                    });
                }

                foreach (Order o in orders)
                {
                    context.Orders.Add(o);
                }
            }

            // if no reviews found add these
            if (!context.Reviews.Any())
            {
                var reviews = new List<Review>();
                var customerIds = context.Customers.Select(c => c.CustomerId).ToList();
                var productIds = context.Products.Select(p => p.ProductId).ToList();

                for (int i = 1; i <= 20; i++)
                {
                    reviews.Add(new Review
                    {
                        ReviewId = Guid.NewGuid(),
                        Comment = $"This is a review for Product {i}.",
                        OrderId = context.Orders.FirstOrDefault().OrderId,
                        CustomerId = customerIds[i % customerIds.Count],
                        ProductId = productIds[i % productIds.Count],
                        Rating = (i % 5) + 1,
                    });
                }

                foreach (Review r in reviews)
                {
                    context.Reviews.Add(r);
                }
            }

            context.SaveChanges();
        }
    }
}
