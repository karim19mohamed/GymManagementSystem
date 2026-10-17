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
    public class MemberService(IGenericRepository<Member> _memberRepository, 
                               IGenericRepository<Membership> _membershipRepository,
                               IGenericRepository<Plan> _planRepository) : IMemberService {
        public async Task<bool> CreateMemberAsync(CreateMemberViewModel member, CancellationToken ct = default) {
            var memberExists = await _memberRepository.AnyAsync(m => member.Email == m.Email || member.Phone == m.Phone, ct: ct);
            if (memberExists) {
                return false;
            }
            var result = await _memberRepository.AddAsync(
                new Member {
                    Name = member.Name,
                    Email = member.Email,
                    Phone = member.Phone,
                    DateOfBirth = member.DateOfBirth,
                    Gender = member.Gender,
                    Address = new Address {
                        Street = member.Street,
                        City = member.City,
                        BuildingNumber = member.BuildingNumber
                    },
                    HealthRecord = new HealthRecord {
                        Height = member.HealthRecordViewModel.Height,
                        Weight = member.HealthRecordViewModel.Weight,
                        BloodType = member.HealthRecordViewModel.BloodType,
                        Note = member.HealthRecordViewModel.Note
                    }
                }
                , ct: ct);
            return result > 0;
        }

        public async Task<IEnumerable<MemberViewModel>> GetAllMembersAsync(CancellationToken ct = default) {
            var members = await _memberRepository.GetAllAsync(ct: ct);
            return members.Select(m => new MemberViewModel {
                Id = m.Id,
                Photo = m.Photo,
                Name = m.Name,
                Email = m.Email,
                Phone = m.Phone,
                Gender = m.Gender.ToString()
            });
        }

        public async Task<MemberViewModel?> GetMemberDetailsAsync(int id, CancellationToken ct = default) {
            var member = await _memberRepository.GetByIdAsync(id, ct);
            if (member == null)
                return null;
            var memberDetails = new MemberViewModel {
                Photo = member.Photo,
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                DateOfBirth = member.DateOfBirth.ToString(),
                Gender = member.Gender.ToString(),
                Address = $"{member.Address.BuildingNumber} - {member.Address.Street} - {member.Address.City}"
            };

            var activeMembership = await _membershipRepository.FirstOrDefaultAsync(m => m.MemberId == id && m.EndDate > DateTime.Now, ct:ct);
            if (activeMembership != null) {
                var plan = await _planRepository.GetByIdAsync(activeMembership.PlanId, ct:ct);
                memberDetails.PlanName = plan?.Name;
                memberDetails.MembershipStartDate = activeMembership.CreatedAt.ToShortDateString();
                memberDetails.MembershipEndDate = activeMembership.EndDate.ToShortDateString();
            }

            return memberDetails;
        }
    }
}
