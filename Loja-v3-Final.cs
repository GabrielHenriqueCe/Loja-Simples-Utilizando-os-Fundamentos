using System;

class Program
{
  //Variáveis Globais
  static double Produto1Valor = 1500.00, Produto2Valor = 3000.00, Produto3Valor = 5000.00;
  static double Produto1Vendido = 0, Produto2Vendido = 0, Produto3Vendido = 0;
  static int Produto1Quantidade = 15, Produto2Quantidade = 10, Produto3Quantidade = 5;
  static int Produto1Vendas = 0, Produto2Vendas = 0, Produto3Vendas = 0;
  static string Produto1 = "Produto1", Produto2 = "Produto2", Produto3 = "Produto3", nomeProdutoAtual ="";
  static int quantidadeVendas = 0;
  static int produtoSelecionado = 0;
  static int quantidadeMaxima = 0;
  static double valorProduto = 0;
  static double valorDesconto = 10000;
  static double porcentagemDesconto = 10;

  //Método Principal
  static void Main (string[] args)
  {
    int entradaDeMenu = 0; //Variavel para entrada do Menu

    do //Loop para escolha do número com validação de entrada e fim ao escolher 6
    {
      string[] opcoes = {
        "Realizar Venda",
        "Relatório de Vendas",
        "Editar Produtos",
        "Estoque",
        "Calculadora",
        "Jogo dos 7 erros",
        "Sair"
      };
      chamarMenu ("Inicial", opcoes);
      entradaDeMenu = entradaValida("Escolha uma opção", 1, 7, "Inicial", opcoes);

      switch (entradaDeMenu) //Chama o Menu correspondente a entrada
      {
        case 1:
          Console.Clear();
          MenuVendas();
          break;

        case 2:
          Console.Clear();
          MenuRelatorio();
          break;

        case 3:
          Console.Clear();
          MenuEditarProdutos();
          break;

        case 4:
          Console.Clear();
          MenuEstoque();
          break;

        case 5:
          Console.Clear();
          MenuCalculadora();
          break;

        case 6:
          Console.Clear();
          MenuJogo();
          break;

        case 7:
          Console.Clear();
          Console.WriteLine("Obrigado pela visita!");
          break;
      }
    } while (entradaDeMenu != 7);   
  }

  //Menu de Vendas
  static void MenuVendas ()
  {
    int entradaVendas = 0; //Variavel para entrada do Menu
    
    do //Loop para escolha do número com validação de entrada e fim ao escolher 4
    {
      string[] opcoesVendas = {
        $"{Produto1} \tR${Produto1Valor:F2} \tQuantidade: {Produto1Quantidade}",
        $"{Produto2} \tR${Produto2Valor:F2} \tQuantidade: {Produto2Quantidade}",
        $"{Produto3} \tR${Produto3Valor:F2} \tQuantidade: {Produto3Quantidade}",
        "Voltar"
      };
      
      chamarMenu ("de Vendas", opcoesVendas); //Chama o Menu de Vendas com as opções de produtos
      entradaVendas = entradaValida ("Escolha uma opção", 1, 4, "de Vendas", opcoesVendas);

      if (entradaVendas != 4)
      {
        definirProdutoAtual (entradaVendas); //Define produto atual, quantidade máxima e valor do produto 

        if (quantidadeMaxima >0) //Quanidade em estoque deve ser maior que zero
        {
          Console.WriteLine($"\n{nomeProdutoAtual} selecionado");
          Console.WriteLine($"Valor: R${valorProduto:F2}");
          Console.WriteLine($"Quantidade disponível: {quantidadeMaxima}");

          //Entrada de quantidade de produtos escolhidos
          Console.WriteLine("Quantos você quer? \nSe deseja voltar pressione 0");
          string quantidadeString = Console.ReadLine();
          int quantidade = 0;

          if (numeroValido(quantidadeString, out quantidade, 0, quantidadeMaxima, $"Digite um número entre 1 e {quantidadeMaxima}"))
          {
            //Se quantidade for 0 volta ao menu de vendas
            if (quantidade == 0)
            {
              Console.WriteLine("Nenhum produto escolhido, escolha novamente!");
              pausaParaLer();
            }
            else
            {
          //Se quantidade for maior que 0 até quantidadeMaxima processa a venda
            processarVenda(quantidade);
            }
          }
        }
        //Se quantidadeMaxima for 0
        else 
        {
          Console.WriteLine($"Produto {produtoSelecionado} fora de estoque!");
          pausaParaLer();
        }
      } //Fim do primeiro if se a entrada for diferente de 4

    } while (entradaVendas !=4);  //Se a entrada for 4 volta ao Menu Inicial
    Console.Clear();
  }//Fim do menu de vendas

  //Menu do Relatório de Vendas
  static void MenuRelatorio ()
  {
    //Variaveis para o relatório de vendas
    int entradaRelatorio = 0;
    double MediaVendas = 0;
    if (quantidadeVendas > 0) //Se quantidade de vendas for maior que zero calcula a média de vendas
    {
        MediaVendas=(Produto1Vendas + Produto2Vendas + Produto3Vendas)/ quantidadeVendas;
    }
    do
    { 
      Console.WriteLine("Relatório de Vendas");
      Console.WriteLine($"Quantidade de Vendas Realizadas = {quantidadeVendas}");
      Console.WriteLine($"{Produto1} - Quantidade = {Produto1Vendas} - Valor Total Vendido {Produto1Vendido:F2}");
      Console.WriteLine($"{Produto1} - Quantidade = {Produto2Vendas} - Valor Total Vendido {Produto2Vendido:F2}");
      Console.WriteLine($"{Produto1} - Quantidade = {Produto3Vendas} - Valor Total Vendido {Produto3Vendido:F2}");
      Console.WriteLine($"Média de Vendas = {MediaVendas:F2}");
      Console.WriteLine();
      string[] relatorioVendas = {
        $"Ajustar desconto para valores acima de = {valorDesconto:F2}",
        $"Ajustar porcentagem de desconto para = {porcentagemDesconto}%",
        $"Voltar"
      };
    
    
      chamarMenu ("de Descontos", relatorioVendas);
    
      entradaRelatorio = entradaValida("Escolha uma opção", 1, 3, "de Descontos", relatorioVendas);
      
      switch (entradaRelatorio) //Chama o Menu correspondente a entrada
      {
        case 1:
          valorDesconto = entradaNumero("Digite o valor mínimo para aplicar o desconto");
          Console.WriteLine($"Valor ajustado para {valorDesconto:F2}");
          pausaParaLer();
          break;
        case 2:
          porcentagemDesconto = entradaNumero("Digite a porcentagem de desconto");
          Console.WriteLine($"Valor ajustado para {porcentagemDesconto}%");
          pausaParaLer();
          break;
        case 3:
          Console.Clear();
          break;
      }
    
    //Fim do loop para escolha do número com validação de entrada e fim ao escolher 8
    }while (entradaRelatorio != 3);
    
  }//Fim do menu de relatório de vendas

  //Menu de Editar Produtos
  static void MenuEditarProdutos ()
  {
    int entradaEditarProdutos = 0;
    
    do
    {
      string[] opcoesEditarProdutos = {
        "Alterar Nome dos Produtos",
        "Alterar Valor dos Produtos",
        "Voltar"
      };
      chamarMenu ("de Editar Produtos", opcoesEditarProdutos);
      entradaEditarProdutos = entradaValida("Escolha uma opção", 1, 3, "de Editar Produtos", opcoesEditarProdutos);

      switch (entradaEditarProdutos)
      {
        case 1:
          MenuNomeProdutos();
          break;
        case 2:
          MenuValorProdutos();
          break;
        case 3:
          Console.Clear();
          break;
      }
      
    }while (entradaEditarProdutos != 3);
  }
  
  //Menu Nome dos Produtos
  static void MenuNomeProdutos ()
  {
    //Menu para alterar o Nome dos produtos
    int entradaNomeProdutos = 0;
    do
    {
    string[] opcoesNomeProdutos = {
      $"Nome:{Produto1} \tValor: R${Produto1Valor:F2}",
      $"Nome:{Produto2} \tValor: R${Produto2Valor:F2}",
      $"Nome:{Produto3} \tValor: R${Produto3Valor:F2}",
      "Voltar"
    };
    Console.Clear();
    chamarMenu ("de Nomes dos Produtos", opcoesNomeProdutos);

    entradaNomeProdutos = entradaValida("Escolha o produto que deseja alterar o nome", 1, 4, "de Nomes dos Produtos", opcoesNomeProdutos);
      switch (entradaNomeProdutos)
      {
        case 1:
          Console.WriteLine($"Digite o novo nome do {Produto1}");
          Produto1 = Console.ReadLine();
          Console.Clear();
          break;
        case 2:
          Console.WriteLine($"Digite o novo nome do {Produto2}");
          Produto2 = Console.ReadLine();
          Console.Clear();
          break;
        case 3:
          Console.WriteLine($"Digite o novo nome do {Produto3}");
          Produto3 = Console.ReadLine();
          Console.Clear();
          break;
        case 4:
          Console.Clear();
          break;
      }
    } while(entradaNomeProdutos != 4);
  }//Fim do menu de Nomes dos produtos

  
  //Menu Valor dos Produtos
  static void MenuValorProdutos ()
  {
    //Menu para alterar o nome dos produtos
    int entradaValorProdutos = 0;
    do
    {
    string[] opcoesValorProdutos = {
      $"Nome:{Produto1} \tValor: R${Produto1Valor:F2}",
      $"Nome:{Produto2} \tValor: R${Produto2Valor:F2}",
      $"Nome:{Produto3} \tValor: R${Produto3Valor:F2}",
      "Voltar"
    };
    Console.Clear();
    chamarMenu ("de Valores dos Produtos", opcoesValorProdutos);

    entradaValorProdutos = entradaValida("Escolha o produto que deseja alterar o Valor", 1, 4, "de Valores dos Produtos", opcoesValorProdutos);
      switch (entradaValorProdutos)
      {
        case 1:
          Produto1Valor = entradaNumero($"Digite o novo valor {Produto1}");
          Console.Clear();
          break;
        case 2:
          Produto2Valor = entradaNumero($"Digite o novo valor {Produto2}");
          Console.Clear();
          break;
        case 3:
          Produto3Valor = entradaNumero($"Digite o novo valor do {Produto3}");
          Console.Clear();
          break;
        case 4:
          Console.Clear();
          break;
      }
    } while(entradaValorProdutos != 4);
  }//Fim do menu de valores dos produtos

  
  //Menu de Estoque
  static void MenuEstoque ()
  {
    int entradaEstoque = 0; //Variavel para entrada do Menu

    do //Loop para escolha do número com validação de entrada e fim ao escolher 4
    {
      string[] opcoesEstoque = {
        $"{Produto1} \tR${Produto1Valor:F2} \tQuantidade: {Produto1Quantidade}",
        $"{Produto2} \tR${Produto2Valor:F2} \tQuantidade: {Produto2Quantidade}",
        $"{Produto3} \tR${Produto3Valor:F2} \tQuantidade: {Produto3Quantidade}",
        "Voltar"
      };
      chamarMenu ("de Estoque", opcoesEstoque);

      Console.WriteLine("\nDeseja repor algum produto?");
      entradaEstoque = entradaValida("Escolha um produto", 1, 4, "de Estoque", opcoesEstoque);

      if (entradaEstoque !=4) //Se a entrada for diferente de 4 define produto atual
      {
        definirProdutoAtual (entradaEstoque);

        Console.WriteLine($"\nProduto {produtoSelecionado} selecionado");
        Console.WriteLine($"Estoque atual {quantidadeMaxima}");
          
        //Entrada de quantidade de produtos escolhidos
        int reporQuantidade = entradaValidaSimples ("Quantos você quer adicionar ao estoque?", 0, 100);

        if (reporQuantidade == 0) //Se quantidade for 0 volta ao menu de estoque
        {
          Console.WriteLine("Nenhum produto foi adicionado ao estoque!");
          pausaParaLer();
        }
        else //Se quantidade for maior que 0 e menor que 100 processa a reposição de estoque e volta ao menu de estoque
        {
          reporEstoque(reporQuantidade);
        }
      }

    }while (entradaEstoque != 4); //Se a entrada for 4 volta ao Menu Inicial
    Console.Clear();
  }

  //Calculadora
  static void MenuCalculadora ()
  {
    int entradaCalculadora = 0; //Variavel para entrada do Menu de Calculadora

    do //Loop para escolha do número com validação de entrada e fim ao escolher 5
    {
      string[] opcoesCalculadora = {
        "Soma \t(+)",
        "Subtração \t(-)",
        "Multiplicação \t(*)",
        "Divisão \t(/)",
        "Voltar"
      };

      chamarMenu ("de Calculadora",opcoesCalculadora);
      entradaCalculadora = entradaValida("Escolha uma opção", 1, 5, "de Calculadora", opcoesCalculadora);

      if(entradaCalculadora != 5) //Se a entrada for diferente de 5 processa a operação
      {
        Console.Clear();
        double primeiroNumero = entradaNumero("Digite o primeiro número:");
        double segundoNumero = entradaNumero("Digite o segundo número:");
        double resultado = 0;
        string operacao = "";

        switch (entradaCalculadora) //Chama o Operador correspondente a entrada
        {
          case 1:
            resultado = primeiroNumero + segundoNumero;
            operacao = "+";
            break;

          case 2:
            resultado = primeiroNumero - segundoNumero;
            operacao = "-";
            break;
          
          case 3:
            resultado = primeiroNumero * segundoNumero;
            operacao = "*";
            break;

          case 4:
            if (segundoNumero != 0) //Se o segundo número for diferente de zero divide
            {	
              resultado = primeiroNumero / segundoNumero;
              operacao = "/";
            }
            else
            {
              Console.WriteLine("Não é possível dividir por zero");
              pausaParaLer();
              continue;
            }
            break;
        }//Fim do switch
          
        //Mostra o resultado da operação
        Console.WriteLine($"\nResultado: {primeiroNumero} {operacao} {segundoNumero} = {resultado:F2}");
        pausaParaLer();
      }//Fim do if se a entrada for diferente de 5
        
    } while (entradaCalculadora != 5);  //Se a entrada for 5 volta ao Menu Inicial
    Console.Clear();
  }// Fim do menu de calculadora

  //Jogo dos 7 erros
  static void MenuJogo ()
  {
    // Gera um número aleatório entre 1 e 100
    Random random = new Random(); 
    // Variáveis para o jogo
    int numeroSecreto = random.Next(1, 101);
    int tentativas = 0;
    int maxTentativas = 7;
    int palpite = 0;
    bool acertou = false;
      
    // Início do jogo
    Console.Clear();
    Console.WriteLine("Jogo dos 7 Erros");
    Console.WriteLine("Tente adivinhar o número entre 1 e 100!");
    Console.WriteLine($"Você tem {maxTentativas} tentativas.");

    do // Loop para o jogo
    {
      tentativas++;
      Console.WriteLine($"Tentativa {tentativas}/{maxTentativas}");

      palpite = entradaValidaSimples("Digite seu palpite:", 1, 100);
        
      // Verifica se o palpite está correto
      if (palpite == numeroSecreto) 
      {
        acertou = true;
        Console.WriteLine($"\nPARABÉNS! Você acertou em {tentativas} tentativas!");
        Console.WriteLine($"O número era {numeroSecreto}!");
      }

      else if (palpite < numeroSecreto)
      {
        Console.WriteLine("Muito baixo! Tente um número maior.");
      }

      else 
      {
        Console.WriteLine("Muito alto! Tente um número menor.");
      }
        
    // Fim do loop para o jogo e verifica se o jogador acertou ou se as tentativas acabaram
    } while (!acertou && tentativas < maxTentativas);

    if (!acertou) // Se o jogador não acertou, mostra o número secreto
    {
      Console.WriteLine($"\nFim de jogo! O número era {numeroSecreto}.");
      Console.WriteLine("Mais sorte na próxima vez!");
    }

    pausaParaLer();
  }//Fim do menu de jogo


  // Método para criação de Menu
  static void chamarMenu (string Menu, string[] opcoes)
  {
    Console.WriteLine($"Bem vindo ao Menu {Menu}");
    for (int i = 0; i < opcoes.Length; i++)
    {
      Console.WriteLine($"{i + 1} - {opcoes[i]}");
     }
  }//Fim do método para criação de Menu

  //Método para definir produto atual
  static void definirProdutoAtual (int produto)
  {
    produtoSelecionado = produto;

    switch (produto) //Define produto atual, quantidade máxima e valor do produto
    {
      case 1:
        nomeProdutoAtual = Produto1;
        quantidadeMaxima = Produto1Quantidade;
        valorProduto = Produto1Valor;
        break;

      case 2:
        nomeProdutoAtual = Produto2;
        quantidadeMaxima = Produto2Quantidade;
        valorProduto = Produto2Valor;
        break;

      case 3:
        nomeProdutoAtual = Produto3;
        quantidadeMaxima = Produto3Quantidade;
        valorProduto = Produto3Valor;
        break;

      default:
        quantidadeMaxima = 0;
        valorProduto = 0;
        break;
    }
  }//Fim do método definir produto atual

  //Método para processar a Venda
  static void processarVenda (int quantidade)
  {
    Console.Clear();
    double valorTotal = valorProduto * quantidade;
    //Obs: precisa chamar o método definirProdutoAtual antes de chamar este método
    Console.WriteLine("Venda Realizada");
    Console.WriteLine($"Produto: {nomeProdutoAtual}");
    Console.WriteLine($"Quantidade: {quantidade}");
    Console.WriteLine($"Valor do Produto: {valorProduto}");
    if (valorTotal >= valorDesconto)
    {
      Console.WriteLine($"Valor do Desconto: {valorTotal * porcentagemDesconto / 100}");
      valorTotal = valorTotal * (1 - porcentagemDesconto / 100);
      Console.WriteLine($"Desconto de {porcentagemDesconto}% aplicado!");
    }
    Console.WriteLine($"Total: {valorTotal}");
    
    //A quantidade é subtraida do estoque do produto selecionado e adicionada as vendas
    switch (produtoSelecionado) 
    {
      case 1:
        Produto1Quantidade -= quantidade;
        Produto1Vendas += quantidade;
        Produto1Vendido += valorTotal;
        quantidadeVendas++;
        break;

      case 2:
        Produto2Quantidade -= quantidade;
        Produto2Vendas += quantidade;
        Produto2Vendido += valorTotal;
        quantidadeVendas++;
        break;

      case 3:
        Produto3Quantidade -= quantidade;
        Produto3Vendas += quantidade;
        Produto3Vendido += valorTotal;
        quantidadeVendas++;
        break;	
    }

    Console.WriteLine($"Estoque restante: {quantidadeAtual(produtoSelecionado)}");
    pausaParaLer();	
  }//Fim do método processar venda

  //Método para Repor Estoque
  static void reporEstoque (int quantidade)
  {
    //Obs: precisa chamar o método definirProdutoAtual antes de chamar este método
    Console.WriteLine($"\nReposição de Estoque");
    Console.WriteLine($"Produto: {produtoSelecionado}");
    Console.WriteLine($"Estoque anterior: {quantidadeMaxima}");

    switch (produtoSelecionado) //A quantidade é adicionada ao estoque do produto selecionado
    {
      case 1:
        Produto1Quantidade += quantidade;
        break;
      case 2:
        Produto2Quantidade += quantidade;
        break;
      case 3:
        Produto3Quantidade += quantidade;
        break;
    }

    Console.WriteLine($"Quantidade adicionada: {quantidade}");
    Console.WriteLine($"Estoque atual: {quantidadeAtual(produtoSelecionado)}");
    pausaParaLer();
  }//Fim do método repor estoque

  //Método para quantidade de produto em estoque.
  static int quantidadeAtual(int produto)
  {
    switch (produto) //Retorna a quantidade do produto selecionado
    {
      case 1:
        return Produto1Quantidade;
      case 2:
        return Produto2Quantidade;
      case 3:
        return Produto3Quantidade;
      default:
        return 0;
    }
  }//Fim do método quantidade atual

  //Método uma pausa pro usuario ler o que está na tela e continuar.
  static void pausaParaLer ()
  {
    Console.WriteLine("Pressione Enter para Continuar");
    Console.ReadLine();
    Console.Clear();
  }//Fim do método pausa para ler
  
  //Método para Validação de números entra Min e Max
  static bool numeroValido (string entrada, out int numero, int min, int max, string mensagemErro = null) //Mensagem erro opcional
  {
    if (!int.TryParse(entrada, out numero))//Verifica se a entrada é um número
    {
      Console.WriteLine("Digite apenas números!");
      pausaParaLer ();
      return false;
    }
    if (numero < min || numero > max)//Verifica se o número está entre min e max
    {
      Console.WriteLine(mensagemErro ?? $"Digite um número entre {min} e {max}!");
      pausaParaLer ();
      return false;
    }
    return true; //Se a entrada for válida retorna true
  }//Fim do método número válido

  // Método para entrada válida que retorna o Menu
  static int entradaValida (string mensagem, int min, int max, string nomeMenu, string[] opcoes, string mensagemErro = null)
  {
    //Variaveis para entrada válida
    string entrada = "";
    int resultado = 0;
    bool primeiraVez = true;

    do //Loop para entrada válida
    {
      if (!primeiraVez) //Se não for a primeira vez que entra no loop mostra o menu novamente
      {
        chamarMenu (nomeMenu, opcoes);
      }
      primeiraVez = false;

      Console.WriteLine(mensagem);
      entrada = Console.ReadLine();
      
    //Chama o método número válido se a entrada for válida sai do loop
    }while (!numeroValido(entrada, out resultado, min, max, mensagemErro));

    return resultado; //Retorna o número válido
  }//Fim do método entrada válida

  // Método para entrada válida simples que não retorna o Menu
  static int entradaValidaSimples (string mensagem, int min, int max, string mensagemErro = null)
  {
    //Variaveis para entrada válida
    string entrada = "";
    int resultado = 0;

    do //Loop para entrada válida
    {
      Console.WriteLine(mensagem);
      entrada = Console.ReadLine();
    //Chama o método número válido se a entrada for válida sai do loop
    }while (!numeroValido(entrada, out resultado, min, max, mensagemErro));

    return resultado; //Retorna o número válido
  }//Fim do método entrada válida simples

  //Entrada Valida para números sem min/max
  static double entradaNumero (string mensagem, string mensagemErro = null)
  {
    //Variaveis para entrada válida
    string entrada = "";
    double numero = 0;

    do //Loop para entrada válida
    {				
      Console.WriteLine(mensagem);
      entrada = Console.ReadLine();

      if(!double.TryParse(entrada, out numero)) //Verifica se a entrada é um número
      {
        Console.WriteLine("Digite apenas números");
      }
    }while (!double.TryParse(entrada, out numero));//Se a entrada for válida sai do loop

    return numero;//Retorna o número válido
  }//Fim do método entrada número
  
}//Fim da classe Program
