﻿using ELab_NetCore_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ELab_NetCore_API.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class AddFieldsController : ControllerBase
    {
        private readonly Context context;
        public AddFieldsController(Context _context)
        {
            context = _context;
        }

        [HttpPost("category")]
        public async Task<ActionResult<String>> SaveCategory(string CategoryName)
        {
            string Result = "";

            Category category = new Category();
            category.Name = CategoryName;

            //Store in DB
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(category);
                    await context.SaveChangesAsync();
                    transaction.Commit();

                    Result = "Successfully Done";

                }
                catch
                {
                    transaction.Rollback();
                    Result = "Not Done";
                }
            }

            return Ok(Result);
        }
 

        [HttpGet("getcategory")]
        public async Task<ActionResult<List<Category>>> GetCategory()
            {
            string Result = "";

            List<Category> categories = await context.Categories.ToListAsync();
              
              if(categories != null)
            {
                return Ok(categories);
            }
            else
            {

            }
            Result = "Not found any records";
            return Ok(Result);

        }
        
        [HttpPost("testtype")]
        public async Task<ActionResult<string>> StoreTestType(int CategoryId, string TestName)
        {
            TestType testType = new TestType();
            testType.TestName = TestName;
            testType.CategoryId = CategoryId;

            string Result = "";
           
            
            //Db Save
            using(IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try 
                {
                   await context.AddAsync(testType);
                   await context.SaveChangesAsync();
                    transaction.Commit();
            
                    Result = "Data Stored Successfully";
                }
                catch
                {
                    transaction.Rollback();
                   
                    Result = "Not Saved";
                }
            }


            return Ok(Result);

        }
    


    }
}
