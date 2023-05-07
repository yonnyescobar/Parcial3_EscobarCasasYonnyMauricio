using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WashingCars.DAL.Entities
{
    public class Vehicle : Entity
    {
        #region properties
        [ForeignKey("Service")]
        public Guid ServiceId { get; set; }

        [Display(Name = "Servicio")]
        public Service Service { get; set; }

        [Display(Name = "Propietario")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe ser de máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Owner { get; set; }

        [Display(Name = "Número de Placa")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe ser de máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NumberPlate { get; set; }

        [Display(Name = "Detalles")]
        public ICollection<VehicleDetail> VehicleDetails { get; set; }
        #endregion
    }
}
