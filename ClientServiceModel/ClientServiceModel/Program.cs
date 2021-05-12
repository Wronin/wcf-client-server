using System;
using System.Collections.Generic;
using System.ServiceModel;
using testServiceModel.model;

namespace ClientServiceModel
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
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
    class Program
    {
        static void Main(string[] args)
        {
            Uri tcpUri = new Uri("http://localhost:1337/");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IMyService> factory = new ChannelFactory<IMyService>(binding, address);
            IMyService service = factory.CreateChannel();

            int usetInput = 10000;
            string s = "hello world";
            string startPoint, endPoint;

            Console.WriteLine(service.EchoWithGet(s));

            while (usetInput != 0)
            {
                
                Console.WriteLine("1. Вывести на экран все рейсы \n2. Найти нужный рейс по пунктам назначения \n3. Заказать билет \n");
                
                try {

                    usetInput = Convert.ToInt32(Console.ReadLine());

                    if (usetInput.Equals(1) || usetInput.Equals(2) || usetInput.Equals(3))
                        switch (usetInput)
                        {
                            case 1:
                                {
                                    foreach (Route route in service.GetRoutes())
                                        Console.WriteLine(route.ToString());
                                }
                                break;

                            case 2:
                                {
                                    Console.Write("Введите начальный пункт рейса ");
                                    startPoint = Console.ReadLine();
                                    Console.Write("Введите конечный пункт рейса ");
                                    endPoint = Console.ReadLine();

                                    foreach (Route route in service.ShowRouteByPoint(startPoint, endPoint))
                                        Console.WriteLine(route.ToString());

                                }
                                break;
                            case 3:
                                {
                                    int i = 0, id = 0;
                                    foreach (Route route in service.GetRoutes())
                                    {
                                        Console.WriteLine();
                                        Console.Write(i++ + ". ");
                                        Console.WriteLine(route.ToString());
                                    }
                                    id = Convert.ToInt32(Console.ReadLine());
                                    service.BuyTicket(id);

                                }
                                break;
                        }

                } catch(Exception ex)
                {
                    Console.WriteLine("Введено не число");
                }
                

                
            }
            Console.ReadLine();
        }
    }
}
