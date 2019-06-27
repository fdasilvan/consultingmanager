using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Infra.Database.Models
{
    public class CityPoco
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
    }
}
