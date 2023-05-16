using Domain.Importer;

namespace WebApi.Models.Out;

public class ParameterModel
{
    public ParameterType ParameterType { get; set; }
    public string Name { get; set; }
    public bool Necessary { get; set; }
    
    public ParameterModel(Parameter parameter)
    {
        ParameterType = parameter.ParameterType;
        Name = parameter.Name;
        Necessary = parameter.Necessary;
    }
}