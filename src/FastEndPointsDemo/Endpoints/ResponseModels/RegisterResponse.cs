namespace FastEndPointsDemo.Endpoints.ResponseModels;

public class RegisterResponse
{
        public string Id { get; set; }
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string EmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; } = Models.Status.Active.ToString();
        public string AccessToken { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string ReferralCode { get; set; } = string.Empty;
    
}