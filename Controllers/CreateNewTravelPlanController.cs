﻿using AutoMapper;
using Infobip.Infrastructure;
using Infobip.Models;
using Infobip.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Infobip.Controllers
{
    [ApiController]
    [Route("api/createnewtravelplan")]
    public class CreateNewTravelPlanController : ControllerBase
    {
        private readonly ICarpoolRepository _carpoolRepository; 

        public CreateNewTravelPlanController(ICarpoolRepository carpoolRepository)
        {
            _carpoolRepository = carpoolRepository;
        }

        [HttpGet("cars")]
        public IEnumerable<Car> GetUnallocatedCars()
        {
            var res = _carpoolRepository.GetCars().Result;
            return res.ToList();
        }

        [HttpGet("employees")]
        public IEnumerable<Employee> GetEmployees()
        {
            var res = _carpoolRepository.GetEmployees().Result;
            return res.ToList();
        }

        [HttpPost("submit")]
        public async Task<ActionResult> Submit([FromForm] TravelPlanDto travelPlan)
        {
            try
            {
                await _carpoolRepository.AddNewTravelPlan(travelPlan);

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromForm] TravelPlanDto travelPlan)
        {
            try
            {

                travelPlan.Id = id;
                await _carpoolRepository.UpdateTravelPlan(travelPlan);

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpDelete("delete/{id}")]
        public  async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _carpoolRepository.DeleteTravelPlan(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }
    }
}