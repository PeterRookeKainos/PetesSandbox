using System.ComponentModel.DataAnnotations;

namespace ToDoMvc.Models;

public class ToDo
{
    public int Id { get; set; }
    
    [Display(Name = "To Do Task Name")]
    [Required(ErrorMessage = "ToDo Name is required")]
    [StringLength(40, ErrorMessage = "ToDo Name cannot be longer than 40 characters")]
    public string ToDoName { get; set; }
    
    [Display(Name = "To Do Description")]
    [Required(ErrorMessage = "ToDo Description is required")]
    [StringLength(200, ErrorMessage = "ToDo Description cannot be longer than 200 characters")]
    public string? ToDoDescription { get; set; }
    
    [Display(Name = "Is Complete")]
    public bool? IsComplete { get; set; }
    
    [Display(Name = "Date Completed")]
    [DataType(DataType.Date)]
    public DateTime? DateCompleted { get; set; }
    
    [Display(Name = "User Name")]
    [StringLength(40, ErrorMessage = "User name cannot be longer than 40 characters")]
    public string? UserName { get; set;}
}