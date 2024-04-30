using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Intefaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Common
{
    public class DiagnosisService : IDiagnosisService
    {
        private readonly IDiagnosisRepository repository;
        private readonly IMapper mapper;
        public DiagnosisService(IDiagnosisRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void Add(DiagnosisDTO entity)
        {
            Diagnosis diagnosis = mapper.Map<Diagnosis>(entity);
            repository.Add(diagnosis);
        }

        public IList<DiagnosisDTO> GetAll()
        {
            IList<Diagnosis> diagnosiss = repository.GetAll();
            return diagnosiss.Select(c => mapper.Map<DiagnosisDTO>(c)).ToList();
        }

        public DiagnosisDTO? GetById(int id)
        {
            Diagnosis? diagnosis = repository.GetById(id);
            return mapper.Map<DiagnosisDTO>(diagnosis);
        }

        public void Remove(DiagnosisDTO entity)
        {
            Diagnosis diagnosis = mapper.Map<Diagnosis>(entity);
            repository.Remove(diagnosis.Id);
        }

        public void Update(DiagnosisDTO entity)
        {
            Diagnosis diagnosis = mapper.Map<Diagnosis>(entity);
            repository.Update(diagnosis);
        }
    }
}
