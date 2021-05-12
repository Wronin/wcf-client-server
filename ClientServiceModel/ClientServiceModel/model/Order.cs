using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testServiceModel.model
{
    class Order {
        private Route route;

        public Order(Route route)
        {
            this.route = route;
        }
    }
}
