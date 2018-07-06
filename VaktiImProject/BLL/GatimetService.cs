using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaktiImProject.Models;

namespace VaktiImProject.BLL
{
    public class GatimetService
    {
        private readonly Vakti_ImEntities _db;
        public GatimetService()
        {
            _db = new Vakti_ImEntities();
        }
        public List<GATIM> MerrListenEGatimeve()
        {
            return _db.GATIMs
                .Where(g => g.disponueshmeria == true)
                .AsEnumerable()
                .Select(p => new GATIM
                {
                    cmimi= p.cmimi,
                    gatim_id = p.gatim_id,
                    emriGatimit = p.emriGatimit,
                    KATEGORI = p.KATEGORI,
                    pershkrimi = p.pershkrimi,
                    foto= p.foto

                }).ToList();
        }
    }
}