using ProcManagement.Database;
using ProcManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcManagement.Services
{
    public class BaseServices
    {
        #region Singleton
        public static BaseServices Instance
        {
            get
            {
                if (instance == null) instance = new BaseServices();
                return instance;
            }
        }
        private static BaseServices instance { get; set; }
        private BaseServices()
        {
        }
        #endregion


        public List<Entry> GetEntry(string SearchTerm = "")
        {
            using (var context = new DSContext())
            {
                if (SearchTerm != "")
                {
                    return context.Entries.Where(p => p.Name != null && p.Name.ToLower()
                                            .Contains(SearchTerm.ToLower()))
                                            .OrderBy(x => x.Name)
                                            .ToList();
                }
                else
                {
                    return context.Entries.OrderBy(x => x.Name).ToList();
                }
            }
        }
       

        public Entry GetEntryById(int id)
        {
            using (var context = new DSContext())
            {
                return context.Entries.Find(id);

            }
        }

        public void CreateEntry(Entry Entry)
        {
            using (var context = new DSContext())
            {
                context.Entries.Add(Entry);
                context.SaveChanges();
            }
        }

        public void UpdateEntry(Entry Entry)
        {
            using (var context = new DSContext())
            {
                context.Entry(Entry).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteEntry(int ID)
        {
            using (var context = new DSContext())
            {

                var Entry = context.Entries.Find(ID);
                context.Entries.Remove(Entry);
                context.SaveChanges();
            }
        }


























        public List<Hospital> GetHospital(string SearchTerm = "")
        {
            using (var context = new DSContext())
            {
                if (SearchTerm != "")
                {
                    return context.Hospitals.Where(p => p.Name != null && p.Name.ToLower()
                                            .Contains(SearchTerm.ToLower()))
                                            .OrderBy(x => x.Name)
                                            .ToList();
                }
                else
                {
                    return context.Hospitals.OrderBy(x => x.Name).ToList();
                }
            }
        }


        public Hospital GetHospitalById(int id)
        {
            using (var context = new DSContext())
            {
                return context.Hospitals.Find(id);

            }
        }

        public void CreateHospital(Hospital Hospital)
        {
            using (var context = new DSContext())
            {
                context.Hospitals.Add(Hospital);
                context.SaveChanges();
            }
        }

        public void UpdateHospital(Hospital Hospital)
        {
            using (var context = new DSContext())
            {
                context.Entry(Hospital).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteHospital(int ID)
        {
            using (var context = new DSContext())
            {

                var Hospital = context.Hospitals.Find(ID);
                context.Hospitals.Remove(Hospital);
                context.SaveChanges();
            }
        }
    }
}
