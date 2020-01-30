using IntegracaoBancos.Configuracao;
using System;
using System.Collections.Generic;

namespace IntegracaoBancos
{
    public class ProcessoEntradaBancoEM
    {
        private UltimoRegistro _ultimoRegistro;
        public ProcessoEntradaBancoEM()
        {
            _ultimoRegistro = new UltimoRegistro();
        }
        public void InserirRegistro(List<RegistroEntrada> registroEntradas, MapeadorDadosEM InserirDados)
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
                }
            }
        }

        public List<RegistroEntrada> BuscarPorUltimosRegistros(MapeadorDadosSql DadosBuscados)
        {
            return DadosBuscados.BuscaRegistroPeloUltimo(_ultimoRegistro.LerRegistro());
        }
        public List<RegistroEntrada> BuscarPorDia(MapeadorDadosSql DadosBuscados, DateTime dateTime)
        {
            return DadosBuscados.BuscaRegistroPorDia(dateTime);
        }
        public void RegistraUltimoRegistro(RegistroEntrada registroEntrada)
        {
            _ultimoRegistro.UltimoRegistroAcesso(registroEntrada.Id);
        }
    }
}
