using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiFinalFernandezRiesenNicolas.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApiFinalFernandezRiesenNicolas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly DbHospitalAPIContext context;

        public HospitalController(DbHospitalAPIContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public dynamic Get()
        {
            dynamic hospitales = (from h in context.Hospitales
                                  select new {h.Nombre, h.Telefono, h.NumCama}).ToList();
            return hospitales;
        }

        [HttpGet("{numCama}")]
        public dynamic Get(int numCama)
        {
            dynamic hospitales = (from h in context.Hospitales
                                  where h.NumCama > numCama
                                  select new { h.Nombre, h.Telefono, h.NumCama }).ToList();
            return hospitales;
        }
    }
}
