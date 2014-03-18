using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Entities;

namespace CMS.Services.Interfaces
{
    public interface ISampleService
    {
        IEnumerable<SampleEntity> FetchAll();
        SampleEntity GetById(int id);
        void Create(SampleEntity sample);
        void Update(SampleEntity sample);
        void Delete(int id);
    }
}
