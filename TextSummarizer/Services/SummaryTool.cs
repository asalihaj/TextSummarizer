using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextSummarizer.Models.SummaryTools
{
    public class SummaryTool
    {
        private List<Sentence> sentences;
        private List<Paragraph> paragraphs;
        private Dictionary<Sentence, double> dictionary;
        private List<Sentence> summary;
        private int numOfParagraphs;
        private int numOfSentences;
        private double[,] intersectionMatrix;

        public List<Sentence> ExtractSentences (Text context)
        {
            char[] contextArray = context.Content.ToCharArray();
            int nextChar = 0;
            int prevChar = -1;
            int j = 0;
        
            try
            {
                for (int i = 0; i < contextArray.Length; i++)
                {
                    nextChar = contextArray[i];
                    char[] temp = new char[10000];
                    while ((char)nextChar != '.')
                    {
                        temp[j] = (char)nextChar;
                        if((char)nextChar == '\n' && (char)prevChar == '\n')
                        {
                            numOfParagraphs++;
                        }
                        j++;
                        prevChar = nextChar;
                    }
                    sentences.Add(new Sentence(numOfSentences, (new string(temp).Trim()), numOfParagraphs));
                    numOfSentences++;
                    prevChar = nextChar;
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // List<Sentence> sentencesToReturn = new List<Sentence>();
            // sentences.ForEach((item) =>
            // {
            //     sentencesToReturn.Add(new Sentence(item.Number, item.Value, item.ParagraphNumber));
            // });
            return sentences;
        }

        public List<Paragraph> GroupSentencesIntoParagrapgs() 
        {
            int paragraphNumber = 0;
            Paragraph paragraph = new Paragraph(0);

            for (int i = 0; i < numOfSentences; i++)
            {
                if (sentences.ElementAt(i).ParagraphNumber != paragraphNumber)
                {
                    paragraphs.Add(paragraph);
                    paragraphNumber++;
                    paragraph = new Paragraph(paragraphNumber);
                }
                paragraph.Sentences.Add(sentences.ElementAt(i));
            }
            paragraphs.Add(paragraph);
            return paragraphs;
        }

        public int NumberOfCommonWords(Sentence s1, Sentence s2)
        {
            int commonCount = 0;
            string[] s1Words = s1.Value.Split("\\s+");
            string[] s2Words = s2.Value.Split("\\s+");

            foreach (string word1 in s1Words)
            {
                foreach (string word2 in s2Words)
                {
                    if(word1.CompareTo(word2) == 0)
                    {
                        commonCount++;
                    }
                }
            }
            return commonCount;
        }

        public void CreateIntersectionMatrix()
        {
            intersectionMatrix = new double[numOfSentences, numOfSentences];
            for (int i = 0; i < numOfSentences; i++)
            {
                for (int j = 0; j < numOfSentences; j++)
                {
                    if (i <= j)
                    {
                        Sentence s1 = sentences.ElementAt(i);
                        Sentence s2 = sentences.ElementAt(j);
                        intersectionMatrix[i, j] = NumberOfCommonWords(s1, s2) / ((double) (s1.NumberOfWords + s2.NumberOfWords) / 2);
                    } else {
                        intersectionMatrix[i, j] = intersectionMatrix[j, i];
                    }
                }
            }
        }

        public void CreateDictionary()
        {
            for (int i = 0; i < numOfSentences; i++)
            {
                double score = 0;
                for (int j = 0; j < numOfSentences; j++)
                {
                    score += intersectionMatrix[i, j];
                }
                dictionary.Add(sentences.ElementAt(i), score);
                ((Sentence)sentences.ElementAt(i)).Score = score;
            }
        }

        public List<Sentence> CreateSummary()
        {
            for(int i = 0; i <= numOfParagraphs; i++)
            {
                int primarySet = paragraphs.ElementAt(i).Sentences.Count() / 5;

                paragraphs.ElementAt(i).Sentences.Sort(new SentenceComparator());
                for (int j = 0; j <= primarySet; j++)
                {
                    summary.Add(paragraphs.ElementAt(i).Sentences.ElementAt(j));
                }
            }
            summary.Sort(new SentenceComparatorForSummary());
            return summary;
        }
    }
}