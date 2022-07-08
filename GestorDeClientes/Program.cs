using System.Runtime.Serialization.Formatters.Binary;

namespace GestorDeClientes;

class Program
{
    [Serializable]
    struct Contato { public string nome, email, cpf; }
    static List<Contato> contatos = new List<Contato>();

    enum Menu { Adicionar = 1, Listar = 2, Remover = 3, Sair = 4 }

    static void Main(string[] args)
    {
        Carregar();
        bool sairApp = false;
        while (!sairApp)
        {
            Console.WriteLine("Bem vindo ao app Gestor de Clientes");
            Console.WriteLine("Selecione a opção desejada:\n");
            Console.WriteLine("1 - Adicionar novo contato\n" +
                "2 - Listar contatos adicionados\n" +
                "3 - Editar contatos\n" +
                "4 - Sair do Gestor de Clientes\n");

            Menu menu = new Menu();
            menu = (Menu)int.Parse(Console.ReadLine());

            switch (menu)
            {
                case Menu.Adicionar:
                    Adicionar();
                    break;
                case Menu.Listar:
                    Listar();
                    break;
                case Menu.Remover:
                    Remover();
                    break;
                case Menu.Sair:
                    sairApp = true;
                    break;
            }
            Console.Clear();
        }
    }
    static void Adicionar()
    {
        Contato cliente = new Contato();
        Console.WriteLine("Entre com os dados do cliente");
        Console.WriteLine("Nome: ");
        cliente.nome = Console.ReadLine();
        Console.WriteLine("E-mail: ");
        cliente.email = Console.ReadLine();
        Console.WriteLine("CPF: ");
        cliente.cpf = Console.ReadLine();

        contatos.Add(cliente);
        Salvar();
    }
    static void Listar()
    {
        if (contatos.Count > 0)
        {
            System.Console.WriteLine("Lista de clientes adicionadas\n");
            int i = 0;

            foreach (Contato contato in contatos)
            {
                System.Console.WriteLine($"ID: {i}");
                System.Console.WriteLine($"Nome: {contato.nome}");
                System.Console.WriteLine($"E-mail: {contato.email}");
                System.Console.WriteLine($"CPF: {contato.cpf}");
                i++;
                System.Console.WriteLine("*****************************");
            }
        }
        else
        {
            System.Console.WriteLine("Não foi encontrato nenhum dado na base.");
        }
        System.Console.WriteLine("Aperte enter para sair");
        Console.ReadLine();
    }
    static void Salvar()
    {
        FileStream stream = new FileStream("contato.dat", FileMode.OpenOrCreate);
        BinaryFormatter encoder = new BinaryFormatter();

        encoder.Serialize(stream, contatos);

        stream.Close();
    }
    static void Carregar()
    {
        FileStream stream = new FileStream("contato.dat", FileMode.OpenOrCreate);

        try
        {
            BinaryFormatter encoder = new BinaryFormatter();

            contatos = (List<Contato>)encoder.Deserialize(stream);

            if (contatos == null)
            {
                contatos = new List<Contato>();
            }

        }
        catch (Exception ex)
        {
            contatos = new List<Contato>();
        }

        stream.Close();
    }
    static void Remover()
    {
        Console.WriteLine("Digite o valor de ID desejado para excluir o dado: ");
        Listar();
        int id = int.Parse(Console.ReadLine());
        if (id >= 0 && id < contatos.Count)
        {
            contatos.RemoveAt(id);
            Salvar();
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }
}