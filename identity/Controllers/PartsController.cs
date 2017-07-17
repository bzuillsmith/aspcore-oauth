using AspCoreExperiments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreExperiments.Controllers
{
    [Route("api/[controller]")]
    public class PartsController : Controller
    {
        public List<Part> Parts = new List<Part> {
            new Part() {
                Id = new Guid("2ED3D8FD-AC66-4B96-B0B7-552E97F00D0A"),
                PartNumber = "A101",
                Description = "A101 sample part description",
                UnitType = UnitType.OptimizedLenth
            },
            new Part() {
                Id = new Guid("71925C27-51D5-44D4-972E-9185630E9588"),
                PartNumber = "A110",
                Description = "A110 sample part description",
                UnitType = UnitType.OptimizedLenth
            },
            new Part() {
                Id = new Guid("D7567A12-AFF7-4492-95F9-81B669839F60"),
                PartNumber = "S10",
                Description = "Screw for the A100 system",
                UnitType = UnitType.Count,
                
            }
        };

        [HttpGet]
        public IEnumerable<Part> GetAllParts()
        {
            return Parts;
        }

        [HttpGet("{id}", Name="GetPart")]
        public IActionResult GetById(Guid id)
        {
            var part = Parts.FirstOrDefault((p) => p.Id == id);
            if (part == null)
            {
                return NotFound();
            }
            return new ObjectResult(part);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Part part)
        {
            if(part == null) return BadRequest();

            part.Id = Guid.NewGuid();
            Parts.Add(part);

            return CreatedAtRoute("GetPart", new { Id = part.Id }, part);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var part = Parts.FirstOrDefault(p => p.Id == id);
            if(part == null) return NotFound();

            Parts.Remove(part);
            return new NoContentResult();
        }

    }
}