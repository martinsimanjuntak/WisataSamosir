using API.Model;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WisataSamosir.Base.Urls;

namespace WisataSamosir.Repository.Data
{
    public class ScheduleRepository : GeneralRepository<Schedule, int>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
        public ScheduleRepository(Address address, IHttpContextAccessor context, string request = "Schedules/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = context;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
        public async Task<List<ScheduleViewVM>> GetSchedule(int id)
        {
            List<ScheduleViewVM> entities = new List<ScheduleViewVM>();

            using (var response = await httpClient.GetAsync(request + "GetSchedule/"+ id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<ScheduleViewVM>>(apiResponse);
            }
            return entities;
        }
    }
}
