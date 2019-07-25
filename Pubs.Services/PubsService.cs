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
using Pubs.Data.Contracts;
using Pubs.Data.DAL;
using Pubs.Data.Models;
using Pubs.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Pubs.Services
{
    public class PubsService : IPubsService
    {
        private IPubsData _pubsDAO;

        public PubsService()
        {
            _pubsDAO = new PubsDAO();
            //_pubsDAO = new PubsDAOADO();
        }

        public PubsService(IPubsData pubsDAO)
        {
            _pubsDAO = pubsDAO;
        }

        public List<Author> ListAuthors()
        {
            List<Author> authors = _pubsDAO.ListAuthors();
            foreach (Author author in authors)
            {
                author.YearToDateSales = CalculateYearToDateSales(author.Titles);
            }

            return authors;
        }

        public List<Author> ListAuthorsByLastName(string lastName)
        {
            List<Author> authors = _pubsDAO.ListAuthorsByLastName(lastName);
            foreach (Author author in authors)
            {
                author.YearToDateSales = CalculateYearToDateSales(author.Titles);
            }

            return authors;
        }

        public List<Author> ListAuthorsByID(string authorID)
        {
            List<Author> authors = _pubsDAO.ListAuthorsByID(authorID);
            foreach (Author author in authors)
            {
                author.YearToDateSales = CalculateYearToDateSales(author.Titles);
            }

            return authors;
        }

        public Author GetAuthor(string authorID)
        {
            Author author = _pubsDAO.GetAuthor(authorID);
            author.YearToDateSales = CalculateYearToDateSales(author.Titles);

            return author;
        }

        public void CreateAuthor(Author author)
        {
            _pubsDAO.CreateAuthor(author);
        }

        public void UpdateAuthor(Author author)
        {
            _pubsDAO.UpdateAuthor(author);
        }

        public void DeleteAuthor(string authorID)
        {
            _pubsDAO.DeleteAuthor(authorID);
        }

        public List<Publisher> ListPublishers()
        {
            List<Publisher> publishers = _pubsDAO.ListPublishers();
            foreach (Publisher publisher in publishers)
            {
                publisher.YearToDateSales = CalculateYearToDateSales(publisher.Titles);
            }

            return publishers;
        }

        public Publisher GetPublisher(string publisherID)
        {
            Publisher publisher = _pubsDAO.GetPublisher(publisherID);
            publisher.YearToDateSales = CalculateYearToDateSales(publisher.Titles);

            return publisher;
        }

        public void CreatePublisher(Publisher publisher)
        {
            _pubsDAO.CreatePublisher(publisher);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            _pubsDAO.UpdatePublisher(publisher);
        }

        public void UpdatePublishers(List<Publisher> publishers)
        {
            _pubsDAO.UpdatePublishers(publishers);
        }

        public void DeletePublisher(string publisherID)
        {
            _pubsDAO.DeletePublisher(publisherID);
        }

        public List<Title> ListTitles()
        {
            return _pubsDAO.ListTitles();
        }

        public Title GetTitle(string titleID)
        {
            return _pubsDAO.GetTitle(titleID);
        }

        public void CreateTitle(Title title)
        {
            _pubsDAO.CreateTitle(title);
        }

        public void UpdateTitle(Title title)
        {
            _pubsDAO.UpdateTitle(title);
        }

        public void DeleteTitle(string titleID)
        {
            _pubsDAO.DeleteTitle(titleID);
        }

        private int CalculateYearToDateSales(ICollection<Title> titles)
        {
            int yearToDateSales = 0;

            if (titles != null)
            {
                yearToDateSales = titles.Sum(t => t.YearToDateSales);
            }

            return yearToDateSales;                
        }


        public List<Author> ListAuthorsPaged(int startRow, int numberOfRows, string sortBy, string sortDirection, out int numberOfAuthors)
        {
            List<Author> authors = _pubsDAO.ListAuthors(startRow, numberOfRows, sortBy, sortDirection, out numberOfAuthors);
            foreach (Author author in authors)
            {
                author.YearToDateSales = CalculateYearToDateSales(author.Titles);
            }

            return authors;
        }

        public List<Author> ListAuthorsByLastNamePaged(string lastName, int startRow, int numberOfRows, out int numberOfAuthors)
        {
            List<Author> authors = _pubsDAO.ListAuthorsByLastName(lastName, startRow, numberOfRows, out numberOfAuthors);
            foreach (Author author in authors)
            {
                author.YearToDateSales = CalculateYearToDateSales(author.Titles);
            }

            return authors;
        }

        public List<Author> ListAuthorsByIDPaged(string authorID, int startRow, int numberOfRows, out int numberOfAuthors)
        {
            List<Author> authors = _pubsDAO.ListAuthorsByID(authorID, startRow, numberOfRows, out numberOfAuthors);
            foreach (Author author in authors)
            {
                author.YearToDateSales = CalculateYearToDateSales(author.Titles);
            }

            return authors;
        }

        public List<Publisher> ListPublishersPaged(int startRow, int numberOfRows, out int numberOfPublishers)
        {
            List<Publisher> publishers = _pubsDAO.ListPublishers(startRow, numberOfRows, out numberOfPublishers);
            foreach (Publisher publisher in publishers)
            {
                publisher.YearToDateSales = CalculateYearToDateSales(publisher.Titles);
            }

            return publishers;
        }

        public List<Title> ListTitlesPaged(int startRow, int numberOfRows, out int numberOfTitles)
        {
            return _pubsDAO.ListTitles(startRow, numberOfRows, out numberOfTitles);
        }
    }
}
