using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;

namespace ConsumirAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumoController : ControllerBase
    {
        private readonly ApiConfig _apiConfig;

        public ConsumoController(ApiConfig config)
        {
            _apiConfig = config;
        }

        // GET: api/<ConsumoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var path = _apiConfig.BaseUrl
                    .ConfigureRequest(settings => { }) //para inserir header
                    .AppendPathSegment(_apiConfig.RelativeUrl);

                var response = await path
                    .GetJsonAsync<IEnumerable<Books>>();                                   

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ConsumoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var path = _apiConfig.BaseUrl
                    .ConfigureRequest(settings => { }) //para inserir header
                    .AppendPathSegment(_apiConfig.RelativeUrl)
                    .AppendPathSegment(id);

                var response = await path
                    .GetJsonAsync<Books>();

                if (response == null)
                    return NoContent();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ConsumoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookRequest book)
        {
            try
            {
                var path = _apiConfig.BaseUrl
                    .ConfigureRequest(settings => { }) //para inserir header
                    .AppendPathSegment(_apiConfig.RelativeUrl);

                var response = await path
                    .PostJsonAsync(book)
                    .ReceiveString();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ConsumoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Books book)
        {
            try
            {
                var path = _apiConfig.BaseUrl
                    .ConfigureRequest(settings => { }) //para inserir header
                    .AppendPathSegment(_apiConfig.RelativeUrl)
                    .AppendPathSegment(id);

                var response = await path
                    .PutJsonAsync(book)
                    .ReceiveString();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ConsumoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var path = _apiConfig.BaseUrl
                    .ConfigureRequest(settings => { }) //para inserir header
                    .AppendPathSegment(_apiConfig.RelativeUrl)
                    .AppendPathSegment(id);

                var response = await path
                    .SendAsync(new HttpMethod("DELETE"))
                    .ReceiveString();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
