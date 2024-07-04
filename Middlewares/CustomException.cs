namespace CreditCardValidationAPI.Middlewares
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }
}
