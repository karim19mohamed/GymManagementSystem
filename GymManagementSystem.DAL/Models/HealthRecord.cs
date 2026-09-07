using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Models {
    public class HealthRecord : BaseEnitity {
        public int Height { get; set; }
        public int Weight { get; set; }
        public string BloodType { get; set; } = default!;
        public string? Note { get; set; };
    }
}
