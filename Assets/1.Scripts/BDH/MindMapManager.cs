using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections.Generic;

namespace MindMapManager
{
    // 마인드맵을 관리하고 조작하는 클래스
    public class MindMapRoot
    {
        public MindMapNode Root { get; private set; }

        public MindMapRoot()
        {
            Root = new MindMapNode("Root");
        }

        // 새로운 노드를 추가하는 메서드
        public MindMapNode AddNode(MindMapNode parent, string text)
        {
            MindMapNode newNode = new MindMapNode(text);
            parent.Children.Add(newNode);
            return newNode;
        }

        // 노드를 제거하는 메서드
        public void RemoveNode(MindMapNode parent, MindMapNode nodeToRemove)
        {
            parent.Children.Remove(nodeToRemove);
        }

        // 마인드맵을 텍스트로 출력하는 메서드 (재귀적으로 호출됨)
        private void PrintNode(MindMapNode node, string indent = "")
        {
            Console.WriteLine(indent + node.Text);
            foreach (var child in node.Children)
            {
                PrintNode(child, indent + "  ");
            }
        }

        // 전체 마인드맵을 출력하는 메서드
        public void PrintMindMap()
        {
            PrintNode(Root);
        }

    }

    // 마인드맵의 각 노드를 나타내는 클래스
    public class MindMapNode
    {
        
        private string text;
        private Image image;

        public string Text { get; set; }
        public List<MindMapNode> Children { get; set; }

        public MindMapNode(string text)
        {
            Text = text;
            Children = new List<MindMapNode>();
        }
    }

}