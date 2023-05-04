using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Repositories
{
    public class TagRepository
    {
        private readonly Context _context;

        public TagRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<Tag> GetAllTags(int tagId)
        {
            var tags = _context.Tags.Where(t => t.Id == tagId);
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
            return tag.Id;
        }
    }
}
