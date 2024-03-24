﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Application.Models.Dto;
using PersonalCollection.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace PersonalCollection.Application.Services
{
    public class CollectionService
    {
        private readonly IMapper _mapper;
        private readonly ICollectionRepository _collectionRepository;
        private readonly IThemeRepository _themeRepository;

        public CollectionService(IMapper mapper, ICollectionRepository collectionRepository, IThemeRepository themeRepository)
        {
            _mapper = mapper;
            _collectionRepository = collectionRepository;
            _themeRepository = themeRepository;
        }

        public async Task<IEnumerable<Theme>> GetThemes() => await _themeRepository.GetAll().AsNoTracking().ToListAsync();

        public async Task<CollectionEditCreateDto?> GetCollectionById(int collectionId)
        {
            return await _collectionRepository.GetAll()
               .ProjectTo<CollectionEditCreateDto>(_mapper.ConfigurationProvider)
               .AsNoTracking()
               .FirstOrDefaultAsync(c => c.Id == collectionId);
        }

        public async Task<CollectionCustomFieldSettingsDto?> GetCollectionCustomFieldSettings(int collectionId)
        {
            return await _collectionRepository.GetAll()
               .ProjectTo<CollectionCustomFieldSettingsDto>(_mapper.ConfigurationProvider)
               .AsNoTracking()
               .FirstOrDefaultAsync(c => c.Id == collectionId);
        }

        public async Task<IEnumerable<CollectionDto>> GetLargestCollections(int count)
        {
            return await _collectionRepository.GetAll()
                .OrderByDescending(c => c.Items.Count)
                .Take(count)
                .ProjectTo<CollectionDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<CollectionDto>> GetUserCollections(string userId)
        {
            return await _collectionRepository.GetAll()
                .Where(c => c.UserId == userId)
                .ProjectTo<CollectionDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CollectionWithItemsDto?> GetCollectionWithItems(int collectionId)
        {
            return await _collectionRepository.GetAll()
               .ProjectTo<CollectionWithItemsDto>(_mapper.ConfigurationProvider)
               .AsNoTracking()
               .FirstOrDefaultAsync(c => c.Id == collectionId);
        }

        public async Task<int> AddCollection(CollectionEditCreateDto collectionDto)
        {
            var collection = _mapper.Map<Collection>(collectionDto);

            await _collectionRepository.Create(collection);
            await _collectionRepository.SaveChangesAsync();

            return collection.Id;
        }

        public async Task UpdateCollection(CollectionEditCreateDto collectionDto)
        {
            var collection = await _collectionRepository.GetById(collectionDto.Id);
            _mapper.Map(collectionDto, collection);

            _collectionRepository.Update(collection);
            await _collectionRepository.SaveChangesAsync();
        }

        public async Task UpdateCollectionImage(int collectionId, string? image)
        {
            await _collectionRepository.GetAll()
                .Where(c => c.Id == collectionId)
                .ExecuteUpdateAsync(setters => setters.SetProperty(c => c.Image, image));
        }

        public async Task DeleteCollection(int collectionId)
        {
            await _collectionRepository.GetAll()
                .Where(c => c.Id == collectionId)
                .ExecuteDeleteAsync();
        }
    }
}
