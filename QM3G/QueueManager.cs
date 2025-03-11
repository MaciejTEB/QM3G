namespace QM3G
{
    public class QueueManager
    {
        private Queue<Person> queue = new();
        private List<Window> windows = new();
        private int ticketCouter = 1;

        private string[] serviceTypes = { "Dowody", "Paszporty", "Podatki", "Donosy" };
        private string[] names = { "Jan Kowalski", "Anna Nowak", "Bolesław Chrobry" };

        public QueueManager() 
        {
            foreach (var type in serviceTypes)
            {
                windows.Add(new Window(type));  
            }
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n Kolejka w urzędzie");
                Console.WriteLine("1. Dodaj osobę do kolejki");
                Console.WriteLine("2. Obsłuż osobę");
                Console.WriteLine("3. Wyświetl kolejkę");
                Console.WriteLine("4. Zamknij program");

                Console.Write("Wybierz opcję: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPersonToQueue();
                        break;
                    case "2":
                        ServeNextPerson();
                        break;
                    case "3":
                        DisplayQueue();
                        break;
                    case "4":
                        return;
                }
            }

        }

        public void AddPersonToQueue()
        {
            Random rnd = new Random();
            string name = names[rnd.Next(names.Length)];
            string service = serviceTypes[rnd.Next(serviceTypes.Length)];
            Person newPerson = new(name, service, ticketCouter++);
            queue.Enqueue(newPerson);
            Console.WriteLine($"Dodano do kolejki: {newPerson.ToString()}");

        }

        public void ServeNextPerson()
        {
            if(queue.Count == 0)
            {
                Console.WriteLine("Brak osób w kolejce!");
                return;
            }

            Person nextPerson = queue.Dequeue();
            Window freeWindow = windows.FirstOrDefault(w => w.ServiceType == nextPerson.ServiceType && w.IsAvailable);   
            
            if(freeWindow != null)
            {
                freeWindow.StartService(nextPerson);
                
            } else
            {
                Console.WriteLine($"Wszystkie okienka dla {nextPerson.ServiceType} są zajęte!");
                queue.Enqueue(nextPerson);
            }

        }

        public void DisplayQueue()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Brak osób w kolejce!");
                
            } else
            {
                Console.WriteLine("Lista oczekujących:");
                foreach(var person in queue)
                {
                    Console.WriteLine(person.ToString());
                }
            }

            Console.WriteLine("\nStatus okienek");
            foreach(var window in windows)
            {
                Console.WriteLine($"{window.ServiceType}: {(window.IsAvailable ? "WOLNE" : "ZAJĘTE")}");
            }
        }
    }
}
