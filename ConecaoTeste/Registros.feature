	#language: pt-BR
	Funcionalidade: Transforte de registro de acesso de um banco SQL Server para um banco de dados FBC
	Como operador do sistema do Escolar Manager 
	Quero poder altomatizar a entrada de dados do registro de acesso dos alunos 
	Para facilitar trabalho e colocar funcionadidade como aviso para os pais horario de entrada e saida dos seus filhos 

	*Deve registra no Banco FBC os registros dos clientes  

		Cenario:De tempos em tempos busca os registros cadastrados no Servidor do Sql Server 
		Dado que eu processe esses registros vindo do SQLServer 
		Quando faco a transação de dados de um banco ao outro 
		Então sou informado que o foi transferidos todos com sucesso 