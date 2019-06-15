namespace DomainModel.Funza
{
    public class SubClient
    {
        public int Id { get; set; }

        public int FunzaId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Margen { get; set; }

        public bool Status { get; set; }

        public int ClientId { get; set; }

        public string ClientName { get; set; }
    }
}