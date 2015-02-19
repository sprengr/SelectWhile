using System;
using System.Threading;
using FluentAssert;
using NUnit.Framework;

namespace SelectWhile.Test
{
    [TestFixture]
    public class SelectWhileTest
    {
        public class Animal
        {
            public string Type { get; set; }
            public bool IsExtinct { get; set; }
        }

        [Test]
        public void TestConditionOnSource()
        {
            var animals = new[]
            {
                new Animal{Type = "Cat"}, 
                new Animal{Type = "Dog"}, 
                new Animal{Type = "Unicorn", IsExtinct = true}
            };
            var existingAnimals = animals.SelectWhile(a => !a.IsExtinct, 
                                                      a => a.Type);
            existingAnimals.ShouldContainAllInOrder(new []{ "Cat", "Dog"});
        }

        [Test]
        public void TestConditionOnResult()
        {
            var animals = new[]
            {
                new Animal{Type = "Cat"}, 
                new Animal{Type = "Dog"}, 
                new Animal{Type = "Unicorn", IsExtinct = true}
            };
            var existingAnimals = animals.SelectWhile(a => a.Type, 
                                                      a => a.Length == 3);
            existingAnimals.ShouldContainAllInOrder(new[] { "Cat", "Dog" });
        }
    }
}
