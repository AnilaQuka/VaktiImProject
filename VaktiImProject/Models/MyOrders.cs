using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VaktiImProject.Models
{
    public class MyOrders
    {
        [DisplayName("Emri")]
        public string emriGatimit { get; set; }
        [DisplayName("Sasia")]
        public int sasia { get; set; }
        [DisplayName("Çmimi")]
        public decimal cmimi { get; set; }
        public int porosi_id { get; set; }
    }
}