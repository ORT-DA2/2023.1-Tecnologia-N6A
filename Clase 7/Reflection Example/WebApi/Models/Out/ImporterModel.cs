using ImporterInterface;

namespace WebApi.Models.Out;

public class ImporterModel
{
    public string Name { get; set; }
    public List<ParameterModel> Parameters { get; set; }
    
    public ImporterModel(IImporter importer)
    {
        Name = importer.GetName();
        Parameters = importer.GetParameters()
            .Select(p => new ParameterModel(p)).ToList();
    }
}