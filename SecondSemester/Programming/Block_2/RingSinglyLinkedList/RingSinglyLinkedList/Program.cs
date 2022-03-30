using System;

namespace RingSinglyLinkedList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Циклический односвязный список:");
            
            var ringSinglyLinkedList = new RingSinglyLinkedList<int>();
            Console.WriteLine("Добавим несколько элементов:");
            ringSinglyLinkedList.Add(10);
            ringSinglyLinkedList.Add(20);
            ringSinglyLinkedList.Add(30);
            ringSinglyLinkedList.Add(40);
            foreach (var item in ringSinglyLinkedList)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("Удалим элемент:");
            ringSinglyLinkedList.Delete(10);
            foreach (var item in ringSinglyLinkedList)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("Удалим все элементы:");
            ringSinglyLinkedList.Clear();
            foreach (var item in ringSinglyLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}