using AutoMapper;
using AutoMapper.QueryableExtensions;
using JobPortal.Application.Interfaces;
using JobPortal.Application.ViewModels.CategoryVm;
using JobPortal.Application.ViewModels.JobVm;
using JobPortal.Application.ViewModels.JobVM;
using JobPortal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public int AddTag(NewTagViewModel model)
        {    
            
            throw new NotImplementedException();
        }

        public int DeleteTag(int id)
        {
            throw new NotImplementedException();
        }

        public ListOfTagsForListViewModel GetAllTags()
        {
            var tags = _tagRepository.GetAllTags()
              .ProjectTo<TagForListViewModel>(_mapper.ConfigurationProvider).ToList();

            var listOfTags = new ListOfTagsForListViewModel()
            {
                Tags = tags,
                Count = tags.Count

               

            };

            return listOfTags;
        }

        public int UpdateTag(int tagId, NewTagViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
