using System;
using System.Collections.Generic;
using MultiValueDictionary;
using static MultiValueDictionary.Constants;


Dictionary<string, HashSet<string>> multivalueDictionary = new();
DictionaryHandler.Init(multivalueDictionary);

while (true)
{
    Console.Write(Symbol.Input);
    string? input = Console.ReadLine();
    string output = string.Empty;

    if (string.IsNullOrEmpty(input))
    {
        output = Error.InvalidInput;
    }
    else
    {
        output = DictionaryHandler.ProcessInput(input);
    }

    MessageHandler.ShowMessage(output);
}
