using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace WashingCars.DAL.Entities
{
    public class Service : Entity
    {
        #region properties
        [Display(Name = "Servicio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe ser de máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Precio")]
        [Range(0, 999999999)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public float Price { get; set; }

        [Display(Name = "Vehículos")]
        public ICollection<Vehicle> Vehicles { get; set; }
        #endregion
    }
}
