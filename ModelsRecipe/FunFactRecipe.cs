using System;
using System.Collections.Generic;

namespace RecipeBookVisual.ModelsRecipe;

public partial class FunFactRecipe
{
    public int Id { get; set; }

    public string? FoodForTought { get; set; }

    public int Idmain { get; set; }

    public virtual MainRecipe IdmainNavigation { get; set; } = null!;
}
