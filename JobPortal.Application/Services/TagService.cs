using AutoMapper;
using AutoMapper.QueryableExtensions;
using JobPortal.Application.Interfaces;
using JobPortal.Application.ViewModels.CategoryVm;
using JobPortal.Application.ViewModels.JobVm;
using JobPortal.Application.ViewModels.JobVM;
using JobPortal.Domain.Interfaces;
using JobPortal.Domain.Model;
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

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public int AddTag(NewTagViewModel model)
        {
            var TagModel = new Tag()
            { 
                Id = model.Id,
                Name = model.Name,
            };
            _tagRepository.AddTag(TagModel);

            return TagModel.Id;

        }

        public int DeleteTag(int id)
        {
            throw new NotImplementedException();
        }

        public ListOfTagsForListViewModel GetAllTags()
        {
            var TagsModels = _tagRepository.GetAllTags();
            var tags = new List<TagForListViewModel>();

            foreach (var tag in TagsModels)
            {
                tags.Add(new TagForListViewModel() { Id = tag.Id, Name = tag.Name });
            }


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
