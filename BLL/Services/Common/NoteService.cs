using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Intefaces;
using DAL.Models;

namespace BLL.Services.Common
{
    internal class NoteService: INoteService
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
            return mapper.Map<IList<NoteDTO>>(notes);
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
