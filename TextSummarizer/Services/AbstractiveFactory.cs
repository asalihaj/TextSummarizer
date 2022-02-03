using TextSummarizer.Models;

namespace TextSummarizer.Services
{
    public class AbstractiveFactory : SummaryFactory
    {
        private string content;
        public AbstractiveFactory(Text text)
        {
            this.content = text.Content;
        }
        public override string GetSummary()
        {
            Summary summary = AbstractiveSummary.GetInstance();
            return summary.Summarize(content);
        }
    }
}