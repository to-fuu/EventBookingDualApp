using System;
using System.Collections.Generic;
using System.Text;

namespace eventBookDesktop.Data.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }

    }

}
