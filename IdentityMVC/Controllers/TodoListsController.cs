using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentityMVC.Models;

namespace IdentityMVC.Controllers
{ 
    [Authorize]
    public class TodoListsController : Controller
    {
        private ApplicationDbContext conn = new ApplicationDbContext();

        // GET: TodoLists
        public ActionResult Index()
        {
            List<TodoList> lists = new List<TodoList>();
            foreach (TodoList list in conn.todoLists.ToList())
            {
                if (list.UserId == Session["Id"].ToString())
                {
                    lists.Add(list);
                }
            }
            return View(lists.ToList());
            //return View(db.todoLists.ToList());
        }

        // GET: TodoLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoList todoList = conn.todoLists.Find(id);
            if (todoList == null)
            {
                return HttpNotFound();
            }
            return View(todoList);
        }

        // GET: TodoLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoLists/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,isCompleted,UserId")] TodoList todoList)
        {
            //if (ModelState.IsValid)
            //{
            //    db.todoLists.Add(todoList);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(todoList);
            try
            {
                // TODO: Add insert logic here
                todoList.UserId = Session["Id"].ToString();
                conn.todoLists.Add(todoList);
                conn.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(todoList);
            }
        }

        // GET: TodoLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoList todoList = conn.todoLists.Find(id);
            if (todoList == null)
            {
                return HttpNotFound();
            }
            return View(todoList);
        }

        // POST: TodoLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,isCompleted,UserId")] TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                conn.Entry(todoList).State = EntityState.Modified;
                conn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoList);
        }

        // GET: TodoLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoList todoList = conn.todoLists.Find(id);
            if (todoList == null)
            {
                return HttpNotFound();
            }
            return View(todoList);
        }

        // POST: TodoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TodoList todoList = conn.todoLists.Find(id);
            conn.todoLists.Remove(todoList);
            conn.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                conn.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
