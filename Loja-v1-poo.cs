using System;

namespace Pratica
{
    // Classe Produto para armazenar informações do produto
    class Produto
    {
        // Campos privados (encapsulados)
        private int codigo;
        private string nome;
        private double preco;
        private int quantidadeEstoque;
        private int quantidadeVendida;
        private double valorTotalVendas;

        // Métodos públicos para manipular os dados
        public void SetCodigo(int novoCodigo)
        {
            codigo = novoCodigo;
        }
        public int GetCodigo()
        {
            return codigo;
        }

        public void SetNome(string novoNome)
        {
            nome = novoNome;
        }

        public string GetNome()
        {
            return nome;
        }

        public void SetPreco(double novoPreco)
        {
            // Validação: preço não pode ser negativo
            if (novoPreco >= 0)
            {
                preco = novoPreco;
            }
            else
            {
                Console.WriteLine("Erro: Preço não pode ser negativo!");
            }
        }

        public double GetPreco()
        {
            return preco;
        }

        public void AdicionarEstoque(int quantidade)
        {
            if (quantidade > 0)
            {
                quantidadeEstoque += quantidade;
            }
        }

        // Método para remover do estoque com validação de quantidade válida e disponível no estoque
        public void RemoverEstoque(int quantidade)
        {
            if (quantidade > 0 && quantidade <= quantidadeEstoque)
            {
                quantidadeEstoque -= quantidade;
            }
            else
            {
                Console.WriteLine("Erro: Quantidade inválida ou estoque insuficiente!");
            }
        }

        public int GetQuantidadeEstoque()
        {
            return quantidadeEstoque;
        }
        
        // Método para exibir informações do produto
        public void ExibirInfo()
        {
            Console.WriteLine($"Código: {codigo}     Produto: {nome}     Preço: R${preco:F2}     Estoque: {quantidadeEstoque} unidades");
        }

        public void RegistrarVenda(int quantidade, double valorVenda)
        {
            quantidadeVendida += quantidade;
            valorTotalVendas += valorVenda;
        }

        public int GetQuantidadeVendida()
        {
            return quantidadeVendida;
        }

        public double GetValorTotalVendas()
        {
            return valorTotalVendas;
        }
    }
    
    // Classe Caixa para armazenar o saldo e os percentuais de desconto
    class Caixa
    {
        private double saldo;
        private double valorMinimoDesconto;
        private double percentualDesconto;

        public void SetSaldo(double novoSaldo)
        {
            saldo = novoSaldo;
        }

        public double GetSaldo()
        {
            return saldo;
        }

        public void SetValorMinimoDesconto(double novoValorMinimoDesconto)
        {
            valorMinimoDesconto = novoValorMinimoDesconto;
        }

        public double GetValorMinimoDesconto()
        {
            return valorMinimoDesconto;
        }

        public void SetPercentualDesconto(double novoPercentualDesconto)
        {
            percentualDesconto = novoPercentualDesconto;
        }

        public double GetPercentualDesconto()
        {
            return percentualDesconto;
        }

    }
    
    // Classe Menu para exibir os menus e pausar a execução
    class Menu
    {
        public static int ExibirMenuInicial()
        {
            Console.Clear();
            string[] opcoes = {
                "Relatórios e Opções",
                "Editar produtos",
                "Atualizar Estoque",
                "Realizar Venda",
                "Sair"};

            return chamarMenu("Inicial", opcoes);
        }

        public static int ExibitMenuRelatorio()
        {
            string[] opcoes = {
                "Relatório de Vendas",
                "Ajustar Valor Minimo para Desconto",
                "Ajustar Percentual de Desconto",
                "Voltar"};

            return chamarMenu("Relatório", opcoes);
        }

        public static int ExibirMenuEdit()
        {
            string[] opcoes = {
                "Editar nome do produto",
                "Editar preço do produto",
                "Voltar"};

            return chamarMenu("de Edição", opcoes);
        }

        public static int ExibirMenuEstoque()
        {
            string[] opcoes = {
                "Adicionar Produto",
                "Remover Produto",
                "Voltar"};

            return chamarMenu("Estoque", opcoes);

        }

        public static int ExibirMenuVenda()
        {
            string[] opcoes = {
                "Realizar Venda",
                "Voltar" };

            return chamarMenu("Venda", opcoes);
        }

        // Método utilitário para chamar o menu
        static int chamarMenu(string Menu, string[] opcoes)
        {
            Console.WriteLine($"Bem vindo ao Menu {Menu}");
            for (int i = 0; i < opcoes.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {opcoes[i]}");
            }
            Console.WriteLine("Escolha uma opção:");
            return opcoes.Length;
        }

        public static void Pausa()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadLine();
        }
    }
    
    // Classe Ler para ler opções e confirmar operações com validação
    class Ler
    {
        // Lê e valida uma opção numérica dentro de um intervalo
        public static int LerOpcao(int min, int max)
        {
            int opcao;
            // Continua pedindo até receber um valor válido
            while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < min || opcao > max)
            {
                Console.WriteLine($"Opção inválida! Digite entre {min} e {max}:");
            }
            return opcao;
        }
        // Lê e valida um número decimal dentro de um intervalo
        public static double LerDecimal(int min, int max)
        {
            double numero;
            while (!double.TryParse(Console.ReadLine(), out numero) || numero < min || numero > max)
            {
                Console.WriteLine($"Valor inválido! Digite entre {min} e {max}:");
            }
            return numero;
        }

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

    // Classe Program onde está todo o código principal
    class Program
    {
        static void Main(string[] args)
        {
            // Inicialização dos produtos do sistema com estoque inicial
            Produto p1 = new Produto();
            
            // Configurando o produto
            p1.SetCodigo(1);
            p1.SetNome("Notebook");
            p1.SetPreco(2500.00);
            p1.AdicionarEstoque(10);

            Produto p2 = new Produto();

            p2.SetCodigo(2);
            p2.SetNome("Mouse");
            p2.SetPreco(50.00);
            p2.AdicionarEstoque(50);

            // Inicialização do caixa com saldo e regras de desconto
            Caixa c1 = new Caixa();

            c1.SetSaldo(1000.00);
            c1.SetValorMinimoDesconto(100.00);
            c1.SetPercentualDesconto(10);

            int maxOpcoes;
            int opcao;

            // Loop principal do programa - continua até o usuário escolher "Sair"
            do
            {
                maxOpcoes = Menu.ExibirMenuInicial();
                opcao = Ler.LerOpcao(1, maxOpcoes);

                switch (opcao)
                {
                    case 1:
                        //Opção 1 onde está o relatório e opções de edição de desconto
                        Console.Clear();
                        int maxOpcoesRelatorio;
                        int opcaoRelatorio;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine($"Saldo atual: R${c1.GetSaldo():F2}");
                            Console.WriteLine($"Valor minimo para desconto: R${c1.GetValorMinimoDesconto():F2}");
                            Console.WriteLine($"Percentual de desconto: {c1.GetPercentualDesconto():F2}%");
                            Console.WriteLine();
                            maxOpcoesRelatorio = Menu.ExibitMenuRelatorio();
                            opcaoRelatorio = Ler.LerOpcao(1, maxOpcoesRelatorio);

                            switch (opcaoRelatorio)
                            {
                                case 1:
                                     // Exibe relatório completo de vendas de todos os produtos
                                    p1.ExibirInfo();
                                    Console.WriteLine($"Total vendido: {p1.GetQuantidadeVendida()} unidades - R${p1.GetValorTotalVendas():F2}");
                                    Console.WriteLine();
                                    p2.ExibirInfo();
                                    Console.WriteLine($"Total vendido: {p2.GetQuantidadeVendida()} unidades - R${p2.GetValorTotalVendas():F2}");
                                    Menu.Pausa();
                                    break;
                                case 2:
                                     Console.WriteLine("Digite o novo valor minimo para desconto (0 para cancelar):");
                                    double novoValorMinimoDesconto = Ler.LerDecimal(0, 10000);
                                    
                                    // Verifica se o usuário digitou 0 para cancelar a operação
                                    if (novoValorMinimoDesconto == 0)
                                    {
                                        Console.WriteLine("Operação cancelada.");
                                        break;
                                    }
                                    else
                                    {
                                        c1.SetValorMinimoDesconto(novoValorMinimoDesconto);
                                        Console.WriteLine($"Valor minimo para desconto atualizado para: R${c1.GetValorMinimoDesconto():F2}");
                                        Menu.Pausa();
                                        break;
                                    }
                                case 3:
                                    Console.WriteLine("Digite o novo percentual de desconto (0 para cancelar):");
                                    double novoPercentualDesconto = Ler.LerDecimal(0, 30);
                                    if (novoPercentualDesconto == 0)
                                    {
                                        Console.WriteLine("Operação cancelada.");
                                        break;
                                    }
                                    else
                                    {
                                        c1.SetPercentualDesconto(novoPercentualDesconto);
                                        Console.WriteLine($"Percentual de desconto atualizado para: {c1.GetPercentualDesconto():F2}%");
                                        Menu.Pausa();
                                        break;
                                    }
                            }
                        } while (opcaoRelatorio != maxOpcoesRelatorio);
                        break;


                    case 2:
                        //Menu para edição de produtos (nome e preço)
                        Console.Clear();
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
                            p1.ExibirInfo();
                            p2.ExibirInfo();
                            Console.WriteLine("Digite o código do produto que deseja editar ou pressione 0 para sair:");
                            int codigoProduto = Ler.LerOpcao(0, 2);
                            if (codigoProduto == 0)
                            {
                                continue;
                            }
                            // Seleciona p1 se código for 1, caso contrário seleciona p2
                            Produto produtoSelecionado = (codigoProduto == 1) ? p1 : p2;

                            switch (opcaoEdit)
                            {
                                case 1:
                                    Console.WriteLine("Digite o novo nome (Enter para cancelar):");
                                    string novoNome = Console.ReadLine();

                                    if (string.IsNullOrWhiteSpace(novoNome))
                                    {
                                        Console.WriteLine("Operação cancelada.");
                                        break;
                                    }
                                    else
                                    {
                                        produtoSelecionado.SetNome(novoNome);
                                        Console.WriteLine("Nome atualizado!");
                                        produtoSelecionado.ExibirInfo();
                                        break;
                                    }
                                case 2:
                                    Console.WriteLine("Digite o novo preço (0 para cancelar):");
                                    double novoPreco = Ler.LerDecimal(0, 10000);
                                    
                                    if (novoPreco == 0)
                                    {
                                        Console.WriteLine("Operação cancelada.");
                                        break;
                                    }
                                    else
                                    {
                                        produtoSelecionado.SetPreco(novoPreco);
                                        produtoSelecionado.ExibirInfo();
                                        break;
                                    }
                            }
                            Menu.Pausa();
                            Console.Clear();

                        } while (opcaoEdit != maxOpcoesEdit);
                        break;
                    case 3:
                        //Menu para alteração de quantidade de estoque (adicionar ou remover)
                        Console.Clear();
                        int maxOpcoesEstoque;
                        int opcaoEstoque;
                        do
                        {
                            Console.Clear();
                            maxOpcoesEstoque = Menu.ExibirMenuEstoque();
                            opcaoEstoque = Ler.LerOpcao(1, maxOpcoesEstoque);

                            switch (opcaoEstoque)
                            {
                                case 1:
                                    p1.ExibirInfo();
                                    p2.ExibirInfo();
                                    Console.WriteLine("Digite o código do produto que deseja adicionar estoque ou pressione 0 para sair:");
                                    int codigoProduto = Ler.LerOpcao(0, 2);

                                    if (codigoProduto == 0)
                                    {
                                        break;
                                    }

                                    Produto produtoSelecionado = (codigoProduto == 1) ? p1 : p2;

                                    Console.WriteLine("Digite a quantidade que deseja adicionar ou pressione 0 para sair:");
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
                                case 2:
                                    p1.ExibirInfo();
                                    p2.ExibirInfo();
                                    Console.WriteLine("Digite o código do produto que deseja remover estoque ou pressione 0 para sair:");
                                    codigoProduto = Ler.LerOpcao(0, 2);
                                    if (codigoProduto == 0)
                                    {
                                        break;
                                    }

                                    produtoSelecionado = (codigoProduto == 1) ? p1 : p2;

                                    Console.WriteLine("Digite a quantidade que deseja remover ou pressione 0 para sair:");
                                    quantidade = Ler.LerOpcao(0, produtoSelecionado.GetQuantidadeEstoque());
                                    produtoSelecionado.RemoverEstoque(quantidade);
                                    if (quantidade > 0)
                                    {
                                        Console.WriteLine("Estoque atualizado com sucesso!");
                                        produtoSelecionado.ExibirInfo();
                                        Menu.Pausa();
                                    }

                                    Console.Clear();

                                    break;
                            }
                        } while (opcaoEstoque != maxOpcoesEstoque);
                        break;
                    case 4:
                        //Menu de vendas que calcula valores e descontos além de remover estoque se a venda for confirmada
                        Console.Clear();
                        int maxOpcoesVenda;
                        int opcaoVenda;
                        do
                        {
                            Console.Clear();
                            maxOpcoesVenda = Menu.ExibirMenuVenda();
                            opcaoVenda = Ler.LerOpcao(0, maxOpcoesVenda);
                            switch (opcaoVenda)
                            {
                                case 1:

                                    Console.Clear();
                                    p1.ExibirInfo();
                                    p2.ExibirInfo();

                                    Console.WriteLine("Digite o código do produto ou pressione 0 para sair:");
                                    int codigoProduto = Ler.LerOpcao(0, 2);
                                    if (codigoProduto == 0)
                                    {
                                        break;
                                    }

                                    Produto produtoSelecionado = (codigoProduto == 1) ? p1 : p2;

                                    Console.WriteLine("Digite a quantidade que deseja vender:");
                                    int quantidade = Ler.LerOpcao(0, produtoSelecionado.GetQuantidadeEstoque());

                                    if (quantidade > 0)
                                    {
                                        double valorTotal = quantidade * produtoSelecionado.GetPreco();
                                        // Verifica se o valor total atinge o mínimo para desconto
                                        if (valorTotal >= c1.GetValorMinimoDesconto())
                                        {
                                            double desconto = valorTotal * c1.GetPercentualDesconto() / 100;
                                            Console.WriteLine($"Desconto aplicado: R${desconto:F2}");
                                            // Aplica o desconto ao valor total
                                            valorTotal -= valorTotal * c1.GetPercentualDesconto() / 100;
                                            Console.WriteLine($"Valor total com desconto: R${valorTotal:F2}");
                                        }
                                        Console.WriteLine($"Vender {quantidade} unidades de {produtoSelecionado.GetNome()} por R${valorTotal:F2}");
                                        if (Ler.Confirmar("Confirmar venda?"))
                                        {
                                            c1.SetSaldo(c1.GetSaldo() + valorTotal);
                                            Console.WriteLine($"Saldo atualizado: R${c1.GetSaldo():F2}");
                                            produtoSelecionado.RemoverEstoque(quantidade);
                                            Console.WriteLine("Estoque atualizado!");
                                            produtoSelecionado.ExibirInfo();
                                            produtoSelecionado.RegistrarVenda(quantidade, valorTotal);
                                            Menu.Pausa();
                                        }
                                    }
                                    break;

                                case 2:
                                    break;

                            }

                        } while (opcaoVenda != maxOpcoesVenda);
                        break;

                }
            } while (opcao != maxOpcoes);
        }
    }
}
