namespace AMSS.Models
{
    public class ValidationErrorResponse
    {
        public string Message { get; set; }
        public List<ValidationErrorField> Errors { get; set; }
    }

    public class ValidationErrorField
    {
        public string Field { get; set; }
        public List<string> Messages { get; set; }
    }
}
