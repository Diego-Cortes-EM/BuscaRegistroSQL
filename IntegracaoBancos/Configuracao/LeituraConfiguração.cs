using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoBancos
{
    public class LeituraConfiguração
    {
        private string _caminho;
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
        public ConfiguracaoServidores LerConfiguracao()
        {
            var caminho = AppDomain.CurrentDomain.BaseDirectory;
            _caminho = caminho;
            ConfiguracaoServidores configuracao = new ConfiguracaoServidores();
            StreamReader reader = new StreamReader(caminho + "Configuração.txt", true);
            using (reader)
            {
                string linha;

                while ((linha = reader.ReadLine()) != null)
                {
                    // A linha possui a informação que procuro?
                    if (linha.Contains("servidor:"))
                    {
                        // Sim. Então guarda a informação e abandona o loop
                        configuracao.nomeServidor = linha.Replace("servidor:", "").Trim();
                    }
                    else
                    if (linha.Contains("banco: "))
                    {
                        // Sim. Então guarda a informação e abandona o loop
                        configuracao.nomeBanco = linha.Replace("banco: ", "").Trim();
                    }
                    else
                    if (linha.Contains("usuario:"))
                    {
                        // Sim. Então guarda a informação e abandona o loop
                        configuracao.usuario = linha.Replace("usuario:", "").Trim();
                    }
                    else
                    if (linha.Contains("senha:"))
                    {
                        // Sim. Então guarda a informação e abandona o loop
                        configuracao.senha = linha.Replace("senha:", "").Trim();
                    }
                    else
                    if (linha.Contains("BDEM:"))
                    {
                        // Sim. Então guarda a informação e abandona o loop
                        configuracao.localizacaoEM = linha.Replace("BDEM:", "").Trim();
                    }

                }
            }
            return configuracao;
        }
        public void UltimoRegistro(int id)
        {
            try
            {
                File.Delete("UltimoRegistro.txt");
                var writer = new StreamWriter(_caminho + "UltimoRegistro.txt", true);
                using (writer)
                {
                    writer.WriteLine(id);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public int lerRegistro()
        {
            var caminho = AppDomain.CurrentDomain.BaseDirectory;
            int idRegistro = 0;
            StreamReader reader = new StreamReader(caminho + "UltimoRegistro.txt", true);
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
