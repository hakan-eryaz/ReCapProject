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
            //CarTest();
            //BrandTest();
            ColorTest();
            ColorAdd();

        }

        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color { ColorName = "Gray", ColorId = 6 });
            foreach (var colors in colorManager.GetAll())
            {
                System.Console.WriteLine(colors.ColorName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ID: " + color.ColorId);
                Console.WriteLine("ColorId: " + color.ColorName);
                
            }
            
            
            
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAllByCarId(1))
            {
                Console.WriteLine("ID: " + brand.BrandId);
                Console.WriteLine("BrandId: " + brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("ID: " + car.Id);
                Console.WriteLine("BrandId: " + car.BrandId);
                Console.WriteLine("ColorId: " + car.ColorId);
                Console.WriteLine("ModelYear: " + car.ModelYear);
                Console.WriteLine("DailyPrice: " + car.DailyPrice);
                Console.WriteLine("Description: " + car.Description);
                Console.WriteLine("Description: " + car.BrandName);
            }
            
        }
    }
}
