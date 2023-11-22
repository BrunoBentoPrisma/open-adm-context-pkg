using System.ComponentModel.DataAnnotations;

namespace pkg_context.Entities;

public sealed class Address : BaseEntity
{
    public Address(string zipCode, string state, string city, string neighborhood, string road, int number) : base(number)
    {
        ZipCode = zipCode;
        State = state;
        City = city;
        Neighborhood = neighborhood;
        Road = road;
    }
    [MaxLength(9)]
    public string ZipCode { get; private set; }
    [MaxLength(100)]
    public string State { get; private set; }
    [MaxLength(100)]
    public string City { get; private set; }
    [MaxLength(100)]
    public string Neighborhood { get; private set; }
    [MaxLength(100)]
    public string Road { get; private set; }
}
