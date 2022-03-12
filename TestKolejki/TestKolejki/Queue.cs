using System;
using System.Collections.Generic;
using System.Text;


namespace KolejkaFIFO
{
    /*
     * PYTANIE 1. Który kod - przed modyfikacj¹, czy po modyfikacji - uwa¿asz za prostrzy (³atwiejszy w pisaniu, analizie)?
     * Który kod uwa¿asz za bezpieczniejszy? Dlaczego?
     * 
     * ODPOWIEDZ: Uwa¿am, ¿e kod po modyfikacji, napisany obiektowo jest prostrzy, 
     * ³atwiejszy w analizowaniu, bardziej przejrzysty oraz du¿o bardziej intuicyjny. 
     * Raz napisany kod, mo¿emy wykorzystaæ wiele raz, równie¿ w innych projektach.
     * Jest bezpieczniejszy, poniewa¿ nie mo¿emy bezpoœrednio przypisywaæ wartoœci pól innym obiektom w nieoczekiwany sposób. 
     * Ka¿dy obiekt udostêpnia interfejs, który okreœla jak mo¿na te dane zmieniæ, 
     * dziêki czemu nasz kod jest bardziej uporz¹dkowany i bezpieczny. 
     */

    public class Queue
    {
        private string[] kolejka;
        private int first;
        private int last;

        public void Create(int liczbaElementow)
        {
            first = last = -1;
            kolejka = new string[liczbaElementow];
        }

        public bool IsFull()
        {
            return ((first == 0 && last == kolejka.Length - 1) || first == last + 1);
        }

        public void Enqueue(string os)
        {
            if (IsFull())
                throw new InvalidOperationException("Kolejka jest pe³na");
            if (last == kolejka.Length - 1 || last == -1)
            {
                kolejka[0] = os;
                last = 0;
                if (first == -1)
                    first = 0;
            }
            else
                kolejka[++last] = os;
        }

        public bool IsEmpty()
        {
            return first == -1;
        }

        public string Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Kolejka jest pusta");
            string tmp;
            tmp = kolejka[first];
            if (first == last)
                last = first = -1;
            else
                if (first == kolejka.Length - 1)
                    first = 0;
                else
                    first++;
            return tmp;
        }

        public void Clear()
        {
            Create(kolejka.Length);
        }

        public string Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Kolejka jest pusta");
            return kolejka[first];
        }

        public int GetLength()
        {
            if(first == -1)
                return 0;
            if (first <= last)
                return last - first + 1;
            return kolejka.Length - first + last + 1;
        }
    }
}
