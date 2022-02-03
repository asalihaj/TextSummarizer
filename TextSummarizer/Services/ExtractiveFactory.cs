using TextSummarizer.Models;

namespace TextSummarizer.Services
{
    public class ExtractiveFactory : SummaryFactory
    {
        private string content;
        public ExtractiveFactory (Text text)
        {
            this.content = text.Content;
        }
        public override string GetSummary()
        {
            Summary summary = ExtractiveSummary.GetInstance();
            return summary.Summarize(content);
        }
    }
}