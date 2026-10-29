using AutoMapper;
using GymManagementSystem.BLL.Services.Interfaces;
using GymManagementSystem.BLL.ViewModels.MemberViewModels;
using GymManagementSystem.DAL.Data.Models;
using GymManagementSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.BLL.Services.Classes {
    public class MemberService(IUnitOfWork _unitOfWork, IMapper _mapper) : IMemberService {
        public async Task<bool> CreateMemberAsync(CreateMemberViewModel member, CancellationToken ct = default) {
            var memberExists = await _unitOfWork.GetRepository<Member>().AnyAsync(m => member.Email == m.Email || member.Phone == m.Phone, ct: ct);
            if (memberExists) {
                return false;
            }
            _unitOfWork.GetRepository<Member>().Add(
                _mapper.Map<Member>(member)
                , ct: ct);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<MemberViewModel>> GetAllMembersAsync(CancellationToken ct = default) {
            var members = await _unitOfWork.GetRepository<Member>().GetAllAsync(ct: ct);
            return _mapper.Map<IEnumerable<MemberViewModel>>(members);
        }

        public async Task<MemberViewModel?> GetMemberDetailsAsync(int id, CancellationToken ct = default) {
            var member = await _unitOfWork.GetRepository<Member>().GetByIdAsync(id, ct);
            if (member == null)
                return null;
            
            var memberDetails = _mapper.Map<MemberViewModel>(member);

            var activeMembership = await _unitOfWork.GetRepository<Membership>().FirstOrDefaultAsync(m => m.MemberId == id && m.EndDate > DateTime.Now, ct:ct);
            if (activeMembership != null) {
                var plan = await _unitOfWork.GetRepository<Plan>().GetByIdAsync(activeMembership.PlanId, ct:ct);
                memberDetails.PlanName = plan?.Name;
                memberDetails.MembershipStartDate = activeMembership.CreatedAt.ToShortDateString();
                memberDetails.MembershipEndDate = activeMembership.EndDate.ToShortDateString();
            }

            return memberDetails;
        }

        public async Task<HealthRecordViewModel?> GetHealthRecordAsync(int id, CancellationToken ct = default) {
            var healthRecordDetails = await _unitOfWork.GetRepository<HealthRecord>().FirstOrDefaultAsync(h => h.MemberId == id, ct: ct);
            if (healthRecordDetails == null)
                return null;
            return _mapper.Map<HealthRecordViewModel>(healthRecordDetails);
        }
    }
}
