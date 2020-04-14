using SalesApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesApp.Database;

namespace SalesApp.Services.Address
{
    public class MockAddressService : IAddressService
    {
        public async Task<CurrentLocation> GetAssignedLocationAsync(User user)
        {
            return new CurrentLocation()
            {
                City = "Pittsburg",
                State = "KS",
                Zip = "66762",
                Latitude = 37.405076,
                Longitude = -94.709497,
            };
        }

        public async Task<AddressValidationResult> ValidateAddressAsync(Models.Address address)
        {
            await Task.Delay(1000);
            return new AddressValidationResult
            {
                Valid = true,
                Address = address
            };
        }

        public async Task<Models.Address> SaveNewAddressAsync(Models.Address address)
        {
            await Task.Delay(1000);

            return address;
        }

        public async Task<List<Models.Address>> SearchAddressesAsync(string address, string zip)
        {
            await Task.Delay(1000);

            List<Models.Address> output = new List<Models.Address>();

            return output;
        }

        public async Task<List<Models.Address>> GetNearbyAddressesAsync(double latitude, double longitude)
        {
            var output = getFakeAddressData();
            await Task.Delay(2000);

            return output;
        }

        public async Task<Models.Address> GetAddressInfoAsync(long id)
        {
            await Task.Delay(1000);

            return new Models.Address
            {
                Id = id,
                City = "Pittsburg",
                Address1 = "100 South Olive",
                Province = "KS",
                PostalCode = "66762",
                Latitude = 37.405076,
                Longitude = -94.709497
            };
        }

        public async Task<AddressBuckets> GetAddressBucketsAsync(string zip)
        {
            var addresses = getFakeAddressData();
            await Task.Delay(2000);

            return new AddressBuckets()
            {
                Addresses = addresses.ToList(),
                Interactions = addresses.Where(x=>x.AddressStatusId == 1 || x.AddressStatusId == 5).ToList(),
                Sales = addresses.Where(x=>x.AddressStatusId == 1).ToList(),
                Promising = addresses.Where(x=>x.AddressStatusId == 3).ToList()
            };
        }

        public async Task<List<AddressStatus>> GetAddressStatusesAsync()
        {
            await Task.Delay(1000);

            List<AddressStatus> output = new List<AddressStatus>();

            AddressStatus status = new AddressStatus
            {
                Id = 1,
                Name = "Do Not Knock",
                Description = "Do Not Knock",
                Icon = ""
            };
            output.Add(status);

            return output;
        }

        public async Task SetAddressStatusAsync(Models.Address address, AddressStatus status)
        {
            await Task.Delay(1000);
        }

        public async Task<List<InteractionType>> GetInteractionTypesAsync()
        {
            await Task.Delay(1000);

            List<InteractionType> output = new List<InteractionType>();

            InteractionType status = new InteractionType
            {
                Id = 1,
                Name = "No Answer",
                Description = "No Answer",
                Icon = ""
            };
            output.Add(status);

            return output;
        }

        public async Task AddInteractionAsync(UserAddressInteraction userAddressInteraction)
        {
            await Task.Delay(1000);
        }

        private static List<Models.Address> getFakeAddressData()
        {
            List<Models.Address> output = new List<Models.Address>()
            {
                new Models.Address
                {
                    Id = 1,
                    City = "Pittsburg",
                    Address1 = "100 South Olive",
                    Province = "KS",
                    PostalCode = "66762",
                    Latitude = 37.405076,
                    Longitude = -94.709497,
                    AddressStatusId = 1,
                },
                new Models.Address
                {
                    Id = 2,
                    City = "Pittsburg",
                    Address1 = "101 South Olive",
                    Province = "KS",
                    PostalCode = "66762",
                    Latitude = 37.404130,
                    Longitude = -94.709443,
                    AddressStatusId = 2,
                },
                new Models.Address
                {
                    Id = 3,
                    City = "Pittsburg",
                    Address1 = "102 South Olive",
                    Province = "KS",
                    PostalCode = "66762",
                    Latitude = 37.402587,
                    Longitude = -94.709443,
                    AddressStatusId = 3,
                },
                new Models.Address
                {
                    Id = 4,
                    City = "Pittsburg",
                    Address1 = "101 South College",
                    Province = "KS",
                    PostalCode = "66762",
                    Latitude = 37.403559,
                    Longitude = -94.711476,
                    AddressStatusId = 2,
                }
            };
            return output;
        }
    }
}
