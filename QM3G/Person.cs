namespace QM3G
{
    public class Person
    {
        public string Name { get; set; }
        public string ServiceType  { get; set; }
        public int TicketNumber { get; set; }

        public Person(string name, string serviceType, int ticketNumber) 
        {
            Name = name;
            ServiceType = serviceType;
            TicketNumber = ticketNumber;
        }

        public override string ToString()
        {
            return $"{TicketNumber}: {Name} - {ServiceType}";
        }

    }
}