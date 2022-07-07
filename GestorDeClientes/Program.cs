namespace GestorDeClientes
{
    [Serializable]
    struct Contato { public string nome, email, cpf; }
    enum Menu { Adicionar = 1, Listar = 2, Editar = 3, Sair = 4 }
    class Program
    {
        static void Main(string[] args)
        {                

            bool sairApp = false;
            while(!sairApp)
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
                        break;
                    case Menu.Editar:
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
        }
    }
}