using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoBancos
{
    class LeituraConfiguração
    {
        public void gravarConfiguracao(ConfiguracaoServidores configuraçãoServidores)
        {
            StreamWriter writer = new StreamWriter("Configuração.txt", true);
            using (writer)
            {
                // Escreve uma nova linhas no final do arquivo
                writer.WriteLine("servidor: " + configuraçãoServidores.nomeServidor);
                writer.WriteLine("banco: " + configuraçãoServidores.nomeBanco);
                writer.WriteLine("usuario: " + configuraçãoServidores.usuario);
                writer.WriteLine("senha: " + configuraçãoServidores.senha);
                writer.WriteLine("BDEM: " + configuraçãoServidores.localizacaoEM);
            }
        }
        public ConfiguracaoServidores lerConfiguracao()
        {
            ConfiguracaoServidores configuracao = new ConfiguracaoServidores();
            StreamReader reader = new StreamReader("Configuração.txt", true);
            using (reader)
            {
                string linha;

                // Lê cada uma das linhas do arquivo
                var linhas = reader.ReadLine();

                while (linhas != null)
                {
                    // A linha possui a informação que procuro?
                    if (linhas.Contains("servidor:"))
                    {
                        // Sim. Então guarda a informação e abandona o loop
                        configuracao.nomeServidor = linhas.Replace("servidor:", "");
                        break;
                    }
                    else
                    if (linhas.Contains("banco: "))
                    {
                        // Sim. Então guarda a informação e abandona o loop
                        configuracao.nomeServidor = linhas.Replace("banco: ", "");
                        break;
                    }
                    else
                    if (linhas.Contains("usuario:"))
                    {
                        // Sim. Então guarda a informação e abandona o loop
                        configuracao.nomeServidor = linhas.Replace("usuario", "");
                        break;
                    }
                    else
                    if (linhas.Contains("senha:"))
                    {
                        // Sim. Então guarda a informação e abandona o loop
                        configuracao.nomeServidor = linhas.Replace("senha", "");
                        break;
                    }
                    linhass = reader.ReadLine();
                }
            }
            return configuracao;
        }
    }
}
