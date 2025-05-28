namespace EventRegistration.Model;

public class Event
{
    // Event class attributes
    public String name { get; set; }
    public DateTime startData { get; set; }
    public DateTime endData { get; set; }
    public int numberOfAttendees { get; set; }
    public string location { get; set; }
    public double pricePerAttendee { get; set; }
    public double custPerDayForEachAttendee { get; set; }
    public string totalPriceFromEvent => TotalPriceFromEvent();

    // Constructor from Event class
    public Event(string name, DateTime startData, DateTime endData, int numberOfAttendees, string location, double pricePerAttendee, double custPerDayForEachAttendee)
    {
        // Validate parameters using a tuple array
        var parameters = new (object value, String paramName, String ErrorMesage)[]
        {
            (name,nameof(name), "Name cannot be null or empty"),
            (startData, nameof(startData), "Start date cannot be in the past"),
            (endData, nameof(endData), "End date cannot be in the past"),
            (numberOfAttendees, nameof(numberOfAttendees), "Number of attendees must be greater than 0"),
            (location, nameof(location), "Location cannot be null or empty"),
            (pricePerAttendee, nameof(pricePerAttendee), "Price per attendee must be greater than or equal to 0"),
            (custPerDayForEachAttendee, nameof(custPerDayForEachAttendee), "Cost per day for each attendee must be greater than or equal to 0")
        };

        // Check if parameters are valid
        foreach (var (value, paramName, errorMessage) in parameters)
        {
            if (value is null ||
               (value is DateTime d && d == default) ||
               (value is int i && i <= 0) ||
               (value is double db && db <= 0))
            {
                throw new ArgumentException(errorMessage, paramName);
            }
        }

        this.name = name;
        this.startData = startData;
        this.endData = endData;
        this.numberOfAttendees = numberOfAttendees;
        this.location = location;
        this.pricePerAttendee = pricePerAttendee;
        this.custPerDayForEachAttendee = custPerDayForEachAttendee;
    }

    public int TotalDaysOfTheEvent()
    {
        // Calculate the total days of the event
        TimeSpan interval = endData - startData;

        return interval.Days + 1;

    }

    public string totalDaysFormatted
    {
        // Format the total days of the event
        get => TotalDaysOfTheEvent().ToString() + "dias";
    }

    public string dataStartEvent
    {
        // Format the start date of the event
        get => this.startData.ToString("dd/MM/yyyy");
    }

    public string dataEndEvent
    {
        // Format the end date of the event
        get => this.endData.ToString("dd/MM/yyyy");
    }

    public string TotalPriceFromEvent()
    {
        // Calculate the total price from the event
        double totalPrice = (TotalDaysOfTheEvent() * this.numberOfAttendees * this.custPerDayForEachAttendee);

        return totalPrice.ToString("C", new System.Globalization.CultureInfo("pt-BR"));
    }
}

