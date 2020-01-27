using IntegracaoBancos.Configuracao;
using System;
using System.Collections.Generic;

namespace IntegracaoBancos
{
    public class ProcessoEntradaBancoEM
    {
        private void InserirRegistro(List<RegistroEntrada> registroEntradas, MapeadorDadosEM InserirDados, UltimoRegistro ultimoRegistro)
        {
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
                    ultimoRegistro.UltimoRegistroAcesso(registro);
                }
            }
        }

        public void BuscarPorUltimoRegistro(MapeadorDadosSql DadosBuscados, MapeadorDadosEM mapeadorDadosEM, UltimoRegistro ultimoRegistro)
        {
            List<RegistroEntrada> registroEntradas = DadosBuscados.BuscaRegistroPeloUltimo(ultimoRegistro.LerRegistro());
            InserirRegistro(registroEntradas, mapeadorDadosEM, ultimoRegistro);
        }
        public void BuscarPorDia(MapeadorDadosSql DadosBuscados, MapeadorDadosEM mapeadorDadosEM, UltimoRegistro ultimoRegistro)
        {
            List<RegistroEntrada> registroEntradas = DadosBuscados.BuscaRegistroPorDia();
            InserirRegistro(registroEntradas, mapeadorDadosEM, ultimoRegistro);
        }

    }
}
