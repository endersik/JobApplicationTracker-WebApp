using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationTracker.Data;
using JobApplicationTracker.Models.Dtos;
using JobApplicationTracker.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class ApplicationsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ApplicationsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllApplications(){
            var allApplications = dbContext.Applications.ToList();

            return Ok(allApplications);
        }

        [HttpGet]
        [Route("{id:long}")]

        public IActionResult GetApplicationById(long id){
            var application = dbContext.Applications.Find(id);

            if(application is null){
                return NotFound();
            }

            return Ok(application);
        }

        [HttpPost]
        public IActionResult AddApplication(CreateApplicationDto newApplication){
            var application = new Application(){
                Company = newApplication.Company,
                Position = newApplication.Position,
                Deadline = newApplication.Deadline,
                Applied = newApplication.Applied
            };

            dbContext.Applications.Add(application);
            dbContext.SaveChanges();

            return Ok(application);
        }

        [HttpPut]
        [Route("{id:long}")]

        public IActionResult UpdateApplication(long id, UpdateApplicationDto updatedApplication){
            var existingApplication = dbContext.Applications.Find(id);

            if (existingApplication is null){
                return NotFound();
            }

            existingApplication.Company = updatedApplication.Company;
            existingApplication.Position = updatedApplication.Position;
            existingApplication.Deadline = updatedApplication.Deadline;
            existingApplication.Applied = updatedApplication.Applied;

            dbContext.SaveChanges();

            return Ok(existingApplication);
        }

        [HttpDelete]
        [Route("{id:long}")]

        public IActionResult DeleteApplication(long id){
            var application = dbContext.Applications.Find(id);

            if(application is null){
                return NotFound();
            }

            dbContext.Applications.Remove(application);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}