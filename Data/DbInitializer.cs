using Microsoft.AspNetCore.Identity;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            // Ensure admins exist before adding related entities
            if (!context.Admins.Any())
            {
                var admins = new Admin[]
                {
                    new Admin { AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115"), FirstName = "Mohammad", LastName = "Alkhamis", Email = "moh@example.com", Image = "moh.webp", Mobile = "966554556677", CreatedAt = new DateTime(2024, 4, 28, 11, 35, 0, DateTimeKind.Utc), Password = _passwordHasher.HashPassword(null, "Test@123") },
                    new Admin { AdminId = Guid.Parse("03c18f24-d667-4c07-8c4f-454dea50c115"), FirstName = "Enas", LastName = "Batarfi", Email = "enas@example.com", Image = "enas.webp", Mobile = "966554556677", CreatedAt = new DateTime(2024, 4, 29, 15, 44, 22, DateTimeKind.Utc), Password = _passwordHasher.HashPassword(null, "Test@123") },
                    new Admin { AdminId = Guid.Parse("04c18f24-d667-4c07-8c4f-454dea50c115"), FirstName = "Ahad", LastName = "Nasser", Email = "ahad@example.com", Image = "ahad.webp", Mobile = "966554556677", CreatedAt = new DateTime(2024, 4, 28, 8, 18, 32, DateTimeKind.Utc), Password = _passwordHasher.HashPassword(null, "Test@123") },
                    new Admin { AdminId = Guid.Parse("05c18f24-d667-4c07-8c4f-454dea50c115"), FirstName = "Shahad", LastName = "Draim", Email = "shahad@example.com", Image = "shahad.webp", Mobile = "966554556677", CreatedAt = new DateTime(2024, 4, 30, 18, 55, 55, DateTimeKind.Utc), Password = _passwordHasher.HashPassword(null, "Test@123") }
                };

                foreach (var admin in admins)
                {
                    context.Admins.Add(admin);
                }

                await context.SaveChangesAsync();
            }

            // Ensure customers exist before adding related entities
            if (!context.Customers.Any())
            {
                var customers = new Customer[]
                {
                    new Customer { CustomerId = Guid.Parse("feee9ca6-fd69-46cf-a990-64db26780922"), FirstName = "Marim", LastName = "Ahmad", Email = "marim@example.com", Image = "image.webp", Mobile = "966554556677", CreatedAt = new DateTime(2024, 5, 1, 12, 12, 12, DateTimeKind.Utc), Password = _passwordHasher.HashPassword(null, "Test@123") },
                    new Customer { CustomerId = Guid.Parse("12295810-446c-4ef3-b5f9-8b7ec0a81e88"), FirstName = "Nora", LastName = "Faisal", Email = "nora@example.com", Image = "image.webp", Mobile = "966554556677", CreatedAt = new DateTime(2024, 5, 1, 12, 12, 12, DateTimeKind.Utc), Password = _passwordHasher.HashPassword(null, "Test@123") },
                    new Customer { CustomerId = Guid.Parse("a470781d-df28-4a68-b5f4-9b259b4b69d9"), FirstName = "Fahad", LastName = "Abdulrahman", Email = "fahad@example.com", Image = "image.webp", Mobile = "966554556677", CreatedAt = new DateTime(2024, 5, 1, 12, 12, 12, DateTimeKind.Utc), Password = _passwordHasher.HashPassword(null, "Test@123") },
                    new Customer { CustomerId = Guid.Parse("cb45d6e0-b134-491a-8968-9f27fc5c4c37"), FirstName = "Somyia", LastName = "Saad", Email = "somyia@example.com", Image = "image.webp", Mobile = "966554556677", CreatedAt = new DateTime(2024, 5, 1, 12, 12, 12, DateTimeKind.Utc), Password = _passwordHasher.HashPassword(null, "Test@123") },
                    new Customer { CustomerId = Guid.Parse("1f24d0f8-4cb6-4a56-8c6b-6b64a17b7dc6"), FirstName = "Lina", LastName = "Zayed", Email = "lina@example.com", Image = "image.webp", Mobile = "966554556677", CreatedAt = new DateTime(2024, 5, 2, 10, 15, 10, DateTimeKind.Utc), Password = _passwordHasher.HashPassword(null, "Test@123") },
                    new Customer { CustomerId = Guid.Parse("e3b5d9a3-b5db-4f96-8c3d-8d6e4e0a7e1e"), FirstName = "Mona", LastName = "Hassan", Email = "mona@example.com", Image = "image.webp", Mobile = "966554556677", CreatedAt = new DateTime(2024, 5, 3, 11, 25, 45, DateTimeKind.Utc), Password = _passwordHasher.HashPassword(null, "Test@123") },
                    new Customer { CustomerId = Guid.Parse("4a63796b-cd62-4b6e-8c9f-2f58b748dc92"), FirstName = "Omar", LastName = "Ali", Email = "omar@example.com", Image = "image.webp", Mobile = "966554556677", CreatedAt = new DateTime(2024, 5, 4, 12, 35, 30, DateTimeKind.Utc), Password = _passwordHasher.HashPassword(null, "Test@123") },
                    new Customer { CustomerId = Guid.Parse("9c586234-1c66-4e9c-8f21-9b5f7e0b5c63"), FirstName = "Sara", LastName = "Naji", Email = "sara@example.com", Image = "image.webp", Mobile = "966554556677", CreatedAt = new DateTime(2024, 5, 5, 14, 45, 50, DateTimeKind.Utc), Password = _passwordHasher.HashPassword(null, "Test@123") }
                };

                foreach (var customer in customers)
                {
                    context.Customers.Add(customer);
                }

                await context.SaveChangesAsync();
            }

            // Ensure addresses exist before adding related entities
            if (!context.Addresses.Any())
            {
                var addresses = new Address[]
                {
                    new Address { AddressId = Guid.Parse("9d358843-fd84-4af3-b486-fa8725c8af42"), Name = "Home", AddressLine1 = "123 Maple Street", AddressLine2 = "Apt 301", Country = "Saudi Arabia", Province = "Central", City = "Riyadh", ZipCode = "90001", CustomerId = Guid.Parse("feee9ca6-fd69-46cf-a990-64db26780922") },
                    new Address { AddressId = Guid.Parse("76f4d253-2171-4985-8c9e-f1979423ebc8"), Name = "Work", AddressLine1 = "456 Oak Avenue", AddressLine2 = "", Country = "Saudi Arabia", Province = "Central", City = "Riyadh", ZipCode = "10001", CustomerId = Guid.Parse("feee9ca6-fd69-46cf-a990-64db26780922") },
                    new Address { AddressId = Guid.Parse("d4b782fb-9f62-4258-9d16-0e673268945e"), Name = "My house address", AddressLine1 = "789 Elm Street", AddressLine2 = "Suite 102", Country = "Saudi Arabia", Province = "Eastern", City = "Dammam", ZipCode = "77002", CustomerId = Guid.Parse("a470781d-df28-4a68-b5f4-9b259b4b69d9") },
                    new Address { AddressId = Guid.Parse("fb639447-d196-4de4-b03d-6bcc3ca000e4"), Name = "My Work Address", AddressLine1 = "321 Pine Avenue", AddressLine2 = "Apt 10B", Country = "Saudi Arabia", Province = "Central", City = "Riyadh", ZipCode = "33101", CustomerId = Guid.Parse("a470781d-df28-4a68-b5f4-9b259b4b69d9") },
                    new Address { AddressId = Guid.Parse("c13854e7-aab7-4e5f-88dd-8a701924d80b"), Name = "Work", AddressLine1 = "567 Cedar Street", AddressLine2 = "Suite 501", Country = "Saudi Arabia", Province = "Central", City = "Riyadh", ZipCode = "60601", CustomerId = Guid.Parse("12295810-446c-4ef3-b5f9-8b7ec0a81e88") },
                    new Address { AddressId = Guid.Parse("e29e8d72-a949-4fe9-a986-eae03ed2a48f"), Name = "Home", AddressLine1 = "901 Walnut Avenue", AddressLine2 = "", Country = "Saudi Arabia", Province = "Western", City = "Jubail", ZipCode = "19101", CustomerId = Guid.Parse("12295810-446c-4ef3-b5f9-8b7ec0a81e88") },
                    new Address { AddressId = Guid.Parse("e89df668-cef1-402f-88c2-7c00990867aa"), Name = "Friend's house", AddressLine1 = "234 Birch Street", AddressLine2 = "Apt 15C", Country = "Saudi Arabia", Province = "Western", City = "Dammam", ZipCode = "02101", CustomerId = Guid.Parse("12295810-446c-4ef3-b5f9-8b7ec0a81e88") },
                    new Address { AddressId = Guid.Parse("b931adf8-5ae3-41c0-b6d2-c7da06a90b2b"), Name = "Home 1", AddressLine1 = "678 Pineapple Avenue", AddressLine2 = "", Country = "Saudi Arabia", Province = "Eastern", City = "Alhasa", ZipCode = "32801", CustomerId = Guid.Parse("feee9ca6-fd69-46cf-a990-64db26780922") },
                    new Address { AddressId = Guid.Parse("d5c6760b-8563-43e6-950b-2ebdd9ace603"), Name = "Work 2", AddressLine1 = "890 Cherry Street", AddressLine2 = "Suite 401", Country = "Saudi Arabia", Province = "Eastern", City = "Khobar", ZipCode = "94101", CustomerId = Guid.Parse("feee9ca6-fd69-46cf-a990-64db26780922") },
                    new Address { AddressId = Guid.Parse("7a5787cd-2d91-430e-a421-9bd60fa072f1"), Name = "Home 2", AddressLine1 = "543 Plum Avenue", AddressLine2 = "", Country = "Saudi Arabia", Province = "Eastern", City = "Dammam", ZipCode = "78701", CustomerId = Guid.Parse("feee9ca6-fd69-46cf-a990-64db26780922") },
                    new Address { AddressId = Guid.Parse("a31c4a36-9d55-4a50-9d4e-b8c2a2992c08"), Name = "Home", AddressLine1 = "321 Oak Street", AddressLine2 = "Apt 202", Country = "Saudi Arabia", Province = "Central", City = "Riyadh", ZipCode = "10002", CustomerId = Guid.Parse("1f24d0f8-4cb6-4a56-8c6b-6b64a17b7dc6") },
                    new Address { AddressId = Guid.Parse("f23a6b2b-3df8-4e18-8bfc-44e1e8d5cf7e"), Name = "Office", AddressLine1 = "987 Cedar Avenue", AddressLine2 = "", Country = "Saudi Arabia", Province = "Central", City = "Riyadh", ZipCode = "10003", CustomerId = Guid.Parse("1f24d0f8-4cb6-4a56-8c6b-6b64a17b7dc6") },
                    new Address { AddressId = Guid.Parse("b0a8d8b5-68f8-448e-9e2a-dedeeea50af7"), Name = "Home", AddressLine1 = "654 Pine Avenue", AddressLine2 = "Apt 303", Country = "Saudi Arabia", Province = "Eastern", City = "Dammam", ZipCode = "77003", CustomerId = Guid.Parse("e3b5d9a3-b5db-4f96-8c3d-8d6e4e0a7e1e") },
                    new Address { AddressId = Guid.Parse("d3c1b8a7-2f8d-4b34-8f4d-feb8f6d3a7f9"), Name = "Work", AddressLine1 = "123 Birch Street", AddressLine2 = "Suite 404", Country = "Saudi Arabia", Province = "Eastern", City = "Khobar", ZipCode = "94102", CustomerId = Guid.Parse("4a63796b-cd62-4b6e-8c9f-2f58b748dc92") },
                    new Address { AddressId = Guid.Parse("a8d1b8b6-2f3a-4b24-9d5d-d2c1b7e9b0c8"), Name = "Home", AddressLine1 = "789 Palm Avenue", AddressLine2 = "", Country = "Saudi Arabia", Province = "Western", City = "Jubail", ZipCode = "19102", CustomerId = Guid.Parse("9c586234-1c66-4e9c-8f21-9b5f7e0b5c63") },
                    new Address { AddressId = Guid.Parse("c2a1e9d8-4a8d-4a2d-8f2c-d2a3c7d5b8f7"), Name = "Work", AddressLine1 = "456 Elm Street", AddressLine2 = "Suite 505", Country = "Saudi Arabia", Province = "Western", City = "Dammam", ZipCode = "02102", CustomerId = Guid.Parse("9c586234-1c66-4e9c-8f21-9b5f7e0b5c63") }
                };

                foreach (var address in addresses)
                {
                    context.Addresses.Add(address);
                }

                await context.SaveChangesAsync();
            }

            // Ensure categories exist before adding related entities
            if (!context.Categories.Any())
            {
                var adminIdList = context.Admins.Select(a => a.AdminId).ToList();
                var categories = new Category[]
                {
                    new Category { CategoryId = Guid.Parse("bca83459-e31f-4ffc-9573-9245c9cbe6b7"), Name = "Skincare", Slug = "skincare", Description = "Cleansers, moisturizers, and treatments", CreatedAt = new DateTime(2024, 4, 28, 22, 25, 25, DateTimeKind.Utc), AdminId = adminIdList[0] },
                    new Category { CategoryId = Guid.Parse("c94d673b-be8d-4b1f-8a36-cbd6ed765644"), Name = "Makeup", Slug = "makeup", Description = "Foundations, lipsticks, and eyeshadows", CreatedAt = new DateTime(2024, 4, 28, 22, 25, 25, DateTimeKind.Utc), AdminId = adminIdList[0] },
                    new Category { CategoryId = Guid.Parse("9c506bbf-0fd7-43af-9507-40fb32d8bdbd"), Name = "Haircare", Slug = "haircare", Description = "Shampoos, conditioners, and styling products", CreatedAt = new DateTime(2024, 4, 28, 23, 25, 25, DateTimeKind.Utc), AdminId = adminIdList[0] },
                    new Category { CategoryId = Guid.Parse("fafbdf01-de53-486b-9e4b-5b501cc8369e"), Name = "Fragrances", Slug = "fragrances", Description = "Perfumes and colognes", CreatedAt = new DateTime(2024, 4, 28, 22, 25, 25, DateTimeKind.Utc), AdminId = adminIdList[0] },
                    new Category { CategoryId = Guid.Parse("e1d5b9c5-4e6d-4b3d-8c2b-f8c7e6d8b9e2"), Name = "Bodycare", Slug = "bodycare", Description = "Lotions, scrubs, and body oils", CreatedAt = new DateTime(2024, 5, 2, 14, 35, 45, DateTimeKind.Utc), AdminId = adminIdList[1] },
                    new Category { CategoryId = Guid.Parse("d2c6a7e8-5a9f-4b1c-8d2e-c5e9d7a8c1f3"), Name = "Nailcare", Slug = "nailcare", Description = "Nail polishes, treatments, and tools", CreatedAt = new DateTime(2024, 5, 3, 13, 45, 30, DateTimeKind.Utc), AdminId = adminIdList[2] }
                };

                foreach (var category in categories)
                {
                    context.Categories.Add(category);
                }

                await context.SaveChangesAsync();
            }

            // Ensure products exist before adding related entities
            if (!context.Products.Any())
            {
                var categoryIdList = context.Categories.Select(c => c.CategoryId).ToList();
                var adminIdList = context.Admins.Select(a => a.AdminId).ToList();
                var products = new Product[]
                {
                    new Product { ProductId = Guid.Parse("7b88a4f8-ee9f-44f7-99ef-e084da0c8ee9"), Name = "Facial Cleanser", Slug = "facial-cleanser", Price = 39.9m, Description = "Gentle and effective cleanser", StockQuantity = 110, SKU = "SKI-12345", ImgUrl = "facial-cleanser.webp", CreatedAt = new DateTime(2024, 4, 29, 15, 25, 25, DateTimeKind.Utc), CategoryId = categoryIdList[0], AdminId = adminIdList[0] },
                    new Product { ProductId = Guid.Parse("4963d195-33e0-4718-9c0c-f7db68678917"), Name = "Hydrating Moisturizer", Slug = "hydrating-moisturizer", Price = 25.9m, Description = "Keeps your skin hydrated all day", StockQuantity = 150, SKU = "SKI-12346", ImgUrl = "hydrating-moisturizer.webp", CreatedAt = new DateTime(2024, 4, 29, 16, 25, 25, DateTimeKind.Utc), CategoryId = categoryIdList[0], AdminId = adminIdList[0] },
                    new Product { ProductId = Guid.Parse("210518cb-b4c4-4d2f-9a53-f6520b534657"), Name = "Matte Foundation", Slug = "matte-foundation", Price = 30.5m, Description = "Long-lasting matte finish foundation", StockQuantity = 60, SKU = "MAK-12345", ImgUrl = "matte-foundation.webp", CreatedAt = new DateTime(2024, 4, 29, 17, 25, 25, DateTimeKind.Utc), CategoryId = categoryIdList[1], AdminId = adminIdList[0] },
                    new Product { ProductId = Guid.Parse("33ad3125-c70f-485e-bf32-b90ad76e3ad4"), Name = "Red Lipstick", Slug = "red-lipstick", Price = 20.5m, Description = "Bold and vibrant red lipstick", StockQuantity = 80, SKU = "MAK-12346", ImgUrl = "red-lipstick.webp", CreatedAt = new DateTime(2024, 4, 29, 17, 25, 25, DateTimeKind.Utc), CategoryId = categoryIdList[1], AdminId = adminIdList[0] },
                    new Product { ProductId = Guid.Parse("b106d590-002f-4b10-9237-b3954651efd0"), Name = "Shampoo", Slug = "shampoo", Price = 15.5m, Description = "Nourishing shampoo for all hair types", StockQuantity = 200, SKU = "HAI-12345", ImgUrl = "shampoo.webp", CreatedAt = new DateTime(2024, 4, 29, 17, 25, 25, DateTimeKind.Utc), CategoryId = categoryIdList[2], AdminId = adminIdList[0] },
                    new Product { ProductId = Guid.Parse("d5e6f7a8-9c5b-4a1c-8d6b-7f2e8c6d9e0a"), Name = "Body Lotion", Slug = "body-lotion", Price = 18.9m, Description = "Moisturizing body lotion for smooth skin", StockQuantity = 120, SKU = "BOD-12345", ImgUrl = "body-lotion.webp", CreatedAt = new DateTime(2024, 5, 2, 10, 15, 25, DateTimeKind.Utc), CategoryId = categoryIdList[4], AdminId = adminIdList[1] },
                    new Product { ProductId = Guid.Parse("e8c7d6a9-5b2a-4d8f-9c1b-6d8a5e7c9b0f"), Name = "Nail Polish", Slug = "nail-polish", Price = 12.5m, Description = "Long-lasting and vibrant nail polish", StockQuantity = 90, SKU = "NAI-12345", ImgUrl = "nail-polish.webp", CreatedAt = new DateTime(2024, 5, 3, 11, 25, 45, DateTimeKind.Utc), CategoryId = categoryIdList[5], AdminId = adminIdList[2] }
                };

                foreach (var product in products)
                {
                    context.Products.Add(product);
                }

                await context.SaveChangesAsync();
            }

            // Ensure orders and order products exist before adding related entities
            // Ensure orders and order products exist before adding related entities
            if (!context.Orders.Any())
            {
                var customerIdList = context.Customers.Select(c => c.CustomerId).ToList();
                var addressIdList = context.Addresses.Select(a => a.AddressId).ToList();
                var orders = new List<Order>
                {
                    new Order { OrderId = Guid.Parse("d043296e-d2d5-4374-88f8-5fe0d6d71e5e"), AddressId = addressIdList[0], CreatedAt = DateTime.UtcNow, CustomerId = customerIdList[0], PaymentMethod = "Credit Card" },
                    new Order { OrderId = Guid.Parse("f1c9eae7-7ba4-482e-ba5f-f4a795b2c228"), AddressId = addressIdList[1], CreatedAt = DateTime.UtcNow, CustomerId = customerIdList[1], PaymentMethod = "PayPal" },
                    new Order { OrderId = Guid.Parse("b0cd279d-5316-45b5-8c47-fcd3cb707cb2"), AddressId = addressIdList[2], CreatedAt = DateTime.UtcNow, CustomerId = customerIdList[2], PaymentMethod = "Credit Card" },
                    new Order { OrderId = Guid.Parse("e3d2c1b0-4a5b-4f6e-8c1b-5e6d7a8b9c1f"), AddressId = addressIdList[3], CreatedAt = DateTime.UtcNow, CustomerId = customerIdList[3], PaymentMethod = "PayPal" },
                    new Order { OrderId = Guid.Parse("c5b2a8d7-6c1f-4a9e-8b6d-5a4b3c7d8e9f"), AddressId = addressIdList[4], CreatedAt = DateTime.UtcNow, CustomerId = customerIdList[4], PaymentMethod = "Credit Card" },
                    new Order { OrderId = Guid.Parse("f2e3c4b1-7d6a-4c9f-8a1b-9c5d7e8b9a1f"), AddressId = addressIdList[5], CreatedAt = DateTime.UtcNow, CustomerId = customerIdList[5], PaymentMethod = "PayPal" }
                };

                foreach (var order in orders)
                {
                    context.Orders.Add(order);
                }

                await context.SaveChangesAsync();
            }

            if (!context.OrderProducts.Any())
            {
                var productIdList = context.Products.Select(p => p.ProductId).ToList();
                var orderIdList = context.Orders.Select(o => o.OrderId).ToList();
                var orderProducts = new List<OrderProduct>
                {
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = productIdList[0], OrderId = orderIdList[0], ProductPrice = 12m, Quantity = 2 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = productIdList[1], OrderId = orderIdList[0], ProductPrice = 5.9m, Quantity = 3 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = productIdList[2], OrderId = orderIdList[1], ProductPrice = 25.5m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = productIdList[3], OrderId = orderIdList[1], ProductPrice = 35.5m, Quantity = 2 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = productIdList[4], OrderId = orderIdList[1], ProductPrice = 35.5m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = productIdList[0], OrderId = orderIdList[2], ProductPrice = 12m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = productIdList[1], OrderId = orderIdList[2], ProductPrice = 5.9m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = productIdList[2], OrderId = orderIdList[2], ProductPrice = 25.5m, Quantity = 2 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = productIdList[5], OrderId = orderIdList[3], ProductPrice = 18.9m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = productIdList[6], OrderId = orderIdList[3], ProductPrice = 12.5m, Quantity = 2 }
                };

                foreach (var orderProduct in orderProducts)
                {
                    context.OrderProducts.Add(orderProduct);
                }

                await context.SaveChangesAsync();
            }

            // Ensure reviews exist after orders and products
            if (!context.Reviews.Any())
            {
                var customerIdList = context.Customers.Select(c => c.CustomerId).ToList();
                var orderIdList = context.Orders.Select(o => o.OrderId).ToList();
                var productIdList = context.Products.Select(p => p.ProductId).ToList();
                var reviews = new List<Review>
                {
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Great product!", OrderId = orderIdList[0], CustomerId = customerIdList[0], ProductId = productIdList[0], Rating = 5, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Fast delivery!", OrderId = orderIdList[1], CustomerId = customerIdList[1], ProductId = productIdList[2], Rating = 4, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Not as described.", OrderId = orderIdList[1], CustomerId = customerIdList[1], ProductId = productIdList[3], Rating = 2, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Good quality, thank you!", OrderId = orderIdList[2], CustomerId = customerIdList[2], ProductId = productIdList[0], Rating = 4, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Nice moisturizer!", OrderId = orderIdList[2], CustomerId = customerIdList[2], ProductId = productIdList[1], Rating = 4, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Loved the body lotion!", OrderId = orderIdList[3], CustomerId = customerIdList[3], ProductId = productIdList[5], Rating = 5, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Nice color and quality", OrderId = orderIdList[3], CustomerId = customerIdList[3], ProductId = productIdList[6], Rating = 4, ReviewDate = DateTime.UtcNow }
                };

                foreach (var review in reviews)
                {
                    context.Reviews.Add(review);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
