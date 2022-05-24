using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Data
{
    public static class DatabaseInteraction
    {
        private static Context _context = new Context();

        public static List<Employee> GetEmployees()
        {
            return _context.Employee.ToList();
        }
        public static List<EmployeeType> GetEmployeeTypes()
        {
            return _context.EmployeeType.ToList();
        }
        public static List<EmployeeStatus> GetEmployeeStatuses()
        {
            return _context.EmployeeStatus.ToList();
        }
        public static List<Gender> GetGenders()
        {
            return _context.Gender.ToList();
        }
        public static List<Producer> GetProducers()
        {
            return _context.Producer.ToList();
        }
        public static List<Supplier> GetSuppliers()
        {
            return _context.Supplier.ToList();
        }

        public static List<Product> GetProducts()
        {
            return _context.Product.ToList();
        }

        public static List<ProductType> GetProductTypes()
        {
            return _context.ProductType.ToList();
        }

        public static List<HistoryView> GetHistory()
        {
            return _context.HistoryView.ToList();
        }

        public static void SaveEditedProduct(Product product)
        {
            _context.SaveChanges();
        }
        public static void SaveEditedEmployee(Employee employee)
        {
            _context.SaveChanges();
        }
        public static void AddNewEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
        }

        public static void AddNewProduct(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public static void AddNewHistory(History history)
        {
            _context.History.Add(history);
            _context.SaveChanges();
        }

        public static void AddNewProducer(Producer producer)
        {
            _context.Producer.Add(producer);
            _context.SaveChanges();
        }
        public static void AddNewSupplier(Supplier supplier)
        {
            _context.Supplier.Add(supplier);
            _context.SaveChanges();
        }

        public static void AddNewProductType(ProductType productType)
        {
            _context.ProductType.Add(productType);
            _context.SaveChanges();
        }
    }
}
