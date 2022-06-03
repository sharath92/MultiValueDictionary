using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    public static class Constants
    {
        public static class Symbol
        {
            public const string Input = ">";
            public const string Output = ")";
            public const string Enter = "\n";
            public const string Space = " ";
            public const string Colon = ":";
        }

        public static class Method
        {
            public const string KEYS = "KEYS";
            public const string MEMBERS = "MEMBERS";
            public const string ADD = "ADD";
            public const string REMOVE = "REMOVE";
            public const string REMOVEALL = "REMOVEALL";
            public const string CLEAR = "CLEAR";
            public const string KEYEXISTS = "KEYEXISTS";
            public const string MEMBEREXISTS = "MEMBEREXISTS";
            public const string ALLMEMBERS = "ALLMEMBERS";
            public const string ITEMS = "ITEMS";

        }

        public static class Error
        {
            public const string InvalidInput = "ERROR, Invalid input. Please try again.";
            public const string KeyDoesNotExist = "ERROR, key does not exist";
            public const string MemberDoesNotExist = "ERROR, member does not exist";
            public const string MemberAlreadyExistsForKey = "ERROR, member already exists For the key";

        }

        public static class Message
        {
            public const string Added = "Added";
            public const string Removed = "Removed";
            public const string Cleared = "Cleared";
            public const string EmptySet = "(empty set)";
        }
    }
}
