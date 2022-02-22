using System;
using System.Globalization;
using System.Threading;

class Program {
  public static void Main() {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

    Console.WriteLine("Bem-vindo ao IFPet");
    int op = 0;
    do {
      try {
        op = Menu();
        switch(op) {
          case 1 : EspecieInserir(); break;
          case 2 : EspecieListar(); break;
          case 3 : EspecieAtualizar(); break;
          case 4 : EspecieExcluir(); break;
          case 5 : PetInserir(); break;
          case 6 : PetListar(); break;
          case 7 : PetAtualizar(); break;
          case 8 : PetExcluir(); break;
          case 9 : ClienteInserir(); break;
          case 10: ClienteListar(); break;
          case 11: ClienteAtualizar(); break;
          case 12: ClienteExcluir(); break;
          case 13: ServicoInserir(); break;
          case 14: ServicoListar(); break;
          case 15: ServicoAtualizar(); break;
          case 16: ServicoExcluir(); break;
          case 17: AgendamentoAbrirAgenda(); break;
          case 18: AgendamentoConsultarAgenda(); break;
        }
      }
      catch (Exception erro) {
        op = -1;
        Console.WriteLine("Erro: " + erro.Message);
      }
    } while (op != 0);
  }
  public static int Menu() {
    Console.WriteLine();
    Console.WriteLine("----- Escolha uma opção! -----");
    Console.WriteLine("01 - Inserir uma nova espécie");
    Console.WriteLine("02 - Listar as espécies cadastradas");
    Console.WriteLine("03 - Atualizar uma espécie");
    Console.WriteLine("04 - Excluir uma espécie");
    Console.WriteLine("05 - Inserir um novo pet");
    Console.WriteLine("06 - Listar os pets cadastrados");
    Console.WriteLine("07 - Atualizar um pet");
    Console.WriteLine("08 - Excluir um pet");
    Console.WriteLine("09 - Inserir um novo cliente");
    Console.WriteLine("10 - Listar os clientes cadastrados");
    Console.WriteLine("11 - Atualizar um cliente");
    Console.WriteLine("12 - Excluir um cliente");
    Console.WriteLine("13 - Inserir um novo serviço");
    Console.WriteLine("14 - Listar os serviços cadastrados");
    Console.WriteLine("15 - Atualizar um serviço");
    Console.WriteLine("16 - Excluir um serviço");
    Console.WriteLine("17 - Abrir Agenda");
    Console.WriteLine("18 - Consultar Agenda");
    Console.WriteLine("00 - Finalizar o sistema");
    Console.WriteLine("------------------------------");
    Console.Write("Opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static void EspecieInserir() {
    Console.WriteLine("----- Inserir uma nova espécie -----");
    // Dados da espécie
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a descrição: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe Espécie
    Especie obj =  new Especie(id, descricao);
    // Inserir a espécie no sistema
    Sistema.EspecieInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void EspecieListar() {
    Console.WriteLine("----- Listar as espécies cadastradas -----");
    foreach(Especie obj in Sistema.EspecieListar()) 
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }
  public static void EspecieAtualizar() {
    Console.WriteLine("----- Atualizar uma espécie -----");
    // Dados da espécie
    Console.Write("Informe o id da espécie a ser atualizada: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a nova descrição: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe Espécie
    Especie obj =  new Especie(id, descricao);
    // Atualizar a espécie no sistema
    Sistema.EspecieAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void EspecieExcluir() {
    Console.WriteLine("----- Excluir uma espécie -----");
    // Dados da espécie
    Console.Write("Informe o id da espécie a ser excluída: ");
    int id = int.Parse(Console.ReadLine());
    string descricao = "";
    // Instanciar a classe Espécie
    Especie obj =  new Especie(id, descricao);
    // Excluir a espécie no sistema
    Sistema.EspecieExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void PetInserir() {
    Console.WriteLine("----- Inserir um novo pet -----");
    // Dados do pet
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a raça: ");
    string raca = Console.ReadLine();
    Console.Write("Informe a data de nascimento: ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    // Lista as espécies
    EspecieListar();
    Console.Write("Informe a id da espécie: ");
    int idEspecie = int.Parse(Console.ReadLine());
    // Lista os clientes
    ClienteListar();
    Console.Write("Informe a id do cliente: ");
    int idCliente = int.Parse(Console.ReadLine());
    // Instanciar a classe Pet
    Pet obj =  new Pet(id, nome, raca, nasc, idEspecie, idCliente);
    // Inserir o pet no sistema
    Sistema.PetInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void PetListar() {
    Console.WriteLine("----- Listar os pets cadastrados -----");
    foreach(Pet obj in Sistema.PetListar()) { 
      Especie e = Sistema.EspecieListar(obj.GetIdEspecie());
      Cliente c = Sistema.ClienteListar(obj.GetIdCliente());
      Console.WriteLine($"{obj} {e.GetDescricao()} {c.Nome}");
    }
    Console.WriteLine("------------------------------------------");
  }
  public static void PetAtualizar() {
    Console.WriteLine("----- Atualizar um pet -----");
    // Dados do pet
    Console.Write("Informe o id do pet a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a raça: ");
    string raca = Console.ReadLine();
    Console.Write("Informe a data de nascimento: ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    // Lista as espécies
    EspecieListar();
    Console.Write("Informe a id da espécie: ");
    int idEspecie = int.Parse(Console.ReadLine());
    // Lista os clientes
    ClienteListar();
    Console.Write("Informe a id do cliente: ");
    int idCliente = int.Parse(Console.ReadLine());
    // Instanciar a classe Pet
    Pet obj =  new Pet(id, nome, raca, nasc, idEspecie, idCliente);
    // Atualizar o pet no sistema
    Sistema.PetAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void PetExcluir() {
    Console.WriteLine("----- Excluir um pet -----");
    // Dados do pet
    Console.Write("Informe o id do pet a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    // Instanciar a classe Pet
    Pet obj =  new Pet(id);
    // Excluir o pet do sistema
    Sistema.PetExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void ClienteInserir() {
    Console.WriteLine("----- Inserir um novo cliente -----");
    // Dados do cliente
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o fone: ");
    string fone = Console.ReadLine();
    // Instanciar a classe Cliente
    Cliente obj =  new Cliente { Nome = nome, Fone = fone };
    // Inserir o cliente no sistema
    Sistema.ClienteInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void ClienteListar() {
    Console.WriteLine("----- Listar os clientes cadastrados -----");
    foreach(Cliente obj in Sistema.ClienteListar()) 
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }
  public static void ClienteAtualizar() {
    Console.WriteLine("----- Atualizar um cliente -----");
    // Dados do cliente
    Console.Write("Informe o id do cliente a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o fone: ");
    string fone = Console.ReadLine();
    // Instanciar a classe Cliente
    Cliente obj =  new Cliente { Id = id, Nome = nome, Fone = fone };
    // Atualizar o cliente no sistema
    Sistema.ClienteAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void ClienteExcluir() {
    Console.WriteLine("----- Excluir um cliente -----");
    // Dados do cliente
    Console.Write("Informe o id do cliente a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    // Instanciar a classe Cliente
    Cliente obj =  new Cliente { Id = id };
    // Excluir o cliente do sistema
    Sistema.ClienteExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void ServicoInserir() {
    Console.WriteLine("----- Inserir um novo serviço -----");
    // Dados do serviço
    Console.Write("Informe a descrição: ");
    string desc = Console.ReadLine();
    Console.Write("Informe o preço: ");
    double preco = double.Parse(Console.ReadLine());
    // Instanciar a classe Servico
    Servico obj =  new Servico { Descricao = desc, Preco = preco };
    // Inserir o serviço no sistema
    Sistema.ServicoInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void ServicoListar() {
    Console.WriteLine("----- Listar os serviços cadastrados -----");
    foreach(Servico obj in Sistema.ServicoListar()) 
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }
  public static void ServicoAtualizar() {
    Console.WriteLine("----- Atualizar um serviço -----");
    // Dados do cliente
    Console.Write("Informe o id do serviço a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a descrição: ");
    string desc = Console.ReadLine();
    Console.Write("Informe o preço: ");
    double preco = double.Parse(Console.ReadLine());
    // Instanciar a classe Servico
    Servico obj =  new Servico { Id = id, Descricao = desc, Preco = preco };
    // Atualizar o serviço no sistema
    Sistema.ServicoAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void ServicoExcluir() {
    Console.WriteLine("----- Excluir um serviço -----");
    // Dados do serviço
    Console.Write("Informe o id do serviço a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    // Instanciar a classe Servico
    Servico obj =  new Servico { Id = id };
    // Excluir o serviço do sistema
    Sistema.ServicoExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void AgendamentoAbrirAgenda() {
    Console.WriteLine("----- Abrir Agenda -----");
    // Dia da agenda para Abrir
    DateTime data = DateTime.Today;
    Console.Write("Informe a data <enter para hoje>: ");
    string s = Console.ReadLine();
    if (s != "") data = DateTime.Parse(s);
    // Abrir Agenda
    Sistema.AgendamentoAbrirAgenda(data);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void AgendamentoConsultarAgenda() {
    Console.WriteLine("----- Consultar Agenda -----");
    foreach(Agendamento obj in Sistema.AgendamentoListar()) 
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }


}
