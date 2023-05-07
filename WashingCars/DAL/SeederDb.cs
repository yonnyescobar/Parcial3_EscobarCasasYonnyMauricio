using System.Net;
using WashingCars.DAL.Entities;
using WashingCars.Enums;
using WashingCars.Helpers;
using WashingCars.Services;

namespace WashingCars.DAL
{
    public class SeederDb
    {
        private readonly DatabaseContext _context;
        private readonly IUserHelper _userHelper;

        public SeederDb(DatabaseContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        #region update-database
        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulateServicesAsync();
            await PopulateRolesAsync();
            await PopulateUserAsync("Client", "Role", "client_role@yopmail.com", "3002323232", "Street One", "102030", UserType.Client);
            await PopulateUserAsync("Admin", "Role", "admin_role@yopmail.com", "40056566756", "Street Two", "405060", UserType.Admin);


            await _context.SaveChangesAsync();
        }

        #endregion

        #region methods
        private async Task PopulateServicesAsync()
        {
            if (!_context.Services.Any())
            {
                _context.Services.Add(new Service { Name = "Lavada simple", Price = 25000 });
                _context.Services.Add(new Service { Name = "Lavada + Polishada", Price = 50000 });
                _context.Services.Add(new Service { Name = "Lavada + Aspirada de Cojinería", Price = 30000 });
                _context.Services.Add(new Service { Name = "Lavada Full", Price = 65000 });
                _context.Services.Add(new Service { Name = "Lavada en seco del Motor", Price = 80000 });
                _context.Services.Add(new Service { Name = "Lavada Chasis", Price = 90000 });
            }
        }

        private async Task PopulateRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Client.ToString());
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
        }

        private async Task PopulateUserAsync(
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            string document,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);

            if (user == null)
            {
                user = new User
                {
                    CreatedDate = DateTime.Now,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Document = document,
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            #endregion
        }
    }
}
