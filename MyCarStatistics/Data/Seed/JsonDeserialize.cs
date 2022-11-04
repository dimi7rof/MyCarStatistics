using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;
using Newtonsoft.Json;
using System.Text;

namespace MyCarStatistics.Data.Seed
{
    public class JsonDeserialize
    {
        private readonly ApplicationDbContext context;

        public JsonDeserialize(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void ImportBrands(ApplicationDbContext context)
        {
            StringBuilder sb = new StringBuilder();

            BrandJsonModel[] brands = JsonConvert.DeserializeObject<BrandJsonModel[]>(@"..\..\..\Data\Seed\brands.json");

            List<Brand> valid = new List<Brand>();
            foreach (var br in brands)
            {
                var brand = new Brand()
                {
                    BrandName = br.Name,
                    Url = br.Url,
                    Logo = br.Logo
                };
                valid.Add(brand);
            }

            context.Brands.AddRange(valid);
            context.SaveChanges();

            Console.WriteLine($"Successfully imported {valid.Count}");
        }
    }
}
