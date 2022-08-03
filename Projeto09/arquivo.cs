using System; 
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;

class Arquivo<T> {
  public T Abrir(string arquivo) {
    XmlSerializer xml = new XmlSerializer(typeof(T));
    StreamReader f = new StreamReader(arquivo, Encoding.Default);
    T obj = (T) xml.Deserialize(f);
    f.Close();
    return obj;
  }

  public void Salvar(string arquivo, T obj) {
    XmlSerializer xml = new XmlSerializer(typeof(T));
    StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
    xml.Serialize(f, obj);
    f.Close();
  }
}
