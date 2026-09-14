using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Data.Models {
    public class Address {
        public int BuildingNumber { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
    }
}
