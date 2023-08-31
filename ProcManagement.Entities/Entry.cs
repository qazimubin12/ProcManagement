using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcManagement.Entities
{
    public class Entry:BaseEntity
    {
        public DateTime Date { get; set; }
        public string Hospital { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Procedure { get; set; }

        public string UserID { get; set; }
    }
}
