using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaktiImProject.Models;


namespace VaktiImProject.BLL
{
    public class OrdersService
    {
        private readonly Vakti_ImEntities _db;
        public OrdersService()
        {
            _db = new Vakti_ImEntities();
        }

        public List<PorosiModel> MerrListenEPorosive(int id)
        {
            if (id == 0 || id < 0)
                return null;
            return _db.Porosit_e_bera(id).Select(p => new PorosiModel
            {
                EmriGatimit = p.emriGatimit,
                Sasia = p.sasia,
                Status = p.status_porosie,
                Klienti= p.emriKlientit,
                Pergjegjesi=p.emri,
                Adresa= p.pershkrimi
            }).ToList();
        }

        public List<MyOrders> MyOrderList(int id)
        {
            if (id == 0 || id < 0)
                return null;
            return _db.Detaje_porosie(id).Select(q => new MyOrders
            {   porosi_id= q.porosi_id,
                emriGatimit= q.emriGatimit,
                sasia=q.sasia,
                cmimi= q.cmimi
            }).ToList();
        }


    }
}