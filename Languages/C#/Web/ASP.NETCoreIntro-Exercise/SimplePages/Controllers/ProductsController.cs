namespace SimplePages.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Net.Http.Headers;
	using SimplePages.Models;
	using System.Text;
	using System.Text.Json;
	using System.Text.Json.Serialization;

	public class ProductsController : Controller
	{
		private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
		{
			new ProductViewModel()
			{
				Id = 1,
				Name = "Cheese",
				Price = 7.00
			},
            new ProductViewModel()
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50
            },
            new ProductViewModel()
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50
            },
        };

		[ActionName("My-Products")]
		public IActionResult All(string keyword)
		{
			if (keyword != null)
			{
				var foundProducts = this.products
					.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));

				return View(foundProducts);
            }

			return View(this.products);
		}

		public IActionResult ById(int id)
		{
			var product = this.products.FirstOrDefault(p => p.Id == id);

			if (product == null)
			{
				return BadRequest();
			}

			return View(product);
		}

		public IActionResult AllAsJson()
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true
			};

			return Json(products, options);
		}

        public IActionResult AllAsText()
        {
			StringBuilder text = new StringBuilder();

			foreach (var product in this.products)
			{
				text.AppendLine($"Product {product.Id}: {product.Name} - {product.Price}lv");
			}

            return Content(text.ToString().Trim());
        }

        public IActionResult AllAsTextFile()
        {
            StringBuilder text = new StringBuilder();

            foreach (var product in this.products)
            {
                text.AppendLine($"Product {product.Id}: {product.Name} - {product.Price}lv");
            }

			Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(text.ToString().Trim()), "text/plain");
        }
    }
}
