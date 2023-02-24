using Api.Models;
using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Api.Managers
{

    public interface IArtistManager
    {
        Task<ArtistViewModel> CreateAsync(ArtistInputModel model);
        Task<List<ArtistViewModel>> GetAll();
        Task Update(long id, ArtistInputModel model);
        Task DeleteArtist(long id);
    }

    public class ArtistManager:IArtistManager
    {
      
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistManager(IUnitOfWork<ApplicationDbContext> unitOfWork, IArtistService artistService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _artistService = artistService;
            _mapper = mapper;
        }

        public async Task<ArtistViewModel> CreateAsync(ArtistInputModel model)
        {
            var artist = new Artist(model.Name,model.Streams,model.Rate);
            var new_artist = await _artistService.CreateAsync(artist);
            await _unitOfWork.CommitWithGuardAsync();

            return _mapper.Map<ArtistViewModel>(new_artist);
        }
        public async Task<List<ArtistViewModel>> GetAll()
        {
            return await _artistService.GetAll()
                .Select(x => _mapper.Map<ArtistViewModel>(x))
                .ToListAsync();
        }
        public async Task Update(long id,ArtistInputModel model)
        {
            var artist = await _artistService.FindAnswerAsync(id) ?? throw new HttpStatusCodeException(HttpStatusCode.NotFound, ErrorMessage.DoesNotExist, nameof(id));
            artist.SetValue(model.Name,model.Streams,model.Rate);
            _artistService.Update(artist);
            await _unitOfWork.CommitWithGuardAsync();
        }
        public async Task DeleteArtist(long id)
        {
            var artist = await _artistService.FindAnswerAsync(id) ?? throw new HttpStatusCodeException(HttpStatusCode.NotFound, ErrorMessage.DoesNotExist, nameof(id));
            artist.Delete();
            await _unitOfWork.CommitWithGuardAsync();
        }
    }
}
