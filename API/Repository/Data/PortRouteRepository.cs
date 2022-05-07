using API.Context;
using API.Model;
using API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class PortRouteRepository : GeneralRepository<PortRoute, MyContext, int>
    {
        private readonly MyContext context;

        public PortRouteRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;

        }
        public int AddPortRoute(PortRouteVM portRouteVM)
        {
            PortRoute portRoute = new PortRoute();
            var harbor_start = context.Harbors.Where(x => x.Id == portRouteVM.Harbor_start).FirstOrDefault();
            var harbor_end = context.Harbors.Where(x => x.Id == portRouteVM.Harbor_end).FirstOrDefault();
            portRoute.RouteName = harbor_start.Harbor_Name + "-" + harbor_end.Harbor_Name;
            portRoute.Harbor_start = portRouteVM.Harbor_start;
            portRoute.Harbor_end = portRouteVM.Harbor_end;
            context.PortRoutes.Add(portRoute);
            return context.SaveChanges();

        }
        public async Task<List<RouteVM>> GetRoute()
        {
            List<RouteVM> data = await Task.Run(() => (from p in context.PortRoutes
                                                       join s in context.Schedules
                                                       on p.Id equals s.PortRoute_id
                                                       select new RouteVM
                                                       {
                                                           RouteName = p.RouteName,
                                                           Session = s.Session,
                                                           Time = s.Time
                                                       }
                        ).ToList());
            return data;
        }
       public async Task<RouteItemVM> GetRoute(string route_name)
        {
            RouteItemVM data = await Task.Run(() => (from p in context.PortRoutes
                                                       join h in context.Harbors
                                                       on p.Harbor_start equals h.Id
                                                       into porthar
                                                       from ed in porthar.DefaultIfEmpty()
                                                       where p.RouteName == route_name
                                                         select new RouteItemVM
                                                           {
                                                               RouteName = p.RouteName
                                                           }).FirstOrDefault());
            return data;        
        }
    }

}
