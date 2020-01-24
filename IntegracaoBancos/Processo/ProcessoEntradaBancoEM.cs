using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoBancos
{
    public class ProcessoEntradaBancoEM
    {
        private void InserirRegistro(List<RegistroEntrada> registroEntradas)
        {
            MapeadorDadosEM InserirDados = new MapeadorDadosEM();
            if (registroEntradas.Count != 0)
            {
                foreach (var registro in registroEntradas)
                {
                    if (InserirDados.ConsultaAluno(registro.Matricula.Value))
                    {
                        InserirDados.RegistraEntrada(registro);
                    }
                    char? sentido;
                    if (registro.Sentido == 1)
                    {
                        sentido = 'E';
                    }
                    else
                    {
                        if (registro.Sentido == 2)
                        {
                            sentido = 'S';
                        }
                        else
                        {
                            sentido = null;
                        }
                    }
                    Console.WriteLine($"{registro.Id} - {registro.Matricula} - {registro.Horario.ToString()} - {sentido} ");
                    new LeituraConfiguração().UltimoRegistro(registro.Id);
                }
            }
        }

        public void BuscarPorUltimoRegistro()
        {
            var ultimoRegistro = new LeituraConfiguração().lerRegistro();
            var DadosBuscados = new MapeadorDadosSql();
            List<RegistroEntrada> registroEntradas = DadosBuscados.BuscaRegistroPeloUltimo(ultimoRegistro);
            InserirRegistro(registroEntradas);
        }
        public void BuscarPorDia()
        {
            var DadosBuscados = new MapeadorDadosSql();
            List<RegistroEntrada> registroEntradas = DadosBuscados.BuscaRegistroPorDia();
            InserirRegistro(registroEntradas);
        }

    }
}
