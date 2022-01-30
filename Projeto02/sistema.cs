using System; 

class Sistema {
  private static Especie[] especies = new Especie[10];
  private static int nEspecie;
  public static void EspecieInserir(Especie obj) {
    // Verifica o tamenho vetor
    if (nEspecie == especies.Length)
      Array.Resize(ref especies, 2 * especies.Length);
    // Inserir o objeto no vetor
    especies[nEspecie] = obj;
    // incrementar o contador
    nEspecie++;
  }
  public static Especie[] EspecieListar() {
    // Retornar os objetos cadastrados
    Especie[] aux = new Especie[nEspecie];
    Array.Copy(especies, aux, nEspecie);
    return aux;
  }
  public static Especie EspecieListar(int id) {
    // Percorrer o vetor as espécies e retornar a espécie com o id informado
    foreach(Especie obj in especies)
      if (obj != null && obj.GetId() == id) return obj;
    return null;  
  }
  public static void EspecieAtualizar(Especie obj) {
    // Localizar a especie com o if informado
    Especie aux = EspecieListar(obj.GetId());
    // Atualiza a descrição da espécia
    if (aux != null)
      aux.SetDescricao(obj.GetDescricao());
  }
  public static void EspecieExcluir(Especie obj) {
    // Localizar no vetor o indice desse objeto
    int aux = EspecieIndice(obj.GetId());
    // Remove a especie se o indice foi encontrado
    if (aux != -1) {
      for (int i = aux; i < nEspecie - 1; i++)
        especies[i] = especies[i + 1];
      // decrementa o contador de especies
      nEspecie--;  
    }
  }
  private static int EspecieIndice(int id) {
    // Percorrer o vetor com as espécies e retornar o índice do elemento com o id informado    
    for(int i = 0; i < nEspecie; i++) {
      // Cada objeto especie no vetor
      Especie obj = especies[i];
      if (obj.GetId() == id) return i;
    }
    return -1;
  }
}