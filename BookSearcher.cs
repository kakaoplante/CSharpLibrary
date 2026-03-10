using System;
using System.Text.Json;

namespace CSharpLibrary;

public class BookSearcher
{

    public List<BookApiBookInstance>? ListOfResults;

    //Call API
    public async Task SearchBook(string query)
    {
        using HttpClient client = new HttpClient();

        string url = $"https://openlibrary.org/search.json?q={query}";

        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseBody);
            string json = await response.Content.ReadAsStringAsync();
            BookApiSearchResults? result = JsonSerializer.Deserialize<BookApiSearchResults>(json);
            if (result?.docs is { Count: > 0 } docs)
            {
                ListOfResults = result.docs;
            }

        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
        }
    }

    //Return list

    //Choose from list
    public void ShowResults()
    {
        if (ListOfResults?.Count > 0)
        {
            foreach (var book in ListOfResults)
            {
                System.Console.WriteLine(book.title + " " + book.author_name?[0]);
            }
        }
        else
        {
            System.Console.WriteLine("no results to show");
        }
    }
}
