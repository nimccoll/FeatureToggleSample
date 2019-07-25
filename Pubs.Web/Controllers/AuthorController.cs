//===============================================================================
// Microsoft Premier Support for Developers
// FeatureToggle Sample
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using Pubs.Data.Models;
using Pubs.Services;
using Pubs.Services.Contracts;
using Pubs.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Pubs.Web.Controllers
{
    public class AuthorController : Controller
    {
        private IPubsService _pubsService;

        public AuthorController()
        {
            _pubsService = new PubsService();
        }

        public AuthorController(IPubsService pubsService)
        {
            _pubsService = pubsService;
        }

        public ActionResult Index()
        {
            List<Author> model = _pubsService.ListAuthors();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ModelState.Clear();
            Author model = new Author();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Author model)
        {
            if (ModelState.IsValid)
            {
                _pubsService.CreateAuthor(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult List(int startRow = 1, int numberOfRows = 5)
        {
            int numberOfAuthors = 0;
            List<Author> model = _pubsService.ListAuthorsPaged(startRow, numberOfRows, "Name", "asc", out numberOfAuthors);
            if (startRow > 1)
            {
                ViewBag.PreviousClass = "previous";
                ViewBag.PreviousRow = startRow - numberOfRows;
            }
            else
            {
                ViewBag.PreviousClass = "previous disabled";
                ViewBag.PreviousRow = startRow;
            }
            if (startRow + numberOfRows > numberOfAuthors)
            {
                ViewBag.NextClass = "next disabled";
                ViewBag.NextRow = numberOfAuthors;
            }
            else
            {
                ViewBag.NextClass = "next";
                ViewBag.NextRow = startRow + numberOfRows;
            }
            ViewBag.TotalRows = numberOfAuthors;
            return View("Index", model);
        }

        public JsonResult ListByLastName(string lastName)
        {
            List<Author> authors = _pubsService.ListAuthorsByLastName(lastName);
            List<string> authorNames = new List<string>();
            foreach (Author author in authors)
            {
                authorNames.Add(string.Format("{0} ({1})", author.Name, author.AuthorID));
            }
            return Json(authorNames, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListByID(string authorID)
        {
            List<Author> authors = _pubsService.ListAuthorsByID(authorID);
            List<string> authorNames = new List<string>();
            foreach (Author author in authors)
            {
                authorNames.Add(string.Format("{0} ({1})", author.Name, author.AuthorID));
            }
            return Json(authorNames, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListByLastNamePaged(string lastName, int startRow, int numberOfRows)
        {
            int numberOfAuthors = 0;
            List<Author> authors = _pubsService.ListAuthorsByLastNamePaged(lastName, startRow, numberOfRows, out numberOfAuthors);
            if (startRow > 1)
            {
                ViewBag.PreviousClass = "previous";
                ViewBag.PreviousRow = startRow - numberOfRows;
            }
            else
            {
                ViewBag.PreviousClass = "previous disabled";
                ViewBag.PreviousRow = startRow;
            }
            if (startRow + numberOfRows > numberOfAuthors)
            {
                ViewBag.NextClass = "next disabled";
                ViewBag.NextRow = numberOfAuthors;
            }
            else
            {
                ViewBag.NextClass = "next";
                ViewBag.NextRow = startRow + numberOfRows;
            }
            ViewBag.TotalRows = numberOfAuthors;
            return PartialView("_AuthorList", authors);
        }

        public ActionResult ListByIDPaged(string authorID, int startRow, int numberOfRows)
        {
            int numberOfAuthors = 0;
            List<Author> authors = _pubsService.ListAuthorsByIDPaged(authorID, startRow, numberOfRows, out numberOfAuthors);
            if (startRow > 1)
            {
                ViewBag.PreviousClass = "previous";
                ViewBag.PreviousRow = startRow - numberOfRows;
            }
            else
            {
                ViewBag.PreviousClass = "previous disabled";
                ViewBag.PreviousRow = startRow;
            }
            if (startRow + numberOfRows > numberOfAuthors)
            {
                ViewBag.NextClass = "next disabled";
                ViewBag.NextRow = numberOfAuthors;
            }
            else
            {
                ViewBag.NextClass = "next";
                ViewBag.NextRow = startRow + numberOfRows;
            }
            ViewBag.TotalRows = numberOfAuthors;
            return PartialView("_AuthorList", authors);
        }

        public ActionResult Grid(int startRow = 1, int numberOfRows = 5)
        {
            string sortBy = "Name";
            string sortDirection = "asc";

            if (this.Request.QueryString["page"] != null)
            {
                int startPage = Convert.ToInt32(this.Request.QueryString["page"]);
                if (startPage > 1) startRow = startPage * numberOfRows;
            }

            if (this.Request.QueryString["sort"] != null)
            {
                sortBy = this.Request.QueryString["sort"];
            }

            if (this.Request.QueryString["sortdir"] != null)
            {
                sortDirection = this.Request.QueryString["sortdir"];
            }

            int numberOfAuthors = 0;
            List<Author> model = _pubsService.ListAuthorsPaged(startRow, numberOfRows, sortBy, sortDirection, out numberOfAuthors);
            if (startRow > 1)
            {
                ViewBag.PreviousClass = "previous";
                ViewBag.PreviousRow = startRow - numberOfRows;
            }
            else
            {
                ViewBag.PreviousClass = "previous disabled";
                ViewBag.PreviousRow = startRow;
            }
            if (startRow + numberOfRows > numberOfAuthors)
            {
                ViewBag.NextClass = "next disabled";
                ViewBag.NextRow = numberOfAuthors;
            }
            else
            {
                ViewBag.NextClass = "next";
                ViewBag.NextRow = startRow + numberOfRows;
            }
            ViewBag.TotalRows = numberOfAuthors;
            return View(model);
        }

        public ActionResult Table(string lastName = "", string authorID = "", int startRow = 1, int numberOfRows = 5)
        {
            List<Author> model = null;
            string sortBy = "Name";
            string sortDirection = "asc";

            if (this.Request.QueryString["sort"] != null)
            {
                sortBy = this.Request.QueryString["sort"];
            }

            if (this.Request.QueryString["sortdir"] != null)
            {
                sortDirection = this.Request.QueryString["sortdir"];
            }

            int numberOfAuthors = 0;
            if (string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(authorID))
            {
                model = _pubsService.ListAuthorsPaged(startRow, numberOfRows, sortBy, sortDirection, out numberOfAuthors);
            }
            else if (!string.IsNullOrEmpty(lastName))
            {
                model = _pubsService.ListAuthorsByLastNamePaged(lastName, startRow, numberOfRows, out numberOfAuthors);
            }
            else
            {
                model = _pubsService.ListAuthorsByIDPaged(authorID, startRow, numberOfRows, out numberOfAuthors);
            }

            if (startRow > 1)
            {
                ViewBag.PreviousClass = "previous";
                ViewBag.PreviousRow = startRow - numberOfRows;
            }
            else
            {
                ViewBag.PreviousClass = "previous disabled";
                ViewBag.PreviousRow = startRow;
            }
            if (startRow + numberOfRows > numberOfAuthors)
            {
                ViewBag.NextClass = "next disabled";
                ViewBag.NextRow = numberOfAuthors;
            }
            else
            {
                ViewBag.NextClass = "next";
                ViewBag.NextRow = startRow + numberOfRows;
            }
            ViewBag.TotalRows = numberOfAuthors;
            ViewBag.LastName = lastName;
            ViewBag.AuthorID = authorID;
            return View(model);
        }

        [HttpGet]
        public ActionResult AuthorFilter()
        {
            AuthorFilterViewModel model = new AuthorFilterViewModel();
            model.Publishers = _pubsService.ListPublishers();
            model.Authors = new List<Author>();

            return View(model);
        }

        [HttpPost]
        [ActionName("AuthorFilter")]
        public ActionResult AuthorFilterPost()
        {
            AuthorFilterViewModel model = new AuthorFilterViewModel();
            model.Publishers = _pubsService.ListPublishers();
            model.Authors = new List<Author>();

            string titleIDList = Request.Form["ddlTitles"];
            if (!string.IsNullOrEmpty(titleIDList))
            {
                string[] titleIDs = titleIDList.Split(new char[] { ',' });
                foreach (string titleID in titleIDs)
                {
                    Title title = _pubsService.GetTitle(titleID);
                    foreach (Author author in title.Authors)
                    {
                        if (model.Authors.FirstOrDefault(a => a.AuthorID == author.AuthorID) == null)
                        {
                            model.Authors.Add(author);
                        }
                    }
                }
            }

            return View(model);
        }
    }
}