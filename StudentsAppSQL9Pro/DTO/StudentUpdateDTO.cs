using System.ComponentModel.DataAnnotations;

namespace StudentsAppSQL9Pro.DTO
{
    public record StudentUpdateDTO
    (
        int Id,

        [property: Required(ErrorMessage = "{0} is required.")]
        [property: MinLength(1, ErrorMessage = "{0} must not be empty.")]
        string? Firstname,

        [property: Required(ErrorMessage = "{0} is required.")]
        [property: MinLength(1, ErrorMessage = "{0} must not be empty.")]
        string? Lastname

    ) : BaseDTO(Id) 
    {
        public StudentUpdateDTO() : this(0, string.Empty, string.Empty) { }
    }
}
