using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Documents;

namespace Core.Domain.Vendedores
{
    public class Vendedor
    {
        public required Guid Id { get; set; }
        public required string Nombre { get; set; }
        public string? Sexo { get; set; }
        public string? RFC { get; set; }
        public string? Correo { get; set; }
        public int? Telefono { get; set; }
        public string? ZonaDeVenta { get; set; }
        public decimal? VentasTotales { get; set; }
        public List<Document> Documentos { get; set; } = new List<Document>();
        public virtual TipoVendedor TipoVendedor { get; set; }
    }

    public enum TipoVendedor
    {
        Junior,
        Senior,
        Supervisor
    }
}
