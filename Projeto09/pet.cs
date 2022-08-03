using System;

public class Pet {
  private int id;
  private string nome;
  private string raca;
  private DateTime nasc;
  private int idEspecie;
  private int idCliente;

  public int Id { 
    get => id; 
    set => id = value; 
  }
  public string Nome { 
    get => nome; 
    set => nome = value; 
  }
  public string Raca { 
    get => raca; 
    set => raca = value; 
  }
  public DateTime Nasc { 
    get => nasc; 
    set => nasc = value; 
  }
  public int IdEspecie { 
    get => idEspecie; 
    set => idEspecie = value; 
  }
  public int IdCliente { 
    get => idCliente; 
    set => idCliente = value; 
  }
 
  public Pet() { }
  public Pet(int id) {
    this.id = id;
  }
  public Pet(int id, string nome, string raca, DateTime nasc, int idEspecie, int idCliente) {
    this.id = id;
    this.nome = nome;
    this.raca = raca;
    this.nasc = nasc;
    this.idEspecie = idEspecie;
    this.idCliente = idCliente;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetNome(string nome) {
    this.nome = nome;
  }
  public void SetRaca(string raca) {
    this.raca = raca;
  }
  public void SetNasc(DateTime nasc) {
    this.nasc = nasc;
  }
  public void SetIdEspecie(int idEspecie) {
    this.idEspecie = idEspecie;
  }
  public void SetIdCliente(int idCliente) {
    this.idCliente = idCliente;
  }
  public int GetId() {
    return id;
  }
  public string GetNome() {
    return nome;
  }
  public string GetRaca() {
    return raca;
  }
  public DateTime GetNasc() {
    return nasc;
  }
  public int GetIdEspecie() {
    return idEspecie;
  }
  public int GetIdCliente() {
    return idCliente;
  }
  public override string ToString() {
    return $"{id} - {nome} - {raca} - {nasc:dd/MM/yyyy}";
  }
}