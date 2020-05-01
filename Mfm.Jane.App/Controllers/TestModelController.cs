using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mfm.Jane.App.Models;
using Mfm.Jane.Domain.Contracts;
using Mfm.Jane.Domain.Models;
using Mfm.Jane.Domain.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mfm.Jane.App.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestModelController : ControllerBase
    {
        private readonly ILogger<TestModelController> _logger;
        private readonly ITestModelDomainService _testModelDomainService;

        public TestModelController(ITestModelDomainService testModelDomainService, ILogger<TestModelController> logger)
        {
            _testModelDomainService = testModelDomainService;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<APIRequestResult<string>> CreateTestModel([FromBody] TestModel testModel)
        {
            try
            {
                await _testModelDomainService.CreateTestModel(testModel);
                return new APIRequestResult<string>
                {
                    Success = true
                };
            }
            catch (InvalidTestModelException ex)
            {
                _logger.LogError(ex, ex.Message);
                return new APIRequestResult<string>
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new APIRequestResult<string>
                {
                    Success = false,
                    ErrorMessage = "Server error occured."
                };
            }
        }

        [HttpGet("get")]
        public async Task<APIRequestResult<List<TestModel>>> GetTestModels()
        {
            try
            {
                var list = await _testModelDomainService.GetTestModels();
                return new APIRequestResult<List<TestModel>>
                {
                    Success = true,
                    Data = list
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new APIRequestResult<List<TestModel>>
                {
                    Success = false,
                    ErrorMessage = "Server error occured."
                };
            }
        }
    }
}
