﻿using JobPortal.Domain.Interfaces;
using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {   
        private readonly Context _context;
        public ApplicationRepository(Context context)
        {
            _context = context;
        }


        public List<Application> GetAllApplications()
        {
            return _context.Applications.ToList();
        }
        public int AddApplication(Application application)
        {
            if(application != null)
            {
                _context.Applications.Add(application);
                _context.SaveChanges();
                return application.Id;

            }
            throw new NullReferenceException(); 
        }
         
        public void RemoveApplicationById(int ApplicationId)
        {
            Application application = _context.Applications.FirstOrDefault(ap => ap.Id == ApplicationId);
            if(application != null)
            {
                _context.Applications.Remove(application);
                _context.SaveChanges();
            }
        }

        public Application GetApplicationById(int ApplicationId)
        {
            Application app = _context.Applications.FirstOrDefault(a => a.Id == ApplicationId);
            if(app != null)
            {
                return app;
            }
            throw new Exception();
        }
    }
}
