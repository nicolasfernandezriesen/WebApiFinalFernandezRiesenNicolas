using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiFinalFernandezRiesenNicolas.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApiFinalFernandezRiesenNicolas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DbHospitalAPIContext context;

        public DoctorController(DbHospitalAPIContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Doctor> Get()
        {
            List<Doctor> doctores = (from d in context.Doctores
                                     select d).ToList();
            return doctores;
        }

        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var doctor = (from d in context.Doctores
                          where d.DoctorNo == id
                          select d).SingleOrDefault();
            return doctor;
        }

        [HttpGet("/api/doctores/{especialidad}")]
        public dynamic GetEspecialidad(string especialidad)
        {
            var doctores = (from d in context.Doctores
                            where d.Especialidad.ToLower() == especialidad.ToLower()
                            select d).ToList();
            return doctores;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Doctor doctor)
        {
            context.Doctores.Add(doctor);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Doctor doctor)
        {
            if (id != doctor.DoctorNo)
            {
                BadRequest();
            }

            context.Entry(doctor).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var doctor = context.Doctores.Find(id);

            if (doctor == null)
            {
                return NotFound();
            }

            context.Doctores.Remove(doctor);
            context.SaveChanges();
            return Ok();
        }
    }
}
