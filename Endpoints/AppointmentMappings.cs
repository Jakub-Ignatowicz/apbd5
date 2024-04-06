using cw5.Validators;
using cw5.Models;
using cw5.Database;

namespace cw5.Endpoints;

public static class AppointmentMappings
{
    public static void MapAppointmentEndpoints(this WebApplication app)
    {
        app.MapGet("/appointments", (MockDb db) =>
        {
            List<Appointment> appointments = db.Appointments;

            return Results.Ok(appointments);
        });

        app.MapPost("/appointments", (Appointment newAppointment, MockDb db) =>
        {
            var errors = AppointmentValidator.Validate(newAppointment).ToList();

            if (errors.Any())
            {
                return Results.BadRequest(errors);
            }

            db.Appointments.Add(newAppointment);
            return Results.Created($"/appointments", newAppointment);
        });

    }
}
