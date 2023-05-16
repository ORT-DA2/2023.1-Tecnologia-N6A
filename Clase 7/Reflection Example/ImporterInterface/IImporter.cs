using Domain;
using Domain.Importer;

namespace ImporterInterface;

public interface IImporter
{
  string GetName();
  List<Parameter> GetParameters();
  List<Pet> ImportPets(List<Parameter> parameters);
}
