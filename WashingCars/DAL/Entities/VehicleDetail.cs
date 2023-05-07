using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WashingCars.DAL.Entities
{
    public class VehicleDetail : Entity
    {
        #region properties
        [ForeignKey("Vehicle")]
        public Guid VehicleId { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "Fecha de Entrega")]
        public DateTime? DeliveryDate { get; set; }
        #endregion
    }
}
