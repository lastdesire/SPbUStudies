using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RingSinglyLinkedList // Циклический односвязный список.
{
    // Класс, реализующий узел списка.
    public class CircleListNode<T> where T : IComparable
    {
        public T Data { get; set; }
        public CircleListNode<T> Next { get; set; }

        public CircleListNode(T data)
        {
            Data = data;
        }
    }

    public class CircleList<T> : IEnumerable<T> where T : IComparable // Сам односвязный список.
    {
        public CircleListNode<T> _head { get; private set; } // Первый элемент списка.
        public CircleListNode<T> _tail { get; private set; } // Последний элемент списка.
        private int _count; // Количество элементов списка.

        public int Count
        {
            get { return _count; }
        }

        public bool IsEmpty
        {
            get { return _count == 0; }
        }

        // Инициализирует новый экземпляр пустого класса CircleList<T>.
        public CircleList()
        {
        }

        // Инициализирует новый экземпляр класса CircleList<T>, содержащий
        // элементы, скопированные из указанного класса IEnumerable, и обладающий
        // емкостью, достаточной для того, чтобы вместить количество скопированных элементов.
        public CircleList(IEnumerable<T> list)
        {
            _count = 0;
            foreach (var item in list)
            {
                AddLast(item);
            }
        }

        // Добавляет заданный новый узел после заданного существующего узла в CircleList<T>.
        public void AddAfter(CircleListNode<T> newNode, CircleListNode<T> current)
        {
            if (Count == 0)
            {
                throw new ArgumentNullException();
            }
            var savedNext = current.Next;
            current.Next = newNode; 
            newNode.Next = savedNext; 
            _count += 1; 
        }

        // Добавляет новый узел, содержащий заданное значение, после заданного существующего узла в CircleList<T>.
        public void AddAfter(CircleListNode<T> node, T value)
        {
            var newNode = new CircleListNode<T>(value);
            AddAfter(newNode, node);
            
        }

        // Добавляет новый узел, содержащий заданное значение, перед заданным существующим узлом в CircleList<T>.
        public void AddBefore(CircleListNode<T> newNode, CircleListNode<T> current)
        {
            if (_count == 1)
            {
                _tail = newNode;
                _tail.Next = _head;
                _head.Next = _tail;
                _count++;
                return;
            }

            if (current == _head)
            {
                _tail.Next = newNode;
                _tail = newNode;
                _tail.Next = _head;
                _count++;
                return;
            }
            
            var savedPrev = current;
            for (var i = 0; i < _count; i++) 
            {
                savedPrev = current;
                current = current.Next;
            }
            savedPrev.Next = newNode;
            newNode.Next = current;
            _count++;
        }
        
        public void AddBefore(CircleListNode<T> node, T value)
        {
            var newNode = new CircleListNode<T>(value);
            AddBefore(newNode, node);
        }

        // Добавляет заданный новый узел в начало CircleList<T>.
        public void AddFirst(CircleListNode<T> node)
        {
            if (_head == null)
            {
                _head = node;
                _tail = _head;
                _tail.Next = _tail;
                _count++;
                return;
            }

            var savedHead = _head;
            _tail.Next = node;
            _head = node;
            _head.Next = savedHead;
            _count++;
        }

        // Добавляет новый узел, содержащий заданное значение, в начало CircleList<T>.
        public void AddFirst(T value)
        {
            var newNode = new CircleListNode<T>(value);
            AddFirst(newNode);
        }

        // Определение наличия узла с нужным значением в списке.
        public bool Contains(T data)
        {
            var current = _head;
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
        public void AddLast(T data)
        {
            var node = new CircleListNode<T>(data);
            AddLast(node);
        }

        public void AddLast(CircleListNode<T> node)
        {
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

        // Копирует целый массив CircleList<T> в совместимый одномерный массив Array,
        // начиная с заданного индекса целевого массива.
        public void CopyTo(T[] array, int i)
        {
            foreach (var item in this)
            {
                array[i] = item;
                i++;
            }
        }

        // Определяет, равен ли указанный объект текущему объекту. (Унаследовано от Object)
        public bool Equals(Object obj)
        {
            CircleList<T> q;
            try
            {
                q = (CircleList<T>) obj;
            }
            catch (Exception e)
            {
                return false;
            }

            if (q._count != this._count)
            {
                return false;
            }

            var curr = q._head;
            foreach (var item in this)
            {
                if (curr.Data.CompareTo(item) != 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Находит первый узел, содержащий указанное значение.
        public CircleListNode<T> Find(T value)
        {
            if (_head == null)
            {
                return null;
            }

            var curr = _head;
            if (curr.Data.CompareTo(value) == 0)
            {
                return _head;
            }

            while (curr.Next != _head)
            {
                curr = curr.Next;
                if (curr.Data.CompareTo(value) == 0)
                {
                    return curr;
                }
            }

            return null;
        }

        // Удаление элемента из списка.
        public bool Remove(T data)
        {
            var current = _head;
            CircleListNode<T> previous = null;
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
        
        // Удаляет заданный узел из объекта CircleList<T>.
        public void RemoveNode(CircleListNode<T> node)
        {
            var savedPrev = _tail;
            var curr = _head;
            while (curr != node)
            {
                if (curr.Next == _head) // Узел не принадлежит списку.
                {
                    return;
                }

                savedPrev = curr;
                curr = curr.Next;
            }
            savedPrev.Next = curr.Next;
            _count--;
        }
        
        // Удаляет узел в начале CircleList<T>.
        public void RemoveFirst()
        {
            if (_head == null)
            {
                return;
            }

            if (_count == 1)
            {
                Clear();
                return;
            }

            var savedNext = _head.Next;
            _tail.Next = savedNext;
            _head = savedNext;
            _count -= 1;
        }

        // Удаляет узел в конце CircleList<T>.
        public void RemoveLast()
        {
            if (_head == null)
            {
                return;
            }

            if (_count == 1)
            {
                Clear();
                return;
            }

            var curr = _head;
            var savedPrev = _head;
            for (var i = 0; i < _count - 1; i++) // Then curr is tail.
            {
                savedPrev = curr;
                curr = curr.Next;
            }

            savedPrev.Next = _head;
            _tail = savedPrev;
            _count -= 1;
        }

        //Возвращает строку, представляющую текущий объект. (Унаследовано от Object)
        public string ToString()
        {
            var str = "";
            var counter = 0;
            foreach (var item in this)
            {
                counter++;
                Object obj = item;
                if (counter == _count)
                {
                    str += obj.ToString();
                }
                else
                {
                    str += obj.ToString() + " ";
                }
            }
            
            return str;
        }

        // Находит последний узел, содержащий указанное значение.
        public CircleListNode<T> FindLast(T value)
        {
            if (_head == null)
            {
                return null;
            }

            var curr = _head;
            CircleListNode<T> returnNode = null;
            while (curr != _tail)
            {
                if (curr.Data.CompareTo(value) == 0)
                {
                    returnNode = curr;
                }

                curr = curr.Next;
            }

            if (curr.Data.CompareTo(value) == 0)
            {
                returnNode = curr;
            }

            return returnNode;
        }

        // Возвращает объект Type для текущего экземпляра.
        public Type ListGetType()
        {
            return this.GetType();
        }

        
        // Создает неполную копию текущего объекта Object. (Унаследовано от Object)
        public CircleList<T> MyMemberwiseClone()
        {
            var list = (object) this;
            return (CircleList<T>) list;
        }

        // Реализация оператора перебора foreach.
        // Возвращает перечислитель, осуществляющий перебор элементов списка CircleList<T>.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
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
            } while (current != _head);
        }
    }


    public static class ListExtensions
    {
        // Проверяет, все ли элементы последовательности удовлетворяют условию.
        public static bool MyAll<TSource>(this IEnumerable<TSource> list, Func<TSource, Boolean> cond) where TSource : IComparable
        {
            foreach (var item in list)
            {
                if (!cond(item))
                {
                    return false;
                }
            }
            return true;
        }
        
        
        // Проверяет, содержит ли последовательность какие-либо элементы.
        public static bool MyAny<TSource>(this IEnumerable<TSource> list)
        {
            return list.Select(item => item != null).MyFirstOrDefault();
        }
        
        // Проверяет, удовлетворяет ли какой-либо элемент последовательности заданному условию.
        public static bool MyAny<TSource>(this IEnumerable<TSource> list, Func<TSource, Boolean> cond)
        {
            foreach (var item in list)
            {
                if (cond(item))
                {
                    return true;
                }
            }
            return false;
        }

        // Добавляет значение в конец последовательности.
        // Необходимо приравнивание
        // к новому объекту.
        public static IEnumerable<TSource> MyAppend<TSource>(this IEnumerable<TSource> list, TSource addItem) where TSource : IComparable
        {
            var newList = ((CircleList<TSource>) list).MyMemberwiseClone();
            newList.AddLast(addItem);
            return newList;
        }

        // Объединяет две последовательности.
        // Необходимо приравнивание
        // к новому объекту.
        public static IEnumerable<TSource> MyConcat<TSource>(this IEnumerable<TSource> list0, IEnumerable<TSource> list1) where TSource : IComparable
        {
            var newList = ((CircleList<TSource>) list0).MyMemberwiseClone();
            foreach (var item in list1)
            {
                newList.AddLast(item);
            }

            return newList;
        }

        // Определяет, содержится ли указанный элемент в последовательности, используя компаратор проверки на равенство по умолчанию.
        public static bool MyContains<TSource>(this IEnumerable<TSource> list, TSource data) where TSource : IComparable
        {
            foreach (var item in list)
            {
                if (item.CompareTo(data) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        // Возвращает количество элементов в последовательности.
        public static int MyCount<TSource>(this IEnumerable<TSource> list)
        {
            var count = 0;
            foreach (var item in list)
            {
                if (item != null)
                {
                    count++;
                }
            }
            return count;
        }
        
        // Возвращает число, представляющее количество элементов последовательности, удовлетворяющих заданному условию.
        public static int MyCount<TSource>(this IEnumerable<TSource> list, Func<TSource, Boolean> cond)
        {
            var counter = 0;
            foreach (var item in list)
            {
                if (cond(item))
                {
                    counter++;
                }
            }
            return counter;
        }

        // Возвращает различающиеся элементы последовательности.
        // Необходимо приравнивание
        // к новому объекту.
        public static IEnumerable<TSource> MyDistinct<TSource>(this IEnumerable<TSource> list) where TSource : IComparable
        {
            var newList = new CircleList<TSource>();
            foreach (var item in list)
            {
                if (!newList.MyContains(item))
                {
                    newList.AddLast(item);
                }
            }
            return newList;
        }

        
        // Возвращает элемент по указанному индексу в последовательности.
        public static TSource MyElementAt<TSource>(this IEnumerable<TSource> list, Int32 index)
        {
            var i = 0;
            foreach (var item in list)
            {
                if (i == index)
                {
                    return item;
                }

                i++;
            }

            throw new ArgumentOutOfRangeException();
        }
        
        // Возвращает элемент последовательности по указанному
        // индексу или значение по умолчанию, если индекс вне
        // допустимого диапазона.
        public static TSource MyElementAtOrDefault<TSource>(this IEnumerable<TSource> list, Int32 index)
        {
            var i = 0;
            foreach (var item in list)
            {
                if (i == index)
                {
                    return item;
                }
                i++;
            }
            return default;
        }

        // Находит разность множеств, представленных двумя последовательностями (A\B).
        // Необходимо приравнивание
        // к новому объекту.
        public static IEnumerable<TSource> MyExcept<TSource>(this IEnumerable<TSource> list0, IEnumerable<TSource> list1) where TSource : IComparable
        {
            var newList = new CircleList<TSource>();

            foreach (var item in list0)
            {
                if (!list1.MyContains(item))
                {
                    newList.AddLast(item);
                }
            }
            return newList;
        }
        
        // Возвращает первый элемент последовательности.
        public static TSource MyFirst<TSource>(this IEnumerable<TSource> list)
        {

            foreach (var item in list)
            {
                return item;
            }

            throw new ArgumentNullException();
        }
        
        // Возвращает первый элемент последовательности или
        // значение по умолчанию,
        // если последовательность не содержит элементов.
        public static TSource MyFirstOrDefault<TSource>(this IEnumerable<TSource> list)
        {
            foreach (var item in list)
            {
                return item;
            }
            return default;
        }

        // Находит пересечение множеств, представленных двумя последовательностями.
        // Необходимо приравнивание
        // к новому объекту.
        public static IEnumerable<TSource> MyIntersect<TSource>(this IEnumerable<TSource> list0, IEnumerable<TSource> list1) where TSource : IComparable
        {
            var newList = new CircleList<TSource>();

            foreach (var item in list0)
            {
                if (list1.MyContains(item))
                {
                    newList.AddLast(item);
                }
            }
            return newList;
        }
        
        // Возвращает последний элемент последовательности.
        public static TSource MyLast<TSource>(this IEnumerable<TSource> list)
        {
            TSource returnItem = default;
            var count = 0;
            foreach (var item in list)
            {
                returnItem = item;
                count++;
            }

            if (count == 0)
            {
                throw new ArgumentNullException();
            }

            return returnItem;
        }

        // Возвращает последний элемент последовательности или значение по умолчанию,
        // если последовательность не содержит элементов.
        public static TSource MyLastOrDefault<TSource>(this IEnumerable<TSource> list)
        {
            TSource returnItem = default;
            var count = 0;
            foreach (var item in list)
            {
                returnItem = item;
                count++;
            }
            return count == 0 ? default : returnItem;
        }

        // Возвращает значение типа Int64, представляющее общее число элементов в последовательности.
        public static Int64 MyLongCount<TSource>(this IEnumerable<TSource> list)
        {
            return list.Count();;
        }
        
        // Возвращает максимальное значение, содержащееся в универсальной последовательности.
        public static TSource MyMax<TSource>(this IEnumerable<TSource> list) where TSource : IComparable
        {
            if (!list.Any())
            {
                throw new ArgumentNullException();
            }

            var max = list.First();
            foreach (var item in list)
            {
                if (item.CompareTo(max) == 1)
                {
                    max = item;
                }
            }

            return max;
        }

        // Возвращает минимальное значение, содержащееся в универсальной последовательности.
        public static TSource MyMin<TSource>(this IEnumerable<TSource> list) where TSource : IComparable
        {
            if (!list.Any())
            {
                throw new ArgumentNullException();
            }

            var min = list.First();
            foreach (var item in list)
            {
                if (item.CompareTo(min) == -1)
                {
                    min = item;
                }
            }

            return min;
        }
        
        // Добавляет значение в начало последовательности.
        // Необходимо приравнивание
        // к новому объекту.
        public static IEnumerable<TSource> MyPrepend<TSource>(this IEnumerable<TSource> list, TSource item) where TSource : IComparable
        {
            var newList = ((CircleList<TSource>) list).MyMemberwiseClone();
            newList.AddFirst(item);
            return newList;
        }
        
        // Изменяет порядок элементов последовательности на противоположный.
        // Необходимо приравнивание
        // к новому объекту.
        public static IEnumerable<TSource> MyReverse<TSource>(this IEnumerable<TSource> list) where TSource : IComparable
        {
            var returnList = new CircleList<TSource>();
            foreach (var item in list)
            {
                returnList.AddFirst(item);
            }
            return returnList;
        }
        
        // Определяет, совпадают ли две последовательности (порядок элементов важен).
        public static bool MySequenceEqual<TSource>(this IEnumerable<TSource> list0, IEnumerable<TSource> list1) where TSource : IComparable
        {
            if (list0.Count() != list1.Count())
            {
                return false;
            }

            var array0 = new TSource[list0.Count()];
            var i = 0;
            foreach (var item in list0)
            {
                array0[i] = item;
            }
            
            var array1 = new TSource[list1.Count()];
            i = 0;
            foreach (var item in list1)
            {
                array1[i] = item;
            }

            for (i = 0; i < list1.Count(); i++)
            {
                if (array0[i].CompareTo(array1[i]) != 0)
                {
                    return false;
                }
            }
            return true;
        }
        
        
        // Возвращает единственный элемент последовательности и
        // генерирует исключение, если число элементов последовательности
        // отлично от 1.
        // Источник: Enumerable.cs library.
        public static TSource MySingle<TSource>(this IEnumerable<TSource> list)
        {
            switch (list)
            {
                case null:
                    throw new ArgumentNullException();
                case List<TSource> sourceList:
                    switch (sourceList.Count)
                    {
                        case 0:
                            throw new ArgumentNullException();
                        case 1:
                            return sourceList[0];
                    }
                    break;
                
                default:
                {
                    using (var enumerator = list.GetEnumerator())
                    {
                        var source1 = enumerator.MoveNext() ? enumerator.Current : throw new ArgumentNullException();
                        if (!enumerator.MoveNext())
                            return source1;
                    }
                    break;
                }
            }
            throw new ArgumentNullException();
        }

        // Возвращает единственный элемент последовательности или значение по умолчанию,
        // если последовательность пуста;
        // если в последовательности более одного элемента, генерируется исключение.
        // Источник: Enumerable.cs library.
        public static TSource MySingleOrDefault<TSource>(this IEnumerable<TSource> list)
        {
            switch (list)
            {
                case null:
                    throw new ArgumentNullException();
                case List<TSource> sourceList:
                    switch (sourceList.Count)
                    {
                        case 0:
                            return default;
                        case 1:
                            return sourceList[0];
                    }
                    break;
                
                default:
                {
                    using (var enumerator = list.GetEnumerator())
                    {
                        if (!enumerator.MoveNext())
                            return default;
                        var curr = enumerator.Current;
                        if (!enumerator.MoveNext())
                            return curr;
                    }
                    break;
                }
            }
            throw new ArgumentNullException();
        }

        // Возвращает указанное число подряд идущих элементов с начала последовательности (если указано больше, чем есть, то возвращается копия).
        // Необходимо приравнивание
        // к новому объекту.
        public static IEnumerable<TSource> MyTake<TSource>(this IEnumerable<TSource> list, int number) where TSource : IComparable
        {
            var counter = 0;
            var newList = new CircleList<TSource>();
            if (number < 0)
            {
                throw new ArgumentNullException();
            }
            if (number == 0)
            {
                return newList;
            }
            foreach (var item in list)
            {
                counter++;
                newList.AddLast(item);
                if (counter == number)
                {
                    return newList;
                }
            }
            return newList;
        }


        // Возвращает указанный диапазон смежных элементов из последовательности (индексация подобна такой, как в массиве).
        // Необходимо приравнивание
        // к новому объекту.
        public static IEnumerable<TSource> MyTake<TSource>(this IEnumerable<TSource> list, int start, int end) where TSource : IComparable
        {
            var newList = new CircleList<TSource>();
            var counter = 0;
            if (start < 0)
            {
                throw new ArgumentNullException();
            }

            if (end > list.Count() - 1)
            {
                throw new ArgumentNullException();
            }
            foreach (var item in list)
            {
                if (counter >= start && counter <= end)
                {
                    newList.AddLast(item);
                }
                else if (counter > end)
                {
                    return newList;
                }

                counter++;
            }

            return newList;
        }

        // Возвращает новую перечислимую коллекцию, содержащую последние count элементов из source (если указано больше, чем есть, то возвращается копия).
        // Необходимо приравнивание
        // к новому объекту.
        public static IEnumerable<TSource> MyTakeLast<TSource>(this IEnumerable<TSource> list, Int32 count) where TSource : IComparable
        {
            var newList = new CircleList<TSource>();
            var counter = 0;
            if (count < 0)
            {
                throw new ArgumentNullException();
            }

            if (count == 0)
            {
                return newList;
            }

            foreach (var item in list.Reverse())
            {
                counter++;
                newList.AddFirst(item);
                if (counter == count)
                {
                    return newList;
                }
            }

            return newList;
        }

        // Находит объединение множеств, представленных двумя последовательностями.
        // Необходимо приравнивание
        // к новому объекту.
        public static IEnumerable<TSource> MyUnion<TSource>(this IEnumerable<TSource> list0, IEnumerable<TSource> list1) where TSource : IComparable
        {
            var newList = new CircleList<TSource>();
            foreach (var item in list0)
            {
                if (!newList.MyContains(item))
                {
                    newList.AddLast(item);
                }
            }
            foreach (var item in list1)
            {
                if (!newList.MyContains(item))
                {
                    newList.AddLast(item);
                }
            }

            return newList;
        }
    }
}