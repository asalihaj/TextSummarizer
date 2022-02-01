using System.Collections.Generic;

namespace TextSummarizer.Models
{
    public class SentenceComparator : Comparer<Sentence>
    {
        public override int Compare(Sentence x, Sentence y)
        {
            if (x.Score > y.Score)
            {
                return -1;
            } else if (x.Score < y.Score)
            {
                return 1;
            } else
            {
                return 0;
            }
                
        }
    }
}
