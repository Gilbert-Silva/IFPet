using System; 
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;

class Sistema {
  private static Especie[] especies = new Especie[10];
  private static int nEspecie;
  private static List<Pet> pets = new List<Pet>();
  private static List<Cliente> clientes = new List<Cliente>();
  private static List<Servico> servicos = new List<Servico>();
  private static List<Agendamento> agendamentos = new List<Agendamento>();

  public static void ArquivosAbrir() {
    Arquivo<Especie[]> f1 = new Arquivo<Especie[]>();
    especies = f1.Abrir("./especies.xml");
    nEspecie = especies.Length;

    Arquivo<List<Pet>> f2 = new Arquivo<List<Pet>>();
    pets = f2.Abrir("./pets.xml");

    Arquivo<List<Cliente>> f3 = new Arquivo<List<Cliente>>();
    clientes = f3.Abrir("./clientes.xml");

    Arquivo<List<Servico>> f4 = new Arquivo<List<Servico>>();
    servicos = f4.Abrir("./servicos.xml");

    Arquivo<List<Agendamento>> f5 = new Arquivo<List<Agendamento>>();
    agendamentos = f5.Abrir("./agendamentos.xml");

    /*    
    XmlSerializer xml = new XmlSerializer(typeof(Especie[]));
    StreamReader f = new StreamReader("./especies.xml", Encoding.Default);
    especies = (Especie[]) xml.Deserialize(f);
    nEspecie = especies.Length;
    f.Close();
    */
  }

  public static void ArquivosSalvar() {
    Arquivo<Especie[]> f1 = new Arquivo<Especie[]>();
    f1.Salvar("./especies.xml", EspecieListar());

    Arquivo<List<Pet>> f2 = new Arquivo<List<Pet>>();
    f2.Salvar("./pets.xml", pets);

    Arquivo<List<Cliente>> f3 = new Arquivo<List<Cliente>>();
    f3.Salvar("./clientes.xml", clientes);

    Arquivo<List<Servico>> f4 = new Arquivo<List<Servico>>();
    f4.Salvar("./servicos.xml", servicos);

    Arquivo<List<Agendamento>> f5 = new Arquivo<List<Agendamento>>();
    f5.Salvar("./agendamentos.xml", agendamentos);
    
    /*
    XmlSerializer xml = new XmlSerializer(typeof(Especie[]));
    StreamWriter f = new StreamWriter("./especies.xml", false, Encoding.Default);
    xml.Serialize(f, EspecieListar());
    f.Close();
    */
  }
  
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


  public static void ServicoInserir(Servico obj) {
    // Calcular o id do serviço a ser incluído
    int id = 0;
    foreach(Servico aux in servicos)
      if (aux.Id > id) id = aux.Id;
    obj.Id = id + 1;  
    // Insere o objeto na lista
    servicos.Add(obj);
  }
  public static List<Servico> ServicoListar() {
    // Retorna os objetos cadastrados
    return servicos;
  }
  public static Servico ServicoListar(int id) {
    // Percorre a lista de serviços e retorna o serviço com o id informado
    foreach(Servico obj in servicos)
      if (obj.Id == id) return obj;
    return null;  
  }
  public static void ServicoAtualizar(Servico obj) {
    // Localiza o serviço com o id informado
    Servico aux = ServicoListar(obj.Id);
    // Atualiza as demais propriedades do serviço
    if (aux != null) {
      aux.Descricao = obj.Descricao;
      aux.Preco = obj.Preco;
    }  
  }
  public static void ServicoExcluir(Servico obj) {
    // Localiza o serviço com o id informado
    Servico aux = ServicoListar(obj.Id);
    // Remove o serviço da lista
    if (aux != null) servicos.Remove(aux);
  }

  public static void AgendamentoAbrirAgenda(DateTime data) {
    // Dia e horários de atendimento
    int[] horas = { 8, 9, 10, 11, 14, 15, 16, 17 };
    DateTime hoje = data.Date;
    foreach (int h in horas) {
      TimeSpan horario = new TimeSpan(0, h, 0, 0);
      Agendamento obj = new Agendamento { DataHora = hoje + horario };
      AgendamentoInserir(obj);
    }
  }
  public static void AgendamentoInserir(Agendamento obj) {
    // Calcular o id do agendamento a ser incluído
    int id = 0;
    foreach(Agendamento aux in agendamentos)
      if (aux.Id > id) id = aux.Id;
    obj.Id = id + 1;  
    // Insere o objeto na lista
    agendamentos.Add(obj);
  }
  public static List<Agendamento> AgendamentoListar() {
    // Retorna os objetos cadastrados
    return agendamentos;
  }
  public static List<Agendamento> AgendamentoListar(Cliente cliente) {
    // Retorna os objetos cadastrados para um cliente
    List<Agendamento> r = new List<Agendamento>();
    // Percorre a lista de agendamentos e retorna os agendamentos do cliente informado
    foreach(Agendamento obj in agendamentos)
      if (obj.IdCliente == cliente.Id) 
        r.Add(obj);
    return r;
  }
  public static List<Agendamento> AgendamentoListar(DateTime data) {
    // Retorna os agendamentos disponíveis em uma data
    List<Agendamento> r = new List<Agendamento>();
    // Percorre a lista de agendamentos 
    foreach(Agendamento obj in agendamentos)
      if (obj.IdCliente == 0 && obj.DataHora.Date == data.Date) 
        r.Add(obj);
    return r;
  }
  public static Agendamento AgendamentoListar(int id) {
    // Percorre a lista de agendamentos e retorna o agendamento com o id informado
    foreach(Agendamento obj in agendamentos)
      if (obj.Id == id) return obj;
    return null;  
  }
  public static void AgendamentoAtualizar(Agendamento obj) {
    // Localiza o agendamento com o id informado
    Agendamento aux = AgendamentoListar(obj.Id);
    // Atualiza as demais propriedades do agendamento
    if (aux != null) {
      //aux.DataHora = obj.DataHora;
      aux.IdCliente = obj.IdCliente;
      aux.IdPet = obj.IdPet;
      aux.IdServico = obj.IdServico;
    }  
  }
  public static void AgendamentoExcluir(Agendamento obj) {
    // Localiza o agendamento com o id informado
    Agendamento aux = AgendamentoListar(obj.Id);
    // Remove o agendamento da lista
    if (aux != null) agendamentos.Remove(aux);
  }


}