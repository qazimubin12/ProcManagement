using ProcManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcManagement.ViewModels
{
    public class EntryListingViewModel
    {
        public List<Entry> Entries { get; set; }
        public string  SearchTerm { get; set; }
    }
    public class EntryActionViewModel
    {
        public List<string> Hospitals { get; set; }
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Hospital { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Procedure { get; set; }
    }
}