namespace Clinic.Model;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Weight { get; set; }
    public string FulColor { get; set; }
    
    public List<Visit> Visits { get; set; }
}