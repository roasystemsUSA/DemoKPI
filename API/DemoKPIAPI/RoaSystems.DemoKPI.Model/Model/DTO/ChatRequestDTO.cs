using System.ComponentModel.DataAnnotations;

namespace RoaSystems.DemoKPI.Model.Model.DTO
{
    public class ChatRequestDTO
    {
        [Required(ErrorMessage = "The prompt can't be empty")]
        public string Prompt { get; set; } = string.Empty;

        // Puedes agregar parámetros opcionales
        public double? Temperatura { get; set; } = 0.7;
    }
}
