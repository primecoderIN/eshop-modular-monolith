
namespace Catalog.Products.Models;

public class Product : Aggregate<Guid>
{
    public string Name { get; private set; } = default!;

    public List<string> Category { get; private set; } = new();

    public string Description { get; private set; } = default!;

    public string ImageFile { get; private set; } = default!;

    public decimal Price { get; private set; }

    //Create is static because here no objeect is created yet. 
    public static Product Create(Guid id, string name, List<string> category, string description, string imageFile, decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentNullException.ThrowIfNull(category);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var product = new Product
        {
            Id = id,
            Name = name,
            Category = category,
            Description = description,
            ImageFile = imageFile,
            Price = price
        };



        product.AddDomainEvent(new ProductCreatedEvent(product)); //INside static method there is no this so product.AddDomainEvent

        return product;

    }

    public void Update(
     string? name = null,
     List<string>? category = null,
     string? description = null,
     string? imageFile = null,
     decimal? price = null)
    {
        if (name is not null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            Name = name;
        }

        if (category is not null)
        {
            Category = category;
        }

        if (description is not null)
        {
            Description = description;
        }

        if (imageFile is not null)
        {
            ImageFile = imageFile;
        }

        if (price.HasValue && Price != price.Value)
        {
            //1.First ensure price is not null
            //2.Then compare values
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price.Value);
            Price = price.Value;
            AddDomainEvent(new ProductPriceChangeEvent(this));
        }
    }

}
