using System.ComponentModel.DataAnnotations;

namespace Lab_10.Models
{
    public class ApplicationForm
    {
        [Required(ErrorMessage = "Будь ласка, введіть своє імʼя")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть свій мейл!")]
        [EmailAddress(ErrorMessage = "Неправильний формат е-мейлу! Будь ласка, введіть коректний мейл.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Будь ласка, оберіть дату!")]
        [FutureDate(ErrorMessage = "Дата не може бути заднім числом! Оберіть знову.")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Будь ласка, оберіть продукт зі списку нижче.")]
        public string Product { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (IsFutureDate(date) && !IsWeekend(date))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Будь ласка, оберіть дату в майбутньому, яка не припадає на вихідні!");
        }

        private bool IsFutureDate(DateTime date)
        {
            return date.Date > DateTime.Today;
        }

        private bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
        }
    }
}