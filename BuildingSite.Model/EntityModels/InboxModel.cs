using BuildingSite.Model.EntityModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSite.Model.EntityModels
{
    public class InboxModel : EntityModel
    {
        public DateTime DateTime { get; set; }

        public string IP { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public string Messsage { get; set; }

        public bool Read { get; set; }
    }
}
