namespace net_ef_videogame
;

class Program
{
    static void Main(string[] args)
    {
        VideogameManager manager = new VideogameManager();
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Inserisci nuovo videogioco");
            Console.WriteLine("2. Ricerca videogioco per ID");
            Console.WriteLine("3. Ricerca videogiochi per nome");
            Console.WriteLine("4. Cancella videogioco");
            Console.WriteLine("5. Inserisci nuova software house");
            Console.WriteLine("6. Ricerca videogiochi della softwarehouse");
            Console.WriteLine("7. Chiudi programma");
            Console.Write("Seleziona un'opzione: ");
            int option;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Opzione non valida. Riprova.");
                continue;
            }

            switch (option)
            {
                case 1:
                    Console.Write("Inserisci il nome del videogioco: ");
                    string? gameName = Console.ReadLine();
                    Console.Write("Inserisci la descrizione del videogioco: ");
                    string? gameOverview = Console.ReadLine();
                    Console.Write("Inserisci la data di rilascio del videogioco: ");
                    string releaseDate = Console.ReadLine();
                    Console.Write("Inserisci l'ID della software house: ");
                    int softwareHouseId;
                    while (!int.TryParse(Console.ReadLine(), out softwareHouseId))
                    {
                        Console.Write("ID non valido. Inserisci un numero intero: ");
                    }
                    Videogame newGame = new Videogame
                    {
                        Name = gameName,
                        Overview = gameOverview,
                        ReleaseDate = DateTime.Parse(releaseDate),
                        SoftwareHouseId = softwareHouseId
                    };
                    manager.InsertVideogame(newGame);
                    Console.WriteLine("Gioco inserito con successo");
                    break;
                case 2:
                    Console.Write("Inserisci l'ID del videogioco: ");
                    int id;
                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.Write("ID non valido. Inserisci un numero intero: ");
                    }
                    Videogame foundGame = manager.GetVideogameById(id);
                    if (foundGame != null)
                    {
                        Console.WriteLine(foundGame);
                    }
                    else
                    {
                        Console.WriteLine("Videogioco non trovato.");
                    }
                    break;
                case 3:
                    Console.Write("Inserisci il nome del videogioco da cercare: ");
                    string? searchName = Console.ReadLine();
                    var results = manager.SearchVideogamesByName(searchName);
                    if (results.Count > 0)
                    {
                        foreach(var game in results)
                        {
                            Console.WriteLine("Videogiochi trovati: ");
                            Console.WriteLine(game);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nessun videogioco trovato.");
                    }
                    break;
                case 4:
                    Console.Write("Inserisci l'ID del videogioco da cancellare: ");
                    int deleteId;
                    while (!int.TryParse(Console.ReadLine(), out deleteId))
                    {
                        Console.Write("ID non valido. Inserisci un numero intero: ");
                    }
                    manager.DeleteVideogame(deleteId);
                    Console.WriteLine("Videogioco eliminato con successo");
                    break;
                case 5:
                    Console.Write("Inserisci il nome della nuova software house: ");
                    string? softwareHouseName = Console.ReadLine();
                    SoftwareHouse softwareHouse = new SoftwareHouse { Name = softwareHouseName };
                    manager.InsertSoftwareHouse(softwareHouse);
                    Console.WriteLine("Software house aggiunta con successo");
                    break;
                case 6:
                    Console.Write("Inserisci l'ID della software di cui vuoi vedere i giochi: ");
                    int searchId;
                    while(!int.TryParse(Console.ReadLine(), out searchId))
                    {
                        Console.Write("ID non valido, inserisci un numero intero: ");
                    }
                    var games = manager.GetVideogamesBySoftwarehouseId(searchId);
                    if(games != null && games.Count > 0)
                    {
                        foreach (var game in games)
                        {
                            Console.WriteLine(game);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Nessun videogioco trovato per la Software house con ID {searchId}");
                    }
                    break;
                case 7:
                    running = false;
                    Console.WriteLine("Programma chiuso");
                    break;
                default:
                    Console.WriteLine("Opzione non valida");
                    break;
            }
        }
    }
}