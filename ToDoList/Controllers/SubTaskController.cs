using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ToDoList.DB;

namespace ToDoList.Controllers
{
    public class SubTaskController : ApiController
    {
        private ToDoDB db = new ToDoDB();

        // GET api/SubTask
        public IEnumerable<SubTask> GetSubTasks()
        {
            return db.SubTasks.AsEnumerable();
        }

        // GET api/SubTask/5
        public SubTask GetSubTask(int id)
        {
            SubTask subtask = db.SubTasks.Find(id);
            if (subtask == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return subtask;
        }

        // PUT api/SubTask/5
        public HttpResponseMessage PutSubTask(int id, SubTask subtask)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != subtask.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(subtask).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/SubTask
        public HttpResponseMessage PostSubTask(SubTask subtask)
        {
            if (ModelState.IsValid)
            {
                db.SubTasks.Add(subtask);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, subtask);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = subtask.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/SubTask/5
        public HttpResponseMessage DeleteSubTask(int id)
        {
            SubTask subtask = db.SubTasks.Find(id);
            if (subtask == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.SubTasks.Remove(subtask);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, subtask);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}