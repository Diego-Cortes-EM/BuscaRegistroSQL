	#language: pt-BR
	Funcionalidade: Transforte de registro de acesso de um banco SQL Server para um banco de dados FBC
	Como operador do sistema do Escolar Manager 
	Quero poder altomatizar a entrada de dados do registro de acesso dos alunos 
	Para facilitar trabalho e colocar funcionadidade como aviso para os pais horario de entrada e saida dos seus filhos 

		@tag1
		Cenario: Primeira vez no dia puchar todos registros do dia 
		Dado que abre o sistema na primeira vez no dia 
		Então fazer a sicronização de todos os registros de acesso do dia 

		@tag2
		Cenario:De tempos em tempos sicronize os registros 
		Dado que o tempo foi atigindo 
		Então faça a sicronização dos registros por ultimo ate o mais atual 
		 
