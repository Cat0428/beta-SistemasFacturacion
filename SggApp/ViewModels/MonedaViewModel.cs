using System.ComponentModel.DataAnnotations;

public class MonedaViewModel
{
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Required]
    public string Simbolo { get; set; }
}
