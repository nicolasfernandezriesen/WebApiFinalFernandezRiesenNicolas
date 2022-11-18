using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApiFinalFernandezRiesenNicolas.Models
{
    [Table("Hospital")]
    public class Hospital
    {
        [Key]
        public int HospitalCod { get; set; }

        [StringLength(50)]
        public string? Nombre { get; set; }

        [StringLength(50)]
        public string? Direccion { get; set; }

        [StringLength(50)]
        public string? Telefono { get; set; }
        public int NumCama { get; set; }

        public List<Doctor> Doctores { get; set; }
    }
}
