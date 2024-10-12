using _2024_b1_individueel.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _2024_b1_individueel.ViewModels;

public class FlagCreateEditViewModel
{
    public string? CountryCode { get; set; }
    public string? CorrectAnswer { get; set; }
    public Guid? FlagDeckIdentifier { get; set; }
    public List<SelectListItem>? FlagDecks { get; set; }
}
