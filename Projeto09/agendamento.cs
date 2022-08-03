using System;

public class Agendamento {
  public int Id { get; set; }
  public DateTime DataHora { get; set; }
  public int IdCliente { get; set; }
  public int IdPet { get; set; }
  public int IdServico { get; set; }
  public override string ToString() {
    string s = $"{Id} {DataHora:dd/MM/yyyy HH:mm}";
    if (IdCliente == 0) s += " - Disponível";
    return s;
  }
}