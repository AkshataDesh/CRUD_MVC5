using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCareCrud.Models
{
    public class Patient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Gender { get; set; }
        public DateTime DateTime { get; set; }= DateTime.Now;   

    }
}