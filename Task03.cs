
    /* Сложность хуже, чем О(sqrt(N)) (корень из N), 
       но лучше, чем O(N)
    */
    static bool IsTriangular(int n) 
    {
        for (int i = 2; n > 1; i++) 
        {
            n -= i;
        }
        return n == 1;
    }
    
    // Сложность O(1), но возникает риск переполнения
    static bool IsTriangular(int n) 
    {
        return Math.Sqrt(8 * n + 1) % 1 == 0;

    }