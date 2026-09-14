using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Models {
    public class Member : GymUser {
        public String? Photo { get; set; }
        public HealthRecord HealthRecord { get; set; } = default!;
        public ICollection<Booking> MemberSessions { get; set; } = default!;
        public ICollection<Membership> MemberPlans { get; set; } = default!;
    }
}
