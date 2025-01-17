﻿using System.Threading.Tasks;

namespace NominatimAPI.Interfaces
{
    public interface IReverseGeocoder {
        /// <summary>
        ///     Attempt to get an address or location from a set of coordinates
        /// </summary>
        /// <param name="req">Reverse geocode request object</param>
        /// <returns>A single reverse geocode response</returns>
        Task<GeocodeResponse> ReverseGeocode(ReverseGeocodeRequest req);
    }
}