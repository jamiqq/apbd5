using Clinic.Model;
using Clinic.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controller;

[ApiController]
[Route("api/clinic")]
public class ClinicController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllAnimals()
    {
        return Ok(AnimalRepository.animals);
    }

    [HttpGet("{id}")]
    public IActionResult GetAnimalById(int id)
    {
        var animal = AnimalRepository.animals.FirstOrDefault(x => x.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        animal.Id = AnimalRepository.animals.Count + 1;
        AnimalRepository.animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, Animal updatedAnimal)
    {
        var animal = AnimalRepository.animals.FirstOrDefault(x => x.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        animal.Name = updatedAnimal.Name;
        animal.Category = updatedAnimal.Category;
        animal.Weight = updatedAnimal.Weight;
        animal.FulColor = updatedAnimal.FulColor;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = AnimalRepository.animals.FirstOrDefault(x => x.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        AnimalRepository.animals.Remove(animal);
        return NoContent();
    }

    [HttpGet("{id}/visits")]
    public IActionResult GetVisitById(int id)
    {
        var animal = AnimalRepository.animals.FirstOrDefault(x => x.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        var visits = VisitRepository.Visits.Where(x => x.AnimalId == id).ToList();
        return Ok(visits);
    }

    [HttpPost("{id}/visits")]
    public IActionResult AddVisit(int id, Visit visit)
    {
        var animal = AnimalRepository.animals.FirstOrDefault(x => x.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        visit.AnimalId = id;
        VisitRepository.Visits.Add(visit);
        
        return Ok(visit);
    }
}