using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using testServiceModel.model;

namespace testServiceModel
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        [WebGet]
        string EchoWithGet(string s);

        [OperationContract]
        List<Route> GetRoutes();

        [OperationContract]
        List<Route> ShowRouteByPoint(string startPoint, string endPoint);

        [OperationContract]
        void BuyTicket(int id);

        [OperationContract]
        List<Order> GetOrders();
    }

    public class MyService : IMyService
    {
        public MyService()
        {
            Console.WriteLine("Был вызван пустой MyService");
        }

        public string EchoWithGet(string s)
        {
            return "You said " + s;
        }

        public List<Route> GetRoutes()
        {
            return RouteDao.Instance.GetRoutes();
        }

        public List<Route> ShowRouteByPoint(string startPoint, string endPoint)
        {
            List<Route> routes = new List<Route>();

            foreach (Route route in RouteDao.Instance.GetRoutes())
            {
                if (route.StartPoint.Equals(startPoint) && route.EndPoint.Equals(endPoint))
                    routes.Add(route);
            }

            return routes;
        }

        public void BuyTicket(int id)
        {
            RouteDao.Instance.BuyTicket(id);
            OrderDao.Instance.AddOrder(new Order(RouteDao.Instance.GetCurrentRoute(id)));
        }

        public List<Order> GetOrders()
        {
            return OrderDao.Instance.GetOrders();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(MyService), new Uri("http://localhost:1337/"));
            host.AddServiceEndpoint(typeof(IMyService), new BasicHttpBinding(), "");

            RouteDao routerDao = new RouteDao();
            OrderDao orderDao = new OrderDao();

            host.Open();
            Console.WriteLine("Сервер запущен");
            Console.ReadLine();
            host.Close();

        }
    }
}
