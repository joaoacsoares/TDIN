using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class OrdemController : ApiController
    {
        private OrdemRepository ordemRepository;

        public OrdemController()
        {
            this.ordemRepository = new OrdemRepository();
        }

        public List<Ordem> Get()
        {
            return ordemRepository.GetAllOrdem();
        }

        public HttpResponseMessage Post(Ordem od)
        {

            this.ordemRepository.SaveOrdem(od.clientId, od.companyId, od.email, od.type, od.quant);
            /*Ordem od = new Ordem();
            od.clientId = clientId;
            od.companyId = companyId;
            od.email = email;
            od.type = type;
            od.quant = quant;*/
            
            var response = Request.CreateResponse<Ordem>(System.Net.HttpStatusCode.Created, od);

            return response;
        }
    }
}
