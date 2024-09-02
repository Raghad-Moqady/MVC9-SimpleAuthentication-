using System.ComponentModel.DataAnnotations;

namespace UserAuthenticationTask.Models
{
    public class User
    {
        //Guid=global user id.... example:i293i9fjiej93
        [Key]
        public Guid UserId { get; set; }


        [Display(Name ="User Name")]
        public string? UserName { get; set; }


        [Display(Name = "User Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "User Active")]
        public bool IsActive { get; set; }


        [Display(Name = "Created Date")]
        public DateTime CreatedAt { get; set; }



    }
}
