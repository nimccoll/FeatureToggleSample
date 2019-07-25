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
using System.Collections.Generic;
using System.ServiceModel;

namespace Pubs.Services.Contracts
{
    [ServiceContract]
    public interface IPubsService
    {
        [OperationContract]
        List<Author> ListAuthors();

        [OperationContract]
        List<Author> ListAuthorsPaged(int startRow, int numberOfRows, string sortBy, string sortDirection, out int numberOfAuthors);

        [OperationContract]
        List<Author> ListAuthorsByLastName(string lastName);

        [OperationContract]
        List<Author> ListAuthorsByLastNamePaged(string lastName, int startRow, int numberOfRows, out int numberOfAuthors);

        [OperationContract]
        List<Author> ListAuthorsByID(string authorID);

        [OperationContract]
        List<Author> ListAuthorsByIDPaged(string authorID, int startRow, int numberOfRows, out int numberOfAuthors);

        [OperationContract]
        Author GetAuthor(string authorID);

        [OperationContract]
        void CreateAuthor(Author author);

        [OperationContract]
        void UpdateAuthor(Author author);

        [OperationContract]
        void DeleteAuthor(string authorID);

        [OperationContract]
        List<Publisher> ListPublishers();

        [OperationContract]
        List<Publisher> ListPublishersPaged(int startRow, int numberOfRows, out int numberOfPublishers);

        [OperationContract]
        Publisher GetPublisher(string publisherID);

        [OperationContract]
        void CreatePublisher(Publisher publisher);

        [OperationContract]
        void UpdatePublisher(Publisher publisher);

        [OperationContract]
        void UpdatePublishers(List<Publisher> publishers);

        [OperationContract]
        void DeletePublisher(string publisherID);

        [OperationContract]
        List<Title> ListTitles();

        [OperationContract]
        List<Title> ListTitlesPaged(int startRow, int numberOfRows, out int numberOfTitles);

        [OperationContract]
        Title GetTitle(string titleID);

        [OperationContract]
        void CreateTitle(Title title);

        [OperationContract]
        void UpdateTitle(Title title);

        [OperationContract]
        void DeleteTitle(string titleID);
    }
}
