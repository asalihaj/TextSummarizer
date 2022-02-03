using System;
using System.Collections.Generic;
using System.Text;
using TextSummarizer.Models;
namespace TextSummarizer.Services
{
    public abstract class Summary
    {
        private SummaryTool tool;

        public Summary ()
        {
            tool = new SummaryTool();
            tool.init();
        }

        protected SummaryTool GetSummaryTool()
        {
            return tool;
        }

        public abstract string Summarize(string content);
    }
}