using System.Diagnostics;
using CarServiceASPProject.Models;
using CarServiceLibrary.Models;
using CarServiceLibrary.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarServiceASPProject.Controllers;

public class AdminController : Controller
{

    private readonly CarServiceDbContext _db;

    
    public AdminController(CarServiceDbContext context)
    {
        _db = context;
    }

    public async Task<IActionResult>AdminPanel()
    {
		return View(await _db.Orders.ToListAsync());
	}

	public IActionResult DiagnosticAdminPanel()
	{
        var services = _db.Services.
            Where(s => s.TypeId == 4)
            .ToList();
        var vm = new ServicesViewModel
        {
            Services = services
        };

        var carList = (from car in _db.Cars
                       select new SelectListItem()
                       {
                           Text = car.CarName,
                           Value = car.Id.ToString()
                       }).ToList();

        carList.Insert(0, new SelectListItem()
        {
            Text = "Пожалуйста, выберите марку автомобиля!",
            Value = string.Empty
        });

        var cars = _db.Cars.ToList();

        var cM = new CarsViewModel
        {
            ListofCar = carList
        };

        var modelTuple = (cM, vm);

        ViewBag.ListofCars = carList;

        return View(modelTuple);
    }

	public IActionResult MaintenanceAdminPanel()
	{
        var services = _db.Services.
                                    Where(s => s.TypeId == 2)
                                    .ToList();
        var vm = new ServicesViewModel
        {
            Services = services
        };

        var carList = (from car in _db.Cars
                       select new SelectListItem()
                       {
                           Text = car.CarName,
                           Value = car.Id.ToString()
                       }).ToList();

        carList.Insert(0, new SelectListItem()
        {
            Text = "Пожалуйста, выберите марку автомобиля!",
            Value = string.Empty
        });

        var cars = _db.Cars.ToList();

        var cM = new CarsViewModel
        {
            ListofCar = carList
        };

        var modelTuple = (cM, vm);

        ViewBag.ListofCars = carList;

        return View(modelTuple);
    }

	public IActionResult DetailingAdminPanel()
	{
        var services = _db.Services.
            Where(s => s.TypeId == 3)
            .ToList();
        var vm = new ServicesViewModel
        {
            Services = services
        };

        var carList = (from car in _db.Cars
                       select new SelectListItem
                       {
                           Text = car.CarName,
                           Value = car.Id.ToString()
                       }).ToList();

        carList.Insert(0, new SelectListItem()
        {
            Text = "Пожалуйста, выберите марку автомобиля!",
            Value = string.Empty
        });

        var cars = _db.Cars.ToList();

        var cM = new CarsViewModel
        {
            ListofCar = carList
        };

        var modelTuple = (cM, vm);

        ViewBag.ListofCars = carList;

        return View(modelTuple);
    }

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}