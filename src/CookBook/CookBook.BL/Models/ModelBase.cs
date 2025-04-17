using CommunityToolkit.Mvvm.ComponentModel;

namespace CookBook.BL.Models;

public abstract class ModelBase : ObservableObject
{
    public Guid Id { get; set; }
}
