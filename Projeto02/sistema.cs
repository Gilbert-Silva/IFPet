using System; 

class Sistema {
  private static Especie[] especies = new Especie[10];
  private static int nEspecie;
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
    // Percorre o vetor as espécies e retorna a espécie com o id informado
    foreach(Especie obj in especies)
      if (obj != null && obj.GetId() == id) return obj;
    return null;  
  }
  public static void EspecieAtualizar(Especie obj) {
    // Localiza a especie com o id informado
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
}