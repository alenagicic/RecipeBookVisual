using System;
using System.Collections.Generic;

namespace RecipeBookVisual.ModelsProducts;

public partial class ProductInfo
{
    public int Id { get; set; }

    public string ProductDescription { get; set; } = null!;

    public int MainId { get; set; }

    public virtual ProductsMain Main { get; set; } = null!;
}
