using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WashingCars.DAL;
using WashingCars.Helpers;

namespace WashingCars.Services
{
    public class DropDownListsHelper : IDropDownListsHelper
    {
        private readonly DatabaseContext _context;

        public DropDownListsHelper(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetDDLServicesAsync()
        {
            List<SelectListItem> listServices = await _context.Services
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString(),                    
                })
                .ToListAsync();

            listServices.Insert(0, new SelectListItem
            {
                Text = "Selecione su servicio....",
                Value = "0",
            });

            return listServices;
        }
    }
}
