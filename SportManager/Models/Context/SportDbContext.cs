using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SportManager.Models.Context
{
    public class SportDbContext : DbContext
    {
        public SportDbContext(DbContextOptions<SportDbContext> options) : base(options)
        {
        }
        public DbSet<AccessRight> AccessRights { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<SportDiscipine> SportDiscipines { get; set; }
        //public DbSet<SportDiscipineCaptain> SportDiscipineCaptains { get; set; }
        public DbSet<SportDiscipinePatron> SportDiscipinePatrons { get; set; }
        public DbSet<SportDisciplinesInEvent> SportDisciplinesInEvents { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreCategory> StoreCategories { get; set; }
        public DbSet<StoreItem> StoreItems { get; set; }
        public DbSet<StoreItemInUse> StoreItemInUse { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentsParticipatingInEvent> StudentsParticipatingInEvents { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Message> Messages { get; set; }
        //public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<EventSession> EventSessions { get; set; }
        public DbSet<Password> Passwords { get; set; }
        //public DbSet<Status> Statuses { get; set; }
        public DbSet<MakerChecker> MakerCheckers { get; set; }

        static string Encrypt(string textToEncrypt, string key = "!-gfyugu\\E\\jgjguk87878))_6786yb08\\SSM")
        {
            RijndaelManaged expr_05 = new RijndaelManaged();
            expr_05.Mode = CipherMode.CBC;
            expr_05.Padding = PaddingMode.PKCS7;
            expr_05.KeySize = 128;
            expr_05.BlockSize = 128;
            byte[] arg_3C_0 = Encoding.UTF8.GetBytes(key);
            byte[] keyBytes = new byte[16];
            int len = arg_3C_0.Length;
            if (len > keyBytes.Length)
            {
                len = keyBytes.Length;
            }
            Array.Copy(arg_3C_0, keyBytes, len);
            expr_05.Key = keyBytes;
            expr_05.IV = keyBytes;
            ICryptoTransform arg_75_0 = expr_05.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);
            return Convert.ToBase64String(arg_75_0.TransformFinalBlock(plainText, 0, plainText.Length));
        }

        static string RandomString()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_@#&";
            return new string(Enumerable.Range(0, new Random().Next(6, 6)).Select(x => input[rand.Next(0, input.Length)]).ToArray());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>()
            //    .HasOne(a => a.UserType)
            //    .WithMany(b => b.Users)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TeamMember>()
                .HasOne(a => a.Team)
                .WithMany(b => b.TeamMembers)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Team>()
                .HasOne(a => a.Event)
                .WithMany(b => b.Teams)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Team>()
                .HasOne(a => a.SportDiscipine)
                .WithMany(b => b.Teams)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SportDiscipinePatron>()
                .HasOne(a => a.SportDiscipine)
                .WithOne(b => b.SportDiscipinePatron)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SportDiscipinePatron>()
                .HasOne(a => a.Staff)
                .WithOne(b => b.SportDiscipinePatron)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<SportDiscipinePatron>()
            //    .HasOne(a => a.Staff)
            //    .WithMany(b => b.SportDiscipinePatrons)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<SportDiscipineCaptain>()
            //    .HasOne(a => a.SportDiscipine)
            //    .WithMany(b => b.SportDiscipineCaptains)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<SportDiscipineCaptain>()
            //    .HasOne(a => a.Student)
            //    .WithMany(b => b.SportDiscipineCaptains)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentsParticipatingInEvent>()
                .HasOne(a => a.Student)
                .WithMany(b => b.StudentsParticipatingInEvent)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentsParticipatingInEvent>()
                .HasOne(a => a.SportDisciplinesInEvent)
                .WithMany(b => b.StudentsParticipatingInEvent)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Staff>()
                .HasOne(a => a.Profile)
                .WithMany(b => b.Staffs)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StoreItem>()
                .HasOne(a => a.StoreCategory)
                .WithMany(b => b.StoreItems)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Store>()
            //    .HasOne(a => a.StoreCategory)
            //    .WithMany(b => b.Stores)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<StoreItem>()
            //    .HasOne(a => a.Store)
            //    .WithMany(b => b.StoreItems)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StoreItemInUse>()
                .HasOne(a => a.StoreItem)
                .WithMany(b => b.StoreItemsInUse)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StoreItemInUse>()
                .HasOne(a => a.Event)
                .WithMany(b => b.StoreItemsInUse)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StoreItemInUse>()
                .HasOne(a => a.SportDiscipine)
                .WithMany(b => b.StoreItemsInUse)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MakerChecker>()
                .HasOne(a => a.Maker)
                .WithMany(b => b.MakerCheckers)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<MakerChecker>()
            //    .HasOne(a => a.Checker)
            //    .WithMany(b => b.MakerCheckers)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EventSession>()
                .HasOne(a => a.Event)
                .WithMany(b => b.EventSessions)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<EventSession>()
                .HasOne(a => a.Venue)
                .WithMany(b => b.EventSessions)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Password>()
            //    .HasOne(a => a.User)
            //    .WithMany(b => b.Passwords)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AccessRight>()
                .HasOne(a => a.Menu)
                .WithMany(b => b.AccessRights)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AccessRight>()
                .HasOne(a => a.Profile)
                .WithMany(b => b.AccessRights)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);

            //modelBuilder.Entity<UserType>().HasData(
            //    new UserType
            //    {
            //        Id = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
            //        Name = "Student"
            //    },
            //    new UserType
            //    {
            //        Id = Guid.Parse("bfdedc6a-01d1-44f7-9e70-595b8091342a"),
            //        Name = "Staff"
            //    }
            //);

            //modelBuilder.Entity<MessageType>().HasData(
            //    new MessageType
            //    {
            //        Id = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
            //        Name = "E-Mail"
            //    },
            //    new MessageType
            //    {
            //        Id = Guid.Parse("bfdedc6a-01d1-44f7-9e70-595b8091342a"),
            //        Name = "SMS"
            //    }
            //);

            modelBuilder.Entity<EventType>().HasData(
                new EventType
                {
                    Id = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
                    Name = "Inter-University: Multiple disciplines"
                },
                new EventType
                {
                    Id = Guid.Parse("bfdedc6a-01d1-44f7-9e70-595b8091342a"),
                    Name = "Intra-University: Multiple disciplines"
                },
                new EventType
                {
                    Id = Guid.Parse("cb8f202b-549b-448d-a2e8-927ff944813e"),
                    Name = "Intra-University: Single discipline"
                },
                new EventType
                {
                    Id = Guid.Parse("43abbe95-fc36-4122-b974-6dac96fd8b61"),
                    Name = "Inter-University: Single discipline"
                }
            );

            modelBuilder.Entity<Profile>().HasData(
                new Profile
                {
                    Id = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
                    Name = "Coordinator",
                },
                new Profile
                {
                    Id = Guid.Parse("bfdedc6a-01d1-44f7-9e70-595b8091342a"),
                    Name = "Patron",
                },
                new Profile
                {
                    Id = Guid.Parse("cb8f202b-549b-448d-a2e8-927ff944813e"),
                    Name = "StoreKeeper",
                },
                new Profile
                {
                    Id = Guid.Parse("43abbe95-fc36-4122-b974-6dac96fd8b61"),
                    Name = "Secretary"
                },
                new Profile
                {
                    Id = Guid.Parse("3dd74e55-64b8-4245-8cfe-b79ec6057a3d"),
                    Name = "Student"
                }
            );

            modelBuilder.Entity<Parameter>().HasData(
                new Parameter
                {
                    Id = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
                    Name = "EMAILADDRESS",
                    Value = "appsderick@gmail.com",
                    IsPassword=false
                },
                new Parameter
                {
                    Id = Guid.Parse("bfdedc6a-01d1-44f7-9e70-595b8091342a"),
                    Name = "EMAILPASSWORD",
                    Value = Encrypt("_!Confirmation1"),
                    IsPassword = true
                },
                new Parameter
                {
                    Id = Guid.Parse("cb8f202b-549b-448d-a2e8-927ff944813e"),
                    Name = "EMAILFROM",
                    Value = "SPORTS DEPARTMENT",
                    IsPassword = false
                },
                new Parameter
                {
                    Id = Guid.Parse("76a94ef2-6b7f-4800-bbf9-12030898f3c9"),
                    Name = "OTP_EXPIRY_IN_MINUTES",
                    Value = "60",
                    IsPassword = false
                }
                //, 
                //new Parameter
                //{
                //    Id = Guid.Parse("43abbe95-fc36-4122-b974-6dac96fd8b61"),
                //    Name = "Inter-University: Single discipline"
                //}
            );

            modelBuilder.Entity<Staff>().HasData(
                new Staff
                {
                    Id = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
                    RegistrationNumber = "ST001",
                    Firstname = "Derick",
                    Lastname = "Oduor",
                    Email = "oduorderick@gmail.com",
                    Phone = "+254715812661",
                    Password = Encrypt("s3cret"),
                    Authorized = true,
                    Deleted=false,
                    DateRegistered = DateTime.Now,
                    ProfileId = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad")
                },
                new Staff
                {
                    Id = Guid.Parse("81019aa2-4056-41f9-b4b3-828d51fa7c51"),
                    RegistrationNumber = "ST001",
                    Firstname = "Derick",
                    Lastname = "Oduor",
                    Email = "appsderick@gmail.com",
                    Phone = "+254712345678",
                    Password = Encrypt("s3cret"),
                    Authorized = true,
                    Deleted=false,
                    DateRegistered = DateTime.Now,
                    ProfileId = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad")
                }
            );

            modelBuilder.Entity<SportDiscipine>().HasData(
                new SportDiscipine
                {
                    Id = Guid.Parse("910ce653-c7f1-4429-9b95-19270767129d"),
                    Name = "Football",
                    DateAdded =DateTime.Now,
                    Deleted = false,
                    Status = true
                }
            );

            modelBuilder.Entity<Store>().HasData(
                new Store
                {
                    Id = Guid.Parse("910ce653-c7f1-4429-9b95-19270767129d"),
                    Name = "SportStore"
                }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = Guid.Parse("910ce653-c7f1-4429-9b95-19270767129d"),
                    RegistrationNumber = "S13/21416/14",
                    Firstname = "Derick",
                    Lastname = "Oduor",
                    Email = "derick_oduor@yahoo.com",
                    Phone = "+254756993396",
                    Password = Encrypt("s3cret"),
                    Authorized = true,
                    DateRegistered = DateTime.Now,
                    ProfileId = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
                    SportDiscipineId= Guid.Parse("910ce653-c7f1-4429-9b95-19270767129d")
                }
            );

            modelBuilder.Entity<Menu>().HasData(
                new Menu
                {
                    Id = Guid.Parse("910ce653-c7f1-4429-9b95-19270767129d"),
                    Name = "Manage Staff",
                    Link = "#Staff",
                    MenuType = "MAINMENU",
                    MenuUser = "STAFF",
                    ParentId = Guid.Parse("910ce653-c7f1-4429-9b95-19270767129d"),
                    Level = 1,
                },
                new Menu
                {
                    Id = Guid.Parse("33dcb26b-db77-4147-8398-d45a5d09e952"),
                    Name = "Manage Sport Disciplines",
                    Link = "#Disciplines",
                    MenuType = "MAINMENU",
                    MenuUser = "STAFF",
                    ParentId = Guid.Parse("33dcb26b-db77-4147-8398-d45a5d09e952"),
                    Level = 2,
                },
                new Menu
                {
                    Id = Guid.Parse("d0e36979-1c0e-41a8-9a4a-c19293390f74"),
                    Name = "Manage Events",
                    Link = "#Events",
                    MenuType = "MAINMENU",
                    MenuUser = "STAFF",
                    ParentId = Guid.Parse("d0e36979-1c0e-41a8-9a4a-c19293390f74"),
                    Level = 3,
                },
                new Menu
                {
                    Id = Guid.Parse("1f37b623-7973-43f0-baf5-bd15c995e89f"),
                    Name = "Manage Venues",
                    Link = "#Venues",
                    MenuType = "MAINMENU",
                    MenuUser = "STAFF",
                    ParentId = Guid.Parse("1f37b623-7973-43f0-baf5-bd15c995e89f"),
                    Level = 4,
                },
                new Menu
                {
                    Id = Guid.Parse("400dd70c-af53-4849-9889-823256adf99a"),
                    Name = "Sports Store",
                    Link = "#Store",
                    MenuType = "MAINMENU",
                    MenuUser = "STAFF",
                    ParentId = Guid.Parse("400dd70c-af53-4849-9889-823256adf99a"),
                    Level = 5,
                },
                new Menu
                {
                    Id = Guid.Parse("832f9e6c-ee71-456c-9d70-c43cc756763b"),
                    Name = "Manage User Profiles",
                    Link = "#Profiles",
                    MenuType = "MAINMENU",
                    MenuUser = "STAFF",
                    ParentId = Guid.Parse("832f9e6c-ee71-456c-9d70-c43cc756763b"),
                    Level = 6,
                },
                new Menu
                {
                    Id = Guid.Parse("449511ee-43c6-46a7-931d-53f9895dd3cd"),
                    Name = "Maintenance",
                    Link = "#Maintenance",
                    MenuType = "MAINMENU",
                    MenuUser = "STAFF",
                    ParentId = Guid.Parse("449511ee-43c6-46a7-931d-53f9895dd3cd"),
                    Level = 7,
                },
                new Menu
                {
                    Id = Guid.Parse("8a78e169-db54-49ff-999a-8bb1bcbe7956"),
                    Name = "View Staff",
                    Link = "/Staff/",
                    MenuType = "SUB-MENU",
                    MenuUser = "STAFF",
                    ParentId = Guid.Parse("910ce653-c7f1-4429-9b95-19270767129d"),
                    Level = 1,
                }
            );

            modelBuilder.Entity<AccessRight>().HasData(
                new AccessRight
                {
                    Id = Guid.Parse("910ce653-c7f1-4429-9b95-19270767129d"),
                    MenuId = Guid.Parse("910ce653-c7f1-4429-9b95-19270767129d"),
                    ParentMenuId = Guid.Parse("910ce653-c7f1-4429-9b95-19270767129d"),
                    ProfileId = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
                },
                new AccessRight
                {
                    Id = Guid.Parse("a1a2be93-a724-49db-b0a2-e9bac91a1bf6"),
                    MenuId = Guid.Parse("33dcb26b-db77-4147-8398-d45a5d09e952"),
                    ParentMenuId = Guid.Parse("33dcb26b-db77-4147-8398-d45a5d09e952"),
                    ProfileId = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
                },
                new AccessRight
                {
                    Id = Guid.Parse("9768817f-52ef-4876-8665-408ed66ea7a7"),
                    MenuId = Guid.Parse("d0e36979-1c0e-41a8-9a4a-c19293390f74"),
                    ParentMenuId = Guid.Parse("d0e36979-1c0e-41a8-9a4a-c19293390f74"),
                    ProfileId = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
                },
                new AccessRight
                {
                    Id = Guid.Parse("c94cfbeb-f24f-4373-a95e-e1538bb570f4"),
                    MenuId = Guid.Parse("1f37b623-7973-43f0-baf5-bd15c995e89f"),
                    ParentMenuId = Guid.Parse("1f37b623-7973-43f0-baf5-bd15c995e89f"),
                    ProfileId = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
                },
                new AccessRight
                {
                    Id = Guid.Parse("76d95407-bd1c-4002-8257-bec8cd31b523"),
                    MenuId = Guid.Parse("400dd70c-af53-4849-9889-823256adf99a"),
                    ParentMenuId = Guid.Parse("400dd70c-af53-4849-9889-823256adf99a"),
                    ProfileId = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
                },
                new AccessRight
                {
                    Id = Guid.Parse("b624870d-5137-454a-9ce7-a17447edc16d"),
                    MenuId = Guid.Parse("832f9e6c-ee71-456c-9d70-c43cc756763b"),
                    ParentMenuId = Guid.Parse("832f9e6c-ee71-456c-9d70-c43cc756763b"),
                    ProfileId = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
                },
                new AccessRight
                {
                    Id = Guid.Parse("1c8b5f6a-5b26-4b24-b104-da026f87a210"),
                    MenuId = Guid.Parse("449511ee-43c6-46a7-931d-53f9895dd3cd"),
                    ParentMenuId = Guid.Parse("449511ee-43c6-46a7-931d-53f9895dd3cd"),
                    ProfileId = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
                },
                new AccessRight
                {
                    Id = Guid.Parse("817b01d0-b04e-4bdf-85fd-509d57563ead"),
                    MenuId = Guid.Parse("8a78e169-db54-49ff-999a-8bb1bcbe7956"),
                    ParentMenuId = Guid.Parse("910ce653-c7f1-4429-9b95-19270767129d"),
                    ProfileId = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
                }
            );

            //modelBuilder.Entity<Status>().HasData(
            //    new Status
            //    {
            //        Id = Guid.Parse("327d571a-1690-44e0-806d-65e0593364ad"),
            //        Name = "Pending",
            //        Value = 1
            //    }, new Status
            //    {
            //        Id = Guid.Parse("bfdedc6a-01d1-44f7-9e70-595b8091342a"),
            //        Name = "Approved",
            //        Value = 2
            //    }, new Status
            //    {
            //        Id = Guid.Parse("cb8f202b-549b-448d-a2e8-927ff944813e"),
            //        Name = "Rejected",
            //        Value = 3
            //    }, new Status
            //    {
            //        Id = Guid.Parse("9260111e-930c-4fd7-a085-6070303d243c"),
            //        Name = "Active",
            //        Value = 3
            //    }, new Status
            //    {
            //        Id = Guid.Parse("84634ddb-1ca8-453d-9983-e8a7ebc2b911"),
            //        Name = "Inactive",
            //        Value = 4
            //    }, new Status
            //    {
            //        Id = Guid.Parse("5cb423b7-19ca-47a8-a7b3-854d5460627a"),
            //        Name = "Suspended",
            //        Value = 5
            //    }, new Status
            //    {
            //        Id = Guid.Parse("4c84f40a-5b25-42bb-b09e-4456a3dabb17"),
            //        Name = "Deleted",
            //        Value = 6
            //    }
            //);
        }
    }
}
