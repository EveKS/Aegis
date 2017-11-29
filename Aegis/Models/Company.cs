using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aegis.Models
{
    public class Company
    {
        public string CompanyId { get; set; }

        public string Url { get; set; }

        public string CompanyName { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        public string Category { get; set; }

        public string Production { get; set; }

        public DateTime Actual { get; set; }

        public DateTime Added { get; set; }

        public string FoundingDate { get; set; }

        public string FadType { get; set; }

        public string FadInn { get; set; }

        public string OrderQuantity { get; set; }

        public IList<AdditionaServices> AdditionaServices { get; set; }

        public IList<Delivery> Deliverys { get; set; }

        public IList<DeliveryRegion> DeliveryRegions { get; set; }

        public string ContactName { get; set; }

        public string Telephone { get; set; }

        public string Syte { get; set; }

        public string Email { get; set; }

        public string CategoryName { get; set; }

        public Company()
        {
            Deliverys = new List<Delivery>();
            AdditionaServices = new List<AdditionaServices>();
            DeliveryRegions = new List<DeliveryRegion>();
        }
    }
}
