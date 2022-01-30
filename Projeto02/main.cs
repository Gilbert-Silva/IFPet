using System;

class Program {
  public static void Main() {
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
    // Instanciar a classe Espécia
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
    // Instanciar a classe Espécia
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

}
