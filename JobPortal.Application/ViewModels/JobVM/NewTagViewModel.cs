using FluentValidation;
using JobPortal.Application.ViewModels.CategoryVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.JobVM
{
    public class NewTagViewModel
    {   
       public int Id { get; set; }
       public string Name { get; set; }
    }

    public class NewTagValidator : AbstractValidator<NewTagViewModel>
    {

        public NewTagValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).MaximumLength(20);
            RuleFor(x => x.Name).MinimumLength(2);

        }

    }
}
