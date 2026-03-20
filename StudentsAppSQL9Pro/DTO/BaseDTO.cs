using System.ComponentModel.DataAnnotations;

namespace StudentsAppSQL9Pro.DTO
{
    public abstract record BaseDTO(

        [property: Required(ErrorMessage = "The {0} is required.")]
        int Id
    )
    {
        public BaseDTO() : this(0) { }
    }
}
