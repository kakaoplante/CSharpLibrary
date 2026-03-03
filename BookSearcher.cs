using System;

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
            Console.WriteLine(responseBody);
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
        }
    }

    //Return list

    //Choose from list
}
