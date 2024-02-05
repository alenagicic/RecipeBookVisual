using System;
using System.Collections.Generic;

namespace RecipeBookVisual.ModelsRecipe;

public partial class RecipeStory
{
    public int Id { get; set; }

    public string? Stories { get; set; }

    public int Idmain { get; set; }

    public virtual MainRecipe IdmainNavigation { get; set; } = null!;
}
