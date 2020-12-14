using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomatofarm.co.uk.Models
{
    public class UserEntryModel
    {
        public Guid Accessor { get; set; }

        public List<EntryModel> Entries { get; set; }
    }
}
