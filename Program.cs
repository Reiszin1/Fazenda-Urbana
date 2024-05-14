using System;
using System.Collections.Generic;

public class Program
{
    // Classe para representar um funcionário
    public class Funcionario
    {
        private static int proximoId = 1; // ID sequencial começa em 1

        public int Id { get; } // O ID é somente leitura após ser atribuído no construtor
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public bool Gerente { get; set; } // Indica se o funcionário é gerente
        public bool GerenteProducao { get; set; } // Indica se o funcionário é gerente de produção
        public string Senha { get; set; } // Senha do funcionário
        public int[] Permissoes { get; set; } // Permissões do funcionário

        public Funcionario()
        {
            Id = proximoId++; // Atribui o próximo ID sequencial e incrementa o contador para o próximo ID
        }

        // Método para cadastrar frutas
        public void CadastrarFrutas()
        {
            List<Fruta> frutas = new List<Fruta>();

            while (true)
            {
                Console.WriteLine("Menu Gerente de Produção:");
                Console.WriteLine("1. Cadastrar Frutas");
                Console.WriteLine("2. Visualizar Frutas Cadastradas");
                Console.WriteLine("3. Modificar Fruta"); // Nova opção
                Console.WriteLine("4. Excluir Fruta"); // Nova opção
                Console.WriteLine("5. Sair");

                Console.Write("Escolha uma opção: ");
                int opcaoGerenteProducao;

                try
                {
                    opcaoGerenteProducao = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcaoGerenteProducao)
                {
                    case 1:
                        CadastrarFruta(frutas);
                        break;
                    case 2:
                        VisualizarFrutasCadastradas(frutas);
                        break;
                    case 3:
                        ModificarFruta(frutas); // Chamada do método para modificar fruta
                        break;
                    case 4:
                        ExcluirFruta(frutas); // Chamada do método para excluir fruta
                        break;
                    case 5:
                        Console.WriteLine("Saindo do menu Gerente de Produção...");
                        return; // Retorna ao menu principal
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        // Método para cadastrar uma nova fruta
        private void CadastrarFruta(List<Fruta> frutas)
        {
            Fruta novaFruta = new Fruta();
            Console.Clear(); // Limpa o console antes de exibir o formulário de cadastro de frutas
            Console.WriteLine("Cadastro de Fruta:");
            Console.Write("Nome da fruta: ");
            novaFruta.Nome = Console.ReadLine();
            decimal preco;

            while (true)
            {
                Console.Write("Preço da fruta: ");

                try
                {
                    preco = decimal.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, insira um preço válido.");
                }
            }

            novaFruta.Preco = preco;
            Console.Write("Tipo da fruta: ");
            novaFruta.Tipo = Console.ReadLine();
            frutas.Add(novaFruta);
            Console.WriteLine("Fruta cadastrada com sucesso!");
            Console.ReadKey(); // Aguarda um pressionamento de tecla antes de retornar ao menu Gerente de Produção
        }

        // Método para visualizar as frutas cadastradas
        private void VisualizarFrutasCadastradas(List<Fruta> frutas)
        {
            Console.Clear(); // Limpa o console antes de exibir as frutas cadastradas
            if (frutas.Count == 0)
            {
                Console.WriteLine("Nenhuma fruta cadastrada.");
            }
            else
            {
                Console.WriteLine("\nFrutas Cadastradas:");
                // Mostra as frutas cadastradas
                foreach (var fruta in frutas)
                {
                    Console.WriteLine($"Nome: {fruta.Nome}, Preço: {fruta.Preco}, Tipo: {fruta.Tipo}");
                }
            }
            Console.ReadKey(); // Aguarda um pressionamento de tecla antes de retornar ao menu Gerente de Produção
        }

        // Método para modificar uma fruta existente
        private void ModificarFruta(List<Fruta> frutas)
        {
            Console.Clear(); // Limpa o console antes de exibir as frutas cadastradas
            if (frutas.Count == 0)
            {
                Console.WriteLine("Nenhuma fruta cadastrada para modificar.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Modificar Fruta:");
            Console.WriteLine("Lista de Frutas:");
            for (int i = 0; i < frutas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Nome: {frutas[i].Nome}, Preço: {frutas[i].Preco}, Tipo: {frutas[i].Tipo}");
            }

            Console.Write("Escolha o número da fruta que deseja modificar ou digite 0 para sair: ");
            int indice;

            while (true)
            {
                try
                {
                    indice = int.Parse(Console.ReadLine());
                    if (indice == 0)
                        return; // Sair do método se 0 for digitado
                    if (indice > 0 && indice <= frutas.Count)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, escolha um número válido.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                }
            }

            Fruta frutaSelecionada = frutas[indice - 1];
            Console.WriteLine($"Modificando a fruta: {frutaSelecionada.Nome}");

            Console.Write("Novo nome da fruta: ");
            frutaSelecionada.Nome = Console.ReadLine();

            decimal novoPreco;

            while (true)
            {
                Console.Write("Novo preço da fruta: ");
                try
                {
                    novoPreco = decimal.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, insira um preço válido.");
                }
            }

            frutaSelecionada.Preco = novoPreco;

            Console.Write("Novo tipo da fruta: ");
            frutaSelecionada.Tipo = Console.ReadLine();

            Console.WriteLine("Fruta modificada com sucesso!");
            Console.ReadKey();
        }

        // Método para excluir uma fruta
        private void ExcluirFruta(List<Fruta> frutas)
        {
            Console.Clear(); // Limpa o console antes de exibir as frutas cadastradas
            if (frutas.Count == 0)
            {
                Console.WriteLine("Nenhuma fruta cadastrada para excluir.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Excluir Fruta:");
            Console.WriteLine("Lista de Frutas:");
            for (int i = 0; i < frutas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Nome: {frutas[i].Nome}, Preço: {frutas[i].Preco}, Tipo: {frutas[i].Tipo}");
            }

            Console.Write("Escolha o número da fruta que deseja excluir ou digite 0 para sair: ");
            int indice;

            while (true)
            {
                try
                {
                    indice = int.Parse(Console.ReadLine());
                    if (indice == 0)
                        return; // Sair do método se 0 for digitado
                    if (indice > 0 && indice <= frutas.Count)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, escolha um número válido.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                }
            }

            Fruta frutaSelecionada = frutas[indice - 1];
            Console.WriteLine($"Excluindo a fruta: {frutaSelecionada.Nome}");

            frutas.RemoveAt(indice - 1);

            Console.WriteLine("Fruta excluída com sucesso!");
            Console.ReadKey();
        }
    }

    // Classe para representar uma fruta
    public class Fruta
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Tipo { get; set; }
    }

    // Método para realizar o login
    public static Funcionario FazerLogin(List<Funcionario> funcionarios)
    {
        Console.WriteLine("Login:");
        Console.Write("ID: ");
        int id;

        try
        {
            id = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Por favor, insira um ID válido.");
            return null;
        }

        Console.Write("Senha: ");
        string senha = Console.ReadLine();

        // Verificar se as credenciais estão corretas
        foreach (var funcionario in funcionarios)
        {
            if (funcionario.Id == id && funcionario.Senha == senha)
            {
                return funcionario;
            }
        }
        return null; // Credenciais inválidas
    }

    // Método para cadastrar um novo funcionário
    public static void CadastrarFuncionario(List<Funcionario> funcionarios)
    {
        Funcionario novoFuncionario = new Funcionario();
        string senhaProvisoria1;
        string senhaProvisoria2;

        Console.WriteLine("Cadastro de Funcionário:");
        Console.Write("Nome: ");
        novoFuncionario.Nome = Console.ReadLine();
        decimal salario;

        while (true)
        {
            Console.Write("Salário: ");

            try
            {
                salario = decimal.Parse(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, insira um salário válido.");
            }
        }

        novoFuncionario.Salario = salario;
        Console.Write("Senha: ");
        senhaProvisoria1 = Console.ReadLine();
        Console.WriteLine("Digite a senha novamente");
        senhaProvisoria2 = Console.ReadLine();

        if (senhaProvisoria1 == senhaProvisoria2)
        {
            novoFuncionario.Senha = senhaProvisoria1;
        }
        else
        {
            Console.WriteLine("Senhas não correspondem. Cadastro cancelado.");
            return;
        }

        Console.WriteLine("Selecione o setor do funcionário:");
        Console.WriteLine("1. Produção");
        Console.WriteLine("2. Estoque");
        Console.WriteLine("3. Vendas");
        Console.WriteLine("4. Financeiro");
        Console.WriteLine("5. RH");
        Console.WriteLine("6. Administrativo");
        Console.Write("Escolha uma opção: ");
        int opcaoSetor;

        while (true)
        {
            try
            {
                opcaoSetor = int.Parse(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, insira uma opção válida.");
            }
        }

        switch (opcaoSetor)
        {
            case 1:
                novoFuncionario.Gerente = true;
                novoFuncionario.GerenteProducao = true;
                novoFuncionario.Permissoes = new int[] { 1, 0, 0, 0, 0, 0 }; // Permissão 1 para o setor de produção
                break;
            case 2:
                novoFuncionario.Gerente = true;
                novoFuncionario.Permissoes = new int[] { 0, 1, 0, 0, 0, 0 }; // Permissão 1 para o setor de estoque
                break;
            case 3:
                novoFuncionario.Gerente = true;
                novoFuncionario.Permissoes = new int[] { 0, 0, 1, 0, 0, 0 }; // Permissão 1 para o setor de vendas
                break;
            case 4:
                novoFuncionario.Gerente = true;
                novoFuncionario.Permissoes = new int[] { 0, 0, 0, 1, 0, 0 }; // Permissão 1 para o setor financeiro
                break;
            case 5:
                novoFuncionario.Gerente = true;
                novoFuncionario.Permissoes = new int[] { 0, 0, 0, 0, 1, 0 }; // Permissão 1 para o setor RH
                break;
            case 6:
                novoFuncionario.Gerente = true;
                novoFuncionario.Permissoes = new int[] { 0, 0, 0, 0, 0, 1 }; // Permissão 1 para o setor administrativo
                break;
            default:
                Console.WriteLine("Opção inválida. Funcionário não é gerente.");
                novoFuncionario.Gerente = false;
                novoFuncionario.GerenteProducao = false;
                novoFuncionario.Permissoes = new int[] { 0, 0, 0, 0, 0, 0 }; // Sem permissões adicionais
                break;
        }

        funcionarios.Add(novoFuncionario);
        Console.WriteLine($"Funcionário cadastrado com sucesso! Seu ID é: {novoFuncionario.Id}");
        Console.ReadKey(); // Aguarda um pressionamento de tecla antes de retornar ao menu principal
    }

    // Método para listar todos os funcionários cadastrados
    public static void ListarFuncionarios(List<Funcionario> funcionarios)
    {
        Console.Clear(); // Limpa o console antes de exibir a lista de funcionários
        Console.WriteLine("\nLista de Funcionários:");
        foreach (var funcionario in funcionarios)
        {
            Console.WriteLine($"ID: {funcionario.Id}, Nome: {funcionario.Nome}, Salário: {funcionario.Salario}, Gerente: {funcionario.Gerente}, Gerente de Produção: {funcionario.GerenteProducao}");
        }
        Console.ReadKey(); // Aguarda um pressionamento de tecla antes de retornar ao menu principal
    }

    public static void ModificarFuncionario(List<Funcionario> funcionarios)
    {
        Console.Clear(); // Limpa o console antes de exibir a lista de funcionários
        if (funcionarios.Count == 0)
        {
            Console.WriteLine("Nenhum funcionário cadastrado para modificar.");
            Console.ReadKey();
            return;
        }

        while (true)
        {
            Console.WriteLine("Modificar Funcionário:");
            Console.WriteLine("Lista de Funcionários:");
            for (int i = 0; i < funcionarios.Count; i++)
            {
                Console.WriteLine($"{i + 1}. ID: {funcionarios[i].Id}, Nome: {funcionarios[i].Nome}, Salário: {funcionarios[i].Salario}, Gerente: {funcionarios[i].Gerente}, Gerente de Produção: {funcionarios[i].GerenteProducao}");
            }

            Console.Write("Escolha o número do funcionário que deseja modificar ou digite 0 para sair: ");
            int indice;

            while (true)
            {
                try
                {
                    indice = int.Parse(Console.ReadLine());
                    if (indice == 0)
                        return; // Sair do método se 0 for digitado
                    if (indice > 0 && indice <= funcionarios.Count)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, escolha um número válido.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                }
            }

            Funcionario funcionarioSelecionado = funcionarios[indice - 1];

            Console.Clear();
            Console.WriteLine($"Modificando o funcionário: ID: {funcionarioSelecionado.Id}, Nome: {funcionarioSelecionado.Nome}, Salário: {funcionarioSelecionado.Salario}, Gerente: {funcionarioSelecionado.Gerente}, Gerente de Produção: {funcionarioSelecionado.GerenteProducao}");

            Console.WriteLine("Selecione o campo que deseja modificar:");
            Console.WriteLine("1. Nome");
            Console.WriteLine("2. Salário");
            Console.WriteLine("3. Senha");
            Console.WriteLine("4. Tipo de gerência");
            Console.WriteLine("5. Permissões");

            int opcaoCampo;

            while (true)
            {
                try
                {
                    opcaoCampo = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, insira uma opção válida.");
                }
            }

            switch (opcaoCampo)
            {
                case 1:
                    Console.Write("Novo nome: ");
                    funcionarioSelecionado.Nome = Console.ReadLine();
                    break;
                case 2:
                    decimal novoSalario;
                    while (true)
                    {
                        Console.Write("Novo salário: ");
                        try
                        {
                            novoSalario = decimal.Parse(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Por favor, insira um salário válido.");
                        }
                    }
                    funcionarioSelecionado.Salario = novoSalario;
                    break;
                case 3:
                    Console.Write("Nova senha: ");
                    funcionarioSelecionado.Senha = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Selecione o tipo de gerência:");
                    Console.WriteLine("1. Gerente de Produção");
                    Console.WriteLine("2. Outro tipo de gerência");
                    int tipoGerencia;
                    while (true)
                    {
                        try
                        {
                            tipoGerencia = int.Parse(Console.ReadLine());
                            if (tipoGerencia == 1)
                            {
                                funcionarioSelecionado.GerenteProducao = true;
                                break;
                            }
                            else if (tipoGerencia == 2)
                            {
                                funcionarioSelecionado.GerenteProducao = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Por favor, escolha uma opção válida.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Por favor, insira uma opção válida.");
                        }
                    }
                    break;
                case 5:
                    Console.WriteLine("Modificação de permissões não implementada neste exemplo.");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine("Funcionário modificado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar modificando ou '0' para sair.");
            var continuar = Console.ReadLine();
            if (continuar == "0")
            {
                break;
            }
        }
    }


    // Método para excluir um funcionário
    public static void ExcluirFuncionario(List<Funcionario> funcionarios)
    {
        Console.WriteLine("Excluir Funcionário");
        ListarFuncionarios(funcionarios);

        Console.WriteLine("\n");
        Console.Write("Digite o ID do funcionário que deseja excluir: ");
        Console.Write("Digite 0 para sair: ");

        int id;

        while (true)
        {
            try
            {
                id = int.Parse(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, insira um ID válido.");
            }
        }

        if (id == 0)
        {
            Console.WriteLine("Saindo...");
            Console.ReadKey();
            return;
        }

        Funcionario funcionario = funcionarios.Find(f => f.Id == id);

        if (funcionario == null)
        {
            Console.WriteLine("Funcionário não encontrado.");
            Console.ReadKey();
            return;
        }

        funcionarios.Remove(funcionario);
        Console.WriteLine("Funcionário excluído com sucesso!");
        Console.ReadKey();
    }

    public static void Main(string[] args)
    {
        List<Funcionario> funcionarios = new List<Funcionario>();

        while (true)
        {
            Console.Clear(); // Limpa o console antes de exibir o menu principal
            Console.WriteLine("Bem-vindo ao sistema da Fazenda Urbana!");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Cadastrar Funcionário");
            Console.WriteLine("3. Listar Funcionários");
            Console.WriteLine("4. Atualizar Informações do Funcionário");
            Console.WriteLine("5. Excluir Funcionário");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");
            int opcao;

            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, insira um número válido.");
                Console.ReadKey();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    Funcionario funcionarioLogado = FazerLogin(funcionarios);

                    if (funcionarioLogado != null)
                    {
                        Console.WriteLine($"Login bem-sucedido! Bem-vindo, {funcionarioLogado.Nome}!");
                        if (funcionarioLogado.GerenteProducao)
                        {
                            funcionarioLogado.CadastrarFrutas(); // Executa o método de cadastro de frutas se o funcionário é gerente de produção
                        }
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Falha no login. Verifique suas credenciais.");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    CadastrarFuncionario(funcionarios);
                    break;
                case 3:
                    ListarFuncionarios(funcionarios);
                    break;
                case 4:
                    ModificarFuncionario(funcionarios);
                    break;
                case 5:
                    ExcluirFuncionario(funcionarios);
                    break;
                case 6:
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
