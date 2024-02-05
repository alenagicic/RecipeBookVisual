using System;
using System.Collections.Generic;

namespace RecipeBookVisual.ModelsRecipe;

public partial class PairingsRecipe
{
    public int Id { get; set; }

    public string? SuggestDrinks { get; set; }

    public string? SuggestDesserts { get; set; }

    public string? SuggestMovie { get; set; }

    public int Idmain { get; set; }

    public virtual MainRecipe IdmainNavigation { get; set; } = null!;
}
