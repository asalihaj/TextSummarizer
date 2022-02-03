using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TextSummarizer.Models;
using TextSummarizer.Services;

namespace TextSummarizer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SummaryController : ControllerBase
    {

        [HttpPost]
        public JsonResult Get(Text text)
        {
            string result = Summary.Summarize(text.Content);
            return new JsonResult(result);
        }
    }
}