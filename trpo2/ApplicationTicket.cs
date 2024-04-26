using System.ComponentModel.DataAnnotations;

namespace trpo2
{
    public class ApplicationTicket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'Фамилия' обязательно для заполнения.")]
        public string Surname { get; set; } = null!;

        [Required(ErrorMessage = "Поле 'Имя' обязательно для заполнения.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Поле 'Email' обязательно для заполнения.")]
        [EmailAddress(ErrorMessage = "Некорректный формат Email")]
        public string Email { get; set; } = null!;

        public ApplicationTicketState State { get; set; }

        public DateTime? Created { get; set; }
    }
}
