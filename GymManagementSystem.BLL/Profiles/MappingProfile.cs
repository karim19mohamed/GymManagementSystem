using AutoMapper;
using GymManagementSystem.BLL.ViewModels.MemberViewModels;
using GymManagementSystem.BLL.ViewModels.PlanViewModels;
using GymManagementSystem.BLL.ViewModels.SessionViewModels;
using GymManagementSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.BLL.Profiles {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Member, MemberViewModel>()
                .ForMember(d => d.Gender, o => o.MapFrom(s => s.Gender.ToString()))
                .ForMember(d => d.DateOfBirth, o => o.MapFrom(s => s.DateOfBirth.ToShortDateString()))
                .ForMember(d => d.Address, o => o.MapFrom(s => $"{s.Address.BuildingNumber} - {s.Address.Street} - {s.Address.City}"));
            CreateMap<HealthRecord, HealthRecordViewModel>();
            CreateMap<CreateMemberViewModel, Member>()
                .ForMember(d => d.Address, o => o.MapFrom(s => new Address {
                    Street = s.Street,
                    City = s.City,
                    BuildingNumber = s.BuildingNumber
                }))
                .ForMember(d => d.HealthRecord, o => o.MapFrom(s => s.HealthRecordViewModel));
            CreateMap<Plan, PlanViewModel>();
            CreateMap<Session, SessionViewModel>();
        }
    }
}
