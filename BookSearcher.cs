using System;
using System.Text.Json;

namespace CSharpLibrary;

public class BookSearcher
{

    //Call API
    public async Task SearchBook()
    {
        using HttpClient client = new HttpClient();

        string url = "https://openlibrary.org/search.json?q=harry+potter";

        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseBody);
            string json = await response.Content.ReadAsStringAsync();
            BookApiSearchResults? result = JsonSerializer.Deserialize<BookApiSearchResults>(json);
            if (result?.docs is { Count: > 0 } docs)
            {
                Console.WriteLine(result.docs[0].title);
                Console.WriteLine(result.docs[1].title);
                Console.WriteLine(result.docs[2].title);
            }

        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
        }
    }

    //Return list

    //Choose from list
}
