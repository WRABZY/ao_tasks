    
    // Решение с использованием рекурсии
    static int SuperPuperDeepCounterRecursive(object[] array) 
    {
        int count = array.Length;
        
        for (int i = 0; i < array.Length; i++) 
        {
            if (array[i].GetType().IsArray) 
            {
                count += SuperPuperDeepCounterRecursive((array[i] as object[]));
            }
        }
            
        return count;
    }
    
    
    /* Решение с использованием цикла и очереди:
       Происходит проверка типа каждого элемента данного массива.
       Если элемент массива сам является массивом - он помещается в очередь на проверку.
       Содержимое очереди проверяется, пока очередь не опустеет.
       
       Так как по условию входной параметр всегда массив, 
       используется цикл с постусловием (хотя бы один раз по массиву точно придется пробежаться).
       
       Для использования класса Queue<T> необходима директива "using System.Collections.Generic;"
    */
    static int SuperPuperDeepCounterCyclic(object[] array) 
    {
        Queue<object[]> arraysToCheck = new Queue<object[]>();
        arraysToCheck.Enqueue(array);
    
        int count = 0;

        do 
        {
            object[] nextArray = arraysToCheck.Dequeue();
            count += nextArray.Length;
            for (int i = 0; i < nextArray.Length; i++) 
            {
                if (nextArray[i].GetType().IsArray) 
                {
                    arraysToCheck.Enqueue((nextArray[i] as object[]));
                }
            }
            
        } while(arraysToCheck.Count > 0);
    
        return count;
    }
    
    