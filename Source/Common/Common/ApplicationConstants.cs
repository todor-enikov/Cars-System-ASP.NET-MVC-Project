namespace Common
{
    public class ApplicationConstants
    {
        // User Roles
        public const string AdminRole = "Admin";
        public const string UserRole = "User";

        // Exception Messages
        public const string UsersServiceErrorMessage = "Users service should not be null!";
        public const string CarssServiceErrorMessage = "Cars service should not be null!";
        public const string FilterServiceErrorMessage = "Filter service should not be null!";
        public const string MailServiceErrorMessage = "Mail service should not be null!";

        // Messages for sending email - subject and content
        public const string SubjectExpiringAnnualCheckUp = "Expiring annual check up!";
        public const string ContentExpiringAnnualCheckUp = "Hello dear customer, your annual check up expires today! Please contact us for more information!";
        public const string SuccessOfAutomationSendingOnEmailsForAnnualCheckUp = "All Mails to the customers, which annual check up expires today was send!";

        public const string SubjectExpiringInsurance = "Expiring insurance!";
        public const string ContentExpiringInsurance = "Hello dear customer, your insurance expires today! Please contact us for more information!";
        public const string SuccessOfAutomationSendingOnEmailsForInsurance = "All Mails to the customers, which insurance expires today was send!";

        public const string SubjectExpiringVignette = "Expiring vignette!";
        public const string ContentExpiringVignette = "Hello dear customer, your vignette expires today! Please contact us for more information!";
        public const string SuccessOfAutomationSendingOnEmailsForVignette = "All Mails to the customers, which vignette expires today was send!";
    }
}
