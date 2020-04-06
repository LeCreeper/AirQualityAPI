using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using AirQualityAPI.Models;
using AirQualityAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AirQualityAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly MeasurementService _measurementService;

        public MeasurementController(MeasurementService measurementService)
        {
            _measurementService = measurementService;
        }

        /// <summary>
        /// This returns all records from the Measurements collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Measurements>> GetAll() =>
            _measurementService.Get();


        /// <summary>
        /// This returns a specific record from the Measurements collection using its objectId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:length(24)}" /*, Name = "GetMeasurement"*/)]
        public ActionResult<Measurements> Get(string id)
        {
            var Measurement = _measurementService.Get(id);

            if (Measurement == null)
            {
                return NotFound();
            }

            return Measurement;
        }





        [HttpPost]
        public ActionResult<Measurements> Create(Measurements Measurement)
        {
            _measurementService.Create(Measurement);

            return CreatedAtRoute("GetMeasurement", new {id = Measurement.ID.ToString()}, Measurement);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Measurements MeasurementIn)
        {
            var Measurement = _measurementService.Get(id);

            if (Measurement == null)
            {
                return NotFound();
            }

            _measurementService.Update(id, MeasurementIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Measurement = _measurementService.Get(id);

            if (Measurement == null)
            {
                return NotFound();
            }

            _measurementService.Remove(Measurement.ID);

            return NoContent();
        }


    }
}

  