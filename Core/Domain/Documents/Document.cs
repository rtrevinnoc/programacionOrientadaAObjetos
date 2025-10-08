using System;
using System.IO;
using System.Net.Mime;
using Core.Domain.Employees;

namespace Core.Domain.Documents;

public class Document
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public byte[] Content { get; set; }
    public string MimeType { get; set; } = MediaTypeNames.Application.Pdf;
    public Employee Owner { get; set; }
    public Guid OwnerId { get; set; }
}