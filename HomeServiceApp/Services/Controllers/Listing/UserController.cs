﻿using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Configuration;
using System.Net.Http;
using HSM.Entity;
using HSM.DAL;
using HSM.Interface;
using HSM.Common;
using HSM.BL;


namespace HSM.Services
{
    public class UserController : ApiController
    {

        /// <summary>
        /// Controller for Getting User Listing
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IHttpActionResult GetAllUser()
        {
            string response=null;
            var QueryString = Request.RequestUri.ParseQueryString();
            int roleId = (QueryString["roleid"] != null && !String.IsNullOrEmpty(QueryString["roleid"].ToString())) ? Convert.ToInt32(QueryString["roleid"]) : -1;
            IUnityContainer container = new UnityContainer();
            UserBL userBl = new UserBL(container);
            try
            {

                response = JsonConvert.SerializeObject(userBl.GetAllUser(roleId));

            }
            catch (Exception ex)
            {
                var objErr = new ErrorClass(ex, "OfferController.GetAllListings()");
                objErr.LogException();
            }
            return Ok(response);

        }

        //public IHttpActionResult GetUserById()
        //{
        //    string response = null;
        //    var QueryString = Request.RequestUri.ParseQueryString();
        //    int userId = (QueryString["userid"] != null && !String.IsNullOrEmpty(QueryString["userid"].ToString())) ? Convert.ToInt32(QueryString["userid"]) : -1;
        //    IUnityContainer container = new UnityContainer();
        //    UserBL userBl = new UserBL(container);
        //    try
        //    {

        //        response = JsonConvert.SerializeObject(userBl.GetUserById(userId));

        //    }
        //    catch (Exception ex)
        //    {
        //        var objErr = new ErrorClass(ex, "OfferController.GetAllListings()");
        //        objErr.LogException();
        //    }
        //    return Ok(response);

        //}
    }
}
