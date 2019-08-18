﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class CustomerMeetingPoco
    {
        public Guid Id { get; set; }

        public DateTime OriginalDate { get; set; }
        public DateTime Date { get; set; }

        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public CustomerPoco Customer { get; set; }

        public virtual ICollection<CustomerProcessPoco> CustomerProcesses { get; set; }
    }
}
