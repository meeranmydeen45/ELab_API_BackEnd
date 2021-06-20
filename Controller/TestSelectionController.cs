using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELab_NetCore_API.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace ELab_NetCore_API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestSelectionController : ControllerBase
    {
        private readonly Context context;
        public TestSelectionController(Context _context)
        {
            context = _context;

        }

        [HttpGet("checkbox-data")]
        public async Task<ActionResult<List<TestSelectionModel>>> GetData()
        {
            string Result = "";
            bool status = false;
            List<TestSelectionModel> Models = new List<TestSelectionModel>();
            //Db in Use
            using(IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                List<Category> categories =  await context.Categories.ToListAsync();
                  if(categories != null)
                    {
                        status = true;
                        foreach (Category category in categories)
                        {
                            TestSelectionModel model = new TestSelectionModel();
                            model.CategoryName = category.Name;
                            model.TestTypes = await context.TestTypes.Where(x => x.CategoryId == category.Id).ToListAsync();
                            Models.Add(model);
                        }
                  }
                  else
                  {
                        status = false;
                        Result = "No Data Found";
                  }
                }
                catch
                {
                    status = false;
                    Result = "Error in Database Operation";

                }
            }
        
            //Returning Server Data to the Client
             if(status)
            {
                return Ok(Models);
            }
            else
            {
                return Ok(Result);
            }
        }
        
        [HttpPost("get-test-params")]
        public async Task<ActionResult<List<TestParamModel>>> GetTestParams(TestTypeIdPostModel TestTypeIdPostModel, int TotalCost)
        {
            List<TestParamModel> paramModels =  new List<TestParamModel>();
            
                foreach (string TestTypeId in TestTypeIdPostModel.TestTypeId)
                {
                TestParamModel model = new TestParamModel();
                var TestType = await context.TestTypes.SingleAsync(x => x.Id.ToString() == TestTypeId);
                List<TestParam> TestParams = await context.TestParams.Where(x => x.TypeId.ToString() == TestTypeId).ToListAsync();
                model.TestName = TestType.TestName;
                model.TestParamList = TestParams;
                paramModels.Add(model);
                   
                }
            
            return Ok(paramModels);
        }
    
    
    
    
    
    
    
    
    
    
    
    }
}
