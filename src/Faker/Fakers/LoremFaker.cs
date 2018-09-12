using System;
using System.Collections.Generic;
using System.Linq;
using Faker.Extensions;
using Faker.Wrappers;

namespace Faker.Fakers
{
    public interface ILorem
    {
        IEnumerable<string> Words(int count);
        string GetFirstWord();
        string Sentence(int minWordCount = 4);
        IEnumerable<string> Sentences(int sentenceCount);
        string Paragraph(int minSentenceCount = 3);
        IEnumerable<string> Paragraphs(int paragraphCount);
    }
    
    public class LoremFaker : ILorem
    {
        private readonly IResourceWrapper _resourceWrapper;

        public LoremFaker()
            : this(new ResourceWrapper())
        {
        }

        internal LoremFaker(IResourceWrapper resourceWrapper)
        {
            _resourceWrapper = resourceWrapper;
        }
        
        /// <summary>
        /// Get a random collection of words.
        /// </summary>
        /// <param name="count">Number of words required</param>
        /// <returns></returns>
        public IEnumerable<string> Words(int count)
        {
            if (count <= 0) throw new ArgumentException("Count must be greater than zero", "count");

            return count.Times(x => _resourceWrapper.Lorem.Words.Split(Config.Separator).Random());
        }

        /// <summary>
        /// Get the first word of the random word collection. Useful for unit tests.
        /// </summary>
        /// <returns></returns>
        public string GetFirstWord()
        {
            return _resourceWrapper.Lorem.Words.Split(Config.Separator).First();
        }

        /// <summary>
        /// Generates a capitalised sentence of random words.
        /// </summary>
        /// <param name="minWordCount">Minimum number of words required</param>
        /// <returns></returns>
        public string Sentence(int minWordCount = 4)
        {
            if (minWordCount <= 0) throw new ArgumentException("Count must be greater than zero", nameof(minWordCount));

            return string.Join(" ", Words(minWordCount + RandomNumber.Next(6)).ToArray()).Capitalise() + ".";
        }

        public IEnumerable<string> Sentences(int sentenceCount)
        {
            if (sentenceCount <= 0) throw new ArgumentException("Count must be greater than zero", nameof(sentenceCount));

            return sentenceCount.Times(x => Sentence());
        }

        public string Paragraph(int minSentenceCount = 3)
        {
            if (minSentenceCount <= 0) throw new ArgumentException("Count must be greater than zero", nameof(minSentenceCount));

            return string.Join(" ", Sentences(minSentenceCount + RandomNumber.Next(3)).ToArray());
        }

        public IEnumerable<string> Paragraphs(int paragraphCount)
        {
            if (paragraphCount <= 0) throw new ArgumentException("Count must be greater than zero", nameof(paragraphCount));

            return paragraphCount.Times(x => Paragraph());
        }
    }
}