namespace ACCOUNT.MANAGER.API.ViewModels
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Response { get; set; }  // Indica si la operación fue exitosa
        public string Message { get; set; } // Un mensaje informativo
        public string Codigo { get; set; }     // Código de respuesta
    }
}
