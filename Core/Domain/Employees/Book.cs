using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Domain.Documents;

namespace Core.Domain.Library;

public class Book
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }

    public string? Author { get; set; }         
    public string? ISBN { get; set; }           
    public int? Pages { get; set; }             
    public string? PublisherEmail { get; set; } 

    public List<Document> Documents { get; set; } = new();

    public virtual BookType BookType { get; set; }
}

public enum BookType
{
    Textbook,
    Novel,
    Reference
}
