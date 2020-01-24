using System;

namespace IntegracaoBancos
{
    public class RegistroEntrada
    {
        public int Id { get; set; }
        public int? Matricula { get; set; }
        public DateTime Horario { get; set; }
        public int? Sentido { get; set; }
    }
}