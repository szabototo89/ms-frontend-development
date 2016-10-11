using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace TreeTraversal
{
    // immutable object
    // template<typename TValue = int>
    public abstract class Node<TValue>
    {
        public TValue Value { get; }

        public IEnumerable<Node<TValue>> Children { get; }

        protected Node(TValue value, IEnumerable<Node<TValue>> children = null)
        {
            Value = value;
            Children = children ?? Enumerable.Empty<Node<TValue>>();
        }

        public virtual IEnumerable<Node<TValue>> GetAllChildren()
        {
            return null;
        }
    }

    public class IntNode : Node<Int32>
    {
        public IntNode(Int32 value, IEnumerable<Node<Int32>> children = null) : base(value, children)
        {
        }

        // legacy
        public sealed override IEnumerable<Node<Int32>> GetAllChildren()
        {
            // base.GetAllChildren()
            throw new NotImplementedException();
        }
    }

    public static class NodeExtensions
    {
        // overloading
        public static Int32 Sum(this Node<Int32> node)
        {
            return Sum(node, (x, y) => x + y.Value);
        }

        // Func<> - returns value
        // Action<T1, T2> - return type: void
        public static TValue Sum<TValue>(this Node<TValue> node, Func<TValue, Node<TValue>, TValue> add)
        {
            // guard close / Martin Fowler
            if (node == null) throw new ArgumentNullException(nameof(node));

            var sum = node.Value;

            foreach (var child in node.Children)
            {
                sum = add(sum, child);
            }

            return sum;
        }
    }
}
