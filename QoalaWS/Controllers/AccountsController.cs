﻿using System;
using System.Net;
using System.Web.Http;
using QoalaWS.DAO;
using QoalaWS.Filters;

namespace QoalaWS.Controllers
{
    public class AccountsController : ApiController
    {
        private QoalaEntities db = new QoalaEntities();

        [HttpPost]
        [ValidateModel]
        public IHttpActionResult Register(User user)
        {
            try
            {
                user.Add(db);

                return Created("", 
                    new {
                        token = user.createAccessControl(db).TOKEN,
                        user = new
                        {
                            id_user = user.ID_USER,
                            email = user.EMAIL,
                            name = user.NAME
                        }
                    }
                );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ValidateModel]
        public IHttpActionResult Login(User user)
        {
            AccessControl ac = user.doLogin(db);
            if (ac == null)
                return BadRequest("Email ou senha inválido");

            return Created("", 
                new {
                    token = ac.TOKEN,
                    user = new
                    {
                        id_user = user.ID_USER,
                        email = user.EMAIL,
                        name = user.NAME
                    }
                }
            );
        }

        //needs to check if the token on the body is the same on the headers
        [HttpPost]
        [BasicAuthorization]
        [ValidateModel]
        public IHttpActionResult Logout(AccessControl control)
        {
            AccessControl ac = AccessControl.find(db, control.TOKEN);
            if (ac == null)
                return NotFound();

            ac.Delete(db);

            return StatusCode(HttpStatusCode.OK);
        }

        [BasicAuthorization]
        [HttpPost]
        public IHttpActionResult ValidadeToken(AccessControl control)
        {
            var ac=DAO.AccessControl.find(db, control.TOKEN);
            if (ac == null)
                return StatusCode(HttpStatusCode.Gone);//410
            else
                return StatusCode(HttpStatusCode.Accepted);//202
        }
    }
}
