using cw5.Models;

namespace cw5.Validators;

public class AnimalValidator
{
    public static IEnumerable<string> Validate(Animal animal)
    {
        if (animal.id < 0)
        {
            yield return "Animals ID has to be greater or equal to 0";
        }

        if (string.IsNullOrWhiteSpace(animal.firstname))
        {
            yield return "Animals first name is required";
        }

        if (string.IsNullOrWhiteSpace(animal.category))
        {
            yield return "Animals category is required";
        }

        if (animal.weight <= 0)
        {
            yield return "Animals weight must be greater than zero";
        }

        if (string.IsNullOrWhiteSpace(animal.furcolor))
        {
            yield return "Animals ur color is required";
        }
    }
}

