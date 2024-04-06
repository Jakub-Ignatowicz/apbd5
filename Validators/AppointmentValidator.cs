using cw5.Models;

namespace cw5.Validators;

public class AppointmentValidator
{
    public static IEnumerable<string> Validate(Appointment appointment)
    {
        if (appointment.price < 0)
        {
            yield return "Appointments price has to be greater or equal to 0";
        }

        var errors = AnimalValidator.Validate(appointment.animal).ToList();

        if (errors.Any())
        {
            foreach (var error in errors)
            {
                yield return error;
            }
        }

        if (appointment.description.Length == 0)
        {
            yield return "Appointments description cannot be blank";
        }
    }
}

