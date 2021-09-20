using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ILogger _logger;

        public CarManager(ICarDal carDal,ILogger logger)
        {
            _carDal = carDal;
            _logger = logger;
        }

        //[ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (CheckCategory(car.Id).Success)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);

            }

            return new ErrorResult();

            
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<Car>>  GetAllByCarId(int Id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.Id == Id));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == carId));
        }

        public IDataResult<List<Car>> GetByUnitPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        private IResult CheckCategory(int categoryId)
        {
            var result = _carDal.GetAll(p => p.Id == categoryId).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            return new SuccessResult();
        }
    }
}
