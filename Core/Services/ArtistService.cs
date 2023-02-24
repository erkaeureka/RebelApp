using Core.Entities;
using Core.Interfaces;

namespace Core.Services
{
    public interface IArtistService
    {
        Task<Artist> CreateAsync(Artist artist);
        IQueryable<Artist> GetAll();
        Task<Artist> FindAnswerAsync(long id);
        Artist Update(Artist artist);
    }
    public class ArtistService : IArtistService
    {
        private readonly IRepository<Artist> _artistRepository;
        public ArtistService(IUnitOfWork unitOfWork)
        {
            _artistRepository = unitOfWork.GetRepository<Artist>();
        }
        public async Task<Artist> CreateAsync(Artist artist)
        {
            return await _artistRepository.AddAsync(artist);
        }
        public Artist Update(Artist artist)
        {
            return _artistRepository.Update(artist);
        }
        public IQueryable<Artist> GetAll()
        {
            return _artistRepository.Where(x=>x.DeletedDate == null);
        }
        public Task<Artist> FindAnswerAsync(long id)
        {
            return Task.FromResult(_artistRepository.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
