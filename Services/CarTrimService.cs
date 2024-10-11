﻿using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Services.Interfaces;
using OC_P5.Models;

namespace OC_P5.Services
{
    public class CarTrimService : ICarTrimService
    {
        private readonly ICarTrimRepository _carTrimRepository;

        public CarTrimService(ICarTrimRepository carTrimRepository)
        {
            _carTrimRepository = carTrimRepository;
        }

        public async Task<IEnumerable<CarTrim>> GetAllCarTrimsAsync()
        {
            return await _carTrimRepository.GetAllCarTrimsAsync();
        }

        public async Task<CarTrim> GetCarTrimByIdAsync(int trimId)
        {
            return await _carTrimRepository.GetCarTrimByIdAsync(trimId);
        }
        public async Task<CarTrim> AddNewCarTrimAsync(string trimLabel)
        {
            CarTrim existingTrim = await _carTrimRepository.GetCarTrimByNameAsync(trimLabel);
            if (existingTrim != null)
            {
                throw new InvalidOperationException("Cette finition existe déjà.");
            }

            CarTrim newTrim = new CarTrim { TrimLabel = trimLabel };
            await _carTrimRepository.AddCarTrimAsync(newTrim);

            return newTrim;
        }
    }
}