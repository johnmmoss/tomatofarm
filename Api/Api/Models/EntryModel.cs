using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomatofarm.co.uk.Models
{
    public class EntryModel
    {
        public DateTime Date { get; set; }

        public int Period { get; set; }
        public int ID { get; internal set; }
    }
}
