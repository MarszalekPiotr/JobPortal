using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.CategoryVm
{
    public  class NewCategoryViewModel
    {   
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class NewCategoryValidator : AbstractValidator<NewCategoryViewModel>
    {   

        public NewCategoryValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).MaximumLength(20);
            RuleFor(x => x.Name).MinimumLength(2);

        }
       
    }
}
