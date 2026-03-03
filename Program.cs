using System.Text.Json;

namespace CSharpLibrary;

class Program
{
    static async Task Main(string[] args)
    {

        //Todo:
        // 1. Create borrower Class (Name, id, bookMax, currentBooks)
        // 2. Create Library
        // 3. Create Book Class
        // 4. Find api for book search
        // 5. Add book to library
        // 6.

        Dictionary<string, string> filePaths = new Dictionary<string, string>
        {
            ["pathSettings"] = Path.Combine(AppContext.BaseDirectory, "Settings.json"),
            ["pathBookDB"] = Path.Combine(AppContext.BaseDirectory, "BookDB.json"),
            ["pathBorrowerDB"] = Path.Combine(AppContext.BaseDirectory, "BorrowerDB.json"),
            ["pathLog"] = Path.Combine(AppContext.BaseDirectory, "log.txt")
        };

        List<Borrower>? borrowerDB;
        Dictionary<int, Book>? bookDB;
        Dictionary<string, int>? settings;

        // Loading settings:
        if (!File.Exists(filePaths["pathSettings"]))
        {
            settings = new Dictionary<string, int>
            {
                ["nextUserId"] = 100,

            };

            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePaths["pathSettings"], json);

        }
        else
        {
            settings = JsonSerializer.Deserialize<Dictionary<string, int>>(File.ReadAllText(filePaths["pathSettings"]));
        }

        // READING AND CREATING USERS
        if (!File.Exists(filePaths["pathBorrowerDB"]))
        {
            borrowerDB = new List<Borrower>();

            string json = JsonSerializer.Serialize(borrowerDB, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePaths["pathBorrowerDB"], json);

        }
        else
        {
            borrowerDB = JsonSerializer.Deserialize<List<Borrower>>(File.ReadAllText(filePaths["pathBorrowerDB"]));
        }

        // READING AND CREATING Books
        if (!File.Exists(filePaths["pathBookDB"]))
        {
            bookDB = new Dictionary<int, Book>();

            string json = JsonSerializer.Serialize(bookDB, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePaths["pathBookDB"], json);

        }
        else
        {
            bookDB = JsonSerializer.Deserialize<Dictionary<int, Book>>(File.ReadAllText(filePaths["pathBookDB"]));
        }

        // CREATING LOG:
        if (!File.Exists(filePaths["pathLog"]))
        {
            File.WriteAllText(filePaths["pathLog"], "");
        }


        BookSearcher BS = new BookSearcher();
        await BS.SearchBook();
    }
}
