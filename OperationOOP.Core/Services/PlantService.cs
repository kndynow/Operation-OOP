using System;

namespace OperationOOP.Core.Services;

// Interface defenition to handle different kinds of plants
public interface IPlantService
{
    void Create(Plant plant);
    Plant Update(Plant updatePlant);
    List<Plant> GetAll();
    Plant GetById(int id);
    void Delete(int id);
}

//PlantService handles basic CRUD operations for plants
public class PlantService : IPlantService
{
    //Dependency Injection for database
    private readonly IDatabase _database;

    public PlantService(IDatabase database)
    {
        _database = database;
    }

    //CRUD operations
    public void Create(Plant plant)
    {
        plant.Id = _database.Plants.Any() ? _database.Plants.Max(plant => plant.Id) + 1 : 1;
        _database.Plants.Add(plant);
    }

    public List<Plant> GetAll() => _database.Plants.ToList();

    public Plant GetById(int id)
    {
        var plant = _database.Plants.FirstOrDefault(p => p.Id == id);
        return plant;
    }

    public Plant Update(Plant updatedPlant)
    {
        var existingPlant = _database.Plants.FirstOrDefault(p => p.Id == updatedPlant.Id);

        if (existingPlant != null)
        {
            existingPlant.Name = updatedPlant.Name;
            existingPlant.CareLevel = updatedPlant.CareLevel;

            return existingPlant;
        }
        return null;
    }

    public void Delete(int id)
    {
        var plant = GetById(id);
        if (plant != null)
        {
            _database.Plants.Remove(plant);
        }
    }
}
