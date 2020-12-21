using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFarm.Data
{
    public class Tomato
    {
        [Key]
        public int Id { get; set; }
        public int Duration { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public string Notes { get; set; }

        public User User { get; set; }
    }
}
