namespace DisplayDiff.Models;

public class Display
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Company { get; set; }
    public int VerticalResolution { get; set; }
    public int HorizontalResolution { get; set; }
    public string AdaptiveSync { get; set; }
    public string PanelType { get; set; }
    public decimal DiagonalLength { get; set; }
    public int RefreshRate { get; set; }
    public string FullSpecsURL { get; set; }
    public string ImageName { get; set; }
}
