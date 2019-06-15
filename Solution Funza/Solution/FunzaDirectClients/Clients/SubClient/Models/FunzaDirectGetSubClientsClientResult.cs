using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.SubClient.Models
{
    public class FunzaDirectGetSubClientsClientResult
    {
        public int Id { get; set; }

        public int IdClient { get; set; }

        public int IdTercero { get; set; }

        public string Nombre { get; set; }
        
        public int IdPais { get; set; }

        public string NombrePais { get; set; }

        public int IdTipoTercero { get; set; }

        public string TipoTercero { get; set; }

        public string NombreCiudad { get; set; }

        public string IdentifTercero { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public int IdCiudad { get; set; }

        public bool AplicaIVA { get; set; }

        public bool AplicaRetefuente { get; set; }

        public string NombresPersona { get; set; }

        public int IdUsuario { get; set; }

        public string Fax { get; set; }

        public string PoBox { get; set; }

        public string ApellidosPersona { get; set; }

        public string Cargo { get; set; }

        public string AgenteRetenedor { get; set; }

        public decimal ValorIVA { get; set; }

        public int ValorRetencion { get; set; }

        public decimal BaseRetencion { get; set; }

        public int ComunidadEuropea { get; set; }

        public int IdPlazoPago { get; set; }

        public string PlazoPago { get; set; }

        public string FormaPago { get; set; }

        public decimal CupoCredito { get; set; }

        public decimal SaldoCupoCredito { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Clasificacioncliente { get; set; }

        public int DiasPago { get; set; }

        public int IdMoneda { get; set; }

        public bool AplicaCREE { get; set; }

        public bool DescuentaCreeFactura { get; set; }

        public IEnumerable<FunzaDirectGetQuoteSubClientResult> Clientes { get; set; }
    }
}
