using System;

class Pet {
  private int id;
  private string nome;
  private string raca;
  private DateTime nasc;
  private int idEspecie;
  public Pet(int id) {
    this.id = id;
  }
  public Pet(int id, string nome, string raca, DateTime nasc, int idEspecie) {
    this.id = id;
    this.nome = nome;
    this.raca = raca;
    this.nasc = nasc;
    this.idEspecie = idEspecie;
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
  public override string ToString() {
    return $"{id} - {nome} - {raca} - {nasc:dd/MM/yyyy}";
  }
}