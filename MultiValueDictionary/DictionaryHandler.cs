using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MultiValueDictionary.Constants;

namespace MultiValueDictionary
{
    public static class DictionaryHandler
    {
        private static Dictionary<string, HashSet<string>> _multiValueDictionary = new();
        
        public static void Init(Dictionary<string, HashSet<string>> multiValueDictionary)
        {
            _multiValueDictionary = multiValueDictionary; 
        }

        #region Input-Output Process
        public static string ProcessInput(string input)
        {
            var inputArray = input.Split(Symbol.Space, StringSplitOptions.RemoveEmptyEntries);

            if (!inputArray.Any() || inputArray.Length > 3)
            {
                return Error.InvalidInput;
            }

            var methodName = inputArray[0].ToUpper();

            var result = string.Empty;

            try
            {
                switch (methodName)
                {
                    case Method.KEYS:
                        {
                            if (inputArray.Length == 1)
                            {
                                var keys = Keys();
                                result = keys.Any() ? ParseOutput(keys) : Message.EmptySet;
                            }
                            break;
                        }

                    case Method.MEMBERS:
                        {
                            if (inputArray.Length == 2)
                            {
                                var members = Members(inputArray[1]);
                                result = members.Any() ? ParseOutput(members) : Error.KeyDoesNotExist;
                            }
                            break;
                        }

                    case Method.ADD:
                        {
                            if (inputArray.Length == 3)
                            {
                                result = Add(inputArray[1], inputArray[2]);
                            }
                            break;
                        }

                    case Method.REMOVE:
                        {
                            if (inputArray.Length == 3)
                            {
                                result = Remove(inputArray[1], inputArray[2]);
                            }
                            break;
                        }
                    case Method.REMOVEALL:
                        {
                            if (inputArray.Length == 2)
                            {
                                result = RemoveAll(inputArray[1]);
                            }
                            break;
                        }

                    case Method.CLEAR:
                        {
                            if (inputArray.Length == 1)
                            {
                                result = Clear();
                            }
                            break;
                        }

                    case Method.KEYEXISTS:
                        {
                            if (inputArray.Length == 2)
                            {
                                result = KeyExists(inputArray[1]) ? bool.TrueString : bool.FalseString;
                            }
                            break;
                        }

                    case Method.MEMBEREXISTS:
                        {
                            if (inputArray.Length == 3)
                            {
                                result = MemberExists(inputArray[1], inputArray[2]) ? bool.TrueString : bool.FalseString;
                            }
                            break;
                        }

                    case Method.ALLMEMBERS:
                        {
                            if (inputArray.Length == 1)
                            {
                                var allMembers = AllMembers();
                                result = allMembers.Any() ? ParseOutput(allMembers) : Message.EmptySet;
                            }
                            break;
                        }

                    case Method.ITEMS:
                        {
                            if (inputArray.Length == 1)
                            {
                                var items = Items();
                                result = items.Any() ? ParseOutput(items) : Message.EmptySet;
                            }
                            break;
                        }

                    default:
                        result = Error.InvalidInput;
                        break;
                }
            }
            catch (Exception ex) 
            {
                result = Error.InvalidInput + Symbol.Space + ex.Message;
            }

            return string.IsNullOrEmpty(result) ? Error.InvalidInput : result;
        }

        private static string ParseOutput(IEnumerable<string> collection) 
        {
            return string.Join(Symbol.Enter, collection.Select((item,i)=> $"{++i}{Symbol.Output} {item}"));
        }

        #endregion Input-Output Process

        #region Dictionary Methods
        private static IEnumerable<string> Keys()
        {
            return _multiValueDictionary.Keys.ToList();
        }

        private static IEnumerable<string> Members(string key)
        {
            if (!KeyExists(key))
            {
                return new List<string>(); 
            }

            return  _multiValueDictionary[key].ToList();
        }


        private static string Add(string key, string value)
        {
            if (!KeyExists(key))
            {
                _multiValueDictionary.Add(key, new HashSet<string>());
            }

            var valueCollection = _multiValueDictionary[key];

            if (valueCollection.Contains(value)) 
            { 
                return Error.MemberAlreadyExistsForKey;
            }
            
            valueCollection.Add(value);
            
            return Message.Added;

        }

        private static string Remove(string key, string value)
        {
            if (!KeyExists(key))
            {
                return Error.KeyDoesNotExist;
            }

            var valueCollection = _multiValueDictionary[key];

            if (!valueCollection.Contains(value))
            {
                return Error.MemberDoesNotExist;
            }

            valueCollection.Remove(value);

            if (valueCollection.Count == 0)
                RemoveAll(key);

            return Message.Removed;

        }

        private static string RemoveAll(string key)
        {
            if (!KeyExists(key))
            {
                return Error.KeyDoesNotExist;
            }
            
            _multiValueDictionary.Remove(key);

            return Message.Removed;

        }

        private static string Clear()
        {
            if(_multiValueDictionary.Any())
                _multiValueDictionary.Clear();
            return Message.Cleared;
        }

        private static bool KeyExists(string key)
        {
            return _multiValueDictionary.ContainsKey(key); 
        }


        private static bool MemberExists(string key, string value)
        {
            if (KeyExists(key))
            {
                return _multiValueDictionary[key].Contains(value); 
            }

            return false;
        }

        private static IEnumerable<string> AllMembers()
        {
            return _multiValueDictionary.Values.SelectMany(val => val).ToList();
        }


        private static IEnumerable<string> Items()
        {
            var members = new List<string>();

            foreach (var kvPair in _multiValueDictionary)
            {
                foreach (var valueItem in kvPair.Value)
                {
                    members.Add($"{kvPair.Key} {Symbol.Colon} {valueItem}");
                }
            }

            return members;
        }

        #endregion Dictionary Methods
    }
}
