using System;
using System.IO;

namespace IntegracaoBancos.Configuracao
{
    public class UltimoRegistro
    {
        public void UltimoRegistroAcesso(RegistroEntrada registroEntrada)
        {
            File.Delete("UltimoRegistro.txt");
            StreamWriter writer = new StreamWriter("UltimoRegistro.txt", true);
            using (writer)
            {
                writer.WriteLine(registroEntrada.Id.ToString());
            }
        }

        public int LerRegistro()
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
