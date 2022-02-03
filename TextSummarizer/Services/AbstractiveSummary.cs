using TextSummarizer.Models;

namespace TextSummarizer.Services
{
    public class AbstractiveSummary : Summary
    {
        public override string Summarize(string content)
        {
            //TODO: Generate Abstractive Summarization
            return null;
        }

        private Sentence GenerateSynonyms(Sentence sentence)
        {
            //TODO: Replace words from the sentence with synonyms
            return null;
        }

        private string GetSynonym(string word)
        {
            //TODO
            //Return the synonym of the word as string
            return null;
        }
    }
}