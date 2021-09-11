using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //9.gün izle;
            CarTest();
            Console.WriteLine("");
            BrandTest();
            Console.WriteLine("");
            ColorTest();
            Console.WriteLine("");
            UserTest();
            Console.WriteLine("");
            CustomerTest();
            //ColorAdd();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId=1,CustomerId=1,RentDate=DateTime.Now.Date });

            if (result.Success)
            {
                System.Console.WriteLine(result.Message);
            }
            else
            {
                System.Console.WriteLine(result.Message);
            }


        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            foreach (var customer in result.Data)
            {
                Console.WriteLine("ID: " + customer.Id);
                Console.WriteLine("User ID: " + customer.UserId);
                Console.WriteLine("Company Name: " + customer.CompanyName);


            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine("ID: " + user.Id);
                Console.WriteLine("First Name: " + user.FirstName);
                Console.WriteLine("Last Name: " + user.LastName);
                Console.WriteLine("Email: " + user.Email);
                Console.WriteLine("Password: " + user.Password);

            }
        }

        private static void CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Add(new Car { Id = 3, BrandId = 2, ColorId = 2, ModelYear = 2021, DailyPrice = 20000, Description = "tanım3" });

            if (result.Success)
            {
                System.Console.WriteLine(result.Message);
            }
            else
            {
                System.Console.WriteLine(result.Message);
            }
        }

        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color { ColorName = "Grayss", ColorId = 9 });
            
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            foreach (var color in result.Data )
            {
                Console.WriteLine("ID: " + color.ColorId);
                Console.WriteLine("ColorId: " + color.ColorName);
                
            }
            
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine("ID: " + brand.BrandId);
                Console.WriteLine("BrandId: " + brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
            {
                Console.WriteLine("ID: " + car.Id);
                Console.WriteLine("BrandId: " + car.BrandId);
                Console.WriteLine("ColorId: " + car.ColorId);
                Console.WriteLine("ModelYear: " + car.ModelYear);
                Console.WriteLine("DailyPrice: " + car.DailyPrice);
                Console.WriteLine("Description: " + car.Description);
                Console.WriteLine("Description: " + car.BrandName);
                Console.WriteLine("");
            }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            
        }
    }
}
