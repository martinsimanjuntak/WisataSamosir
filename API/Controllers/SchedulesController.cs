using API.Base;
using API.Model;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : BaseController<Schedule, ScheduleRepository, int>
    {
        private readonly ScheduleRepository scheduleRepository;
        public SchedulesController(ScheduleRepository repository) : base(repository)
        {
            this.scheduleRepository  = repository;
        }
        [HttpGet("GetSchedule/{id}")]
        public async Task<ActionResult<ScheduleVM>> GetAccount(int id)
        {
            var get = await scheduleRepository.GetSchedule(id);
            return Ok(get);
        }
        [HttpPost("AddSchedule")]
        public async Task<ActionResult<Schedule>> AddSchedule(ScheduleVM entity)
        {
            scheduleRepository.AddSchedule(entity);
            return Ok(entity);
        }
    }
}
