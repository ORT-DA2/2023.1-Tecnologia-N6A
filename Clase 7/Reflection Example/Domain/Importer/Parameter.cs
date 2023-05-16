namespace Domain.Importer;

public class Parameter
{
    public ParameterType ParameterType { get; set; }
    public string Name { get; set; }
    public object Value { get; set; }
    public bool Necessary { get; set; }
}