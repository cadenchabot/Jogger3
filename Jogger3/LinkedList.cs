using System;

namespace Collections
{
    public class LinkedList <T>
    {
        // private properties below

        private int length;
        private Node<T> head;
        private Node<T> tail;

        // constructors below

        /// <summary>
        /// Constructs an empty list.
        /// </summary>        
        public LinkedList()
        {
            Finalize();
        }

        /// <summary>
        /// Creates a LinkedList from an array.
        /// </summary>
        /// <param name="array"></param> The array to use.
        public LinkedList(T[] array)
        {
            FromArray(array);
        }

        /// <summary>
        /// Creates a LinkedList from a LinkedList.
        /// </summary>
        /// <param name="list"></param> The LinkedList to use.
        public LinkedList(LinkedList<T> list)
        {
            FromLinkedList(list);
        }

        // public methods below

        /// <summary>
        /// Returns the length of the list.
        /// </summary>
        /// <returns></returns> The length of the list.
        public int Size()
        {
            return length;
        }

        /// <summary>
        /// Makes the list empty and removes all references.
        /// </summary>
        public void Finalize()
        {
            length = 0;
            head = tail = null;
        }

        /// <summary>
        /// Determines if the list is empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return length == 0;
        }

        /// <summary>
        /// Adds a node at the front of the list.
        /// </summary>
        /// <param name="data"></param> the data to add.
        public void AddFront(T data)
        {
            Node<T> node = new Node<T>(data);
            if (IsEmpty()) head = tail = node;
            else
            {
                head.previous = node;
                node.next = head;
                head = node;
            }
            length++;
        }

        /// <summary>
        /// Adds a node at the back of the list.
        /// </summary>
        /// <param name="data"></param> the data to add.
        public void AddBack(T data)
        {
            Node<T> node = new Node<T>(data);
            if (IsEmpty()) head = tail = node;
            else
            {
                tail.next = node;
                node.previous = tail;
                tail = node;
            }
            length++;
        }

        /// <summary>
        /// Gets the data from an index.
        /// </summary>
        /// <param name="index"></param> The index number.
        /// <returns></returns> The data.
        public T Get(int index)
        {
            if (!InRange(index)) return default(T);
            else return (T)GetNode(index).data;
        }

        /// <summary>
        /// Sets the data at an index.
        /// </summary>
        /// <param name="index"></param> The index number.
        /// <param name="data"></param> The data to add.
        /// <returns></returns> True or false.
        public bool Set(int index, T data)
        {
            Node<T> current = GetNode(index);
            if (current == null) return false;
            else
            {
                current.data = data;
                return true;
            }
        }

        /// <summary>
        /// Creates a string with the list.
        /// </summary>
        /// <returns></returns> The string.
        public override String ToString()
        {
            if (IsEmpty()) return "Empty list.";
            else
            {
                String text = "[";
                Node<T> current = head;
                while(current.next != null)
                {
                    text += current + ", ";
                    current = current.next;
                }
                return text + current + "]";
            }
        }

        /// <summary>
        /// Checks if two LinkedLists are equal.
        /// </summary>
        /// <param name="list"></param> The list to check against.
        /// <returns></returns> True or false.
        public bool Equals(LinkedList<T> list)
        {
            if (this.Size() != list.Size()) return false;
            Node<T> current1 = this.GetFirstNode();
            Node<T> current2 = this.GetLastNode();
            while (current1 != null)
            {
                if (!current1.Equals(current2)) return false;
                current1 = current1.next;
                current2 = current2.next;
            }
            return true;
        }

        /// <summary>
        /// Clones the LinkedList.
        /// </summary>
        /// <returns></returns> The cloned LinkedList.
        public LinkedList<T> Clone()
        {
            LinkedList<T> list = new LinkedList<T>();
            for (int i = 0; i < length; i++)
            {
                list.AddBack((T)this.GetNode(i).data);
            }
            return list;
        }

        /// <summary>
        /// Gets the front of the list.
        /// </summary>
        /// <returns></returns> The data.
        public T Front()
        {
            return Get(0);
        }

        /// <summary>
        /// Gets the back of the list.
        /// </summary>
        /// <returns></returns> The data.
        public T Back()
        {
            return Get(length - 1);
        }

        /// <summary>
        /// Removes and returns the front of the list.
        /// </summary>
        /// <returns></returns> The data.
        public T RemoveFront()
        {
            if (IsEmpty()) return default(T);
            else
            {
                T data = (T)head.data;
                if (length == 1) Finalize();
                else
                {
                    head = head.next;
                    head.previous.next = null;
                    head.previous = null;
                    length--;
                    System.GC.Collect();
                }
                return data;
            }
        }

        /// <summary>
        /// Removes and returns the front of the list.
        /// </summary>
        /// <returns></returns> The data.
        public T RemoveBack()
        {
            if (IsEmpty()) return default(T);
            else
            {
                T data = (T)tail.data;
                if (length == 1) Finalize();
                else
                {
                    tail = tail.previous;
                    tail.next.previous = null;
                    tail.next = null;
                    length--;
                    System.GC.Collect();
                }
                return data;
            }
        }

        /// <summary>
        /// Checks if the list contains a piece of data.
        /// </summary>
        /// <param name="data"></param> The data.
        /// <returns></returns> True or false.
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.data.Equals(data))
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        /// <summary>
        /// Adds to the list after an index number.
        /// </summary>
        /// <param name="data"></param> The data to add.
        /// <param name="index"></param> The index to add after.
        /// <returns></returns> True or false.
        public bool AddAfter(T data, int index)
        {
            if (!InRange(index)) return false;
            else
            {
                if (index == length - 1) AddBack(data);
                else
                {
                    Node<T> node = new Node<T>(data);
                    Node<T> current = GetNode(index);
                    node.next = current.next;
                    current.next.previous = node;
                    current.next = node;
                    node.previous = current;
                    length++;
                }
                return true;
            }
        }

        /// <summary>
        /// Adds to the list before an index number.
        /// </summary>
        /// <param name="data"></param> The data to add.
        /// <param name="index"></param> The index to add before.
        /// <returns></returns> True or false.
        public bool AddBefore(T data, int index)
        {
            if (!InRange(index)) return false;
            else
            {
                if (index == 0) AddFront(data);
                else
                {
                    Node<T> node          = new Node<T>(data);
                    Node<T> current       = GetNode(index);
                    node.previous         = current.previous;
                    current.previous.next = node;
                    current.previous      = node;
                    node.next             = current;
                    length++;
                }
                return true;
            }
        }

        /// <summary>
        /// Adds data to the back of the list.
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            AddBack(data);
        }

        /// <summary>
        /// Adds to the list before an index number.
        /// </summary>
        /// <param name="data"></param> The data to add.
        /// <param name="index"></param> The index to add before.
        /// <returns></returns> True or false.
        public bool Add(int index, T data)
        {
            return AddBefore(data, index);
        }

        /// <summary>
        /// Removes a node at a certain index number.
        /// </summary>
        /// <param name="index"></param> The index to remove.
        /// <returns></returns> The data removed.
        public T Remove(int index)
        {
            if (InRange(index))
            { 
                if (index == 0)               return RemoveFront();
                else if (index == length - 1) return RemoveBack();
                else
                {
                    Node<T> current = GetNode(index);
                    current.previous.next = current.next;
                    current.next.previous = current.previous;
                    current.next = current.previous = null;
                    length--;
                    T data = (T)current.data;
                    System.GC.Collect();
                    return data;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Finds the first index of a piece of data.
        /// </summary>
        /// <param name="data"></param> The data to search for.
        /// <returns></returns> The index number.
        public int FirstIndexOf(T data)
        {
            Node<T> current = head;
            int index = 0;
            while (current != null)
            {
                if (current.data.Equals(data))
                {
                    return index;
                }
                current = current.next;
                index++;
            }
            return -1;
        }

        /// <summary>
        /// Finds the last index of a piece of data.
        /// </summary>
        /// <param name="data"></param> The data to search for.
        /// <returns></returns> The index number.
        public int LastIndexOf(T data)
        {
            Node<T> current = tail;
            int index = length - 1;
            while (current != null)
            {
                if (current.data.Equals(data))
                {
                    return index;
                }
                current = current.previous;
                index--;
            }
            return -1;
        }

        /// <summary>
        /// Removes data from the list.
        /// </summary>
        /// <param name="data"></param> The data to remove.
        /// <returns></returns> True or false.
        public bool Remove(T data)
        {
            if (data == null) return false;
            int index = FirstIndexOf(data);
            if (index == -1) return false;
            Remove(index);
            return true;
        }

        /// <summary>
        /// Removes the last index of data from the list.
        /// </summary>
        /// <param name="data"></param> The data to remove.
        /// <returns></returns> True or false.
        public bool RemoveLast(T data)
        {
            if (data == null) return false;
            int index = LastIndexOf(data);
            if (index == -1) return false;
            Remove(index);
            return true;
        }

        /// <summary>
        /// Removes all instances of data from the list.
        /// </summary>
        /// <param name="data"></param> The data to remove.
        public void RemoveAll(T data)
        {
            while (Contains(data)) Remove(data);
        }

        /// <summary>
        /// Clears the list.
        /// </summary>
        public void Clear()
        {
            Node<T> current = head;
            while (current != null)
            {
                Node<T> next = current.next;
                current.Finalize();
                current = next;
            }
            Finalize();
        }

        /// <summary>
        /// Clears the list, retaining an array of items.
        /// </summary>
        /// <param name="items"></param> The items to retain.
        public void RetainAll(T[] items)
        {
            Clear();
            foreach (T item in items) Add(item);
        }

        /// <summary>
        /// Checks if a list contains an array of items.
        /// </summary>
        /// <param name="items"></param> The array of items.
        /// <returns></returns> True or false.
        public bool ContainsAll(T[] items)
        {
            if      (items == null)     return false;
            else if (items.Length == 0) return false;
            else
            {
                foreach (T item in items)
                {
                    if (!Contains(item)) return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Finds the number of times data is in the list.
        /// </summary>
        /// <param name="data"></param> The data.
        /// <returns></returns> The number of occurences.
        public int NumberOf(T data)
        {
            int counter = 0;
            Node<T> current = head;
            while (current != null)
            {
                if (current.data.Equals(data)) counter++;
                current = current.next;
            }
            return counter;
        }

        /// <summary>
        /// Adds a LinkedList to the list.
        /// </summary>
        /// <param name="list"></param> The LinekdList to add.
        public void AddAll(LinkedList<T> list)
        {
            for(int i = 0; i < list.Size(); i++)
            {
                this.Add((T)list.Get(i));
            }
        }

        /// <summary>
        /// Adds a LinkedList to the list after a certain index.
        /// </summary>
        /// <param name="list"></param> The LinekdList to add.
        /// <param name="index"></param> The index to add after.
        public void AddAll(LinkedList<T> list, int index)
        {
            for (int i = 0; i < list.Size(); i++)
            {
                this.AddAfter((T)list.Get(i), index);
                index++;
            }
        }

        /// <summary>
        /// Creates a sublist between two indices.
        /// </summary>
        /// <param name="from"></param> The starting index.
        /// <param name="to"></param> The ending index.
        /// <returns></returns> The sublist.
        public LinkedList<T> sublist (int from, int to)
        {
            if      (to < from)      return null;
            else if (!InRange(to))   return null;
            else if (!InRange(from)) return null;
            LinkedList<T> list = new LinkedList<T>();
            for (int i = from; i <= to; i++)
            {
                list.Add(this.Get(i));
            }
            return list;
        }

        /// <summary>
        /// Creates a LinkedList from an array.
        /// </summary>
        /// <param name="array"></param> The array.
        public void FromArray(T[] array)
        {
            Finalize();
            foreach (T t in array) Add(t);
        }

        /// <summary>
        /// Creates a LinkedList from another LinkedList.
        /// </summary>
        /// <param name="list"></param> The LinkedList.
        public void FromLinkedList(LinkedList<T> list)
        {
            Finalize();
            for (int i = 0; i < list.Size(); i++)
            {
                this.Add((T)list.Get(i));
            }
        }

        /// <summary>
        /// Creates an array from the LinkedList.
        /// </summary>
        /// <param name="array"></param> The array to fill.
        /// <returns></returns> The array.
        public T[] ToArray(T[] array)
        {
            array = (T[])Array.CreateInstance(array.GetType(), length);
            for (int i = 0; i < Size(); i++) array[i] = Get(i);
            return array;
        }

        /// <summary>
        /// Creates an array from the LinkedList.
        /// </summary>
        /// <returns></returns> The array.
        public T[] ToArray()
        {
            T[] array = new T[length];
            for (int i = 0; i < Size(); i++) array[i] = Get(i);
            return array;

        }

        /// <summary>
        /// Finds all indices of a piece of data.
        /// </summary>
        /// <param name="data"></param> The data.
        /// <returns></returns> An array of indices.
        public int[] AllIndices(T data)
        {
            int count = NumberOf(data);
            int[] indices = new int[count];
            int index = 0, i = 0;
            Node<T> current = head;
            while (current != null)
            {
                if (current.data.Equals(data))
                {
                    indices[index] = i;
                    index++;
                }
                current = current.next;
                i++;
            }
            return indices;
        }

        // protected methods below
        
        /// <summary>
        /// Gets the node at an index number.
        /// </summary>
        /// <param name="index"></param> The index number.
        /// <returns></returns> The node.
        protected Node<T> GetNode(int index) 
        {
            if      (!InRange(index))     return null;
            else if (index == 0)          return GetFirstNode();
            else if (index == length - 1) return GetLastNode();
            else
            {
                Node<T> current = head;
                for(int i = 0; i < index; i++)
                {
                    current = current.next;
                }
                return current; 
            }

        }

        /// <summary>
        /// Gets the last node in the list.
        /// </summary>
        /// <returns></returns> The node.
        protected Node<T> GetLastNode()
        {
            return tail;
        }

        /// <summary>
        /// Gets the first node in the list.
        /// </summary>
        /// <returns></returns> The node.
        protected Node<T> GetFirstNode()
        {
            return head;
        }

        /// <summary>
        /// Checks if the index number is in the list.
        /// </summary>
        /// <param name="index"></param> The index number.
        /// <returns></returns> True or false.
        private bool InRange(int index)
        {
            if (IsEmpty())            return false;
            else if (index < 0)       return false;
            else if (index >= length) return false;
            else                      return true;
        }
    }
}
