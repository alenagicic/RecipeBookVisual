using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBookVisual.ModelsProducts;

public partial class ProductsMain
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string NameOfProduct { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<ProductArticleNrPrice> ProductArticleNrPrices { get; set; } = new List<ProductArticleNrPrice>();

    public virtual ICollection<ProductInfo> ProductInfos { get; set; } = new List<ProductInfo>();

    public virtual ICollection<ProductUsage> ProductUsages { get; set; } = new List<ProductUsage>();
}
