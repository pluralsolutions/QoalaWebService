﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QoalaWS.DAO;

namespace QoalaWS.Controllers
{
    public class AccountsController : ApiController
    {
        [HttpGet]
        [HttpPost]
        public IHttpActionResult Index()
        {
            this.Logger().Debug("Index");
            return Ok("OK");
        }

        [HttpPost]
        public IHttpActionResult Register(USER user)
        {
            //TODO: Fazer um model para usar somente no login(nome, somente email, senha), sem os demais atributos no model USER.
            using (QoalaEntities qe = new QoalaEntities())
            {
                ACCESSCONTROL ca = user.register(qe);
                
                if (ca == null)
                    return BadRequest();
                else
                    return Ok(ca);
            }
        }

        [HttpPost]
        public IHttpActionResult ResetPassword([FromBody] string email)
        {
            using (QoalaEntities qe = new QoalaEntities())
            {
                USER user = USER.findByEmail(qe, email);
                if (user.resetPassword())
                    return Ok();
                else
                    return BadRequest();
            }
        }

        [HttpPost]
        public IHttpActionResult Login(USER user)
        {
            this.Logger().DebugFormat("Login: {0}", user.ToString());
            using (QoalaEntities qe = new QoalaEntities())
            {
                this.Logger().DebugFormat("Login {0} initiate", user.EMAIL);
                ACCESSCONTROL ca = USER.doLogin(qe, user.EMAIL, user.PASSWORD);
                this.Logger().DebugFormat("Login {0} result: {1}", user.EMAIL, ca);
                if (ca == null)
                    return NotFound();
                else
                    return Ok(ca);
            }
        }

        [HttpPost]
        public IHttpActionResult Logout([FromBody] string token)
        {
            using (QoalaEntities qe = new QoalaEntities())
            {
                if (USER.doLogout(qe, token))
                    return Ok();
                else
                    return BadRequest();
            }
        }
    }
}
