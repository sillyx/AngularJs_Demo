using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using BLL;

namespace AngularJs_Demo.Controllers
{
    public class EmController : ApiController
    {
        private IService _iService = new Service();
        public List<Employee> GetDataList()
        {
            var model = _iService.FindList<Employee>();
            return model;
        }

        //public bool DelEntity(Employee e)
        //{
        //    return _iService.DelEntity(e);
        //}
        public bool UpadateEntity(Employee e)
        {
            return _iService.UpdateEntity(e);
        }
    }
}
