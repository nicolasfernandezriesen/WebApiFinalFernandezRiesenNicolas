using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFinalFernandezRiesenNicolas.Models
{
    [Table("Doctor")]
    public class Doctor
    {
        [Key]
        public int DoctorNo { get; set; }

        [ForeignKey("Hospital")]
        public int HospitalCod { get; set; }

        [StringLength(50)]
        public string? Apellido { get; set; }

        [StringLength(50)]
        public string? Especialidad { get; set; }

        public Hospital Hospital { get; set; }
    }
}
