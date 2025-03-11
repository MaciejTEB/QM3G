namespace QM3G
{
    public class Window
    {
        public string ServiceType { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string CurrentClient { get; set; }

        public Window(string serviceType)
        {
            ServiceType = serviceType;
        }

        public void StartService(Person person)
        {
            if(IsAvailable)
            {
                IsAvailable = false;
                CurrentClient = person.Name;
                Console.WriteLine($"Okienko {ServiceType}  obsługuje teraz {CurrentClient}"); 
            } else
            {
                Console.WriteLine($"Okienko {ServiceType} jest zajęte.");
            }
        }

        public void FinishService()
        {
            if(!IsAvailable)
            {
                Console.WriteLine($"Okienko {ServiceType} zakończyło obsługę {CurrentClient}.");
                IsAvailable = true;
                CurrentClient = null;
            }
        }

    }
}

