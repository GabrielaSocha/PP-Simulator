using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    private string description = "Unknown";
    private bool IsDesSet = false;
    public required string Description
    { 
        get { return description; }
        set
        {
            if (IsDesSet)
                return;
            if (string.IsNullOrEmpty(value))
            {
                value = "Unknown";
            }
            value = value.Trim();
            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }
            if (value.Length > 15)
            {
                value = value.Substring(0, 15).TrimEnd();
            }
            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }
            description = value;
            IsDesSet = true;
        }
    }
    public uint Size { get; set; } = 3;
    public string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}
