using System.Collections;
using System.Collections.Generic;
// Источник: https://metanit.com/sharp/algoritm/2.7.php
namespace RingSinglyLinkedList // Циклический односвязный список.
{
    public class Node<T> // Класс, реализующий узел списка.
    {
        public T Data {get; set;}
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    public class RingSinglyLinkedList<T> : IEnumerable<T> // Сам односвязный список.
    {
        private Node<T> _head; // Первый элемент списка.
        private Node<T> _tail; // Последний элемент списка.
        private int _count; // Количество элементов списка.
        public int Count { get { return _count; } }
        public bool IsEmpty { get { return _count == 0; } }

        // Определение наличия узла с нужным значением в списке.
        public bool Contains(T data) 
        {
            Node<T> current = _head;
            if (null == current)
            {
                return false;
            }
            do
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            } while (current != _head);

            return false;
        }

        // Удаление списка.
        public void Clear()
        {
            _head = null;
            _tail = _head;
            _count = 0;
        }

        // Добавление элемента в список.
        public void Add(T data)
        {
            var node = new Node<T>(data);
            if (null == _head) // Если список пустой.
            {
                _head = node;
                _tail = node;
                _tail.Next = _head;
            }
            else
            {
                node.Next = _head;
                _tail.Next = node;
                _tail = node;
            }

            _count += 1;
        }

        // Удаление элемента из списка.
        public bool Delete(T data)
        {
            var current = _head;
            Node<T> previous = null;
            if (IsEmpty)
            {
                return false;
            }

            do
            {
                if (current.Data.Equals(data))
                {
                    if (null != previous) // Если узел -- не голова.
                    {
                        previous.Next = current.Next;
                        
                        if (current == _tail) // Если узел является последним.
                        {
                            _tail = previous;
                        }
                    }
                    else // Если удаляем голову.
                    {
                        if (_count == 1)
                        {
                            _head = _tail = null;
                        }
                        else
                        {
                            _head = current.Next;
                            _tail.Next = current.Next;
                        }
                    }

                    _count -= 1;
                    return true;
                }

                previous = current;
                current = current.Next;
            } while (current != _head);

            return false;
        }
        
        // Реализация оператора перебора foreach.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = _head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != _head);
        }
        // None-public?
        //override IEnumerator<T> GetEnumerator()
        //{
        //    
        //}
    }
    
    }