namespace WebApi.Mapping.Resources.Documents;

public class DocumentResource
{
    public required Guid Id { get; set; }
    public string Name { get; set; }
    public byte[] Content { get; set; }
    public string MimeType { get; set; }
    // public string OwnerId { get; set; }
}