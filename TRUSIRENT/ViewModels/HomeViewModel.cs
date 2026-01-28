using TRUSIRENT.Models.Entities;

namespace TRUSIRENT.ViewModels;

public class HomeViewModel
{
    public IEnumerable<Vehicle> Vehicles { get; }

    public HomeViewModel(IEnumerable<Vehicle> vehicles)
    {
        Vehicles = vehicles;
    }
}