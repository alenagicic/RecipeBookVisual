using System;
using System.Collections.Generic;

namespace RecipeBookVisual.ModelsProducts;

public partial class ProductUsage
{
    public int Id { get; set; }

    public string ProductUsage1 { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual ProductsMain Category { get; set; } = null!;
}
