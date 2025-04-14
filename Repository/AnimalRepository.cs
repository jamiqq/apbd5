using Clinic.Model;

namespace Clinic.Repository;

public class AnimalRepository
{
    public static List<Animal> animals = new List<Animal>
    {
        new Animal { Id = 1, Name = "Avcharka", Category = "Dog", Weight = 23.2, FulColor = "Brown" },
        new Animal { Id = 2, Name = "Sfinx", Category = "Cat", Weight = 3.4, FulColor = "Grey" },
    };
}