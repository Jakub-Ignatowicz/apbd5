using cw5.Models;

namespace cw5.Database;

public class MockDb
{
    public List<Animal> Animals { get; set; } = new List<Animal>();
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    public MockDb()
    {
        Animals.Add(new Animal { id = 1, firstname = "Fluffy", category = "Cat", weight = 5, furcolor = "White" });
        Animals.Add(new Animal { id = 2, firstname = "Buddy", category = "Dog", weight = 10, furcolor = "Brown" });
        Animals.Add(new Animal { id = 3, firstname = "Snowball", category = "Rabbit", weight = 2, furcolor = "Grey" });
        Animals.Add(new Animal { id = 4, firstname = "Whiskers", category = "Cat", weight = 4, furcolor = "Black" });

        Appointments.Add(new Appointment
        {
            date = DateTime.Today,
            animal = Animals[0],
            description = "Appointment 1 description",
            price = 50
        });

        Appointments.Add(new Appointment
        {
            date = DateTime.Today.AddDays(1),
            animal = Animals[1],
            description = "Appointment 2 description",
            price = 60
        });

        Appointments.Add(new Appointment
        {
            date = DateTime.Today.AddDays(2),
            animal = Animals[2],
            description = "Appointment 3 description",
            price = 70
        });

        Appointments.Add(new Appointment
        {
            date = DateTime.Today.AddDays(3),
            animal = Animals[3],
            description = "Appointment 4 description",
            price = 80
        });

        Appointments.Add(new Appointment
        {
            date = DateTime.Today.AddDays(4),
            animal = Animals[0],
            description = "Appointment 5 description",
            price = 90
        });

    }
}
