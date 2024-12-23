using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HealthCareCrud.Models
{
    public class PatientHistory
    {
        public int ID { get; set; }
        public string IssueDetails { get; set; }

        //[Column("Patient_ID")]
        //public int PatientID { get; set; }
        public Patient Patient { get; set; }
    }
}