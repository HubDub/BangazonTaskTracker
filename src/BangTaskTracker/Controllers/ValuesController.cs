using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BangTaskTracker.Models;
using BangTaskTracker.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static BangTaskTracker.Models.TrackedTask;

namespace BangTaskTracker.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private TrackerContext context;

        public ValuesController(TrackerContext ctx)
        {
            context = ctx;
        }

        // GET api/values - this will automatically get whatever values are in the DB when you navigate to this address. if there is nothing in the DB it should return a NotFound error. if there are tasks, it should return the task objects (or nothing if the table exists but there are no objects saved in it)
        [HttpGet]
        public IActionResult Get()
        {
            //return new string[] { "value1", "value2" };
            IQueryable<object> trackedTasks = from TrackedTask in context.TrackedTask select TrackedTask;

            if (trackedTasks == null)
            {
                return NotFound();
            }

            return Ok(trackedTasks);
        }

        // GET api/values/5
        // when you type this address in it will run th e get method and just get the one object you are asking for. if that object does not exist it should return a NotFound error
        [HttpGet("{id}", Name = "GetTrackedTask")]
        public IActionResult Get([FromRoute]int id)
        {
            if (!ModelState.IsValid) //why are we checking model state on a get?
            {
                return BadRequest(ModelState); //if the model state is bad it will return badrequest
            }
            try //here we will try to pull the one task by using a linq query matching the passed in id (from the http route) with the id of a single task id in the DB
            {
                TrackedTask trackedTask = context.TrackedTask.Single(m => m.Taskid == id);
                if (trackedTask == null)
                {
                    return NotFound(); //if it does not find the id, it will return not found
                }
                return Ok(trackedTask); //if it finds the task it will return it
            }
            catch (System.InvalidOperationException ex)
            //if the try doesn't work, it will catch the error
            {
                return NotFound(ex);  //and then return the error
            }
        }

        // POST api/values
        [HttpPost]
        //when you post using the above http address it will run this method. it will pass the object you are posting into the method
        public IActionResult Post([FromBody]TrackedTask trackedTask)
        {
            if (!ModelState.IsValid)   //it will check the model state to make sure it's valid
            {
                return BadRequest(ModelState); //if invalid it will return badrequest
            }
            context.TrackedTask.Add(trackedTask); //if valid it will add the task to the context
            try
            {
                context.SaveChanges(); //to add save the changes to the context to the DB
            }
            catch (DbUpdateException)//if the try doesn't work, we'll catch the exception
            {
                if (TrackedTaskExists(trackedTask.Taskid)) //if the task exists, 
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict); //we'll return an error saying there is a conflict
                }
                else
                {
                    throw;
                }
            }

            //return new OkObjectResult(trackedTask); //this one worked when the CreatedAtRoute was not working
            return CreatedAtRoute("GetTrackedTask", new { id = trackedTask.Taskid }, trackedTask); //this did not work until I named the route in the get method above
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TrackedTask trackedTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != trackedTask.Taskid)
            {
                return BadRequest(ModelState);
            }
            if (trackedTask.TaskOrderStatus == OrderStatus.Complete)
                //this checks the value of the enum to see if it is complete
            {
                trackedTask.CompletedOn = DateTime.Now;
            }
            context.TrackedTask.Update(trackedTask);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TrackedTaskExists(trackedTask.Taskid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;

                }
            }
            return Ok(trackedTask);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody]TrackedTask trackedTask)
        {
            if(id != trackedTask.Taskid)
            {
                return BadRequest(ModelState);
            }
            context.TrackedTask.Remove(trackedTask);
            try
            {
                context.SaveChanges();
            }
            catch
            {
                if (TrackedTaskExists(trackedTask.Taskid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return Ok(trackedTask);
        }

        //here we are setting up a boolean for better exception handling
        private bool TrackedTaskExists(int id)
        {
            return context.TrackedTask.Count(t => t.Taskid == id) > 0;
        }
    }
}
