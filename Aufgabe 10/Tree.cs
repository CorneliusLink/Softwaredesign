using System;
using System.Collections.Generic;
using System.Globalization;

namespace Aufgabe_10
{
    public class Tree<T>
    {
        public T Data;
        public List<Tree<T>> children = new List<Tree<T>>();
        public Tree<T> CreateNode(T _Data)
        {
            Tree<T> node = new Tree<T>
            {
                Data = _Data
            };
            return node;
        }
        public void AppendChild(Tree<T> child)
        {
            children.Add(child);
        }
        public void RemoveChild(Tree<T> child)
        {
            children.Remove(child);
        }
        public void PrintTree(String order = "")
        {
            Console.WriteLine(order + Data);
            foreach (Tree<T> child in children)
            {
                child.PrintTree(order + "*");
            }
        }
    }
}