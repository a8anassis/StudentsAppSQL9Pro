using System.ComponentModel.DataAnnotations;

namespace StudentsAppSQL9Pro.DTO
{
    public record StudentInsertDTO(

        [property: Required(ErrorMessage = "{0} is required.")]
        [property: MinLength(1, ErrorMessage = "{0} must not be empty.")]
        string? Firstname,

        [property: Required(ErrorMessage = "{0} is required.")]
        [property: MinLength(1, ErrorMessage = "{0} must not be empty.")]
        string? Lastname
    )
    {
        public StudentInsertDTO() : this(string.Empty, string.Empty) { }
    }
}
