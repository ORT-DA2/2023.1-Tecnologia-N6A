using WebApi.Models.Out;

namespace WebApi.Models.In;

public class ImportModel
{
    public string ImporterName { get; set; }
    public List<NeededParameterModel> Parameters { get; set; }

}