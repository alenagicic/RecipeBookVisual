using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBookVisual.ModelsRecipe;

public partial class MainRecipe
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? TitleRecipe { get; set; }

    public string? Ingredient { get; set; }

    public string? Descriptions { get; set; }

    public string? CookingTimes { get; set; }

    public virtual ICollection<AlternativeIngredient> AlternativeIngredients { get; set; } = new List<AlternativeIngredient>();

    public virtual ICollection<FunFactRecipe> FunFactRecipes { get; set; } = new List<FunFactRecipe>();

    public virtual ICollection<PairingsRecipe> PairingsRecipes { get; set; } = new List<PairingsRecipe>();

    public virtual ICollection<RecipeStory> RecipeStories { get; set; } = new List<RecipeStory>();
}
