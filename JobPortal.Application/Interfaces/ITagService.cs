using JobPortal.Application.ViewModels.JobVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Interfaces
{
    public interface ITagService
    {
        int AddTag(NewTagViewModel model);
        int UpdateTag(int tagId,NewTagViewModel model);
        int DeleteTag(int id);

        ListOfTagsForListViewModel GetAllTags();

    }
}
