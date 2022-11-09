using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;
using Newtonsoft.Json;
using System.Text;

namespace MyCarStatistics.Data.Seed
{
    public static class JsonDeserialize
    {
        public static List<Brand> MySeed()
        {
            string data = File.ReadAllText(@"Data\Seed\CarBrandsAndModels.json");
            ImportBrandModel[] brands = JsonConvert.DeserializeObject<ImportBrandModel[]>(data);
            List<Brand> valid = new List<Brand>();
            foreach (var br in brands)
            {
                var modelList = new List<CarModel>();
                foreach (var model in br.Models)
                {                   
                    var model1 = new CarModel()
                    { 
                        ModelName = model
                    };
                    modelList.Add(model1);
                }
                var brand = new Brand()
                {
                    BrandName = br.Brand,
                    CarModels = modelList

                };
                valid.Add(brand);
            }
            return valid;
        }
    }
}
