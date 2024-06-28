using System;

class MainClass
{
    public static void Main(string[] args)
    {
        TravelAgency agency = new TravelAgency("TravelCo", "Airplane" , 200 , true);
        // Get number of bookings
        int numberOfBookings = agency.GetNumberOfBookings();
        if (numberOfBookings <= 0)
        {
            Console.WriteLine("OK, no bookings needed.");
            return;
        }

        // Get name
        string fullName = agency.GetName();

        // Get age
        int age = agency.GetAge();

        // Make bookings
        int successfulBookings = agency.MakeBookings(numberOfBookings);

        // Get total seats booked
        int totalSeatsBooked = agency.GetTotalSeatsBooked();

        // Display summary
        agency.DisplaySummary(successfulBookings, totalSeatsBooked);

        // Display name, surname, and age
        Console.WriteLine("Name: " + fullName);
        Console.WriteLine("Age: " + age);
    }
}
