using NUnit.Framework;
using MultiValueDictionary;
using System.Collections.Generic;
using static MultiValueDictionary.Constants;

namespace MultiValueDictionary.Test
{
    public class MultiValueDictionaryTests
    {

        [Test]
        public void AddKeyValueTest()
        {
            Dictionary<string, HashSet<string>> dictionary = new();
            DictionaryHandler.Init(dictionary);

            string input = "ADD k v1";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v2";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v3";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v4";
            DictionaryHandler.ProcessInput(input);

            Assert.True(dictionary.ContainsKey("k"));
            Assert.True(dictionary["k"].Count == 4);

        }

        [Test]
        public void RemoveAValueFromAKeyTest()
        {
            Dictionary<string, HashSet<string>> dictionary = new();
            DictionaryHandler.Init(dictionary);

            string input = "ADD k v1";
            DictionaryHandler.ProcessInput(input);
            
            input = "ADD k v2";
            DictionaryHandler.ProcessInput(input);

            input = "REMOVE k v1";
            DictionaryHandler.ProcessInput(input);

            Assert.False(dictionary["k"].Contains("v1"));
        }

        [Test]
        public void RemoveAllValuesOfKeyTest()
        {
            Dictionary<string, HashSet<string>> dictionary = new();

            DictionaryHandler.Init(dictionary);

            string input = "ADD k v1";
            DictionaryHandler.ProcessInput(input);

            input = "REMOVEALL k";
            DictionaryHandler.ProcessInput(input);

            Assert.False(dictionary.ContainsKey("k"));
        }


        [Test]
        public void MembersWrongKeyTest()
        {
            Dictionary<string, HashSet<string>> dictionary = new();

            DictionaryHandler.Init(dictionary);

            string input = "ADD k v1";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v2";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v3";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v4";
            DictionaryHandler.ProcessInput(input);

            input = "MEMBERS j";
            var output = DictionaryHandler.ProcessInput(input);

            Assert.AreEqual(output, Error.KeyDoesNotExist);
        }


        [Test]
        public void MembersCorrectKeyTest()
        {
            Dictionary<string, HashSet<string>> dictionary = new();

            DictionaryHandler.Init(dictionary);

            string input = "ADD k v1";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v2";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v3";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v4";
            DictionaryHandler.ProcessInput(input);

            input = "MEMBERS k";
            var output = DictionaryHandler.ProcessInput(input);

            Assert.AreEqual(output, "1) v1\n2) v2\n3) v3\n4) v4");
        }


        [Test]
        public void ClearDictionaryTest()
        {
            Dictionary<string, HashSet<string>> dictionary = new();

            DictionaryHandler.Init(dictionary);

            string input = "ADD k v1";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v2";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v3";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v4";
            DictionaryHandler.ProcessInput(input);

            input = "CLEAR";
            var output = DictionaryHandler.ProcessInput(input);

            Assert.AreEqual(output, Message.Cleared);
            Assert.True(dictionary.Count == 0);
        }

        [Test]
        public void ClearDictionaryErrorTest()
        {
            Dictionary<string, HashSet<string>> dictionary = new();

            DictionaryHandler.Init(dictionary);

            string input = "ADD k v1";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v2";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v3";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v4";
            DictionaryHandler.ProcessInput(input);

            input = "CLEAR k";
            var output = DictionaryHandler.ProcessInput(input);

            Assert.AreEqual(output, Error.InvalidInput);
            Assert.True(dictionary.Count != 0);
        }


        [Test]
        public void AllMembersSuccessTest()
        {
            Dictionary<string, HashSet<string>> dictionary = new();

            DictionaryHandler.Init(dictionary);

            string input = "ADD k v1";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v2";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v3";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v4";
            DictionaryHandler.ProcessInput(input);

            input = "ADD j v5";
            DictionaryHandler.ProcessInput(input);

            input = "ADD j v6";
            DictionaryHandler.ProcessInput(input);

            input = "ADD h v7";
            DictionaryHandler.ProcessInput(input);

            input = "AllMembers";
            var output = DictionaryHandler.ProcessInput(input);

            Assert.AreEqual(output, "1) v1\n2) v2\n3) v3\n4) v4\n5) v5\n6) v6\n7) v7");
        }

        [Test]
        public void ItemsSuccessTest()
        {
            Dictionary<string, HashSet<string>> dictionary = new();

            DictionaryHandler.Init(dictionary);

            string input = "ADD k v1";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v2";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v3";
            DictionaryHandler.ProcessInput(input);

            input = "ADD k v4";
            DictionaryHandler.ProcessInput(input);

            input = "ADD j v5";
            DictionaryHandler.ProcessInput(input);

            input = "ADD j v6";
            DictionaryHandler.ProcessInput(input);

            input = "ADD h v7";
            DictionaryHandler.ProcessInput(input);
            
            input = "ADD a a1";
            DictionaryHandler.ProcessInput(input); 
            
            input = "ADD a a2";
            DictionaryHandler.ProcessInput(input);

            input = "Items";
            var output = DictionaryHandler.ProcessInput(input);

            Assert.AreEqual(output, "1) k : v1\n2) k : v2\n3) k : v3\n4) k : v4\n5) j : v5\n6) j : v6\n7) h : v7\n8) a : a1\n9) a : a2");
        }

    }
}