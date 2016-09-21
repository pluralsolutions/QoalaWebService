﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using QoalaWS.DAO;
using QoalaWS.Filters;

namespace QoalaWS.Controllers
{
    public class CommentsController : ApiController
    {
        private QoalaEntities db = new QoalaEntities();

        
        [HttpGet]
        [Route("comments/{id}")]
        public IHttpActionResult Get(decimal id)
        {
            Comment comment = Comment.findById(db, id);
            if (comment == null)
                return NotFound();

            return Ok(new {
                content = comment.CONTENT,
                approved_at = comment.APPROVED_AT,
                id_post = comment.ID_POST,
                id_user = comment.ID_USER
            });
        }

        
        [HttpPut]
        [BasicAuthorization]
        [Route("comments/{id}")]
        public IHttpActionResult Put(decimal id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Comment c = DAO.Comment.findById(db, id);

            if (c == null)
                return NotFound();

            comment.ID_COMMENT = id;

            if (comment.CONTENT == null)
                comment.CONTENT = c.CONTENT;
            if (comment.ID_POST.GetType() == null)
                comment.ID_POST = c.ID_POST;
            if (comment.ID_USER.GetType() == null)
                comment.ID_USER = c.ID_USER;
            if (comment.APPROVED_AT == null)
                comment.APPROVED_AT = c.APPROVED_AT;

            comment.Update(db);
            return StatusCode(HttpStatusCode.NoContent);
        }
        
        [HttpPost]
        [BasicAuthorization]
        [Route("comments/")]
        public IHttpActionResult Post(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            comment.Add(db);
            return Created("", new {
                content = comment.CONTENT,
                approved_at = comment.APPROVED_AT,
                id_post = comment.ID_POST,
                id_user = comment.ID_USER
            });
        }

        [HttpDelete]
        [BasicAuthorization]
        [Route("comments/{id}")]
        public IHttpActionResult Delete(decimal id)
        {
            Comment comment = DAO.Comment.findById(db, id);
            if (comment == null)
                return NotFound();

            comment.Delete(db);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [BasicAuthorization]
        [Route("comments/{id}/approve")]
        public IHttpActionResult Approve(decimal id)
        {
            Comment comment = DAO.Comment.findById(db, id);
            if (comment == null)
                return NotFound();

            comment.Approve(db);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}