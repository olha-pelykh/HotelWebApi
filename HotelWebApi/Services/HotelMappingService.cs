using HotelWebApi.Models.Entities;
using HotelWebApi.Models.ViewModels;

namespace HotelWebApi.Services
{
    public class HotelMappingService : IHotelMappingService
    {
        public HotelViewModel ToViewModel(Hotel hotel)
        {
            if (hotel == null)
                throw new ArgumentNullException(nameof(hotel));

            return new HotelViewModel
            {
                Id = hotel.ID,
                Name = hotel.HotelName,
                Description = hotel.HotelDescription,
                Address = hotel.HotelAddress,
                Phone = hotel.HotelPhone,
                Email = hotel.HotelEmail,
                CreatedAt = DateTime.UtcNow // You may want to add CreatedAt to Hotel entity
            };
        }

        public HotelListViewModel ToListViewModel(Hotel hotel)
        {
            if (hotel == null)
                throw new ArgumentNullException(nameof(hotel));

            return new HotelListViewModel
            {
                Id = hotel.ID,
                Name = hotel.HotelName,
                Address = hotel.HotelAddress,
                Phone = hotel.HotelPhone,
                Email = hotel.HotelEmail
            };
        }

        public IEnumerable<HotelViewModel> ToViewModelList(IEnumerable<Hotel> hotels)
        {
            if (hotels == null)
                return Enumerable.Empty<HotelViewModel>();

            return hotels.Select(ToViewModel);
        }

        public IEnumerable<HotelListViewModel> ToListViewModelList(IEnumerable<Hotel> hotels)
        {
            if (hotels == null)
                return Enumerable.Empty<HotelListViewModel>();

            return hotels.Select(ToListViewModel);
        }

        public Hotel ToEntity(CreateHotelViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return new Hotel
            {
                ID = Guid.NewGuid(),
                HotelName = viewModel.Name,
                HotelDescription = viewModel.Description,
                HotelAddress = viewModel.Address,
                HotelPhone = viewModel.Phone,
                HotelEmail = viewModel.Email
            };
        }

        public void UpdateEntity(Hotel hotel, UpdateHotelViewModel viewModel)
        {
            if (hotel == null)
                throw new ArgumentNullException(nameof(hotel));
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            hotel.HotelName = viewModel.Name;
            hotel.HotelDescription = viewModel.Description;
            hotel.HotelAddress = viewModel.Address;
            hotel.HotelPhone = viewModel.Phone;
            hotel.HotelEmail = viewModel.Email;
        }
    }
}