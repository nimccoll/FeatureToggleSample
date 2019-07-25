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

namespace Pubs.Data.Contracts
{
    [ServiceContract]
    public interface IPubsData
    {
        [OperationContract]
        void CreateAuthor(Author author);

        [OperationContract]
        void UpdateAuthor(Author author);

        [OperationContract]
        void DeleteAuthor(string authorID);

        [OperationContract]
        Author GetAuthor(string authorID);

        [OperationContract]
        List<Author> ListAuthors();

        [OperationContract]
        List<Author> ListAuthors(int startRow, int numberOfRows, string sortBy, string sortDirection, out int numberOfAuthors);

        [OperationContract]
        List<Author> ListAuthorsByLastName(string lastName);

        [OperationContract]
        List<Author> ListAuthorsByLastName(string lastName, int startRow, int numberOfRows, out int numberOfAuthors);

        [OperationContract]
        List<Author> ListAuthorsByID(string authorID);

        [OperationContract]
        List<Author> ListAuthorsByID(string authorID, int startRow, int numberOfRows, out int numberOfAuthors);

        [OperationContract]
        void CreatePublisher(Publisher publisher);

        [OperationContract]
        void UpdatePublisher(Publisher publisher);

        [OperationContract]
        void UpdatePublishers(List<Publisher> publishers);

        [OperationContract]
        void DeletePublisher(string publisherID);

        [OperationContract]
        Publisher GetPublisher(string publisherID);

        [OperationContract]
        List<Publisher> ListPublishers();

        [OperationContract]
        List<Publisher> ListPublishers(int startRow, int numberOfRows, out int numberOfPublishers);

        [OperationContract]
        void CreateTitle(Title title);

        [OperationContract]
        void UpdateTitle(Title title);

        [OperationContract]
        void DeleteTitle(string titleID);

        [OperationContract]
        Title GetTitle(string titleID);

        [OperationContract]
        List<Title> ListTitles();

        [OperationContract]
        List<Title> ListTitles(int startRow, int numberOfRows, out int numberOfTitles);
    }
}
