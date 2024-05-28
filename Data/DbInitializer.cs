using Microsoft.AspNetCore.Identity;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                var categories = new Category[]
                {
                    new Category { CategoryId = Guid.Parse("bca83459-e31f-4ffc-9573-9245c9cbe6b7"), Name = "Skincare", Slug = "skincare", Description = "Cleansers, moisturizers, and treatments", CreatedAt = new DateTime(2024, 4, 28, 22, 25, 25, DateTimeKind.Utc), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Category { CategoryId = Guid.Parse("c94d673b-be8d-4b1f-8a36-cbd6ed765644"), Name = "Makeup", Slug = "makeup", Description = "Foundations, lipsticks, and eyeshadows", CreatedAt = new DateTime(2024, 4, 28, 22, 25, 25, DateTimeKind.Utc), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Category { CategoryId = Guid.Parse("9c506bbf-0fd7-43af-9507-40fb32d8bdbd"), Name = "Haircare", Slug = "haircare", Description = "Shampoos, conditioners, and styling products", CreatedAt = new DateTime(2024, 4, 28, 23, 25, 25, DateTimeKind.Utc), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Category { CategoryId = Guid.Parse("fafbdf01-de53-486b-9e4b-5b501cc8369e"), Name = "Fragrances", Slug = "fragrances", Description = "Perfumes and colognes", CreatedAt = new DateTime(2024, 4, 28, 22, 25, 25, DateTimeKind.Utc), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Category { CategoryId = Guid.Parse("e1d5b9c5-4e6d-4b3d-8c2b-f8c7e6d8b9e2"), Name = "Bodycare", Slug = "bodycare", Description = "Lotions, scrubs, and body oils", CreatedAt = new DateTime(2024, 5, 2, 14, 35, 45, DateTimeKind.Utc), AdminId = Guid.Parse("03c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Category { CategoryId = Guid.Parse("d2c6a7e8-5a9f-4b1c-8d2e-c5e9d7a8c1f3"), Name = "Nailcare", Slug = "nailcare", Description = "Nail polishes, treatments, and tools", CreatedAt = new DateTime(2024, 5, 3, 13, 45, 30, DateTimeKind.Utc), AdminId = Guid.Parse("04c18f24-d667-4c07-8c4f-454dea50c115") }
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
                var products = new Product[]
                {
                    // Skincare Products
                    new Product { ProductId = Guid.Parse("7b88a4f8-ee9f-44f7-99ef-e084da0c8ee9"), Name = "Facial Cleanser", Slug = "facial-cleanser", Price = 39.9m, Description = "Gentle and effective cleanser", StockQuantity = 110, SKU = "SKI-12345", ImgUrl = "facial-cleanser.webp", CreatedAt = new DateTime(2024, 4, 29, 15, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("bca83459-e31f-4ffc-9573-9245c9cbe6b7"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("4963d195-33e0-4718-9c0c-f7db68678917"), Name = "Hydrating Moisturizer", Slug = "hydrating-moisturizer", Price = 25.9m, Description = "Keeps your skin hydrated all day", StockQuantity = 150, SKU = "SKI-12346", ImgUrl = "hydrating-moisturizer.webp", CreatedAt = new DateTime(2024, 4, 29, 16, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("bca83459-e31f-4ffc-9573-9245c9cbe6b7"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("8c3f8d23-4e18-4e8b-9c2c-0f3e5c6a8e9f"), Name = "Anti-Aging Serum", Slug = "anti-aging-serum", Price = 45.0m, Description = "Reduces fine lines and wrinkles", StockQuantity = 70, SKU = "SKI-12347", ImgUrl = "anti-aging-serum.webp", CreatedAt = new DateTime(2024, 4, 30, 14, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("bca83459-e31f-4ffc-9573-9245c9cbe6b7"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("e3f8a5d7-4c2f-42f5-9c1a-8d6e7e9b1f5c"), Name = "Sunscreen SPF 50", Slug = "sunscreen-spf50", Price = 29.5m, Description = "Protects skin from harmful UV rays", StockQuantity = 90, SKU = "SKI-12348", ImgUrl = "sunscreen-spf50.webp", CreatedAt = new DateTime(2024, 5, 1, 12, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("bca83459-e31f-4ffc-9573-9245c9cbe6b7"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("f4a8e9c6-5a8f-4c5a-9b2a-7f1e9d5e6c8f"), Name = "Night Cream", Slug = "night-cream", Price = 35.0m, Description = "Rejuvenates skin overnight", StockQuantity = 100, SKU = "SKI-12349", ImgUrl = "night-cream.webp", CreatedAt = new DateTime(2024, 5, 2, 10, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("bca83459-e31f-4ffc-9573-9245c9cbe6b7"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    // Makeup Products
                    new Product { ProductId = Guid.Parse("210518cb-b4c4-4d2f-9a53-f6520b534657"), Name = "Matte Foundation", Slug = "matte-foundation", Price = 30.5m, Description = "Long-lasting matte finish foundation", StockQuantity = 60, SKU = "MAK-12345", ImgUrl = "matte-foundation.webp", CreatedAt = new DateTime(2024, 4, 29, 17, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("c94d673b-be8d-4b1f-8a36-cbd6ed765644"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("33ad3125-c70f-485e-bf32-b90ad76e3ad4"), Name = "Red Lipstick", Slug = "red-lipstick", Price = 20.5m, Description = "Bold and vibrant red lipstick", StockQuantity = 80, SKU = "MAK-12346", ImgUrl = "red-lipstick.webp", CreatedAt = new DateTime(2024, 4, 29, 17, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("c94d673b-be8d-4b1f-8a36-cbd6ed765644"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("9f5b6a3d-7c5e-4a2f-8c1d-0e4f9b7a2c5e"), Name = "Mascara", Slug = "mascara", Price = 18.0m, Description = "Volumizing and lengthening mascara", StockQuantity = 90, SKU = "MAK-12347", ImgUrl = "mascara.webp", CreatedAt = new DateTime(2024, 5, 1, 10, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("c94d673b-be8d-4b1f-8a36-cbd6ed765644"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("a7d8e6b5-4c2d-4e3a-9b2e-0f6e9c7a8d9f"), Name = "Eyeshadow Palette", Slug = "eyeshadow-palette", Price = 22.0m, Description = "Versatile eyeshadow palette with multiple shades", StockQuantity = 50, SKU = "MAK-12348", ImgUrl = "eyeshadow-palette.webp", CreatedAt = new DateTime(2024, 5, 2, 12, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("c94d673b-be8d-4b1f-8a36-cbd6ed765644"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("b6a7d8e9-4c3b-4d2a-9c1f-8e9d7a5e6c4f"), Name = "Blush", Slug = "blush", Price = 15.5m, Description = "Natural-looking blush for a rosy glow", StockQuantity = 70, SKU = "MAK-12349", ImgUrl = "blush.webp", CreatedAt = new DateTime(2024, 5, 3, 11, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("c94d673b-be8d-4b1f-8a36-cbd6ed765644"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    // Haircare Products
                    new Product { ProductId = Guid.Parse("b106d590-002f-4b10-9237-b3954651efd0"), Name = "Shampoo", Slug = "shampoo", Price = 15.5m, Description = "Nourishing shampoo for all hair types", StockQuantity = 200, SKU = "HAI-12345", ImgUrl = "shampoo.webp", CreatedAt = new DateTime(2024, 4, 29, 17, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("9c506bbf-0fd7-43af-9507-40fb32d8bdbd"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("da4756c4-2e5e-4e9f-8b3e-0f7e5b1c8e89"), Name = "Conditioner", Slug = "conditioner", Price = 16.5m, Description = "Nourishing conditioner for all hair types", StockQuantity = 180, SKU = "HAI-12346", ImgUrl = "conditioner.webp", CreatedAt = new DateTime(2024, 4, 30, 17, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("9c506bbf-0fd7-43af-9507-40fb32d8bdbd"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("e8b6c4a7-3e2f-4b9a-9c1d-7f5e6a8d9e1f"), Name = "Hair Oil", Slug = "hair-oil", Price = 12.0m, Description = "Nourishing hair oil for smooth and shiny hair", StockQuantity = 150, SKU = "HAI-12347", ImgUrl = "hair-oil.webp", CreatedAt = new DateTime(2024, 5, 1, 11, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("9c506bbf-0fd7-43af-9507-40fb32d8bdbd"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("c3a7e9b5-4c2d-4e9b-9c2d-8e7d5a9b1c8f"), Name = "Hair Mask", Slug = "hair-mask", Price = 20.0m, Description = "Deep conditioning hair mask for damaged hair", StockQuantity = 100, SKU = "HAI-12348", ImgUrl = "hair-mask.webp", CreatedAt = new DateTime(2024, 5, 2, 13, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("9c506bbf-0fd7-43af-9507-40fb32d8bdbd"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("f4e7b9c2-5a3f-4b9a-9c2f-8d7e6c8a5e4f"), Name = "Hair Serum", Slug = "hair-serum", Price = 18.0m, Description = "Lightweight hair serum for frizz control", StockQuantity = 130, SKU = "HAI-12349", ImgUrl = "hair-serum.webp", CreatedAt = new DateTime(2024, 5, 3, 12, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("9c506bbf-0fd7-43af-9507-40fb32d8bdbd"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    // Fragrances
                    new Product { ProductId = Guid.Parse("f3a5b9d1-8c3b-4b2a-8c1e-5f8a6d7e9c1b"), Name = "Perfume", Slug = "perfume", Price = 45.0m, Description = "Long-lasting perfume with a floral scent", StockQuantity = 70, SKU = "FRA-12345", ImgUrl = "perfume.webp", CreatedAt = new DateTime(2024, 4, 29, 17, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("fafbdf01-de53-486b-9e4b-5b501cc8369e"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("e6a5d4c9-4c3e-4a9b-9c2f-7e5a9d8b1f4c"), Name = "Cologne", Slug = "cologne", Price = 40.0m, Description = "Refreshing cologne with a citrus scent", StockQuantity = 80, SKU = "FRA-12346", ImgUrl = "cologne.webp", CreatedAt = new DateTime(2024, 4, 30, 16, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("fafbdf01-de53-486b-9e4b-5b501cc8369e"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("c9d8a5b2-4e3f-4c9a-9b2c-8e7a5f9b1c3d"), Name = "Body Mist", Slug = "body-mist", Price = 25.0m, Description = "Light and refreshing body mist", StockQuantity = 90, SKU = "FRA-12347", ImgUrl = "body-mist.webp", CreatedAt = new DateTime(2024, 5, 1, 14, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("fafbdf01-de53-486b-9e4b-5b501cc8369e"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("a8d5e6c9-4b3f-4a9a-9c1d-7e6a5f8d1b4e"), Name = "Deodorant", Slug = "deodorant", Price = 15.0m, Description = "Long-lasting deodorant with a fresh scent", StockQuantity = 110, SKU = "FRA-12348", ImgUrl = "deodorant.webp", CreatedAt = new DateTime(2024, 5, 2, 15, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("fafbdf01-de53-486b-9e4b-5b501cc8369e"), AdminId = Guid.Parse("02c18f24-d667-4c07-8c4f-454dea50c115") },
                    // Bodycare Products
                    new Product { ProductId = Guid.Parse("d5e6f7a8-9c5b-4a1c-8d6b-7f2e8c6d9e0a"), Name = "Body Lotion", Slug = "body-lotion", Price = 18.9m, Description = "Moisturizing body lotion for smooth skin", StockQuantity = 120, SKU = "BOD-12345", ImgUrl = "body-lotion.webp", CreatedAt = new DateTime(2024, 5, 2, 10, 15, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("e1d5b9c5-4e6d-4b3d-8c2b-f8c7e6d8b9e2"), AdminId = Guid.Parse("03c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("e8c7d6a9-5b2a-4d8f-9c1b-6d8a5e7c9b0f"), Name = "Body Wash", Slug = "body-wash", Price = 12.5m, Description = "Refreshing body wash with a pleasant scent", StockQuantity = 140, SKU = "BOD-12346", ImgUrl = "body-wash.webp", CreatedAt = new DateTime(2024, 5, 2, 11, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("e1d5b9c5-4e6d-4b3d-8c2b-f8c7e6d8b9e2"), AdminId = Guid.Parse("03c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("c9d5e8a7-4c3d-4a9b-9c2d-8e7a5f8d1c5b"), Name = "Body Scrub", Slug = "body-scrub", Price = 16.0m, Description = "Exfoliating body scrub for smooth skin", StockQuantity = 110, SKU = "BOD-12347", ImgUrl = "body-scrub.webp", CreatedAt = new DateTime(2024, 5, 3, 12, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("e1d5b9c5-4e6d-4b3d-8c2b-f8c7e6d8b9e2"), AdminId = Guid.Parse("03c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("d8e5c6a9-4b3f-4a9a-9c1f-7e6a5f8d1b4c"), Name = "Body Butter", Slug = "body-butter", Price = 20.0m, Description = "Rich and creamy body butter for deep hydration", StockQuantity = 100, SKU = "BOD-12348", ImgUrl = "body-butter.webp", CreatedAt = new DateTime(2024, 5, 4, 13, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("e1d5b9c5-4e6d-4b3d-8c2b-f8c7e6d8b9e2"), AdminId = Guid.Parse("03c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("f8e7b5d4-4c2f-4a9a-9b2c-7e5a8d6a9c1d"), Name = "Hand Cream", Slug = "hand-cream", Price = 10.5m, Description = "Moisturizing hand cream for soft and smooth hands", StockQuantity = 130, SKU = "BOD-12349", ImgUrl = "hand-cream.webp", CreatedAt = new DateTime(2024, 5, 5, 14, 25, 25, DateTimeKind.Utc), CategoryId = Guid.Parse("e1d5b9c5-4e6d-4b3d-8c2b-f8c7e6d8b9e2"), AdminId = Guid.Parse("03c18f24-d667-4c07-8c4f-454dea50c115") },
                    // Nailcare Products
                    new Product { ProductId = Guid.Parse("e8c7d6a9-5b2a-4d8f-9c1b-6d8a5e7c9b1f"), Name = "Nail Polish", Slug = "nail-polish", Price = 12.5m, Description = "Long-lasting and vibrant nail polish", StockQuantity = 90, SKU = "NAI-12345", ImgUrl = "nail-polish.webp", CreatedAt = new DateTime(2024, 5, 3, 11, 25, 45, DateTimeKind.Utc), CategoryId = Guid.Parse("d2c6a7e8-5a9f-4b1c-8d2e-c5e9d7a8c1f3"), AdminId = Guid.Parse("04c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("d4a5b6c9-4c2f-4a9a-9c1f-7e6a5d8b1c4e"), Name = "Nail Strengthener", Slug = "nail-strengthener", Price = 14.0m, Description = "Strengthens and protects nails", StockQuantity = 70, SKU = "NAI-12346", ImgUrl = "nail-strengthener.webp", CreatedAt = new DateTime(2024, 5, 3, 12, 25, 45, DateTimeKind.Utc), CategoryId = Guid.Parse("d2c6a7e8-5a9f-4b1c-8d2e-c5e9d7a8c1f3"), AdminId = Guid.Parse("04c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("e5d7c6a8-4c3e-4a9b-9c2d-7e6a5f8d1b4c"), Name = "Cuticle Oil", Slug = "cuticle-oil", Price = 10.0m, Description = "Moisturizes and nourishes cuticles", StockQuantity = 80, SKU = "NAI-12347", ImgUrl = "cuticle-oil.webp", CreatedAt = new DateTime(2024, 5, 3, 13, 25, 45, DateTimeKind.Utc), CategoryId = Guid.Parse("d2c6a7e8-5a9f-4b1c-8d2e-c5e9d7a8c1f3"), AdminId = Guid.Parse("04c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("d9a5e7b6-4c2f-4a9a-9c1f-7e6a5d8b1c4e"), Name = "Nail File", Slug = "nail-file", Price = 5.0m, Description = "High-quality nail file for smooth edges", StockQuantity = 100, SKU = "NAI-12348", ImgUrl = "nail-file.webp", CreatedAt = new DateTime(2024, 5, 3, 14, 25, 45, DateTimeKind.Utc), CategoryId = Guid.Parse("d2c6a7e8-5a9f-4b1c-8d2e-c5e9d7a8c1f3"), AdminId = Guid.Parse("04c18f24-d667-4c07-8c4f-454dea50c115") },
                    new Product { ProductId = Guid.Parse("e7d5c6a9-4c3e-4a9a-9c1f-7e6a5f8d1b4c"), Name = "Nail Buffer", Slug = "nail-buffer", Price = 6.5m, Description = "Smooths and buffs nails to a high shine", StockQuantity = 110, SKU = "NAI-12349", ImgUrl = "nail-buffer.webp", CreatedAt = new DateTime(2024, 5, 3, 15, 25, 45, DateTimeKind.Utc), CategoryId = Guid.Parse("d2c6a7e8-5a9f-4b1c-8d2e-c5e9d7a8c1f3"), AdminId = Guid.Parse("04c18f24-d667-4c07-8c4f-454dea50c115") }
                };

                foreach (var product in products)
                {
                    context.Products.Add(product);
                }

                await context.SaveChangesAsync();
            }

            // Ensure orders and order products exist before adding related entities
            if (!context.Orders.Any())
            {
                var orders = new List<Order>
                {
                    new Order { OrderId = Guid.Parse("d043296e-d2d5-4374-88f8-5fe0d6d71e5e"), AddressId = Guid.Parse("9d358843-fd84-4af3-b486-fa8725c8af42"), CreatedAt = DateTime.UtcNow, CustomerId = Guid.Parse("feee9ca6-fd69-46cf-a990-64db26780922"), PaymentMethod = "Credit Card", TotalPrice = 45.8m },
                    new Order { OrderId = Guid.Parse("f1c9eae7-7ba4-482e-ba5f-f4a795b2c228"), AddressId = Guid.Parse("76f4d253-2171-4985-8c9e-f1979423ebc8"), CreatedAt = DateTime.UtcNow, CustomerId = Guid.Parse("12295810-446c-4ef3-b5f9-8b7ec0a81e88"), PaymentMethod = "PayPal", TotalPrice = 96.5m },
                    new Order { OrderId = Guid.Parse("b0cd279d-5316-45b5-8c47-fcd3cb707cb2"), AddressId = Guid.Parse("d4b782fb-9f62-4258-9d16-0e673268945e"), CreatedAt = DateTime.UtcNow, CustomerId = Guid.Parse("a470781d-df28-4a68-b5f4-9b259b4b69d9"), PaymentMethod = "Credit Card", TotalPrice = 43.4m },
                    new Order { OrderId = Guid.Parse("e3d2c1b0-4a5b-4f6e-8c1b-5e6d7a8b9c1f"), AddressId = Guid.Parse("fb639447-d196-4de4-b03d-6bcc3ca000e4"), CreatedAt = DateTime.UtcNow, CustomerId = Guid.Parse("cb45d6e0-b134-491a-8968-9f27fc5c4c37"), PaymentMethod = "PayPal", TotalPrice = 71.3m },
                    new Order { OrderId = Guid.Parse("c5b2a8d7-6c1f-4a9e-8b6d-5a4b3c7d8e9f"), AddressId = Guid.Parse("c13854e7-aab7-4e5f-88dd-8a701924d80b"), CreatedAt = DateTime.UtcNow, CustomerId = Guid.Parse("1f24d0f8-4cb6-4a56-8c6b-6b64a17b7dc6"), PaymentMethod = "Credit Card", TotalPrice = 41.0m },
                    new Order { OrderId = Guid.Parse("f2e3c4b1-7d6a-4c9f-8a1b-9c5d7e8b9a1f"), AddressId = Guid.Parse("e29e8d72-a949-4fe9-a986-eae03ed2a48f"), CreatedAt = DateTime.UtcNow, CustomerId = Guid.Parse("e3b5d9a3-b5db-4f96-8c3d-8d6e4e0a7e1e"), PaymentMethod = "PayPal", TotalPrice = 109.8m }
                };

                foreach (var order in orders)
                {
                    context.Orders.Add(order);
                }

                await context.SaveChangesAsync();
            }

            if (!context.OrderProducts.Any())
            {
                var orderProducts = new List<OrderProduct>
                {
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("7b88a4f8-ee9f-44f7-99ef-e084da0c8ee9"), OrderId = Guid.Parse("d043296e-d2d5-4374-88f8-5fe0d6d71e5e"), ProductPrice = 12m, Quantity = 2 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("4963d195-33e0-4718-9c0c-f7db68678917"), OrderId = Guid.Parse("d043296e-d2d5-4374-88f8-5fe0d6d71e5e"), ProductPrice = 5.9m, Quantity = 3 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("8c3f8d23-4e18-4e8b-9c2c-0f3e5c6a8e9f"), OrderId = Guid.Parse("f1c9eae7-7ba4-482e-ba5f-f4a795b2c228"), ProductPrice = 25.5m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("e3f8a5d7-4c2f-42f5-9c1a-8d6e7e9b1f5c"), OrderId = Guid.Parse("f1c9eae7-7ba4-482e-ba5f-f4a795b2c228"), ProductPrice = 35.5m, Quantity = 2 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("f4a8e9c6-5a8f-4c5a-9b2a-7f1e9d5e6c8f"), OrderId = Guid.Parse("f1c9eae7-7ba4-482e-ba5f-f4a795b2c228"), ProductPrice= 35.5m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("210518cb-b4c4-4d2f-9a53-f6520b534657"), OrderId = Guid.Parse("b0cd279d-5316-45b5-8c47-fcd3cb707cb2"), ProductPrice = 12m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("33ad3125-c70f-485e-bf32-b90ad76e3ad4"), OrderId = Guid.Parse("b0cd279d-5316-45b5-8c47-fcd3cb707cb2"), ProductPrice = 5.9m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("9f5b6a3d-7c5e-4a2f-8c1d-0e4f9b7a2c5e"), OrderId = Guid.Parse("b0cd279d-5316-45b5-8c47-fcd3cb707cb2"), ProductPrice = 25.5m, Quantity = 2 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("d5e6f7a8-9c5b-4a1c-8d6b-7f2e8c6d9e0a"), OrderId = Guid.Parse("e3d2c1b0-4a5b-4f6e-8c1b-5e6d7a8b9c1f"), ProductPrice = 18.9m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("e8c7d6a9-5b2a-4d8f-9c1b-6d8a5e7c9b0f"), OrderId = Guid.Parse("e3d2c1b0-4a5b-4f6e-8c1b-5e6d7a8b9c1f"), ProductPrice = 12.5m, Quantity = 2 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("da4756c4-2e5e-4e9f-8b3e-0f7e5b1c8e89"), OrderId = Guid.Parse("c5b2a8d7-6c1f-4a9e-8b6d-5a4b3c7d8e9f"), ProductPrice = 16.5m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("f3a5b9d1-8c3b-4b2a-8c1e-5f8a6d7e9c1b"), OrderId = Guid.Parse("f2e3c4b1-7d6a-4c9f-8a1b-9c5d7e8b9a1f"), ProductPrice = 45.0m, Quantity = 2 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("e6a5d4c9-4c3e-4a9b-9c2f-7e5a9d8b1f4c"), OrderId = Guid.Parse("d043296e-d2d5-4374-88f8-5fe0d6d71e5e"), ProductPrice = 18.0m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("c9d8a5b2-4e3f-4c9a-9b2c-8e7a5f9b1c3d"), OrderId = Guid.Parse("d043296e-d2d5-4374-88f8-5fe0d6d71e5e"), ProductPrice = 22.0m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("a8d5e6c9-4b3f-4a9a-9c1d-7e6a5f8d1b4e"), OrderId = Guid.Parse("f1c9eae7-7ba4-482e-ba5f-f4a795b2c228"), ProductPrice = 20.0m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("d5e6f7a8-9c5b-4a1c-8d6b-7f2e8c6d9e0a"), OrderId = Guid.Parse("f1c9eae7-7ba4-482e-ba5f-f4a795b2c228"), ProductPrice = 15.0m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("f4e7b9c2-5a3f-4b9a-9c2f-8d7e6c8a5e4f"), OrderId = Guid.Parse("b0cd279d-5316-45b5-8c47-fcd3cb707cb2"), ProductPrice = 20.0m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("e8b6c4a7-3e2f-4b9a-9c1d-7f5e6a8d9e1f"), OrderId = Guid.Parse("e3d2c1b0-4a5b-4f6e-8c1b-5e6d7a8b9c1f"), ProductPrice = 12.5m, Quantity = 1 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("c3a7e9b5-4c2d-4e9b-9c2d-8e7d5a9b1c8f"), OrderId = Guid.Parse("e3d2c1b0-4a5b-4f6e-8c1b-5e6d7a8b9c1f"), ProductPrice = 10.0m, Quantity = 2 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("d4a5b6c9-4c2f-4a9a-9c1f-7e6a5d8b1c4e"), OrderId = Guid.Parse("c5b2a8d7-6c1f-4a9e-8b6d-5a4b3c7d8e9f"), ProductPrice = 5.0m, Quantity = 3 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("e5d7c6a8-4c3e-4a9b-9c2d-7e6a5f8d1b4c"), OrderId = Guid.Parse("c5b2a8d7-6c1f-4a9e-8b6d-5a4b3c7d8e9f"), ProductPrice = 6.5m, Quantity = 2 },
                    new OrderProduct { OrderProductId = Guid.NewGuid(), ProductId = Guid.Parse("b106d590-002f-4b10-9237-b3954651efd0"), OrderId = Guid.Parse("f2e3c4b1-7d6a-4c9f-8a1b-9c5d7e8b9a1f"), ProductPrice = 18.9m, Quantity = 1 }
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
                var reviews = new List<Review>
                {
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Great product!", OrderId = Guid.Parse("d043296e-d2d5-4374-88f8-5fe0d6d71e5e"), CustomerId = Guid.Parse("feee9ca6-fd69-46cf-a990-64db26780922"), ProductId = Guid.Parse("7b88a4f8-ee9f-44f7-99ef-e084da0c8ee9"), Rating = 5, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Fast delivery!", OrderId = Guid.Parse("f1c9eae7-7ba4-482e-ba5f-f4a795b2c228"), CustomerId = Guid.Parse("12295810-446c-4ef3-b5f9-8b7ec0a81e88"), ProductId = Guid.Parse("8c3f8d23-4e18-4e8b-9c2c-0f3e5c6a8e9f"), Rating = 4, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Not as described.", OrderId = Guid.Parse("f1c9eae7-7ba4-482e-ba5f-f4a795b2c228"), CustomerId = Guid.Parse("12295810-446c-4ef3-b5f9-8b7ec0a81e88"), ProductId = Guid.Parse("e3f8a5d7-4c2f-42f5-9c1a-8d6e7e9b1f5c"), Rating = 2, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Good quality, thank you!", OrderId = Guid.Parse("b0cd279d-5316-45b5-8c47-fcd3cb707cb2"), CustomerId = Guid.Parse("a470781d-df28-4a68-b5f4-9b259b4b69d9"), ProductId = Guid.Parse("210518cb-b4c4-4d2f-9a53-f6520b534657"), Rating = 4, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Nice moisturizer!", OrderId = Guid.Parse("b0cd279d-5316-45b5-8c47-fcd3cb707cb2"), CustomerId = Guid.Parse("a470781d-df28-4a68-b5f4-9b259b4b69d9"), ProductId = Guid.Parse("33ad3125-c70f-485e-bf32-b90ad76e3ad4"), Rating = 4, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Loved the body lotion!", OrderId = Guid.Parse("e3d2c1b0-4a5b-4f6e-8c1b-5e6d7a8b9c1f"), CustomerId = Guid.Parse("cb45d6e0-b134-491a-8968-9f27fc5c4c37"), ProductId = Guid.Parse("d5e6f7a8-9c5b-4a1c-8d6b-7f2e8c6d9e0a"), Rating = 5, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Nice color and quality", OrderId = Guid.Parse("e3d2c1b0-4a5b-4f6e-8c1b-5e6d7a8b9c1f"), CustomerId = Guid.Parse("cb45d6e0-b134-491a-8968-9f27fc5c4c37"), ProductId = Guid.Parse("e8c7d6a9-5b2a-4d8f-9c1b-6d8a5e7c9b0f"), Rating = 4, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Good conditioner!", OrderId = Guid.Parse("c5b2a8d7-6c1f-4a9e-8b6d-5a4b3c7d8e9f"), CustomerId = Guid.Parse("1f24d0f8-4cb6-4a56-8c6b-6b64a17b7dc6"), ProductId = Guid.Parse("da4756c4-2e5e-4e9f-8b3e-0f7e5b1c8e89"), Rating = 5, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Amazing perfume!", OrderId = Guid.Parse("f2e3c4b1-7d6a-4c9f-8a1b-9c5d7e8b9a1f"), CustomerId = Guid.Parse("e3b5d9a3-b5db-4f96-8c3d-8d6e4e0a7e1e"), ProductId = Guid.Parse("f3a5b9d1-8c3b-4b2a-8c1e-5f8a6d7e9c1b"), Rating = 5, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Effective sunscreen.", OrderId = Guid.Parse("d043296e-d2d5-4374-88f8-5fe0d6d71e5e"), CustomerId = Guid.Parse("feee9ca6-fd69-46cf-a990-64db26780922"), ProductId = Guid.Parse("e3f8a5d7-4c2f-42f5-9c1a-8d6e7e9b1f5c"), Rating = 4, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Great blush color!", OrderId = Guid.Parse("f1c9eae7-7ba4-482e-ba5f-f4a795b2c228"), CustomerId = Guid.Parse("12295810-446c-4ef3-b5f9-8b7ec0a81e88"), ProductId = Guid.Parse("e8c7d6a9-5b2a-4d8f-9c1b-6d8a5e7c9b0f"), Rating = 5, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Smooth nail polish.", OrderId = Guid.Parse("b0cd279d-5316-45b5-8c47-fcd3cb707cb2"), CustomerId = Guid.Parse("a470781d-df28-4a68-b5f4-9b259b4b69d9"), ProductId = Guid.Parse("210518cb-b4c4-4d2f-9a53-f6520b534657"), Rating = 4, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Love the scent.", OrderId = Guid.Parse("e3d2c1b0-4a5b-4f6e-8c1b-5e6d7a8b9c1f"), CustomerId = Guid.Parse("cb45d6e0-b134-491a-8968-9f27fc5c4c37"), ProductId = Guid.Parse("c9d8a5b2-4e3f-4c9a-9b2c-8e7a5f9b1c3d"), Rating = 5, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Effective nail strengthener.", OrderId = Guid.Parse("c5b2a8d7-6c1f-4a9e-8b6d-5a4b3c7d8e9f"), CustomerId = Guid.Parse("1f24d0f8-4cb6-4a56-8c6b-6b64a17b7dc6"), ProductId = Guid.Parse("da4756c4-2e5e-4e9f-8b3e-0f7e5b1c8e89"), Rating = 4, ReviewDate = DateTime.UtcNow },
                    new Review { ReviewId = Guid.NewGuid(), Comment = "Great cuticle oil.", OrderId = Guid.Parse("f2e3c4b1-7d6a-4c9f-8a1b-9c5d7e8b9a1f"), CustomerId = Guid.Parse("e3b5d9a3-b5db-4f96-8c3d-8d6e4e0a7e1e"), ProductId = Guid.Parse("e8c7d6a9-5b2a-4d8f-9c1b-6d8a5e7c9b0f"), Rating = 5, ReviewDate = DateTime.UtcNow }
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
