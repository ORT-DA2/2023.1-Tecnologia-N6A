using System.Reflection;
using Domain;
using Domain.Importer;
using IBusinessLogic;
using ImporterInterface;

namespace BusinessLogic;

public class ImporterLogic : IImporterLogic
{
  public List<IImporter> GetAllImporters()
  {
    return GetImporterImplementations();
  }

  public List<Pet> ImportPets(string importerName, List<Parameter> parameters)
  {
    List<IImporter> importers = GetImporterImplementations();
    IImporter? desiredImplementation = null;

    foreach (IImporter importer in importers)
    {
      if (importer.GetName() == importerName)
      {
        desiredImplementation = importer;
        break;
      }
    }

    if (desiredImplementation == null)
      throw new ResourceNotFoundException("No se pudo encontrar el importador solicitado");

    List<Pet> importedPets = desiredImplementation.ImportPets(parameters);
    return importedPets;
  }

  private List<IImporter> GetImporterImplementations()
  {
    List<IImporter> availableImporters = new List<IImporter>();
    string importersPath = "./Importers";
    string[] filePaths = Directory.GetFiles(importersPath);
    // "./Importers/JsonImporter.dll" y "./Importers/XmlImporter.dll"

    foreach (string filePath in filePaths)
    {
      if (filePath.EndsWith(".dll"))
      {
        FileInfo fileInfo = new FileInfo(filePath);
        Assembly assembly = Assembly.LoadFile(fileInfo.FullName);
        // ./Importers/JsonImporter.dll

        foreach (Type type in assembly.GetTypes())
        {
          // List = [Tipo JsonImporter, ...]
          if (typeof(IImporter).IsAssignableFrom(type) && !type.IsInterface)
          {
            IImporter importer = (IImporter)Activator.CreateInstance(type);
            if (importer != null)
              availableImporters.Add(importer);
          }
        }
      }
    }

    return availableImporters;
  }
}
