using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testServiceModel.model;

namespace testServiceModel
{
        public class OrderDao {

        private static OrderDao INSTANCE;

        private static readonly object lockConst1 = new object();


        public static OrderDao Instance
        {
            get
            {
                lock (lockConst1)
                {
                    if (INSTANCE == null)
                        INSTANCE = new OrderDao();
                    return INSTANCE;
                }
            }
        }

        private List<Order> orders;

        public OrderDao()
        {
            orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public List<Order> GetOrders()
        {
            return new List<Order>(orders);
        }
    }
}
