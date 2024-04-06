using cw5.Validators;
using cw5.Models;
using cw5.Database;

namespace cw5.Endpoints;

public static class AnimalMappings
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        app.MapGet("/animals", (MockDb db) =>
        {
            List<Animal> animals = db.Animals;

            return Results.Ok(animals);
        });
        app.MapGet("/animals/{id}", (int id, MockDb db) =>
        {
            var animal = db.Animals.FirstOrDefault(a => a.id == id);

            return animal is not null
                ? Results.Ok(animal)
                : Results.NotFound();
        });

        app.MapPost("/animals", (Animal newAnimal, MockDb db) =>
        {
            if (db.Animals.Any(a => a.id == newAnimal.id))
            {
                return Results.Conflict("An animal with this ID already exists");
            }

            var errors = AnimalValidator.Validate(newAnimal).ToList();

            if (errors.Any())
            {
                return Results.BadRequest(errors);
            }

            db.Animals.Add(newAnimal);
            return Results.Created($"/animals/{newAnimal.id}", newAnimal);
        });

        app.MapPut("/animals/{id}", (int id, Animal updatedAnimal, MockDb db) =>
        {
            var animalToUpdate = db.Animals.FirstOrDefault(a => a.id == id);

            if (animalToUpdate == null)
            {
                return Results.NotFound("Cannot find animal with this id");
            }

            var animalConflict = db.Animals.FirstOrDefault(a => a.id == updatedAnimal.id && a.id != id);

            if (animalConflict != null)
            {
                return Results.Conflict("There already is record with id you try to update to.");
            }

            var errors = AnimalValidator.Validate(updatedAnimal).ToList();

            if (errors.Any())
            {
                return Results.BadRequest(errors);
            }

            db.Animals[db.Animals.IndexOf(animalToUpdate)] = updatedAnimal;
            return Results.Created($"/animals/{updatedAnimal.id}", updatedAnimal);
        });

        app.MapDelete("/animals/{id}", (int id, MockDb db) =>
        {
            var animalToDelete = db.Animals.FirstOrDefault(a => a.id == id);

            if (animalToDelete == null)
            {
                return Results.NotFound("Cannot find animal with this id");
            }

            db.Animals.Remove(animalToDelete);
            return Results.NoContent();
        });
    }
}
