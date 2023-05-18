using JobPortal.Domain.Interfaces;
using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Repositories
{
    public class TagRepository: ITagRepository
    {
        private readonly Context _context;

        public TagRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<Tag> GetAllTags()
        {
            var tags = _context.Tags;
            if (tags != null)
            {
                return tags;
            }
            throw new NullReferenceException();
        }

        public Tag GetTag(int tagId) 
        {
            var tag = _context.Tags.FirstOrDefault(t => t.Id == tagId);
            if (tag != null)
            {
                return tag;
            }
            throw new NullReferenceException();
        }

        public int AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return tag.Id;
        }
    }
}
