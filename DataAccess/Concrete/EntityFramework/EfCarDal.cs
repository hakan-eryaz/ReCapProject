using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from p in context.Car
                             join c in context.Brand
                             
                             on p.BrandId equals c.BrandId
                             select new CarDetailDto
                             {
                                 Id = p.Id,
                                 BrandId = p.BrandId,
                                 BrandName = c.BrandName,
                                 ColorId = p.ColorId,
                                 ModelYear=p.ModelYear,
                                 DailyPrice=p.DailyPrice,
                                 Description=p.Description
                                 
                             };
                return result.ToList();

            }
        }
    }
}
