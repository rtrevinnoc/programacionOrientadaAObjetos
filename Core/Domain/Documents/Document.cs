using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using Core.Domain.Vendedores;

namespace Core.Domain.Documents
{
    public class Document
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public byte[] Content { get; set; } = Array.Empty<byte>();
        public string MimeType { get; set; } = MediaTypeNames.Application.Pdf;

        // Relación con Vendedor (propiedad de navegación)
        public Vendedor? Owner { get; set; }   // El "?" permite nulo si aún no hay dueño
        public Guid OwnerId { get; set; }      // FK para la base de datos

        // Comparación lógica de igualdad
        public override bool Equals(object? obj)
        {
            if (obj is not Document document)
                return false;

            // Compara por Id (recomendado) o por Owner si lo deseas
            return Id.Equals(document.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
