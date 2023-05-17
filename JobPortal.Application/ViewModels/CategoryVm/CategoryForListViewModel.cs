using AutoMapper;
using JobPortal.Application.Mapping;
using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.CategoryVm
{
    public  class CategoryForListViewModel : IMapFrom<Category>
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryForListViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}
 