using System;
using System.Collections.Generic;

namespace RecipeBookVisual.ModelsProducts;

public partial class ProductArticleNrPrice
{
    public int Id { get; set; }

    public string ProductArticleNumber { get; set; } = null!;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public virtual ProductsMain Category { get; set; } = null!;

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}
