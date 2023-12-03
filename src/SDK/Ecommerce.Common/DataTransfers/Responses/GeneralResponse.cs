namespace Vault.Common.DataTransfers.Responses
{
    public class GeneralResponse
    {
        public class InvalidMessagedResponse
        {
            public bool TokenAllowed = true;
            public string Message { get; set; }
            public string HelpLink { get; }
            public InvalidMessagedResponse(string message)
            {
                Message = message;
            }
            public InvalidMessagedResponse(string message, string helpLink)
            {
                Message = message;
                HelpLink = helpLink;
            }
        }
        public class InvalidParameter : InvalidMessagedResponse
        {
            public object Parameter { get; set; }
            public InvalidParameter(object parameter, string message) : base(message)
            {
                Parameter = parameter;
            }
            public InvalidParameter(object parameter, string message, string helpLink) : base(message, helpLink)
            {
                Parameter = parameter;
            }
        }
    }
}
