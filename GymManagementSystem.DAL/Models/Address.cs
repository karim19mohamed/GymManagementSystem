using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Models {
    [Owned]
    public class Address {
        public int BuildingNumber { get; set; } = default!;
        public String Street { get; set; } = default!;
        public String City { get; set; } = default!;
    }
}
