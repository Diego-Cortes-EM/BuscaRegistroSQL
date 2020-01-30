using System;
using TechTalk.SpecFlow;

namespace ConecaoTeste
{
    [Binding]
    public class TransforteDeRegistroDeAcesso
    {
        [Given(@"que eu processe esses registros vindo do SQLServer")]
        public void DadoQueEuProcesseEssesRegistrosVindoDoSQLServer()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que abre o sistema na primeira vez no dia")]
        public void DadoQueAbreOSistemaNaPrimeiraVezNoDia()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"faco a transação de dados de um banco ao outro")]
        public void QuandoFacoATransacaoDeDadosDeUmBancoAoOutro()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"sou informado que o foi transferidos todos com sucesso")]
        public void EntaoSouInformadoQueOFoiTransferidosTodosComSucesso()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"fazer a sicronização de todos os registros de acesso do dia")]
        public void EntaoFazerASicronizacaoDeTodosOsRegistrosDeAcessoDoDia()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
