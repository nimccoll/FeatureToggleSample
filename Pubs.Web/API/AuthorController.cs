using Pubs.Data.Models;
using Pubs.Services.Contracts;
using Pubs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pubs.Web.API
{
    public class AuthorController : ApiController
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

        // GET api/<controller>
        public List<Author> Get()
        {
            return _pubsService.ListAuthors();
        }

        // GET api/<controller>/5
        public Author Get(string id)
        {
            return _pubsService.GetAuthor(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}