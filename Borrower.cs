using System;

namespace CSharpLibrary;

public class Borrower
{
    public string? UserName { get; set; }
    public int UserId { get; set; }

    public int BookMax=3;
    public List<Book>? CurrentBooks;
    public int CurrentNumberOfBooks = 0;


}
