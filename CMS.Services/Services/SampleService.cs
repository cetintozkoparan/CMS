using System.Collections.Generic;
using CMS.Data.DBInteractions;
using CMS.Entities;
using CMS.Services.Interfaces;
using CMS.Data.EntityRepositories;
using Microsoft.Practices.Unity;

namespace CodeFirstServices.Services
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;
        public SampleService(ISampleRepository SampleRepository)
        {
            this._sampleRepository = SampleRepository;
        }
        #region ISampleService Members

        public IEnumerable<SampleEntity> FetchAll()
        {
            var Samples = _sampleRepository.GetAll();
            return Samples;
        }

        public SampleEntity GetById(int id)
        {
            var Sample = _sampleRepository.GetById(id);
            return Sample;
        }

        public void Create(SampleEntity Sample)
        {
            _sampleRepository.Add(Sample);
        }

        public void Delete(int id)
        {
            var Sample = _sampleRepository.GetById(id);
            _sampleRepository.Delete(Sample);
        }

        public void Update(SampleEntity Sample)
        {
            _sampleRepository.Update(Sample);
        }

        #endregion
    }
}
