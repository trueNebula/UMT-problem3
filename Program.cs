using System;

class Program{
    static bool checkIfPossible(int sum, int l){
        /*
            Fie s - suma elementelor din array-ul initial
                l - lungimea subarray-ului initial
                sB, sC - suma elementelor din subarray-ul B, respectiv C
                b, c - lungimea subarray-ului B, respectiv C
            Astfel: b + c = l; sB + sC = s
            Conditia care trebuie indeplinita este 
                sB/b = sC/c
            <=> (s - sB) / (l - b) = sB/b
            <=> s * (l - b) = (s - sB) * b
            <=> l*s - b*s = b*s - b*sB
            <=> sB = b * s / l

            Deci, daca putem gasi lungimile subarray-urilor astfel incat suma elementelor dintr-unul inmultita cu lungimea sa sa fie divizibila cu lungimea array-ului initial,
            atunci array-ul initial poate fi impartit
        */

        for(int i = 1; i < l/2; ++i)
            if(sum * i % l == 0)
                return true;

        return false;

    }

    static bool splitArray(int[] A){
        /*  
            Problema: trebuie verificat daca elementele dintr-un array de numere intregi poate fi impartit in doua subarray-uri non-goale in asa fel incat media lor sa fie egala
            Solutie:
                - putem scapa rapid de cateva cazuri dpv. matematic.
                - array-ul poate fi impartit doar daca exista un i de la 1 la lungime-1 astfel incat suma elementelor inmultita cu i sa fie divizibila cu lungimea array-ului
                - daca conditia e indeplinita, atunci facem o matrice de sume partiale
                - pe randul i al matricii vom avea sumele partiale pe care le putem obtine cu i elemente din array-ul initial
                - cand trecem la un nou element, il adaugam la fiecare suma partiala din randul anterior pentru a obtine un rand nou, dupa care trecem la la randul dinainte 
                - in final, vom avea toate sumele partiale pe care le putem obtine cu elemente din array-ul initial
                - pentru fiecare lungime posibila al unui subarray, vedem daca respecta conditia matematica si daca suma partiala care ar rezulta exista in matrice
                - daca da, atunci array-ul se poate imparti in doua subarray-uri astfel incat media lor sa fie egala
        */

        // calculam atat lungimea array-ului cat si suma elementelor
        int l = A.Length;

        // daca lungimea array-ului este mai mica decat 2, atunci nu il putem imparti
        if(l < 2)
            return false;

        int sum = A.Sum();
        int mid = l/2;

        // tratez cazurile in care matematic vorbind nu se poate imparti array-ul
        if(!checkIfPossible(sum, l))
            return false;

        // creez si initializez matricea folosita pentru memoizarea sumelor partiale
        // sums[i] va contine toate sumele pe care le putem obtine cu i elemente din A
        // sums[0] = 0
        List<HashSet<int>> sums = new List<HashSet<int>>(mid + 1);
        
        for(int i = 0; i <= mid; i++)
            sums.Add(new HashSet<int>());

        sums[0].Add(0);

        // parcurg array-ul si adaug la lista de sume partiale fiecare suma posibila
        foreach(int i in A)
            for(int j = mid-1; j >= 0; j--)
                foreach(int prev in sums[j])
                    sums[j+1].Add(prev + i);
        
        // verific conditia de impartire si daca pot gasi suma partiala rezultata in lista
        // daca da, array-ul se poate imparti in doua subarray-uri astfel incat media lor sa fie egala
        for(int i = 1; i <= mid; ++i){
            if(sum * i % l == 0 && sums[i].Contains(sum * i / l))
                return true;

        }

        return false;

    }
    
    static void Main(string[] args){
        int[] A = new int[] { 5, 3, 11, 9, 2 };
        Console.WriteLine(splitArray(A));

    }

}

