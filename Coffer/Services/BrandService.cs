using System.Collections.Generic;
using Coffer.Interfaces;
using Coffer.Models;

namespace Coffer.Services
{
    public class BrandService : IBrandService
    {
        public List<Brand> GetBrandsData()
        {
            var obBrands = new List<Brand>();
            obBrands.Add(new Brand
            {
                Id = 1,
                BrandIcon = "https://assets.icoffer.app/image/starbucks.png",
                BrandName = "Starbucks"
            });
            
            obBrands.Add(new Brand
            {
                Id = 2,
                BrandIcon = "https://assets.icoffer.app/image/costa.png",
                BrandName = "Costa"
            });
            
            obBrands.Add(new Brand
            {
                Id = 3,
                BrandIcon = "https://assets.icoffer.app/image/luckin.png",
                BrandName = "Luckin Coffee"
            });

            return obBrands;
        }
    }
}