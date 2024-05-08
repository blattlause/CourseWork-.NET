using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Intefaces;
using DAL.Models;


namespace BLL.Services.Common
{
    internal class ClaimService : IClaimService
    {
        private readonly IClaimRepository repository;
        private readonly IMapper mapper;

        public ClaimService(IClaimRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(ClaimDTO entity)
        {
            Claim claim = mapper.Map<Claim>(entity);
            repository.Add(claim);
        }

        public IList<ClaimDTO> GetAll()
        {
            IList<Claim> claims = repository.GetAll();
            return claims.Select(c => mapper.Map<ClaimDTO>(c)).ToList();
        }

        public ClaimDTO? GetById(int id)
        {
            Claim? claim = repository.GetById(id);
            return mapper.Map<ClaimDTO>(claim);
        }

        public void Remove(ClaimDTO entity)
        {
            Claim claim = mapper.Map<Claim>(entity);
            repository.Remove(claim.Id);
        }

        public void Update(ClaimDTO entity)
        {
            Claim claim = mapper.Map<Claim>(entity);
            repository.Update(claim);
        }
    }
}
