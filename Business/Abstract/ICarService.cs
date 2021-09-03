using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllByCarId(int Id);
        List<Car> GetByUnitPrice(int min,int max);
        List<CarDetailDto> GetCarDetails();

    }
}
