using System; 
using System.Collections.Generic;

class Sistema {
  private static Especie[] especies = new Especie[10];
  private static int nEspecie;
  private static List<Pet> pets = new List<Pet>();
  private static List<Cliente> clientes = new List<Cliente>();
  public static void EspecieInserir(Especie obj) {
    // Verifica o tamanho vetor
    if (nEspecie == especies.Length)
      Array.Resize(ref especies, 2 * especies.Length);
    // Insere o objeto no vetor
    especies[nEspecie] = obj;
    // Incrementa o contador
    nEspecie++;
  }
  public static Especie[] EspecieListar() {
    // Retorna os objetos cadastrados
    Especie[] aux = new Especie[nEspecie];
    Array.Copy(especies, aux, nEspecie);
    return aux;
  }
  public static Especie EspecieListar(int id) {
    // Percorre o vetor de espécies e retorna a espécie com o id informado
    foreach(Especie obj in especies)
      if (obj != null && obj.GetId() == id) return obj;
    return null;  
  }
  public static void EspecieAtualizar(Especie obj) {
    // Localiza a espécie com o id informado
    Especie aux = EspecieListar(obj.GetId());
    // Atualiza a descrição da espécie
    if (aux != null)
      aux.SetDescricao(obj.GetDescricao());
  }
  public static void EspecieExcluir(Especie obj) {
    // Localiza no vetor o índice desse objeto
    int aux = EspecieIndice(obj.GetId());
    // Remove a espécie se o índice for encontrado
    if (aux != -1) {
      for (int i = aux; i < nEspecie - 1; i++)
        especies[i] = especies[i + 1];
      // decrementa o contador de espécies
      nEspecie--;  
    }
  }
  private static int EspecieIndice(int id) {
    // Percorre o vetor com as espécies e retorna o índice do elemento com o id informado    
    for(int i = 0; i < nEspecie; i++) {
      // Cada objeto espécie no vetor
      Especie obj = especies[i];
      if (obj.GetId() == id) return i;
    }
    return -1;
  }
  
  public static void PetInserir(Pet obj) {
    // Insere o objeto na lista
    pets.Add(obj);
  }
  public static List<Pet> PetListar() {
    // Retorna os objetos cadastrados
    return pets;
  }
  public static List<Pet> PetListar(Cliente cliente) {
    // Retorna os objetos cadastrados para um cliente
    List<Pet> r = new List<Pet>();
    // Percorre a lista de pets e retorna os pets do cliente informado
    foreach(Pet obj in pets)
      if (obj.GetIdCliente() == cliente.Id) 
        r.Add(obj);
    return r;
  }
  public static Pet PetListar(int id) {
    // Percorre a lista de pets e retorna o pet com o id informado
    foreach(Pet obj in pets)
      if (obj.GetId() == id) return obj;
    return null;  
  }
  public static void PetAtualizar(Pet obj) {
    // Localiza o pet com o id informado
    Pet aux = PetListar(obj.GetId());
    // Atualiza os demais atributos do pet
    if (aux != null) {
      aux.SetNome(obj.GetNome());
      aux.SetRaca(obj.GetRaca());
      aux.SetNasc(obj.GetNasc());
      aux.SetIdEspecie(obj.GetIdEspecie());
    }  
  }
  public static void PetExcluir(Pet obj) {
    // Localiza o pet com o id informado
    Pet aux = PetListar(obj.GetId());
    // Remove o pet da lista
    if (aux != null) pets.Remove(aux);
  }

  public static void ClienteInserir(Cliente obj) {
    // Calcular o id do cliente a ser incluído
    int id = 0;
    foreach(Cliente aux in clientes)
      if (aux.Id > id) id = aux.Id;
    obj.Id = id + 1;  
    // Insere o objeto na lista
    clientes.Add(obj);
  }
  public static List<Cliente> ClienteListar() {
    // Retorna os objetos cadastrados
    return clientes;
  }
  public static Cliente ClienteListar(int id) {
    // Percorre a lista de clientes e retorna o cliente com o id informado
    foreach(Cliente obj in clientes)
      if (obj.Id == id) return obj;
    return null;  
  }
  public static void ClienteAtualizar(Cliente obj) {
    // Localiza o cliente com o id informado
    Cliente aux = ClienteListar(obj.Id);
    // Atualiza as demais propriedades do cliente
    if (aux != null) {
      aux.Nome = obj.Nome;
      aux.Fone = obj.Fone;
    }  
  }
  public static void ClienteExcluir(Cliente obj) {
    // Localiza o cliente com o id informado
    Cliente aux = ClienteListar(obj.Id);
    // Remove o cliente da lista
    if (aux != null) clientes.Remove(aux);
  }

}