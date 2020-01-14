using ControleEntreDoisBanco;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMCatraca.ConecaoSQL
{
    class MapeadorDadosEM
    {
        public void GravarDados(RegistroEntrada registroEntrada)
        {
            int Id = registroEntrada.Id;
            int Matricula = registroEntrada.Matricula;
            DateTime Horario = registroEntrada.Horario;
            char Sentido = registroEntrada.Sentido == 1?  'E' : 'S';
            using (StreamWriter writer = new StreamWriter("RegistroCatraca.txt"))
            {
                writer.Write($"{Id.ToString()} - {Matricula.ToString()} - {Horario.ToString()} - {Sentido}");
            }
        }
    }
}
