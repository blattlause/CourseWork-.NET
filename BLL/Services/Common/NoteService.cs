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
    public class NoteService: INoteService
    {
        private readonly INoteRepository repository;
        private readonly IMapper mapper;

        public NoteService(INoteRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(NoteDTO entity)
        {
            Note note = mapper.Map<Note>(entity);
            repository.Add(note);
        }

        public IList<NoteDTO> GetAll()
        {
            IList<Note> notes = repository.GetAll();
            return notes.Select(c => mapper.Map<NoteDTO>(c)).ToList();
        }

        public NoteDTO? GetById(int id)
        {
            Note? note = repository.GetById(id);
            return mapper.Map<NoteDTO>(note);
        }

        public IEnumerable<NoteDTO> GetByMedicineCardId(int medicineCardId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NoteDTO> GetByVetId(int vetId)
        {
            throw new NotImplementedException();
        }

        public void Remove(NoteDTO entity)
        {
            Note note = mapper.Map<Note>(entity);
            repository.Remove(note.Id);
        }

        public void Update(NoteDTO entity)
        {
            Note note = mapper.Map<Note>(entity);
            repository.Update(note);
        }
    }
}
