namespace RoaSystems.DemoKPI.Model.Model.DTO
{
    public class ChatResponseDTO
    {
        public string TextoRespuesta { get; set; } = string.Empty;
        public string ModeloUtilizado { get; set; } = string.Empty;
        public DateTime FechaGeneracion { get; set; } = DateTime.UtcNow;
    }
}
