namespace WebApi.Mapping.Resources.Documents;

public class SaveDocumentResource
{
    public string Name { get; set; }
    public byte[] Content { get; set; }
    public string MimeType { get; set; }
}