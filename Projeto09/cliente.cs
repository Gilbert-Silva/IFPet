using System;

public class Cliente {
  public int Id { get; set; }
  public string Nome { get; set; }
  public string Fone { get; set; }
  public override string ToString() {
    return $"{Id} {Nome} {Fone}";
  }
}
