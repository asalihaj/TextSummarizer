using System.Collections.Generic;
using System.Text;
using TextSummarizer.Models;

namespace TextSummarizer.Services
{
    public class ExtractiveSummary : Summary
    {
        public override string Summarize(string content)
        {
            SummaryTool tool = GetSummaryTool();
            tool.ExtractSentences(content);
            tool.CreateIntersectionMatrix();
            tool.AssignScore();
            List<Sentence> summary = tool.CreateSummary();
            string result = ParseToString(summary);
            return result;
        }

        private string ParseToString(List<Sentence> summary)
        {
            StringBuilder result = new StringBuilder();
            foreach (Sentence sentence in summary)
            {
                result.Append(sentence.Value);
                result.Append(' ');
            }
            return result.ToString();
        }
    }
}