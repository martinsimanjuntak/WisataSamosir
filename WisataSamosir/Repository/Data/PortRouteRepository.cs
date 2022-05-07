using API.Model;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WisataSamosir.Base.Urls;

namespace WisataSamosir.Repository.Data
{
    public class PortRouteRepository : GeneralRepository<PortRoute, int>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
        public PortRouteRepository(Address address, IHttpContextAccessor context, string request = "portRoutes/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = context;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
        public HttpStatusCode AddPortRoute(PortRouteVM portRouteVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(portRouteVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(request + "AddPortRoute/", content).Result;
            return result.StatusCode;

        }
    }
}
