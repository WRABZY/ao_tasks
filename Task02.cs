
    // Для использования класса Dictionary<K,V> необходима директива "using System.Collections.Generic;"
    static string DeCrypt(string key, string message) 
    {
        char[] keyCharacters = key.ToCharArray();
        Array.Sort(keyCharacters);

        Dictionary<char, int> dictionary = new Dictionary<char, int>();
        for (int i = 0; i < keyCharacters.Length; i++) 
        {
            dictionary.Add(keyCharacters[i], i);
        }

        char[] decoded = new char[message.Length];
        // Проход по символам ключа
        for (int startPosition = 0; startPosition < key.Length; startPosition++) 
        {
            // Индекс символа исходного сообщения, который должен быть на месте startPosition в раскодированном сообщении
            int indexOfCharacterToMove = dictionary[key[startPosition]];  
            /* Так как теперь нужно расставить символы на позиции: startPosition, startPosition + key.Length, 
               startPosition + key.Length + key.Length и т. д., 
               вводится переменная currentPosition, которая будет принимать эти значения в цикле.
            */
            for (int currentPosition = startPosition; currentPosition < message.Length; currentPosition += key.Length) 
            {
                decoded[currentPosition] = message[indexOfCharacterToMove];
                indexOfCharacterToMove += key.Length; // Сдвиг по индексам исходного сообщения соответсвует сдвигу startPosition на key.Length
            }
        }
        
        return new string(decoded).Trim();
    }
    
    