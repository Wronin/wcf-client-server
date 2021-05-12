using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testServiceModel.model
{
    public class Route {
        private string startPoint;
        private string endPoint;
        private int countOfTickets;
        private DateTime dateStart;
        private DateTime dateEnd;

        public Route()
        {

        }

        public Route(string startPoint, string endPoint, int countOfTickets, DateTime dateStart, DateTime dateEnd)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.countOfTickets = countOfTickets;
            this.dateStart = dateStart;
            this.dateEnd = dateEnd;
        }

        public string StartPoint
        {
            get
            {
                return startPoint;
            } 
            set
            {
                startPoint = value;
            }
        } 

        public string EndPoint
        {
            get
            {
                return endPoint;
            } 
            set
            {
                endPoint = value;
            }
        }

        public int CountOfTickets
        {
            get
            {
                return countOfTickets;
            }
            set
            {
                countOfTickets = value;
            }
        }

        public DateTime DateStart
        {
            get
            {
                return dateStart;
            }
            set
            {
                dateStart = value;
            }
        }
        public DateTime DateEnd
        {
            get
            {
                return dateEnd;
            }
            set
            {
                dateEnd = value;
            }
        }

    }
}
