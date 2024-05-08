using BLL.DTO;


namespace BLL.Services.Interfaces
{
    public interface INoteService : IService<NoteDTO>
    {
        IEnumerable<NoteDTO> GetByMedicineCardId(int medicineCardId);
        IEnumerable<NoteDTO> GetByVetId(int vetId);
    }
}
