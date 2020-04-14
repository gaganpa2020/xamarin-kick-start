using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SalesApp.Models;

namespace SalesApp.Services.Address
{
    public interface IAddressService
    {
        Task<CurrentLocation> GetAssignedLocationAsync(User user);

        Task<AddressValidationResult> ValidateAddressAsync(Models.Address address);
        Task<Models.Address> SaveNewAddressAsync(Models.Address address);

        Task<List<Models.Address>> SearchAddressesAsync(string address, string zip);
        Task<List<Models.Address>> GetNearbyAddressesAsync(double latitude, double longitued);
        Task<AddressBuckets> GetAddressBucketsAsync(string zip);
        Task<Models.Address> GetAddressInfoAsync(long id);


        Task<List<AddressStatus>> GetAddressStatusesAsync();
        Task SetAddressStatusAsync(Models.Address address, AddressStatus status);


        Task<List<InteractionType>> GetInteractionTypesAsync();
        Task AddInteractionAsync(UserAddressInteraction userAddressInteraction);
    }
}
