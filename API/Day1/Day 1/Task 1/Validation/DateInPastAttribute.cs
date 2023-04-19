using System.ComponentModel.DataAnnotations;

namespace Task_1.Validation
{
    public class DateInPastAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime? date = value as DateTime?;
            if(date is null)
            {
                return false;
            }

            if(date < DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
