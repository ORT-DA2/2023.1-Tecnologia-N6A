using Domain;
using Domain.Importer;
using ImporterInterface;

namespace IBusinessLogic;

public interface IImporterLogic
{
  List<IImporter> GetAllImporters();
  List<Pet> ImportPets(string importerName, List<Parameter> parameters);
}
