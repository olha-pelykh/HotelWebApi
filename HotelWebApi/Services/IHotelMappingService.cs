using HotelWebApi.Models.Entities;
using HotelWebApi.Models.ViewModels;

namespace HotelWebApi.Services
{
    public interface IHotelMappingService
    {
        // Entity to ViewModel mappings
        HotelViewModel ToViewModel(Hotel hotel);
        HotelListViewModel ToListViewModel(Hotel hotel);
        IEnumerable<HotelViewModel> ToViewModelList(IEnumerable<Hotel> hotels);
        IEnumerable<HotelListViewModel> ToListViewModelList(IEnumerable<Hotel> hotels);
        
        // ViewModel to Entity mappings
        Hotel ToEntity(CreateHotelViewModel viewModel);
        void UpdateEntity(Hotel hotel, UpdateHotelViewModel viewModel);
    }
}