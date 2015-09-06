using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMvcApp.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        [DisplayName("Process ID")]
        public int ProcessId { get; set; }
        [DisplayName("Total Time Taken")]
        public int TimeElapsed { get; set; }
        [DisplayName("Time in Module")]
        public int TimeInModule { get; set; }
        [DisplayName("Time in State")]
        public int TimeInState { get; set; }
        [DisplayName("Request URL")]
        public string RequestId { get; set; }
       
        [DisplayName("Time Stamp")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CurrentDate { get; set; }
      
    }
}