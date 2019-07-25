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
using Pubs.Data.Context;
using Pubs.Data.Contracts;
using Pubs.Data.Models;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace Pubs.Data.DAL
{
    /// <summary>
    /// Entity Framework implementation of the <see cref="Pubs.Data.Contracts.IPubsData"/> contract
    /// </summary>
    public class PubsDAO : IPubsData
    {
        private PubsContext _context;

        /// <summary>
        /// Constructor - create Entity Framework DbContext
        /// </summary>
        public PubsDAO()
        {
            _context = new PubsContext();
        }

        /// <summary>
        /// Create an author
        /// </summary>
        /// <param name="author"><see cref="Pubs.Data.Models.Author"/></param>
        public void CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update an author
        /// </summary>
        /// <param name="author"><see cref="Pubs.Data.Models.Author"/></param>
        public void UpdateAuthor(Author author)
        {
            _context.Entry(author).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete an author
        /// </summary>
        /// <param name="authorID">Unique author identifier</param>
        public void DeleteAuthor(string authorID)
        {
            Author author = _context.Authors.Find(authorID);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }

        public Author GetAuthor(string authorID)
        {
            Author author = _context.Authors.Find(authorID);
            if (author != null)
            {
                ((IObjectContextAdapter)_context).ObjectContext.LoadProperty(author, a => a.Titles);
            }
            return author;
        }

        public Author GetAuthorByStoredProcedure(string authorID)
        {
            Author author = null;
            DbCommand command = _context.Database.Connection.CreateCommand();
            command.CommandText = "[dbo].[SP_GetAuthorAndTitlesEF]";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter() { ParameterName = "@authorID", Value = authorID });
            try
            {
                // Run the sproc
                _context.Database.Connection.Open();
                DbDataReader reader = command.ExecuteReader();

                // Read Blogs from the first result set
                ObjectResult<Author> authors = ((IObjectContextAdapter)_context)
                    .ObjectContext
                    .Translate<Author>(reader, "Authors", MergeOption.AppendOnly);

                foreach (Author item in authors)
                {
                    author = item;
                }

                if (author != null)
                {
                    author.Titles = new List<Title>();
                    // Move to second result set and read Posts
                    reader.NextResult();
                    ObjectResult<Title> titles = ((IObjectContextAdapter)_context)
                        .ObjectContext
                        .Translate<Title>(reader, "Titles", MergeOption.AppendOnly);

                    foreach (Title item in titles)
                    {
                        author.Titles.Add(item);
                    }
                }
            }
            finally
            {
                _context.Database.Connection.Close();
            }

            return author;
        }

        public List<Author> ListAuthors()
        {
            return _context.Authors.Include("Titles").Include("Titles.Publisher").ToList();
        }

        public List<Author> ListAuthors(int startRow, int numberOfRows, string sortBy, string sortDirection, out int numberOfAuthors)
        {
            numberOfAuthors = _context.Authors.Count();
            List<Author> authors = null;

            if (sortDirection.ToLower() == "asc")
            {
                switch (sortBy)
                {
                    case "AuthorID":
                        authors = _context.Authors.Include("Titles").Include("Titles.Publisher").OrderBy(a => new { a.AuthorID }).Skip(startRow - 1).Take(numberOfRows).ToList();
                        break;
                    case "Name":
                        authors = _context.Authors.Include("Titles").Include("Titles.Publisher").OrderBy(a => new { a.LastName, a.FirstName }).Skip(startRow - 1).Take(numberOfRows).ToList();
                        break;
                    case "City":
                        authors = _context.Authors.Include("Titles").Include("Titles.Publisher").OrderBy(a => new { a.City }).Skip(startRow - 1).Take(numberOfRows).ToList();
                        break;
                    case "State":
                        authors = _context.Authors.Include("Titles").Include("Titles.Publisher").OrderBy(a => new { a.State }).Skip(startRow - 1).Take(numberOfRows).ToList();
                        break;
                    case "HasContract":
                        authors = _context.Authors.Include("Titles").Include("Titles.Publisher").OrderBy(a => new { a.HasContract }).Skip(startRow - 1).Take(numberOfRows).ToList();
                        break;
                    default:
                        authors = _context.Authors.Include("Titles").Include("Titles.Publisher").OrderBy(a => new { a.LastName, a.FirstName }).Skip(startRow - 1).Take(numberOfRows).ToList();
                        break;
                }
            }
            else
            {
                switch (sortBy)
                {
                    case "AuthorID":
                        authors = _context.Authors.Include("Titles").Include("Titles.Publisher").OrderByDescending(a => new { a.AuthorID }).Skip(startRow - 1).Take(numberOfRows).ToList();
                        break;
                    case "Name":
                        authors = _context.Authors.Include("Titles").Include("Titles.Publisher").OrderByDescending(a => new { a.LastName, a.FirstName }).Skip(startRow - 1).Take(numberOfRows).ToList();
                        break;
                    case "City":
                        authors = _context.Authors.Include("Titles").Include("Titles.Publisher").OrderByDescending(a => new { a.City }).Skip(startRow - 1).Take(numberOfRows).ToList();
                        break;
                    case "State":
                        authors = _context.Authors.Include("Titles").Include("Titles.Publisher").OrderByDescending(a => new { a.State }).Skip(startRow - 1).Take(numberOfRows).ToList();
                        break;
                    case "HasContract":
                        authors = _context.Authors.Include("Titles").Include("Titles.Publisher").OrderByDescending(a => new { a.HasContract }).Skip(startRow - 1).Take(numberOfRows).ToList();
                        break;
                    default:
                        authors = _context.Authors.Include("Titles").Include("Titles.Publisher").OrderByDescending(a => new { a.LastName, a.FirstName }).Skip(startRow - 1).Take(numberOfRows).ToList();
                        break;
                }
            }

            return authors;
        }

        public List<Author> ListAuthorsByLastName(string lastName)
        {
            List<Author> authors = (from a in _context.Authors
                                    where a.LastName.StartsWith(lastName)
                                    select a).ToList();

            return authors;
        }

        public List<Author> ListAuthorsByLastName(string lastName, int startRow, int numberOfRows, out int numberOfAuthors)
        {
            numberOfAuthors = _context.Authors.Where(a => a.LastName.StartsWith(lastName)).Count();
            List<Author> authors = (from a in _context.Authors
                                    where a.LastName.StartsWith(lastName)
                                    select a).OrderBy(a => new { a.LastName, a.FirstName }).Skip(startRow - 1).Take(numberOfRows).ToList();

            return authors;
        }

        public List<Author> ListAuthorsByID(string authorID)
        {
            List<Author> authors = (from a in _context.Authors
                                    where a.AuthorID.StartsWith(authorID)
                                    select a).ToList();

            return authors;
        }

        public List<Author> ListAuthorsByID(string authorID, int startRow, int numberOfRows, out int numberOfAuthors)
        {
            numberOfAuthors = _context.Authors.Where(a => a.AuthorID.StartsWith(authorID)).Count();
            List<Author> authors = (from a in _context.Authors
                                    where a.AuthorID.StartsWith(authorID)
                                    select a).OrderBy(a => new { a.LastName, a.FirstName }).Skip(startRow - 1).Take(numberOfRows).ToList();

            return authors;
        }

        /// <summary>
        /// Create a new publisher
        /// </summary>
        /// <param name="publisher"><see cref="Pubs.Data.Models.Publisher"/></param>
        public void CreatePublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public void UpdatePublisher(Publisher publisher)
        {
            _context.Entry(publisher).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
        
        public void UpdatePublishers(List<Publisher> publishers)
        {
            foreach (Publisher p in publishers)
            {
                Publisher publisher = _context.Publishers.Find(p.PublisherID);
                publisher.Name = p.Name;
                publisher.City = p.City;
                publisher.State = p.State;
                publisher.Country = p.Country;
                //_context.Entry(publisher).State = System.Data.Entity.EntityState.Modified;
                //_context.Publishers.Attach(p);
            }
            _context.SaveChanges();
        }

        public void DeletePublisher(string publisherID)
        {
            Publisher publisher = _context.Publishers.Find(publisherID);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }

        public Publisher GetPublisher(string publisherID)
        {
            Publisher publisher = _context.Publishers.Find(publisherID);
            if (publisher != null)
            {
                ((IObjectContextAdapter)_context).ObjectContext.LoadProperty(publisher, p => p.Titles);
            }
            return publisher;
        }

        public List<Publisher> ListPublishers()
        {
            return _context.Publishers.Include("Titles").ToList();
        }

        public List<Publisher> ListPublishers(int startRow, int numberOfRows, out int numberOfPublishers)
        {
            numberOfPublishers = _context.Publishers.Count();
            return _context.Publishers.Include("Titles").Skip(startRow - 1).Take(numberOfRows).ToList();
        }

        public void CreateTitle(Title title)
        {
            _context.Titles.Add(title);
            _context.SaveChanges();
        }

        public void UpdateTitle(Title title)
        {
            Title currentTitle = _context.Titles.Find(title.TitleID);
            if (currentTitle != null)
            {
                ((IObjectContextAdapter)_context).ObjectContext.LoadProperty(currentTitle, t => t.Authors);
                ((IObjectContextAdapter)_context).ObjectContext.ApplyCurrentValues<Title>("Titles", title);
            }
            List<Author> newAuthors = title.Authors.ToList<Author>();
            List<Author> currentAuthors = currentTitle.Authors.ToList<Author>();

            List<Author> addedAuthors = newAuthors.Except(currentAuthors).ToList<Author>();
            List<Author> deletedAuthors = currentAuthors.Except(newAuthors).ToList<Author>();

            addedAuthors.ForEach(aa => currentTitle.Authors.Add(aa));
            deletedAuthors.ForEach(da => currentTitle.Authors.Remove(da));

            _context.SaveChanges();
            //_context.Entry(title).State = System.Data.Entity.EntityState.Modified;
            //_context.SaveChanges();
        }

        public void DeleteTitle(string titleID)
        {
            Title title = _context.Titles.Find(titleID);
            if (title != null)
            {
                // Load the Authors property to ensure the relationship with the author(s) is removed as well
                ((IObjectContextAdapter)_context).ObjectContext.LoadProperty(title, t => t.Authors);
                _context.Titles.Remove(title);
                _context.SaveChanges();
            }
        }

        public Title GetTitle(string titleID)
        {
            Title title = _context.Titles.Find(titleID);
            if (title != null)
            {
                ((IObjectContextAdapter)_context).ObjectContext.LoadProperty(title, t => t.Authors);
                ((IObjectContextAdapter)_context).ObjectContext.LoadProperty(title, t => t.Publisher);

            }
            return _context.Titles.Find(titleID);
        }

        public List<Title> ListTitles()
        {
            return _context.Titles.Include("Authors").Include("Publisher").ToList();
        }

        public List<Title> ListTitles(int startRow, int numberOfRows, out int numberOfTitles)
        {
            numberOfTitles = _context.Titles.Count();
            return _context.Titles.Include("Authors").Include("Publisher").Skip(startRow - 1).Take(numberOfRows).ToList();
        }
    }
}
