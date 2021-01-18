using BuildingSite.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSite.Data.Entities
{
    public class Inbox : Entity
    {
        public DateTime DateTime { get; set; }

        public string IP { get; set; }

        public string  Name{ get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public string Messsage { get; set; }

        public bool Read { get; set; }
    }
}
