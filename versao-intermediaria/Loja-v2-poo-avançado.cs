using System;

namespace Pratica
{
    /// <summary>
    /// Classe que representa um produto no sistema
    /// </summary>
    class Produto
    {
        // Propriedades básicas do produto
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int QuantidadeEstoque { get; set; }

        // Propriedades para controle de vendas
        public int QuantidadeVendida { get; set; }
        public double ValorTotalVendas { get; set; }

        /// <summary>
        /// Construtor com validação de dados obrigatórios
        /// </summary>
        public Produto(string nome, int codigo, double preco, int quantidadeEstoque)
        {
            // Validações para garantir dados consistentes
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser vazio");
            if (preco < 0)
                throw new ArgumentException("Preço não pode ser negativo");
            if (quantidadeEstoque < 0)
                throw new ArgumentException("Quantidade não pode ser negativa");

            Nome = nome;
            Codigo = codigo;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
        }

        /// <summary>
        /// Adiciona unidades ao estoque do produto
        /// </summary>
        public void AdicionarEstoque(int quantidade)
        {
            if (quantidade > 0)
            {
                QuantidadeEstoque += quantidade;
            }
        }

        /// <summary>
        /// Remove unidades do estoque com validação
        /// </summary>
        public void RemoverEstoque(int quantidade)
        {
            if (quantidade > 0 && quantidade <= QuantidadeEstoque)
            {
                QuantidadeEstoque -= quantidade;
            }
            else
            {
                Console.WriteLine("Erro: Quantidade inválida ou estoque insuficiente!");
            }
        }

        /// <summary>
        /// Calcula automaticamente o valor total em estoque (preço × quantidade)
        /// </summary>
        public double ValorTotalEstoque
        {
            get { return Preco * QuantidadeEstoque; }
        }

        /// <summary>
        /// Verifica se o estoque está baixo (menor que 10 unidades)
        /// </summary>
        public bool EstoqueBaixo
        {
            get { return QuantidadeEstoque < 10; }
        }

        /// <summary>
        /// Exibe informações formatadas do produto
        /// </summary>
        public void ExibirInfo()
        {
            Console.WriteLine($"Código: {Codigo}     Produto: {Nome}     Preço: R${Preco:F2}     Estoque: {QuantidadeEstoque} unidades     Valor Total: R${ValorTotalEstoque:F2}");
        }

        /// <summary>
        /// Registra uma venda no histórico do produto
        /// </summary>
        public void RegistrarVenda(int quantidade, double valorVenda)
        {
            QuantidadeVendida += quantidade;
            ValorTotalVendas += valorVenda;
        }
    }

    /// <summary>
    /// Classe que gerencia o caixa e configurações de desconto
    /// </summary>
    class Caixa
    {
        public double Saldo { get; set; }
        public double ValorMinimoDesconto { get; set; } // Valor mínimo para aplicar desconto
        public double PercentualDesconto { get; set; } // Percentual de desconto a ser aplicado
    }

    /// <summary>
    /// Classe responsável por toda interface visual do sistema
    /// </summary>
    class Menu
    {
        /// <summary>
        /// Exibe o menu principal do sistema
        /// </summary>
        public static int ExibirMenuInicial()
        {
            Console.Clear();
            string[] opcoes = {
                "Relatórios e Opções",
                "Editar ou adicionar produtos",
                "Atualizar Estoque",
                "Realizar Venda",
                "Sair"};

            return chamarMenu("Inicial", opcoes);
        }

        /// <summary>
        /// Exibe menu de relatórios e configurações
        /// </summary>
        public static int ExibirMenuRelatorio()
        {
            string[] opcoes = {
                "Relatório de Vendas",
                "Historico de Vendas",
                "Ajustar Valor Minimo para Desconto",
                "Ajustar Percentual de Desconto",
                "Configurar aviso de estoque baixo",
                "Voltar"};

            return chamarMenu("Relatório", opcoes);
        }

        /// <summary>
        /// Exibe menu de edição de produtos
        /// </summary>
        public static int ExibirMenuEdit()
        {
            string[] opcoes = {
                "Editar nome do produto",
                "Editar preço do produto",
                "Adicionar produto",
                "Voltar"};

            return chamarMenu("de Edição", opcoes);
        }

        /// <summary>
        /// Exibe menu de gestão de estoque
        /// </summary>
        public static int ExibirMenuEstoque()
        {
            string[] opcoes = {
                "Adicionar Produto",
                "Remover Produto",
                "Voltar"};

            return chamarMenu("Estoque", opcoes);
        }

        /// <summary>
        /// Exibe menu de vendas/carrinho
        /// </summary>
        public static int ExibirMenuVenda()
        {
            string[] opcoes = {
                "Compra",
                "Ver carrinho",
                "Remover quantidade",
                "Remover Produto",
                "Finalizar compra",
                "Voltar"};

            return chamarMenu("Venda", opcoes);
        }

        /// <summary>
        /// Método genérico para exibir menus formatados
        /// </summary>
        /// <returns>Número de opções disponíveis</returns>
        static int chamarMenu(string Menu, string[] opcoes)
        {
            Console.WriteLine("\n==========================================");
            Console.WriteLine($"       Bem vindo ao Menu {Menu}");
            Console.WriteLine("==========================================\n");
            for (int i = 0; i < opcoes.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {opcoes[i]}");
            }
            Console.WriteLine("            Escolha uma opção:");
            Console.WriteLine("\n==========================================\n");
            return opcoes.Length;
        }

        /// <summary>
        /// Exibe todos os produtos cadastrados no sistema
        /// </summary>
        public static void ExibirTodosProdutos(Produto[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] != null)
                {
                    p[i].ExibirInfo();
                }
            }
        }

        /// <summary>
        /// Pausa a execução e aguarda interação do usuário
        /// </summary>
        public static void Pausa()
        {
            Console.WriteLine("\n==========================================\n");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.WriteLine("\n==========================================\n");
            Console.ReadLine();
        }

        /// <summary>
        /// Exibe alertas para produtos com estoque baixo
        /// </summary>
        public static void AlertaEstoqueBaixo(Produto[] p, bool aviso)
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] != null && p[i].EstoqueBaixo && aviso == true)
                {
                    Console.WriteLine($"ATENÇÃO: {p[i].Nome} com Estoque baixo! {p[i].QuantidadeEstoque} unidades");
                }
            }
        }

        /// <summary>
        /// Exibe opções de busca (por código ou nome)
        /// </summary>
        public static void NomeOuCodigo()
        {
            Console.WriteLine("\n==========================================\n");
            Console.WriteLine("1 - Buscar o produto por codigo:");
            Console.WriteLine("2 - Buscar o produto por nome:");
            Console.WriteLine("3 - Voltar");
            Console.WriteLine("\n==========================================\n");
        }

        /// <summary>
        /// Exibe mensagem de carrinho vazio
        /// </summary>
        public static void CarrinhoVazio()
        {
            Console.Clear();
            Console.WriteLine("\n==========================================");
            Console.WriteLine("            CARRINHO VAZIO");
            Console.WriteLine("==========================================\n");
        }

        /// <summary>
        /// Busca produto por nome exato primeiro, depois por nome similar
        /// </summary>
        /// <returns>Produto encontrado ou null</returns>
        public static Produto BuscarProdutoPorNome(Produto[] p, string nomeBusca, int totalProdutos)
        {
            // Primeira tentativa: busca exata (case insensitive)
            for (int i = 0; i < totalProdutos; i++)
            {
                if (p[i] != null && p[i].Nome.ToLower() == nomeBusca.ToLower())
                {
                    Console.WriteLine($"Produto encontrado: {p[i].Nome}");
                    if (Ler.Confirmar("É este produto?"))
                    {
                        return p[i];
                    }
                }
            }
            // Segunda tentativa: busca por similaridade usando Contains
            Console.WriteLine("Nome exato não encontrado. Buscando nomes similares...");
            for (int i = 0; i < totalProdutos; i++)
            {
                if (p[i] != null && p[i].Nome.ToLower().Contains(nomeBusca.ToLower()))
                {
                    Console.WriteLine($"Produto encontrado: {p[i].Nome}");
                    if (Ler.Confirmar("É este produto?"))
                    {
                        return p[i];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Busca produto no carrinho por nome e retorna a posição
        /// </summary>
        /// <returns>Índice do item no carrinho ou -1 se não encontrado</returns>
        public static int BuscarCarrinhoPorNome(string[,] carrinho, string nomeBusca, int totalCarrinho)
        {
            // Primeira tentativa: busca exata (case insensitive)
            for (int i = 0; i < totalCarrinho; i++)
            {
                if (carrinho[i, 1].ToLower() == nomeBusca.ToLower())
                {
                    Console.WriteLine($"Produto encontrado: {carrinho[i, 1]}");
                    if (Ler.Confirmar("É este produto?"))
                    {
                        return i;
                    }
                }
            }

            Console.WriteLine("Nome exato não encontrado. Buscando nomes similares...");
            // Segunda tentativa: busca por similaridade
            for (int i = 0; i < totalCarrinho; i++)
            {
                if (carrinho[i, 1].ToLower().Contains(nomeBusca.ToLower()))
                {
                    Console.WriteLine($"Produto encontrado: {carrinho[i, 1]}");
                    if (Ler.Confirmar("É este produto?"))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Exibe o conteúdo completo do carrinho com totais
        /// </summary>
        public static void ExibirCarrinho(string[,] carrinho, int totalCarrinho)
        {
            double totalGeral = 0;
            Console.WriteLine("\n==========================================");
            Console.WriteLine("          CARRINHO DE COMPRAS");
            Console.WriteLine("==========================================\n");

            // Percorre e exibe cada item do carrinho
            for (int i = 0; i < totalCarrinho; i++)
            {
                Console.WriteLine($"Produto {i + 1}:");
                Console.WriteLine($"  Codigo: {carrinho[i, 0]}");
                Console.WriteLine($"  Produto: {carrinho[i, 1]}");
                Console.WriteLine($"  quantidade: {carrinho[i, 2]}");
                Console.WriteLine($"  Valor: R${double.Parse(carrinho[i, 3])}");
                Console.WriteLine($"  Valor Total: R${carrinho[i, 4]}");
                Console.WriteLine();
                totalGeral += double.Parse(carrinho[i, 4]);
            }
            Console.WriteLine($"Total do Carrinho: R$ {totalGeral:F2}");
        }

        /// <summary>
        /// Remove um item do carrinho e reorganiza o array
        /// </summary>
        public static void AtualizaCarrinhoRemover(int posicao, ref int totalCarrinho, string[,] carrinho)
        {
            Console.WriteLine("Carrinho atualizado:");

            // Move todos os itens após a posição removida uma posição para trás
            for (int j = posicao; j < totalCarrinho - 1; j++)
            {
                carrinho[j, 0] = carrinho[j + 1, 0];
                carrinho[j, 1] = carrinho[j + 1, 1];
                carrinho[j, 2] = carrinho[j + 1, 2];
                carrinho[j, 3] = carrinho[j + 1, 3];
                carrinho[j, 4] = carrinho[j + 1, 4];
            }
            totalCarrinho--;
            Console.WriteLine("Item removido do carrinho!");

            // Verifica se carrinho ficou vazio
            if (totalCarrinho == 0)
            {
                Console.WriteLine("Nenhum produto no Carrinho");
                Pausa();
            }
            else
            {
                Console.WriteLine("Carrinho de compras:");
                ExibirCarrinho(carrinho, totalCarrinho);
                Console.WriteLine();
                Pausa();
            }
        }

        /// <summary>
        /// Remove quantidade específica de um item do carrinho
        /// </summary>
        public static void RemoverCarrinho(int i, string[,] carrinho, ref int removerItem, ref int totalCarrinho)
        {
            Console.WriteLine($"Item {i + 1}    Codigo: {carrinho[i, 0]}     Produto: {carrinho[i, 1]}     quantidade: {carrinho[i, 2]}     Valor: R${carrinho[i, 3]}     Valor Total: R${carrinho[i, 4]}");

            // Lê quantidade a remover (entre 0 e quantidade atual no carrinho)
            removerItem = Ler.LerOpcao(0, int.Parse(carrinho[i, 2]));

            // Atualiza quantidade e valor total do item
            carrinho[i, 2] = (int.Parse(carrinho[i, 2]) - removerItem).ToString();
            carrinho[i, 4] = (double.Parse(carrinho[i, 4]) - (double.Parse(carrinho[i, 3]) * removerItem)).ToString("F2");
            Console.WriteLine("Quantidade Removida");

            // Se ainda restam unidades, exibe carrinho atualizado
            if (int.Parse(carrinho[i, 2]) > 0)
            {
                Console.Clear();
                Console.WriteLine("Carrinho atualizado:");
                ExibirCarrinho(carrinho, totalCarrinho);
                Pausa();
            }
        }

        /// <summary>
        /// Adiciona produto ao carrinho ou incrementa quantidade se já existir
        /// </summary>
        public static void AdicionarCarrinho(bool produtoJaExiste, int qnt, Produto produtoSelecionado, ref int totalCarrinho, string[,] carrinho)
        {
            if (qnt > 0)
            {
                double valorTotal = qnt * produtoSelecionado.Preco;

                // Verifica se produto já está no carrinho
                for (int i = 0; i < totalCarrinho; i++)
                {
                    double qntCarrinho = int.Parse(carrinho[i, 2]);
                    double valorTotalCarrinho = double.Parse(carrinho[i, 4]);
                    if (carrinho[i, 0] == produtoSelecionado.Codigo.ToString())
                    {
                        produtoJaExiste = true;

                        // Verifica se a quantidade total não excede o estoque
                        if ((int.Parse(carrinho[i, 2]) > (produtoSelecionado.QuantidadeEstoque - qnt)))
                        {
                            Console.WriteLine($"Quantidade acima de Estoque, Selecione até {produtoSelecionado.QuantidadeEstoque - qntCarrinho} unidades, você já tem {qntCarrinho} unidadaes no carrinho");
                            Menu.Pausa();
                        }
                        else
                        {
                            // Incrementa quantidade e valor no carrinho
                            carrinho[i, 2] = (qntCarrinho + qnt).ToString();
                            carrinho[i, 4] = (valorTotalCarrinho + valorTotal).ToString("F2");
                            Console.WriteLine("Adicionado ao carrinho");
                            Console.WriteLine($"Item {i + 1}    Codigo: {carrinho[i, 0]}     Produto: {carrinho[i, 1]}     quantidade: {carrinho[i, 2]}     Valor: R${carrinho[i, 3]}    Valor Total: R${carrinho[i, 4]} ");
                            break;
                        }
                    }
                }

                // Se produto não estava no carrinho, adiciona novo item
                if (!produtoJaExiste)
                {
                    if (totalCarrinho < 10)
                    {
                        // Adiciona novo item na próxima posição disponível
                        carrinho[totalCarrinho, 0] = produtoSelecionado.Codigo.ToString();
                        carrinho[totalCarrinho, 1] = produtoSelecionado.Nome;
                        carrinho[totalCarrinho, 2] = qnt.ToString();
                        carrinho[totalCarrinho, 3] = produtoSelecionado.Preco.ToString("F2");
                        carrinho[totalCarrinho, 4] = valorTotal.ToString("F2");
                        totalCarrinho++;
                        Console.WriteLine("Adicionado ao carrinho");
                        Console.WriteLine($"Item {produtoSelecionado.Codigo.ToString()}    Codigo: {produtoSelecionado.Codigo.ToString()}     Produto: {produtoSelecionado.Nome}     quantidade: {qnt.ToString()}     Valor: R${produtoSelecionado.Preco.ToString("F2")}    Valor Total: R${valorTotal.ToString("F2")}");
                        Menu.Pausa();
                    }
                    else
                    {
                        Console.WriteLine("Limite de produtos no carrinho atingido!");
                        Menu.Pausa();
                    }
                }
            }
        }

    }

    /// <summary>
    /// Classe responsável por validar e ler entradas do usuário
    /// </summary>
    class Ler
    {
        /// <summary>
        /// Lê e valida uma opção inteira dentro de um intervalo
        /// </summary>
        /// <param name="min">Valor mínimo aceito</param>
        /// <param name="max">Valor máximo aceito</param>
        /// <returns>Opção válida escolhida pelo usuário</returns>
        public static int LerOpcao(int min, int max)
        {
            int opcao;
            while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < min || opcao > max)
            {
                Console.WriteLine($"Opção inválida! Digite entre {min} e {max}:");
            }
            return opcao;
        }

        /// <summary>
        /// Lê e valida um valor decimal dentro de um intervalo
        /// </summary>
        /// <param name="min">Valor mínimo aceito</param>
        /// <param name="max">Valor máximo aceito</param>
        /// <returns>Valor decimal válido</returns>
        public static double LerDecimal(int min, int max)
        {
            double numero;
            while (!double.TryParse(Console.ReadLine(), out numero) || numero < min || numero > max)
            {
                Console.WriteLine($"Valor inválido! Digite entre {min} e {max}:");
            }
            return numero;
        }

        /// <summary>
        /// Solicita confirmação do usuário (s/n)
        /// </summary>
        /// <returns>true se confirmado, false se negado</returns>
        public static bool Confirmar(string mensagem)
        {
            string entrada;
            do
            {
                Console.WriteLine($"{mensagem} (s/n):");
                entrada = Console.ReadLine().ToLower();
            } while (entrada != "s" && entrada != "n");

            return entrada == "s";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ==================== INICIALIZAÇÃO DO SISTEMA ====================

            // Array de produtos (capacidade máxima: 5 produtos)
            Produto[] p = new Produto[5];

            // Produtos pré-cadastrados para teste
            p[0] = new Produto("Notebook", 1, 2500.00, 10);

            p[1] = new Produto("Mouse", 2, 50.00, 50);

            p[2] = new Produto("Teclado", 3, 150.00, 30);

            // Contador de produtos cadastrados (próximo índice disponível)
            int novoProduto = 3;

            // Inicialização do caixa com valores padrão
            Caixa c1 = new Caixa();

            c1.Saldo = 1000.00;
            c1.ValorMinimoDesconto = 100.00; // Desconto a partir de R$ 100
            c1.PercentualDesconto = 10.00; // 10% de desconto

            // Controla se exibe avisos de estoque baixo
            bool aviso = true;

            // Histórico de vendas: [50 vendas máximo, 4 informações por venda]
            // Colunas: [0]=Nome do Produto, [1]=Quantidade, [2]=Valor, [3]=Data/Hora
            string[,] historicoVendas = new string[50, 4];
            int totalVendas = 0;

            // Carrinho de compras: [10 itens máximo, 5 informações por item]
            // Colunas: [0]=Código, [1]=Nome, [2]=Quantidade, [3]=Preço Unitário, [4]=Valor Total
            string[,] carrinho = new string[10, 5];
            int totalCarrinho = 0;

            int maxOpcoes;
            int opcao;

            // ==================== LOOP PRINCIPAL DO SISTEMA ====================
            do
            {
                maxOpcoes = Menu.ExibirMenuInicial();
                opcao = Ler.LerOpcao(1, maxOpcoes);
                Console.Clear();

                switch (opcao)
                {
                    // ==================== CASE 1: RELATÓRIOS E OPÇÕES ====================
                    case 1:
                        int maxOpcoesRelatorio;
                        int opcaoRelatorio;
                        do
                        {
                            Console.Clear();
                            // Exibe informações atuais do sistema
                            Console.WriteLine($"Saldo atual: R${c1.Saldo:F2}");
                            Console.WriteLine($"Valor minimo para desconto: R${c1.ValorMinimoDesconto:F2}");
                            Console.WriteLine($"Percentual de desconto: {c1.PercentualDesconto:F2}%");
                            if (aviso)
                            {
                                Console.WriteLine("Aviso ligado");
                            }
                            else
                            {
                                Console.WriteLine("Aviso desligado");
                            }
                            maxOpcoesRelatorio = Menu.ExibirMenuRelatorio();
                            opcaoRelatorio = Ler.LerOpcao(1, maxOpcoesRelatorio);

                            switch (opcaoRelatorio)
                            {
                                case 1: // Relatório de Vendas por Produto
                                    Console.Clear();
                                    for (int i = 0; i < p.Length; i++)
                                    {
                                        if (p[i] != null)
                                        {
                                            p[i].ExibirInfo();
                                            Console.WriteLine($"Total vendido: {p[i].QuantidadeVendida} unidades - R${p[i].ValorTotalVendas:F2}");
                                        }
                                    }
                                    Menu.Pausa();
                                    break;
                                case 2: // Histórico Completo de Vendas
                                    Console.Clear();
                                    Console.WriteLine("Histórico de Vendas");
                                    for (int i = 0; i < totalVendas; i++)
                                    {
                                        Console.WriteLine($"Venda {i + 1}:");
                                        Console.WriteLine($"  Produto: {historicoVendas[i, 0]}");
                                        Console.WriteLine($"  Quantidade: {historicoVendas[i, 1]}");
                                        Console.WriteLine($"  Valor: R${historicoVendas[i, 2]}");
                                        Console.WriteLine($"  Data: {historicoVendas[i, 3]}");
                                        Console.WriteLine();
                                    }
                                    if (totalVendas == 0)
                                    {
                                        Console.WriteLine("Nenhuma venda registrada.");
                                        Menu.Pausa();
                                        break;
                                    }
                                    Menu.Pausa();
                                    break;
                                case 3: // Ajustar Valor Mínimo para Desconto
                                    Console.Clear();
                                    Console.WriteLine("Digite o novo valor minimo para desconto (0 para cancelar):");
                                    double novoValorMinimoDesconto = Ler.LerDecimal(0, 10000);
                                    if (novoValorMinimoDesconto == 0)
                                    {
                                        Console.WriteLine("Operação cancelada.");
                                        Menu.Pausa();
                                        break;
                                    }
                                    else
                                    {
                                        c1.ValorMinimoDesconto = novoValorMinimoDesconto;
                                        Console.WriteLine($"Valor minimo para desconto atualizado para: R${c1.ValorMinimoDesconto:F2}");
                                        Menu.Pausa();
                                        break;
                                    }
                                case 4: // Ajustar Percentual de Desconto
                                    Console.Clear();
                                    Console.WriteLine("Digite o novo percentual de desconto (0 para cancelar):");
                                    double novoPercentualDesconto = Ler.LerDecimal(0, 30);
                                    if (novoPercentualDesconto == 0)
                                    {
                                        Console.WriteLine("Operação cancelada.");
                                        Menu.Pausa();
                                        break;
                                    }
                                    else
                                    {
                                        c1.PercentualDesconto = novoPercentualDesconto;
                                        Console.WriteLine($"Percentual de desconto atualizado para: {c1.PercentualDesconto:F2}%");
                                        Menu.Pausa();
                                        break;
                                    }
                                case 5: // Configurar Aviso de Estoque Baixo
                                    Console.Clear();
                                    if (aviso)
                                    {
                                        if (Ler.Confirmar(@"Aviso de estoque baixo LIGADO, escolha ""n"" para desligar ou ""s"" para manter ligado"))
                                        {
                                            aviso = true;
                                            Console.WriteLine("Aviso ligado!");
                                            Menu.Pausa();
                                        }
                                        else
                                        {
                                            aviso = false;
                                            Console.WriteLine("Aviso desligado!");
                                            Menu.Pausa();
                                        }
                                    }
                                    else
                                    {
                                        if (Ler.Confirmar(@"Aviso de estoque baixo DESLIGADO, escolha ""n"" para manter desligado ou ""s"" para ligar"))
                                        {
                                            aviso = true;
                                            Console.WriteLine("Aviso ligado!");
                                            Menu.Pausa();
                                        }
                                        else
                                        {
                                            aviso = false;
                                            Console.WriteLine("Aviso desligado!");
                                            Menu.Pausa();
                                        }
                                    }
                                    break;
                            }
                        } while (opcaoRelatorio != maxOpcoesRelatorio);
                        break;

                    // ==================== CASE 2: EDITAR OU ADICIONAR PRODUTOS ====================
                    case 2:
                        int maxOpcoesEdit;
                        int opcaoEdit;
                        do
                        {
                            Console.Clear();
                            maxOpcoesEdit = Menu.ExibirMenuEdit();
                            opcaoEdit = Ler.LerOpcao(1, maxOpcoesEdit);

                            if (opcaoEdit == maxOpcoesEdit)
                            {
                                break;
                            }
                            switch (opcaoEdit)
                            {
                                case 1: // Editar Nome do Produto
                                    Console.Clear();
                                    Menu.ExibirTodosProdutos(p);
                                    Console.WriteLine("Digite o código do produto que deseja editar ou pressione 0 para sair:");
                                    int codigoProduto = Ler.LerOpcao(0, novoProduto);

                                    if (codigoProduto == 0)
                                    {
                                        continue;
                                    }
                                    Produto produtoSelecionado = p[codigoProduto - 1];
                                    Console.WriteLine("Digite o novo nome (Enter para cancelar):");
                                    string novoNome = Console.ReadLine();

                                    if (string.IsNullOrWhiteSpace(novoNome))
                                    {
                                        Console.WriteLine("Operação cancelada.");
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        produtoSelecionado.Nome = novoNome;
                                        Console.WriteLine("Nome atualizado!");
                                        Console.WriteLine();
                                        produtoSelecionado.ExibirInfo();
                                    }
                                    break;
                                case 2: // Editar Preço do Produto
                                    Console.Clear();
                                    Menu.ExibirTodosProdutos(p);
                                    Console.WriteLine("Digite o código do produto que deseja editar ou pressione 0 para sair:");
                                    codigoProduto = Ler.LerOpcao(0, novoProduto);

                                    if (codigoProduto == 0)
                                    {
                                        continue;
                                    }
                                    produtoSelecionado = p[codigoProduto - 1];
                                    Console.WriteLine(@"Digite o novo preço (0 para cancelar):");
                                    double novoPreco = Ler.LerDecimal(0, 10000);
                                    if (novoPreco == 0)
                                    {
                                        Console.WriteLine("Operação cancelada.");
                                        break;
                                    }
                                    else
                                    {
                                        if (Ler.Confirmar($@"Confirmar alteração de preço para R${novoPreco:F2}?"))
                                        {
                                            Console.Clear();
                                            produtoSelecionado.Preco = novoPreco;
                                            Console.WriteLine("Preço atualizado!");
                                            Console.WriteLine();
                                            produtoSelecionado.ExibirInfo();
                                        }
                                        break;
                                    }
                                case 3: // Adicionar Novo Produto
                                    Console.Clear();
                                    // Verifica se ainda há espaço no array
                                    if (novoProduto >= p.Length)
                                    {
                                        Console.WriteLine("Limite de produtos atingido!");
                                        break;
                                    }
                                    Console.WriteLine("Digite o nome do novo produto (Enter para cancelar):");
                                    string nome = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(nome))
                                    {
                                        Console.WriteLine("Operação cancelada.");
                                        break;
                                    }
                                    int codigo = novoProduto + 1; // Código sequencial automático
                                    Console.WriteLine("Digite o preço do novo produto (0 para cancelar):");
                                    double preco = Ler.LerDecimal(0, 10000);
                                    if (preco == 0)
                                    {
                                        Console.WriteLine("Operação cancelada.");
                                        break;
                                    }
                                    Console.WriteLine("Digite a quantidade em estoque do novo produto (0 para cancelar):");
                                    int quantidadeEstoque = Ler.LerOpcao(0, 1000);
                                    if (quantidadeEstoque == 0)
                                    {
                                        Console.WriteLine("Operação cancelada.");
                                        break;
                                    }
                                    // Cria o produto temporariamente
                                    p[novoProduto] = new Produto(nome, codigo, preco, quantidadeEstoque);
                                    if (Ler.Confirmar($"Confirmar adição do produto {nome}?"))
                                    {
                                        novoProduto++; // Incrementa contador apenas se confirmado
                                        Console.WriteLine("Produto adicionado com sucesso!");
                                        p[novoProduto - 1].ExibirInfo();

                                    }
                                    else
                                    {
                                        Console.WriteLine("Operação cancelada.");
                                        p[novoProduto] = null; // Remove produto não confirmado
                                    }
                                    break;
                            }
                            Menu.Pausa();
                            Console.Clear();

                        } while (opcaoEdit != maxOpcoesEdit);
                        break;

                    // ==================== CASE 3: ATUALIZAR ESTOQUE ====================
                    case 3:
                        int maxOpcoesEstoque;
                        int opcaoEstoque;
                        do
                        {
                            maxOpcoesEstoque = Menu.ExibirMenuEstoque();

                            // Conta quantos produtos estão com estoque baixo
                            int contador = 0;
                            for (int i = 0; i < p.Length; i++)
                            {
                                if (p[i] != null && p[i].EstoqueBaixo && aviso)
                                {
                                    contador++;
                                }
                            }
                            if (contador > 0)
                            {
                                Console.WriteLine($"ATENÇÃO: Existem {contador} produtos com Estoque baixo!");
                                Console.WriteLine();
                            }

                            opcaoEstoque = Ler.LerOpcao(1, maxOpcoesEstoque);
                            Console.Clear();
                            switch (opcaoEstoque)
                            {
                                case 1: // Adicionar ao Estoque
                                    Menu.AlertaEstoqueBaixo(p, aviso);
                                    Menu.ExibirTodosProdutos(p);

                                    Console.WriteLine("\nDigite o código do produto que deseja adicionar estoque ou pressione 0 para sair:");
                                    int codigoProduto = Ler.LerOpcao(0, novoProduto);

                                    if (codigoProduto == 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }

                                    Produto produtoSelecionado = p[codigoProduto - 1];

                                    Console.WriteLine("\nDigite a quantidade que deseja adicionar ou pressione 0 para sair:");
                                    int quantidade = Ler.LerOpcao(0, 100);
                                    produtoSelecionado.AdicionarEstoque(quantidade);
                                    if (quantidade > 0)
                                    {
                                        Console.WriteLine("Estoque atualizado com sucesso!");
                                        produtoSelecionado.ExibirInfo();
                                        Menu.Pausa();
                                    }

                                    Console.Clear();

                                    break;
                                case 2: // Remover do Estoque
                                    Menu.AlertaEstoqueBaixo(p, aviso);
                                    Menu.ExibirTodosProdutos(p);

                                    Console.WriteLine("\nDigite o código do produto que deseja remover estoque ou pressione 0 para sair:");
                                    codigoProduto = Ler.LerOpcao(0, novoProduto);

                                    if (codigoProduto == 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }

                                    produtoSelecionado = p[codigoProduto - 1];

                                    Console.WriteLine("\nDigite a quantidade que deseja remover ou pressione 0 para sair:");
                                    quantidade = Ler.LerOpcao(0, produtoSelecionado.QuantidadeEstoque);
                                    produtoSelecionado.RemoverEstoque(quantidade);
                                    if (quantidade > 0)
                                    {
                                        Console.WriteLine("Estoque atualizado com sucesso!");
                                        produtoSelecionado.ExibirInfo();
                                        if (produtoSelecionado.EstoqueBaixo && aviso)
                                        {
                                            Console.WriteLine($"ATENÇÃO: {produtoSelecionado.Nome} com Estoque baixo! {produtoSelecionado.QuantidadeEstoque} unidades");
                                        }
                                        Menu.Pausa();
                                    }

                                    Console.Clear();

                                    break;
                            }
                        } while (opcaoEstoque != maxOpcoesEstoque);
                        break;

                    // ==================== CASE 4: REALIZAR VENDA ====================
                    case 4:
                        int opcaoCompra;
                        int maxOpcoesCompra;
                        do
                        {
                            Console.Clear();
                            maxOpcoesCompra = Menu.ExibirMenuVenda();
                            opcaoCompra = Ler.LerOpcao(1, maxOpcoesCompra);
                            switch (opcaoCompra)
                            {
                                case 1: // Adicionar Produto ao Carrinho
                                    Console.Clear();
                                    Menu.NomeOuCodigo();
                                    int opcaoNomeOuCodigo;
                                    opcaoNomeOuCodigo = Ler.LerOpcao(1, 3);
                                    switch (opcaoNomeOuCodigo)
                                    {
                                        case 1:  // Buscar por Código
                                            Console.Clear();
                                            Produto produtoSelecionado = null;
                                            Menu.ExibirTodosProdutos(p);
                                            Console.WriteLine("\nDigite o código do produto ou pressione 0 para sair:");
                                            int codigoProduto = Ler.LerOpcao(0, novoProduto);
                                            if (codigoProduto == 0)
                                            {
                                                break;
                                            }

                                            // Procura o produto pelo código
                                            for (int i = 0; i < novoProduto; i++)
                                            {
                                                if (p[i] != null && p[i].Codigo == codigoProduto)
                                                {
                                                    // Verifica quantidade já no carrinho
                                                    double quantCarrinho = 0;
                                                    for (int j = 0; j < totalCarrinho; j++)
                                                    {
                                                        if (carrinho[j, 0] == codigoProduto.ToString())
                                                        {
                                                            quantCarrinho = int.Parse(carrinho[j, 2]);
                                                            break;
                                                        }
                                                    }
                                                    Console.Clear();
                                                    Console.WriteLine($"Produto encontrado: {p[i].Nome}");
                                                    produtoSelecionado = p[i];
                                                    Console.WriteLine("Digite a quantidade que deseja vender:");
                                                    Console.WriteLine($"Quantidade disponível para adicionar ao carrinho: {produtoSelecionado.QuantidadeEstoque - quantCarrinho}");
                                                    Console.WriteLine("Pressione 0 para cancelar");
                                                    int qt = Ler.LerOpcao(0, produtoSelecionado.QuantidadeEstoque);
                                                    if (qt == 0)
                                                    {
                                                        break;
                                                    }
                                                    Menu.AdicionarCarrinho(false, qt, produtoSelecionado, ref totalCarrinho, carrinho);

                                                }
                                            }
                                            break;

                                        case 2: // Buscar por Nome
                                            produtoSelecionado = null;
                                            Console.Clear();
                                            Menu.ExibirTodosProdutos(p);
                                            Console.WriteLine("\nDigite o nome do produto ou enter para sair");
                                            string nomeProduto = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(nomeProduto))
                                            {
                                                Console.WriteLine("Operação cancelada.");
                                                Menu.Pausa();
                                                break;
                                            }
                                            produtoSelecionado = Menu.BuscarProdutoPorNome(p, nomeProduto, novoProduto);
                                            if (produtoSelecionado == null)
                                            {
                                                Console.WriteLine("Produto não encontrado!");
                                                Menu.Pausa();
                                                break;
                                            }

                                            // Verifica quantidade já no carrinho
                                            double quantiCarrinho = 0;
                                            for (int j = 0; j < totalCarrinho; j++)
                                            {
                                                if (carrinho[j, 0] == produtoSelecionado.Codigo.ToString())
                                                {
                                                    quantiCarrinho = int.Parse(carrinho[j, 2]);
                                                    break;
                                                }
                                            }

                                            Console.Clear();
                                            Console.WriteLine($"Produto encontrado: {produtoSelecionado.Nome}");
                                            Console.WriteLine("Digite a quantidade que deseja vender:");
                                            Console.WriteLine($"Quantidade disponível para adicionar ao carrinho: {produtoSelecionado.QuantidadeEstoque - quantiCarrinho}");
                                            Console.WriteLine("Pressione 0 para cancelar");
                                            int qnt = Ler.LerOpcao(0, produtoSelecionado.QuantidadeEstoque);
                                            if (qnt == 0)
                                            {
                                                break;
                                            }
                                            Menu.AdicionarCarrinho(false, qnt, produtoSelecionado, ref totalCarrinho, carrinho);
                                            break;

                                    }
                                    break;

                                case 2: // Ver Carrinho
                                    Console.Clear();

                                    if (totalCarrinho == 0)
                                    {
                                        Menu.CarrinhoVazio();
                                    }
                                    else
                                    {
                                        Menu.ExibirCarrinho(carrinho, totalCarrinho);
                                    }
                                    Menu.Pausa();
                                    Console.Clear();
                                    break;

                                case 3: // Remover Quantidade do Carrinho
                                    Console.Clear();
                                    if (totalCarrinho == 0)
                                    {
                                        Menu.CarrinhoVazio();
                                        Menu.Pausa();
                                        break;
                                    }
                                    Console.Clear();
                                    Menu.NomeOuCodigo();
                                    int opcaoConfirmar;
                                    opcaoConfirmar = Ler.LerOpcao(1, 3);
                                    Console.Clear();
                                    Menu.ExibirCarrinho(carrinho, totalCarrinho);
                                    switch (opcaoConfirmar)
                                    {
                                        case 1: // Remover por Código
                                            Console.WriteLine("\nDigite o código do produto ou pressione 0 para sair:");
                                            int codigoProduto = Ler.LerOpcao(0, int.MaxValue);
                                            if (codigoProduto == 0)
                                            {
                                                break;
                                            }

                                            // Procura o produto no carrinho
                                            for (int i = 0; i < totalCarrinho; i++)
                                            {
                                                if (carrinho[i, 0] == codigoProduto.ToString())
                                                {
                                                    Console.WriteLine($"Produto encontrado: {carrinho[i, 1]}");
                                                    if (Ler.Confirmar("É este produto?"))
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("\nDigite a quantidade que deseja remover ou pressione 0 para sair:");
                                                        int removerItem = 0;
                                                        Menu.RemoverCarrinho(i, carrinho, ref removerItem, ref totalCarrinho);

                                                        // Se quantidade chegou a zero, remove o item completamente
                                                        if (int.Parse(carrinho[i, 2]) == 0)
                                                        {
                                                            Menu.AtualizaCarrinhoRemover(i, ref totalCarrinho, carrinho);
                                                        }

                                                        if (removerItem == 0)
                                                        {
                                                            Console.WriteLine("Nenhum produto removido");
                                                            Menu.Pausa();
                                                            continue;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Operação cancelada");
                                                        Menu.Pausa();
                                                        break;
                                                    }
                                                }
                                            }
                                            break;

                                        case 2: // Remover por Nome
                                            Console.WriteLine("Digite o nome do produto:");
                                            string nomeProduto = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(nomeProduto))
                                            {
                                                Console.WriteLine("Operação cancelada.");
                                                Menu.Pausa();
                                                break;
                                            }
                                            // Busca no carrinho
                                            int posicao = Menu.BuscarCarrinhoPorNome(carrinho, nomeProduto, totalCarrinho);

                                            if (posicao == -1)
                                            {
                                                Console.WriteLine("Produto não encontrado no carrinho!");
                                                Menu.Pausa();
                                                break;
                                            }
                                            Console.Clear();
                                            Console.WriteLine($"Produto encontrado: {carrinho[posicao, 1]}");
                                            Console.WriteLine("\nDigite a quantidade que deseja remover ou pressione 0 para sair:");

                                            int removeItem = 0;
                                            Menu.RemoverCarrinho(posicao, carrinho, ref removeItem, ref totalCarrinho);
                                            // Se quantidade chegou a zero, remove o item completamente
                                            if (int.Parse(carrinho[posicao, 2]) == 0)
                                            {
                                                Menu.AtualizaCarrinhoRemover(posicao, ref totalCarrinho, carrinho);
                                            }

                                            if (removeItem == 0)
                                            {
                                                Console.WriteLine("Nenhum produto removido");
                                                Menu.Pausa();
                                                break;
                                            }
                                            break;

                                        case 3:// Voltar
                                            break;
                                    }
                                    break;

                                case 4: // Remover Produto Completo do Carrinho
                                    if (totalCarrinho == 0)
                                    {
                                        Console.Clear();
                                        Menu.CarrinhoVazio();
                                        Menu.Pausa();
                                        break;
                                    }
                                    Console.Clear();
                                    Console.WriteLine("1 - Buscar o produto por codigo:");
                                    Console.WriteLine("2 - Buscar o produto por nome:");
                                    Console.WriteLine("3 - Limpar carrinho");
                                    Console.WriteLine("4 - Voltar");
                                    opcaoConfirmar = Ler.LerOpcao(1, 4);
                                    Console.Clear();
                                    Menu.ExibirCarrinho(carrinho, totalCarrinho);
                                    switch (opcaoConfirmar)
                                    {
                                        case 1: // Remover produto por código
                                            Console.WriteLine("Digite o código do produto ou pressione 0 para sair:");
                                            int codigoProduto = Ler.LerOpcao(0, int.MaxValue);
                                            if (codigoProduto == 0)
                                            {
                                                break;
                                            }

                                            // Verifica se código existe no carrinho
                                            bool codigoExiste = false;
                                            for (int i = 0; i < totalCarrinho; i++)
                                            {
                                                if (carrinho[i, 0] == codigoProduto.ToString())
                                                {
                                                    codigoExiste = true;
                                                    break;
                                                }
                                            }

                                            if (!codigoExiste)
                                            {
                                                Console.WriteLine("Código não encontrado no carrinho!");
                                                Menu.Pausa();
                                                break;
                                            }

                                            // Remove o produto
                                            for (int i = 0; i < totalCarrinho; i++)
                                            {
                                                if (carrinho[i, 0] == codigoProduto.ToString())
                                                {
                                                    Console.WriteLine($"Produto encontrado: {carrinho[i, 1]}");
                                                    if (Ler.Confirmar("É este produto?"))
                                                    {
                                                        Console.Clear();
                                                        Menu.AtualizaCarrinhoRemover(i, ref totalCarrinho, carrinho);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Nenhum produto removido");
                                                        Menu.Pausa();
                                                    }

                                                    break;
                                                }
                                            }
                                            break;

                                        case 2: // Remover produto por nome
                                            Console.WriteLine("Digite o nome do produto:");
                                            string nomeProduto = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(nomeProduto))
                                            {
                                                Console.WriteLine("Operação cancelada.");
                                                Menu.Pausa();
                                                break;
                                            }
                                            // Busca no carrinho
                                            int posicao = Menu.BuscarCarrinhoPorNome(carrinho, nomeProduto, totalCarrinho);

                                            if (posicao == -1)
                                            {
                                                Console.WriteLine("Produto não encontrado no carrinho!");
                                                Menu.Pausa();
                                                break;
                                            }

                                            Console.WriteLine($"Produto encontrado: {carrinho[posicao, 1]}");
                                            Menu.AtualizaCarrinhoRemover(posicao, ref totalCarrinho, carrinho);
                                            Console.WriteLine();
                                            break;

                                        case 3: // Limpar todo o carrinho
                                            if (Ler.Confirmar("Tem certeza que deseja limpar o carrinho?"))
                                            {
                                                totalCarrinho = 0;
                                                Console.WriteLine("Carrinho limpo!");
                                                Menu.Pausa();
                                                break;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        case 4:// Voltar
                                            break;
                                    }
                                    break;

                                case 5: // Finalizar Compra
                                    Console.Clear();
                                    if (totalCarrinho == 0)
                                    {
                                        Console.Clear();
                                        Menu.CarrinhoVazio();
                                        Menu.Pausa();
                                        break;
                                    }

                                    // Calcula subtotal do carrinho
                                    double subTotal = 0;
                                    for (int i = 0; i < totalCarrinho; i++)
                                    {
                                        subTotal += double.Parse(carrinho[i, 4]);
                                        Console.WriteLine($"Item {i + 1}    Codigo: {carrinho[i, 0]}     Produto: {carrinho[i, 1]}     quantidade: {carrinho[i, 2]}     Valor: R${double.Parse(carrinho[i, 3])}    Valor Total: R${carrinho[i, 4]} ");
                                    }
                                    Console.WriteLine($"Valor total: R$ {subTotal:F2}");

                                    // Aplica desconto se atingir o valor mínimo
                                    if (subTotal >= c1.ValorMinimoDesconto)
                                    {
                                        double desconto = subTotal * c1.PercentualDesconto / 100;
                                        Console.WriteLine($"Desconto aplicado: R${desconto:F2}");
                                        subTotal -= desconto;
                                        Console.WriteLine($"Valor total com desconto: R${subTotal:F2}");
                                    }

                                    Console.WriteLine();
                                    if (Ler.Confirmar("Confirmar venda?"))
                                    {
                                        Console.Clear();
                                        // Percorre todos os itens no carrinho
                                        for (int i = 0; i < totalCarrinho; i++)
                                        {
                                            int codigoProduto = int.Parse(carrinho[i, 0]);
                                            string nomeProduto = carrinho[i, 1];
                                            int quantidadeVendida = int.Parse(carrinho[i, 2]);
                                            double precoUnitario = double.Parse(carrinho[i, 4]) / double.Parse(carrinho[i, 2]);
                                            double valorTotalItem = double.Parse(carrinho[i, 4]);

                                            // Encontra o produto correspondente no array de produtos
                                            Produto produto = null;
                                            for (int j = 0; j < p.Length; j++)
                                            {
                                                if (p[j] != null && p[j].Codigo == codigoProduto)
                                                {
                                                    produto = p[j];
                                                    break;
                                                }
                                            }

                                            if (produto == null)
                                            {
                                                Console.WriteLine($"Produto código {codigoProduto} ({nomeProduto}) não encontrado - item ignorado.");
                                                Menu.Pausa();
                                                break; ;
                                            }

                                            // Valida estoque e processa a venda
                                            if (quantidadeVendida <= produto.QuantidadeEstoque)
                                            {
                                                produto.RemoverEstoque(quantidadeVendida);
                                                produto.RegistrarVenda(quantidadeVendida, valorTotalItem);

                                                // Alerta se estoque ficou baixo
                                                if (produto.EstoqueBaixo && aviso)
                                                {
                                                    Console.WriteLine($"ATENÇÃO: {produto.Nome} com estoque baixo ({produto.QuantidadeEstoque} unidades)");
                                                }
                                                
                                                // Registra no histórico (limite de 50 vendas)
                                                if (totalVendas < 50)
                                                {
                                                    historicoVendas[totalVendas, 0] = nomeProduto;
                                                    historicoVendas[totalVendas, 1] = quantidadeVendida.ToString();
                                                    historicoVendas[totalVendas, 2] = valorTotalItem.ToString("F2");
                                                    historicoVendas[totalVendas, 3] = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                                                    totalVendas++;
                                                }
                                            }

                                            else
                                            {
                                                Console.WriteLine($"Estoque insuficiente para {nomeProduto}. Pedido: {quantidadeVendida}, Disponível: {produto.QuantidadeEstoque}. Item ignorado.");
                                                Menu.Pausa();
                                            }
                                        }

                                        // Atualiza saldo do caixa
                                        c1.Saldo += subTotal;
                                        Console.WriteLine($"Venda concluída! Total da compra: R${subTotal:F2}");
                                        Console.WriteLine($"Saldo atualizado do caixa: R${c1.Saldo:F2}");

                                         // Limpa o carrinho após finalização
                                        totalCarrinho = 0;
                                    }
                                    Menu.Pausa();
                                    Console.WriteLine();
                                    break;
                                
                            case 6: // Voltar ao menu principal
                                    break;
                            }
                        } while (opcaoCompra != 6);
                        break;
                }
            } while (opcao != maxOpcoes);
        }
    }
}
