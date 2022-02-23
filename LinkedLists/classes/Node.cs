namespace LinkedLists.classes
{
    public class Node
    {
        /* Constructor
         * - Node(object nodeData, Node nextNode)
         * 
         * Private fields
         * - object nodeData: contains the data of the node, that you want to store in the list
         * - Node nextNode: reference to the next node
         * 
         * Public properties
         * - NodeData: get/set the nodeData field
         * - NextNode: get/set the nextNode field
         */

        private object nodeData;
        private Node nextNode;

        // Constructor
        public Node(object nodeData, Node nextNode)
        {
            this.nodeData = nodeData;
            this.nextNode = nextNode;
        }

        public object NodeData
        {
            get { return this.nodeData; }
            set { this.nodeData = value; }
        }

        public Node NextNode
        {
            get { return this.nextNode; }
            set { this.nextNode = value; }
        }
    }
}
