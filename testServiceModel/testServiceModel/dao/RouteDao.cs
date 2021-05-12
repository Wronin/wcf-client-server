using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace testServiceModel.model
{
        public class RouteDao {

        private static RouteDao INSTANCE;

        private static readonly object lockConst = new object();


        public static RouteDao Instance
        {
            get
            {
                lock(lockConst)
                {
                    if (INSTANCE == null)
                        INSTANCE = new RouteDao();
                    return INSTANCE;
                }
            }
        }

        private List<Route> routes;

        public RouteDao()
        {
            routes = new List<Route>
            {
                new Route("Москва", "Самара", 20, new DateTime(2008, 5, 1, 8, 30, 52), new DateTime(2008, 5, 4, 8, 30, 52)),
                new Route("Москва", "Самара", 20, new DateTime(2008, 5, 5, 8, 30, 52), new DateTime(2008, 5, 7, 8, 30, 52)),
                new Route("Орел", "Донбас", 20, new DateTime(2008, 5, 9, 8, 30, 52), new DateTime(2008, 5, 14, 8, 30, 52)),
                new Route("Орел", "Донбас", 20, new DateTime(2008, 5, 16, 8, 30, 52), new DateTime(2008, 5, 19, 8, 30, 52)),
                new Route("Самара", "Орел", 20, new DateTime(2008, 5, 20, 8, 30, 52), new DateTime(2008, 5, 25, 8, 30, 52))
            };
        }

        public void AddRoute(Route route)
        {
            routes.Add(route);
        }

        public List<Route> GetRoutes()
        {
            return new List<Route>(routes);
        }

        public Route GetCurrentRoute(int id)
        {
            return routes[id];
        }

        public void BuyTicket(int id)
        {
            Console.WriteLine(routes[id].CountOfTickets);
            routes[id].CountOfTickets -= 1;
            Console.WriteLine(routes[id].CountOfTickets);
        }

    }
}
