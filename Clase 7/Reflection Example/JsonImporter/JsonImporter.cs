using Domain;
using Domain.Importer;
using ImporterInterface;

namespace JsonImporter;
public class JsonImporter : IImporter
{
  public string GetName()
  {
    return "Soy un Json jajaj";
  }

  public List<Parameter> GetParameters()
  {
    return new List<Parameter>()
    {
      new Parameter()
      {
        Name = "File Name",
        Necessary = true,
        ParameterType = ParameterType.Text
      },
    };
  }

  public List<Pet> ImportPets(List<Parameter> parameters)
  {
    // Deberia leer de un archivo JSON....
    var fileName = parameters.Find(p => p.Name == "File Name");
    var parsedName = fileName.Value.ToString();
    // aca tengo el nombre del archivo, ahora lo leo...
    
    // esto es harcodeado
    return new List<Pet>() { new Pet() { Id = 1, Name = parsedName, Age = 1 } };
  }
}
