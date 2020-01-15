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
                // Escreve uma nova linha no final do arquivo
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

                while ((linha = reader.ReadLine()) != null)
                {
                    // A linha possui a informação que procuro?
                    if (linha.Contains("servidor:"))
                    {
                        // Sim. Então guarda a informação e abandona o loop
                        configuracao.nomeServidor = linha.Replace("servidor:", "");
                    }
                    else
                    if (linha.Contains("banco: "))
                    {
                        // Sim. Então guarda a informação e abandona o loop
                        configuracao.nomeBanco = linha.Replace("banco: ", "");
                    }
                    else
                    if (linha.Contains("usuario:"))
                    {
                        // Sim. Então guarda a informação e abandona o loop
                        configuracao.usuario = linha.Replace("usuario", "");
                    }
                    else
                    if (linha.Contains("senha:"))
                    {
                        // Sim. Então guarda a informação e abandona o loop
                        configuracao.senha = linha.Replace("senha", "");
                    }
                    else
                    if (linha.Contains("BDEM:"))
                    {
                        // Sim. Então guarda a informação e abandona o loop
                        configuracao.localizacaoEM = linha.Replace("BDEM:", "");
                    }

                }
            }
            return configuracao;
        }
        public void UltimoRegistro(RegistroEntrada registroEntrada)
        {
            File.Delete("UltimoRegistro.txt");
            StreamWriter writer = new StreamWriter("UltimoRegistro.txt", true);
            using (writer)
            {
                writer.WriteLine(registroEntrada.Id.ToString());
            }
        }

        public int lerRegistro()
        {
            int idRegistro = 0;
            StreamReader reader = new StreamReader("UltimoRegistro.txt", true);
            using (reader)
            {
                string linha;

                while ((linha = reader.ReadLine()) != null)
                {
                    idRegistro = Convert.ToInt32(linha);
                }
            }
            return idRegistro;
        }
    }
}
