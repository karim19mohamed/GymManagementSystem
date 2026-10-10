using GymManagementSystem.BLL.Services.Interfaces;
using GymManagementSystem.BLL.ViewModels.MemberViewModels;
using GymManagementSystem.DAL.Data.Models;
using GymManagementSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.BLL.Services.Classes {
    public class MemberService(IGenericRepository<Member> _genericRepository) : IMemberService {
        public async Task<IEnumerable<MemberViewModel>> GetAllMembersAsync(CancellationToken ct = default) {
            var members = await _genericRepository.GetAllAsync(ct: ct);
            return members.Select(m => new MemberViewModel {
                Id = m.Id,
                Photo = m.Photo,
                Name = m.Name,
                Email = m.Email,
                Phone = m.Phone,
                Gender = m.Gender.ToString()
            });
        }
    }
}
