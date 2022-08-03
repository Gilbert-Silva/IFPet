using System;

public class Servico {
  public int Id { get; set; }
  public string Descricao { get; set; }
  public double Preco { get; set; }
  public override string ToString() {
    return $"{Id} {Descricao} R$ {Preco:0.00}";
  }
}