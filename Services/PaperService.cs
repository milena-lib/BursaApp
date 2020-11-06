using Bursa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bursa.Services
{
    public class PaperService
    {
        private ApplicationContext db;
        public PaperService(ApplicationContext context)
        {
            db = context;
        }
        public string GetPapers()
        {
            string result = string.Empty;
            IList<Paper> lstPapers = null;
            IList<BursaType> lstBursaTypes = null;
            IList<PaperType> lstPaperTypes = null;

            try
            {
                lstPapers = (from paper in db.Papers.Include(pt => pt.PaperTypeValue)
                       select paper).ToList();
                lstBursaTypes = (from bt in db.BursaTypeList
                       select bt).ToList();
                lstPaperTypes = (from pt in db.PaperTypeList
                                 select pt).ToList();
                var objects = new { PapersList = lstPapers, BursaTypeList = lstBursaTypes, PaperTypeList = lstPaperTypes };
                result = JsonSerializer.Serialize(objects);
                return result;
            }
            catch (Exception ex)
            {
                //TODO
                throw (ex);

            }

        }

    }
}
