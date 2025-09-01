using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class Produto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("header")]
        public string Header { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("target")]
        public string Target { get; set; }

        [JsonPropertyName("limit")]
        public string Limit { get; set; }

        [JsonPropertyName("reviewer")]
        public string Reviewer { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly DataContext _dataContext;


        public ProductController(ILogger<ProductController> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext  = dataContext;
        }

        [HttpPost]
        public ActionResult Post(Produto product)
        {
            _dataContext.Sections.Add(product);
            _dataContext.SaveChanges(); 

            return Ok(product);
        }

        [HttpGet]
        public List<Produto> GetAll()
        {
            var produtos = _dataContext.Sections.ToList();

            return produtos;
        }
    }
}
