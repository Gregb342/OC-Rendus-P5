﻿using OC_P5.Models;

namespace OC_P5.Data.Repositories.Interfaces
{
    public interface ICarMediaRepository
    {
        Task AddCarMediaAsync(CarMedia carMedia);
        Task<IEnumerable<CarMedia>> GetCarMediasByCarIdAsync(int carId);
        Task RemoveCarMediaAsync(int carId, int mediaId);
    }
}
