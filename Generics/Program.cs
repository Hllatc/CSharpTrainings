// See https://aka.ms/new-console-template for more information

Utilities utilities = new Utilities();
List<string> result=utilities.BuildList<string>("Ankara","İstanbul","İzmir");
foreach(var item in result)
{
    Console.WriteLine(item);
}

List<Customer> result2 = utilities.BuildList<Customer>(new Customer { FirstName = "Hilal" },new Customer { FirstName = "Serkan" },new Customer { FirstName = "Ela" });
foreach (var item in result2)
{
    Console.WriteLine(item.FirstName);
}
Console.ReadLine();

class Utilities
{
    public List<T> BuildList<T>(params T[] items)
    {
        return new List<T> (items);
    }
}
class Product:IEntity
{

}
class Customer:IEntity
{
    public string FirstName { get; set; }
}
class Student:IEntity
{

}
interface IProductDal:IGenericRepository<Product>
{

}
interface ICustomerDal:IGenericRepository<Customer>
{

}
interface IEntity
{

}
interface IGenericRepository<T> where T : class, IEntity, new()
{
    List<T> getAll();
    T getEntity(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
    
}
class ProductDal : IProductDal
{
    public void Add(Product entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Product> getAll()
    {
        throw new NotImplementedException();
    }

    public Product getEntity(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Product entity)
    {
        throw new NotImplementedException();
    }
}
class CustomerDal : ICustomerDal
{
    public void Add(Customer entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Customer> getAll()
    {
        throw new NotImplementedException();
    }

    public Customer getEntity(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Customer entity)
    {
        throw new NotImplementedException();
    }
}
