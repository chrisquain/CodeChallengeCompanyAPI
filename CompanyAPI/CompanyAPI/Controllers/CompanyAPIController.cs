using CompanyAPI.Data;
using CompanyAPI.Dtos;
using CompanyAPI.Entities;
using System.Threading.Tasks;
using System.Web.Http;

namespace CompanyAPI.Controllers
{
    public class CompanyAPIController : ApiController
    {
        private IDal _dal { get; set; }

        public CompanyAPIController(IDal dal)
        {
            _dal = dal;
        }


        [Route("api/company")]
        [HttpPost]
        public async Task<IHttpActionResult> InsertCompanyRecord([FromBody] CompanyDto insertCompanyDto)
        {
            var companyEntity = new CompanyEntity()
            {
                Exchange = insertCompanyDto.Exchange,
                ISIN = insertCompanyDto.ISIN,
                Ticker = insertCompanyDto.Ticker,
                Name = insertCompanyDto.Name,
                Website = insertCompanyDto.Website
            };

            var companyGetEntityList = _dal.InsertCompany(companyEntity);
            return Ok(companyGetEntityList);
        }

        [Route("api/company")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateCompanyRecord([FromBody] CompanyDto companyDto)
        {
            var companyEntity = new CompanyEntity()
            {
                CompanyID = companyDto.CompanyID,
                Exchange = companyDto.Exchange,
                ISIN = companyDto.ISIN,
                Ticker = companyDto.Ticker,
                Name = companyDto.Name,
                Website = companyDto.Website
            };

            var companyGetEntityList = _dal.UpdateCompany(companyEntity);
            return Ok(companyGetEntityList);
        }

        [Route("api/company")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllCompanies()
        {
            var companyGetEntityList = _dal.CompanySelectAll();
            return Ok(companyGetEntityList);
        }


        [Route("api/company/{companyID:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCompanyByCompanyID(int companyID)
        {
            var companyGetEntityList = _dal.CompanySelectByCompanyID(companyID);
            return Ok(companyGetEntityList);
        }

        [Route("api/company/{isin}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCompanyByISIN(string isin)
        {
            var companyGetEntityList = _dal.CompanySelectByISIN(isin);
            return Ok(companyGetEntityList);
        }
    }
}