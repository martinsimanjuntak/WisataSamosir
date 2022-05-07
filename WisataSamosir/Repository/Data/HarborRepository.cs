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
    public class HarborRepository : GeneralRepository<Harbor, int>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
        public HarborRepository(Address address, IHttpContextAccessor context, string request = "Harbors/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = context;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
       
    }
}
