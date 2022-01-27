using System;

class Program {
  public static void Main() {
    Console.WriteLine("Bem-vindo ao IFPet");
    Especie e1 = new Especie(1, "Cachorro");
    Especie e2 = new Especie(2, "Gato");
    Pet p1 = new Pet(1, "Dog1", "Raca1", DateTime.Parse("01/01/2015"), 1);
    Pet p2 = new Pet(2, "Dog2", "Raca1", DateTime.Parse("01/01/2016"), 1);
    Console.WriteLine(e1);
    Console.WriteLine(e2);
    Console.WriteLine(p1);
    Console.WriteLine(p2);
  }
}
