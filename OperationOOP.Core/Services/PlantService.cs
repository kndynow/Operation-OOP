using System;

namespace OperationOOP.Core.Services;

//Defining contract for plant CRUD operations
public interface IPlantService
{
    void Create(Plant plant);
    Plant Update(Plant updatePlant);
    List<Plant> GetAll();
    Plant GetById(int id);
    void Delete(int id);
}

//Handles basic CRUD operations for plants (Repository Pattern)
public class PlantService : IPlantService
{
    //DI for database access through constructor
    private readonly IDatabase _database;

    public PlantService(IDatabase database)
    {
        _database = database;
    }

    //CRUD operations, can handle any type derived from Plant
    //Add plant
    public void Create(Plant plant)
    {
        plant.Id = _database.Plants.Any() ? _database.Plants.Max(plant => plant.Id) + 1 : 1;
        _database.Plants.Add(plant);
    }

    //Get all plants
    public List<Plant> GetAll() => _database.Plants.ToList();

    //Get plants by ID
    public Plant GetById(int id)
    {
        var plant = _database.Plants.FirstOrDefault(p => p.Id == id);
        return plant;
    }

    //Update plant
    public Plant Update(Plant updatedPlant)
    {
        //Get existing plant by ID
        var existingPlant = _database.Plants.FirstOrDefault(p => p.Id == updatedPlant.Id);
        //Check that existing plant isn't null and update fields
        if (existingPlant != null)
        {
            existingPlant.Name = updatedPlant.Name;
            existingPlant.CareLevel = updatedPlant.CareLevel;

            return existingPlant;
        }
        return null;
    }

    //Delete plant from database using ID
    public void Delete(int id)
    {
        var plant = GetById(id);
        if (plant != null)
        {
            _database.Plants.Remove(plant);
        }
    }
}
