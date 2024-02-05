using System;
using System.Collections.Generic;

namespace RecipeBookVisual.ModelsRecipe;

public partial class AlternativeIngredient
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Ingredients { get; set; }

    public string? Description { get; set; }

    public string? CookingTime { get; set; }

    public int Idmain { get; set; }

    public virtual MainRecipe IdmainNavigation { get; set; } = null!;
}
