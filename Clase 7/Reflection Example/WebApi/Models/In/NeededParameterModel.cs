using Domain.Importer;

namespace WebApi.Models.In;

public class NeededParameterModel
{
    public ParameterType ParameterType { get; set; }
    public string Name { get; set; }
    public object Value { get; set; }

    public Parameter ToEntity()
    {
        return new Parameter()
        {
            ParameterType = ParameterType,
            Name = Name,
            Value = Value
        };
    }
}