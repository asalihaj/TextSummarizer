using System;
using System.Collections.Generic;
using System.Text;
using TextSummarizer.Models;
namespace TextSummarizer.Services
{
    public class Summary
    {
        public static string Summarize(string context)
        {
            SummaryTool summaryTool = new();
            summaryTool.init();
            summaryTool.ExtractSentences(context);
            summaryTool.CreateIntersectionMatrix();
            summaryTool.CreateDictionary();
            List<Sentence> result = summaryTool.CreateSummary();
            StringBuilder summary = new StringBuilder();
            foreach (Sentence sentence in result)
            {
                summary.Append(sentence.Value);
                summary.Append(' ');
            }
            return summary.ToString();
        }
    }
}