namespace LinkedLists.classes
{
    class LinkedList
    {
        /* Constructor
         * - LinkedList() - initializes the private fields
         * 
         * Private fields
         * - Node headNode: reference to the first node in the list
         * - int length: length of list
         * 
         * Public properties
         * - Empty: if list is empty
         * - Count: return length of list
         * - Indexer: access data like an array
         * 
         * Methods
         * - Add(int index, object o): add item to the list at specified index
         * - Add(object o): add item to the end of the list
         * - Remove(int index): remove item from list at specified index
         * - Clear(): clear the list
         * - IndexOf(object o): gets the index of item in the list, if not in list, return -1
         * - Contains(object o): returns true of false if the list contains object
         * - Get(int index): gets item at specified index
         */

        private Node headNode;
        private int length;

        // Constructor
        public LinkedList()
        {
            headNode = null;
            length = 0;
        }

        public bool Empty
        {
            get { return length == 0; }
        }

        public int Count
        {
            get { return length; }
        }

        public object Add(int index, object o)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index: " + index);

            if (index > length)
                index = length;

            Node current = headNode;

            if (Empty || index == 0)
            {
                headNode = new Node(o, headNode);
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                    current = current.NextNode;

                current.NextNode = new Node(o, current.NextNode);
            }
            length++;
            return o;
        }

        public object Add(object o)
        {
            return Add(length, o);
        }

        public object Remove(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index: " + index);

            if (Empty)
                return null;

            if (index >= length)
                index -= length;

            Node current = headNode;
            object result = null;

            if (index == 0)
            {
                result = current.NodeData;
                headNode = current.NextNode;
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                    current = current.NextNode;
                result = current.NextNode.NodeData;
                current.NextNode = current.NextNode.NextNode;
            }
            length--;
            return result;
        }

        public void Clear()
        {
            headNode = null;
            length = 0;
        }

        public int IndexOf(object o)
        {
            Node current = headNode;
            for (int i = 0; i < length; i++)
            {
                if (current.NodeData.Equals(o))
                    return i;

                current = current.NextNode;
            }
            return -1;
        }

        public bool Contains(object o)
        {
            return IndexOf(o) >= 0;
        }

        public object Get(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index: " + index);

            if (Empty)
                return null;

            if (index >= length)
                index = length - 1;

            Node current = headNode;

            for (int i = 0; i < index; i++)
                current = current.NextNode;

            return current.NodeData;
        }

        public object this[int index]
        {
            get { return Get(index); }
        }

        public void PrintList()
        {
            Node looper = headNode;
            while (looper != null)
            {
                Console.WriteLine(looper.NodeData);
                looper = looper.NextNode;
            }
        }
    }
}
