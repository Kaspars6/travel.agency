using System;

class TravelAgency
{
    // Private fields to store the name of the agency and the available seats
    private string _name;
    private int _availableSeats;
    private string _transportType;
    private bool _isMaintained; 

    // Constructor method to initialize the TravelAgency object with a name and available seats
    public TravelAgency(string name,string transportType,int availableSeats,bool isMaintained)
    {
        // Initialize the name and available seats fields and transport type
        _name = name;
        _transportType = transportType;
        _availableSeats = availableSeats;
        _isMaintained = isMaintained;
    }
        public void PrintParameters()
    {
        Console.WriteLine("Travel Agency Parameters:");
        Console.WriteLine("Name: " + _name);
        Console.WriteLine("Available Seats: " + _availableSeats);
        Console.WriteLine("Transport Type: " + _transportType);
        Console.WriteLine("Maintained: " + (_isMaintained ? "Yes" : "No"));
    }

    // Method to start the booking process
    public void StartBookingProcess()
    {
        // Get the number of bookings from the user
        int numberOfBookings = GetNumberOfBookings();

        // If the user enters 0, no bookings are needed, so exit the method
        if (numberOfBookings <= 0)
        {
            Console.WriteLine("OK, no bookings needed.");
            return;
        }

        // Get the total number of successful bookings and total seats booked
        int successfulBookings = MakeBookings(numberOfBookings);
        int totalSeatsBooked = GetTotalSeatsBooked();

        // Display the summary of bookings made
        DisplaySummary(successfulBookings, totalSeatsBooked);
    }

    // Method to get the number of bookings from the user
    public int GetNumberOfBookings()
    {
        Console.Write("How many bookings would you like to make? ");
        return Convert.ToInt32(Console.ReadLine());
    }

    // Method to get the current available seats
    public int GetAvailableSeats()
    {
        return _availableSeats;
    }

    // Method to get the name from the user
    public string GetName()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.Write("Enter your surname: ");
        string surname = Console.ReadLine();
        return name + " " + surname;
    }

    // Method to get the age from the user
    public int GetAge()
    {
        Console.Write("Enter your age: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    // Method to make bookings based on the number provided
    public int MakeBookings(int numberOfBookings)
    {
        int successfulBookings = 0;

        for (int i = 0; i < numberOfBookings; i++)
        {
            int availableSeats = GetAvailableSeats();

            // If no seats available, stop making further bookings
            if (availableSeats <= 0)
            {
                Console.WriteLine("\nBooking " + (i + 1) + ": Sorry, all seats are booked.");
                break;
            }

            // Get the number of seats for this booking
            int seats = GetSeatsForBooking(availableSeats);

            // Book seats if available
            bool booked = BookSeats(seats);
            if (booked)
            {
                Console.WriteLine("\nBooking " + (i + 1) + ": Seats booked successfully!");
                successfulBookings++;
            }
            else
            {
                Console.WriteLine("\nBooking " + (i + 1) + ": Not enough seats available!");
                break;
            }
        }

        return successfulBookings;
    }

    // Method to get the number of seats for a booking
    public int GetSeatsForBooking(int availableSeats)
    {
        int seats = 0;
        while (seats <= 0 || seats > availableSeats)
        {
            Console.WriteLine("\nEnter the number of seats for this booking (Available seats: " + availableSeats + "): ");
            seats = Convert.ToInt32(Console.ReadLine());
            if (seats > availableSeats)
            {
                Console.WriteLine("Sorry, not enough seats available.");
            }
        }
        return seats;
    }

    // Method to book seats
    public bool BookSeats(int seats)
    {
        // Check if there are enough available seats
        if (seats > _availableSeats)
        {
            return false;
        }

        // Book the seats
        _availableSeats -= seats;
        return true;
    }

    // Method to get the total seats booked
    public int GetTotalSeatsBooked()
    {
        return 200 - _availableSeats; // Assuming total seats are 200
    }

    // Method to display the summary of bookings made
    public void DisplaySummary(int successfulBookings, int totalSeatsBooked)
    {
        Console.WriteLine("Available Seats after Booking: " + _availableSeats);
        Console.WriteLine("\nTotal successful bookings made: " + successfulBookings);
        Console.WriteLine("Total seats booked: " + totalSeatsBooked);
    }
}
