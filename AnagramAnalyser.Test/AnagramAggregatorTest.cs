using AnagramAnalyser.Core;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AnagramAnalyser.Test
{
    public class AnagramAggregatorTest
    {
        [Fact]
        public void FindAnagrams_Multiple()
        {
            var input = new string(@"dog god cat tac bag");
            var result = AnagramAggregator.FindAll(input.Split(" ").ToList());
            var expected = new Dictionary<string, LinkedList<string>>()
            {
               {
                   "dgo",
                   new LinkedList<string>
                   (
                       new string[]
                       {
                           "dog",
                           "god"
                       }
                   )
               },
               {
                   "act",
                   new LinkedList<string>
                   (
                       new string[]
                       {
                           "cat",
                           "tac"
                       }
                   )
               },
               {
                   "abg",
                   new LinkedList<string>
                   (
                       new string[]
                       {
                           "bag"
                       }
                   )
               }
            };
            result.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public void FindAnagrams_NegativeMatch()
        {
            var input = new string(@"dog god cat tac bag");
            var result = AnagramAggregator.FindAll(input.Split(" ").ToList());
            var expected = new Dictionary<string, LinkedList<string>>()
            {
               {
                   "dgo",
                   new LinkedList<string>
                   (
                       new string[]
                       {
                           "dog",
                           "god"
                       }
                   )
               },
            };
            result.Should().NotEqual(expected);
        }
        [Fact]
        public void FindAnagrams_FormatResult()
        {
            var input = new string(@"dog god cat tac bag");
            var result = AnagramAggregator.FindAll(input.Split(" ").ToList()).FormatResult();
        }
    }
}
