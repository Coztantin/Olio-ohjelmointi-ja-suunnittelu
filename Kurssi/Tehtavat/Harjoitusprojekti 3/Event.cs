using System;

namespace Harjoitusprojekti3
{
    class Event : IComparable<Event>
    {
        public string Id;
        public string Title;
        public DateTime Start;
        public int DurationMinutes;
        public EventType Type;
        public EventStatus Status;

        //Konstruktori... 
        public Event(string id, string title, DateTime start,
                     int durationMinutes, EventType type, EventStatus status)
        {
            Id = id;
            Title = title;
            Start = start;
            DurationMinutes = durationMinutes;
            Type = type;
            Status = status;
        }

        public int CompareTo(Event? other)
        {
            // TODO: - DONE
            // 1) Järjestä Start-ajan mukaan
            // 2) Jos sama Start, järjestä Title aakkosjärjestykseen
            // Toimii kuten pitää...
            int timeCompare = this.Start.CompareTo(other.Start);
            if (timeCompare != 0)
            {
                return timeCompare;
            }

            return this.Title.CompareTo(other.Title);
        }

        //Tulostus metodi... hieman muokattu luettavuuden takia... lisätty taulukkomainen rakenne.
        public override string ToString()
        {
            return string.Format("{0,-15} {1,-20} {2,-25} {3,-15} {4,-15} {5,-15}",
                    Id,
                    "| " + Title,
                    "| " + Start,
                    "| " + DurationMinutes + " min",
                    "| " + Type,
                    "| " + Status
                    );
        }

        public static void Headers()
        {
            //Taulukkomuotoilu metodi. tulostaa otsikkorivin, jotta taulukko on siisti
            Console.WriteLine("");
            Console.WriteLine("{0,-15} {1,-20} {2,-25} {3, -15} {4,-15} {5,-15}",
                "ID",
                "| " + "Title",
                "| " + "Start Time",
                "| " + "Duration",
                "| " + "Type",
                "| " + "Status"
                 );
            Console.WriteLine(new string('-', 115));
        }
        
    }
}