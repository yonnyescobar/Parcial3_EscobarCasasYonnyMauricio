using Microsoft.AspNetCore.Mvc.Rendering;

namespace WashingCars.Helpers
{
    public interface IDropDownListsHelper
    {
        Task<IEnumerable<SelectListItem>> GetDDLServicesAsync();

    }
}
