using System;

namespace LojaSystem
{
    class Program
	{
		//Variáveis Globais
		static int SoftwareProQt = 10;
		static int SoftwareMidQt = 15;
		static int SoftwareLowQt = 20;
		static int SoftwarePro = 10000;
		static int SoftwareMid = 5000;
		static int SoftwareLow = 1000;
		static int SoftwareProV = 0;
		static int SoftwareMidV = 0;
		static int SoftwareLowV = 0;
		static int SaldoTotal = 500;
		static int Vendas = 0;
		static int entrada1,entrada2,entrada4,entrada5=0;
		
		
		static void Main(string[] args)
		{
			BoasVindas ();
					
			do
			{
				ExibirMenu ();
				Console.WriteLine("Digite sua opção");
				string entrada = Console.ReadLine();
				entrada1 = Convert.ToInt32(entrada);
			
				switch (entrada1)
				{
					case 1:
						Console.Clear();
						Console.WriteLine("Bem Vindo a Loja,escolha um produto");
						MenuVendas ();
						
						string Produto = Console.ReadLine();
						entrada2 = Convert.ToInt32(Produto);
						
						if (entrada2 < 1 || entrada2 > 3)  
						{
							Console.WriteLine("Produto Invalido");
							break;
						}
						else 
						{
							switch (entrada2)
							{
								case 1:
									Console.WriteLine($"Parabéns por comprar o Programa avançado por {SoftwarePro}");
									SoftwareProQt-=1;
									SaldoTotal += SoftwarePro;
									Vendas +=1;
									SoftwareProV+=1;
								break;
									
								case 2:
									Console.WriteLine($"Parabéns por comprar o Programa básico por {SoftwareMid}");
									SoftwareMidQt-=1;
									SaldoTotal += SoftwareMid;
									Vendas +=1;
									SoftwareMidV+=1;
								break;
								
								case 3:
									Console.WriteLine($"Parabéns por comprar o Site para Empresas por {SoftwareLow}");
									SoftwareLowQt-=1;
									SaldoTotal += SoftwareLow;
									Vendas +=1;
									SoftwareLowV+=1;
								break;
							}
						}
							
					break;
					
					case 2:
						Console.Clear();
						MenuRelatorio ();
						
					break;
					
					case 3:
						Console.Clear();
						MenuEstoque ();
						Console.WriteLine("Você quer repor o estoque de algum produto? (s/n)");
							
						char entrada3 = Convert.ToChar(Console.ReadLine());
						Console.WriteLine((entrada3 == 's' || entrada3 == 'S' || entrada3 == 'n' || entrada3 == 'N') ? "Vamos continuar": "Valor incorreto");
						
						if (entrada3 == 's' || entrada3 == 'S')
						{
							MenuEstoque ();
							Console.WriteLine("Qual produto você quer repor?");
							string  AumentarEstoque= Console.ReadLine();
							entrada4 = Convert.ToInt32(AumentarEstoque);
							
							switch (entrada4)
							{
								case 1:
									Console.WriteLine("Quantos irá adicionar");
									string  AumentarEstoque1= Console.ReadLine();
									entrada5 = Convert.ToInt32(AumentarEstoque1);
									SoftwareProQt+=entrada5;
								break;
									
								case 2:
									Console.WriteLine("Quantos irá adicionar");
									string  AumentarEstoque2= Console.ReadLine();
									entrada5 = Convert.ToInt32(AumentarEstoque2);
									SoftwareMidQt+=entrada5;
								break;
									
								case 3:
									Console.WriteLine("Quantos irá adicionar");
									string  AumentarEstoque3= Console.ReadLine();
									entrada5 = Convert.ToInt32(AumentarEstoque3);
									SoftwareLowQt+=entrada5;
								break;
									
							}
									
						}
						else if (entrada3 == 'n' || entrada3 == 'N')
						{
							Console.WriteLine("Obrigado pela visita");
						}
						
					break;
						
					case 4:
						Console.WriteLine("Obrigado pela visita");
					break;
				}
				
				
				if (entrada1 != 4)
                {
                    System.Console.Write("Pressione Enter para continuar...");
                    System.Console.ReadLine();
                    System.Console.Clear();
				}
			} while (entrada1!=4);
		}
		
		
		//Boas vindas
		static void BoasVindas ()
		{
		Console.WriteLine("Loja do Gabriel");
		}
			
		
		//MENU
		static void ExibirMenu ()
		{
				string menu = @"
Menu Principal
1-Realizar Venda
2-Relatorio de Vendas
3-Estoque
4-Sair";
		Console.WriteLine(menu);	
		}
		
		
		//MENU DE VENDAS
		static void MenuVendas ()
		{			
		Console.WriteLine("Escolha entre (1 a 3)");
		Console.WriteLine($"1-Programa avançado: {SoftwarePro}");
		Console.WriteLine($"2-Programa básico: {SoftwareMid}");
		Console.WriteLine($"3-Site para Empresas: {SoftwareLow}");
		}
		
		
		//MENU DE ESTOQUE
		static void MenuEstoque ()
		{	
		Console.WriteLine($"Saldo disponível: R${SaldoTotal}");
		Console.WriteLine($"1-Programa avançado: \tQuantidade {SoftwareProQt}");
		Console.WriteLine($"2-Programa básico: \tQuantidade {SoftwareMidQt}");
		Console.WriteLine($"3-Site para Empresas: \tQuantidade {SoftwareLowQt}");
		}
			
				
		//MENU RELATORIO DE VENDAS
		static void MenuRelatorio ()
		{	
		Console.WriteLine($"Saldo disponível: R${SaldoTotal}");
		Console.WriteLine($"Quantidade de Vendas: {Vendas}");
		Console.WriteLine($"1-Programa avançado: \tQuantidade {SoftwareProV}");
		Console.WriteLine($"2-Programa básico: \tQuantidade {SoftwareMidV}");
		Console.WriteLine($"3-Site para Empresas: \tQuantidade {SoftwareLowV}");
		}
	}
}
