namespace S02LaboratorioDSWI_01.Models
{
    public class Cliente
    {
        private String codigoCliente;
        private String nombreCliente;
        private String direccion;
        private String descripcionPais;
        private String telefono;

        public string CodigoCliente { get => codigoCliente; set => codigoCliente = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string DescripcionPais { get => descripcionPais; set => descripcionPais = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
