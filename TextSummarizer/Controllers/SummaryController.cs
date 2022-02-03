using Microsoft.AspNetCore.Mvc;
using System;
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
        public JsonResult Summary(Text text)
        {
            SummaryFactory summary = null;
            if(text.Type.ToLower().Equals("extractive"))
            {
                summary = new ExtractiveFactory(text);
            } else if (text.Type.ToLower().Equals("abstractive"))
            {
                summary = new AbstractiveFactory(text);
            }
            string result = summary.GetSummary();
            return new JsonResult(result);
        }
    }
}