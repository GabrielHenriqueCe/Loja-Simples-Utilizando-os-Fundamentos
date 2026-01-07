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
		static int Produto,entrada1,entrada2,entrada4,entrada5=0;
		
		
		static void Main(string[] args)
		{
			BoasVindas ();
					
			do
			{
				ExibirMenu ();
				Console.WriteLine("Digite sua opção");
				string entrada = Console.ReadLine();
				if (!int.TryParse(entrada, out entrada1))  //Se nao conseguir converter para int true. se conseguir converte (out) para entrada1.
				{
					Console.WriteLine("Digite apenas números, pressione enter para voltar");
					Console.ReadLine();
          Console.Clear();
					continue;
				}
				
				
				switch (entrada1)
				{
					case 1:
						bool entradaValida = false; //sempre que a entradaValida for falsa o loop continua.
						do
						{	
							Console.Clear();
							Console.WriteLine("Bem Vindo a Loja, escolha um produto");
							MenuVendas ();
						
							string Produto = Console.ReadLine();
							if (!int.TryParse(Produto, out entrada2))
							{
								Console.WriteLine("Digite apenas números, pressione enter para voltar");
								Console.ReadLine();
                Console.Clear();
								continue;
							}
							
							else if (entrada2 < 1 || entrada2 >3)
							{
								Console.WriteLine("Digite apenas números entre 1 e 3, pressione enter para voltar");
								Console.ReadLine();
                Console.Clear();
								continue;
							}
							
							else 
							{
								switch (entrada2)
								{
									case 1:
										Console.WriteLine("Você escolheu Programa avançado, você quer quantos produtos?");
										Console.WriteLine($"Temos {SoftwareProQt} em estoque.");
										string entradaSN = Console.ReadLine();
										int entradaSNb = 0;
										Console.WriteLine();
										if(!int.TryParse(entradaSN, out entradaSNb))
										{
											Console.WriteLine("Digite apenas números, aperte enter para tentar novamente");
											Console.ReadLine();
											continue;
										}
										
										if(entradaSNb > SoftwareProQt || entradaSNb <=0)
										{
										  Console.WriteLine(entradaSNb <=0 ? "Quantidade deve ser maior que zero" : "Quantidade insuficiente no estoque, aperte enter para tentar novamente");
											Console.ReadLine();
											continue;
										}
										
										
										Console.WriteLine($"Parabéns por comprar {entradaSNb} Programa avançado por {entradaSNb*SoftwarePro}");
										SoftwareProQt-=entradaSNb;
										SaldoTotal += (SoftwarePro*entradaSNb);
										Vendas ++;
										SoftwareProV+=entradaSNb;
										
										
									break;
									
									case 2:
										Console.WriteLine("Você escolheu Programa básico, você quer quantos produtos?");
										Console.WriteLine($"Temos {SoftwareMidQt} em estoque.");
										string entradaSN1 = Console.ReadLine();
										int entradaSNb1 = 0;
										Console.WriteLine();
										if(!int.TryParse(entradaSN1, out entradaSNb1))
										{
											Console.WriteLine(entradaSNb1 <=0 ? "Quantidade deve ser maior que zero" : "Digite apenas números, aperte enter para tentar novamente");
											Console.ReadLine();
											continue;
										}
										
										if(entradaSNb1 > SoftwareMidQt || entradaSNb1 <=0)
										{
											Console.WriteLine("Quantidade insuficiente,aperte enter para tentar novamente");
											Console.ReadLine();
											continue;
										}
										
										
										Console.WriteLine($"Parabéns por comprar {entradaSNb1} Programa básico por {entradaSNb1*SoftwareMid}");
										SoftwareMidQt-=entradaSNb1;
										SaldoTotal += (SoftwareMid*entradaSNb1);
										Vendas ++;
										SoftwareMidV+=entradaSNb1;
										
										
									break;
								
									case 3:
										Console.WriteLine("Você escolheu Site para empresas, você quer quantos produtos?");
										Console.WriteLine($"Temos {SoftwareLowQt} em estoque.");
										string entradaSN2 = Console.ReadLine();
										int entradaSNb2 = 0;
										Console.WriteLine();
										if(!int.TryParse(entradaSN2, out entradaSNb2))
										{
											Console.WriteLine("Digite apenas números, aperte enter para tentar novamente");
											Console.ReadLine();
											continue;
										}
										
										if(entradaSNb2 > SoftwareLowQt || entradaSNb2 <=0)
										{
											Console.WriteLine(entradaSNb2 <=0 ? "Quantidade deve ser maior que zero" : "Quantidade insuficiente,aperte enter para tentar novamente");
											Console.ReadLine();
											continue;
										}
										
									
										Console.WriteLine($"Parabéns por comprar {entradaSNb2} Site para empresas por {entradaSNb2*SoftwareLow}");
										SoftwareLowQt-=entradaSNb2;
										SaldoTotal += (SoftwareLow*entradaSNb2);
										Vendas ++;
										SoftwareLowV+=entradaSNb2;
										
										
									break;
										
								} //fim do switch
							} //fim do else
							
						entradaValida = true;
							
						}while (!entradaValida);
							
							
					break;
						
					case 2:
						Console.Clear();
						MenuRelatorio ();
            
					break;
					
					case 3:
						bool entradaValida1 = false;
						do
						{				
							Console.Clear();
							MenuEstoque ();
							Console.WriteLine("Você quer repor o estoque de algum produto? (s/n)");				
							string entrada3b = Console.ReadLine();
							char entrada3 = ' ';
						
							
							if (entrada3b != "" && entrada3b != null)
							{
								entrada3 = entrada3b[0];
							
								if (entrada3 == 's' || entrada3 == 'S')
							  {
									bool entradaValida2 = false;
									do
									{
						
										MenuEstoque ();
										Console.WriteLine("Qual produto você quer repor?");
										string  AumentarEstoque= Console.ReadLine();
										if(!int.TryParse(AumentarEstoque, out entrada4) || entrada4 <1 || entrada4 >3)
										{
											Console.WriteLine("Digite apenas números entre 1 e 3, aperte enter para tentar novamente");
											Console.ReadLine();
											continue;
										}
										
										bool entradaValida3=false;
										do
										{
											switch (entrada4)
											{
												case 1:
												MenuEstoque ();
												Console.WriteLine("Quantos irá adicionar?");
												string  AumentarEstoque1= Console.ReadLine();
												if (!int.TryParse(AumentarEstoque1, out entrada5) || entrada5<1)
												{
   												Console.WriteLine("Digite apenas números maiores que 1! Pressione enter para voltar");
													Console.ReadLine();
													entradaValida1 = true;
    											continue;
												}
												SoftwareProQt+=entrada5;
												Console.WriteLine($"Agora Programa avançado tem {SoftwareProQt} unidades em estoque");
												entradaValida3 = true;
												break;
									
												case 2:
												MenuEstoque ();
												Console.WriteLine("Quantos irá adicionar?");
												string  AumentarEstoque2= Console.ReadLine();
												if (!int.TryParse(AumentarEstoque2, out entrada5) || entrada5<1)
												{
   												Console.WriteLine("Digite apenas números maiores que 1! Pressione enter para voltar");
													Console.ReadLine();
    											continue;
												}
												SoftwareMidQt+=entrada5;
												Console.WriteLine($"Agora Programa básico tem {SoftwareMidQt} unidades em estoque");
												entradaValida3 = true;
												break;
								
												case 3:
												MenuEstoque ();
												Console.WriteLine("Quantos irá adicionar?");
												string  AumentarEstoque3= Console.ReadLine();
												if (!int.TryParse(AumentarEstoque3, out entrada5) || entrada5<1)
												{
   												Console.WriteLine("Digite apenas números maiores que 1! Pressione enter para voltar");
													Console.ReadLine();
    												continue;
												}
												SoftwareLowQt+=entrada5;
												Console.WriteLine($"Agora Site para Empresas tem {SoftwareLowQt} unidades em estoque");
												entradaValida3 = true;
												break;
											} //fecha switch
											
										entradaValida2 = true;
											
										}while (!entradaValida3);
										
									entradaValida2 = true;
									entradaValida1 = true;
										
									}while (!entradaValida2);
									 
								} //fecha o segundo if do case 3
	
								else if (entrada3 == 'n' || entrada3 == 'N')
								{
									Console.WriteLine("Obrigado pela visita");
									entradaValida1 = true;
								}
								else 
								{
									Console.WriteLine("Digite S ou N, aperte enter para tentar novamente");
									Console.ReadLine();
								}
							//fecha o primeiro if do case 3
							}
							else 
							{
								Console.WriteLine("Digite S ou N, aperte enter para tentar novamente");
								Console.ReadLine();
							}
						}while (!entradaValida1);							
						break;
						
					case 4:
						Console.WriteLine("Obrigado pela visita");
					break;
				
				}//fecha o switch
				
				if (entrada1 >4 || entrada1 <1) //precisa ser entre 1 e 4
        {
          Console.WriteLine("Escolha entre 1 e 4");
				}	
					
				if (entrada1 != 4) //Se nao for igual a 4 da tempo pro usuario ler e continuar
        {
          Console.WriteLine("Pressione Enter para voltar ao menu inicial");
          Console.ReadLine();
          Console.Clear();
				}
				
			}while (entrada1 != 4); //Continua no loop se não for igual a 4
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
		Console.WriteLine($"1-Programa avançado: R${SoftwarePro} \tQuantidade {SoftwareProQt}");
		Console.WriteLine($"2-Programa básico: R${SoftwareMid} \tQuantidade {SoftwareMidQt}");
		Console.WriteLine($"3-Site para Empresas: R${SoftwareLow} \tQuantidade {SoftwareLowQt}");
		}
		
		
		//MENU DE ESTOQUE
		static void MenuEstoque ()
		{	
		Console.WriteLine($"Saldo disponível: R${SaldoTotal}");
		Console.WriteLine($"1-Programa avançado: {(SoftwareProQt >0 ? $"\tQuantidade {SoftwareProQt}" : "\tESGOTADO")}");
		Console.WriteLine($"2-Programa básico: {(SoftwareMidQt >0 ? $"\tQuantidade {SoftwareMidQt}" : "\tESGOTADO")}");
		Console.WriteLine($"3-Site para Empresas: {(SoftwareLowQt >0 ? $"\tQuantidade {SoftwareLowQt}" : "\tESGOTADO")}");
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
