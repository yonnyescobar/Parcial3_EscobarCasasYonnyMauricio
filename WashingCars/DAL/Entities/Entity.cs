using System.ComponentModel.DataAnnotations;

namespace WashingCars.DAL.Entities
{
    public class Entity
    {
        #region properties
        [Key]
        [Required]
        public Guid Id { get; set; }
        #endregion
    }
}
