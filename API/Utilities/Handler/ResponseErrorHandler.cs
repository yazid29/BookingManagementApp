namespace API.Utilities.Handler
{
    public class ResponseErrorHandler
    {
        // atribut yang akan ditampilkan pada response
        public int Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string? Error { get; set; }
    }
}
