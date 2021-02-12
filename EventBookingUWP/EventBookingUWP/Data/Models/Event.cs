using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace EventBookingUWP.Data.Models
{
    public class Event
    {
        [JsonIgnore] // IGNORE ID WHEN SERIALIZING JSON ( ID not needed for post json data )
        public int ID { get; set; }

        [JsonProperty("ID")] // JsonIgnore will cuase the ID to be 0 when retrieving data. ID_Setter tricks the deserializer into getting the ID back
        private int ID_Setter
        {
            // get is intentionally omitted here
            set { ID = value; }
        }

        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }

    }
}
