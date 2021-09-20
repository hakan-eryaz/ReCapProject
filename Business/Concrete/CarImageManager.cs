using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImagesDal _carImagesDal;
        IFileHelper _fileHelper;
        ILogger _logger;

        public CarImageManager(ICarImagesDal carDal, ILogger logger,IFileHelper fileHelper)
        {
            _carImagesDal = carDal;
            _logger = logger;
            _fileHelper = fileHelper;

        }
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                   IsOverflowCarImageCount(carImage.CarId));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            var imageResult = _fileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImagesDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        private IResult IsOverflowCarImageCount(int carId)
        {
            var result = _carImagesDal.GetAll(im => im.CarId == carId);

            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceded);
            }

            return new SuccessResult();
        }

        private IResult CheckCategory(int ıd)
        {
            var result = _carImagesDal.GetAll(p => p.Id == ıd).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceded);
            }
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(), Messages.ImageListed);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> GetById(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetByUnitPrice(int min, int max)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarImage carImage)
        {
            throw new NotImplementedException();
        }
    }
}
