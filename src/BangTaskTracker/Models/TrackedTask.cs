using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BangTaskTracker.Models
{
    public class TrackedTask
    {
        [Key]
        [Required]
        public int Taskid { get; set; }

        [Required]
        public string TaskName { get; set; }

        public string Description { get; set; }

        public enum OrderStatus { ToDo, InProgress, Complete }

        [Required]
        public OrderStatus TaskOrderStatus { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CompletedOn { get; set; }
    }
}
