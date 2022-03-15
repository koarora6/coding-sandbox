namespace SimpleUnitTestingApp.Models
{
    public interface IDataSource
    {
        IEnumerable<Product> Products { get; }
    }
}
