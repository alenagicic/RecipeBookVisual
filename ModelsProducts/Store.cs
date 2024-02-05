using System;
using System.Collections.Generic;

namespace RecipeBookVisual.ModelsProducts;

public partial class Store
{
    public int Id { get; set; }

    public string FindInStoreName { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual ProductArticleNrPrice Category { get; set; } = null!;
}
