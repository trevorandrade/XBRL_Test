using System.IO;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeffFerguson.Gepsio;
using System;
//using log4net;
//using log4net.Config;
using System.Diagnostics;

namespace XBRL_test
{
	class Program
	{
  //      private static ILog _log;
        private static StreamWriter sw2 = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "blah"));
    //    private static ILog log
        //{
        //    get
        //    {
        //        if (_log == null)
        //        {
        //            _log = LogManager.GetLogger(typeof(Program));
        //            string path = Path.Combine(Directory.GetCurrentDirectory(),"log.config");
        //            XmlConfigurator.Configure(new System.IO.FileInfo(path));
        //            return _log;
        //        }
        //        else return _log;
        //    }
        //} 

		static void Main(string[] args)
		{
			XbrlDocument Doc = new XbrlDocument();
			try
			{
				Doc.Load("https://www.sec.gov/Archives/edgar/data/789019/000119312516742796/msft-20160930.xml");
				using (StreamWriter sw = new StreamWriter(@"C:\Users\Trevor\Desktop\blah.txt"))
				{
                   // var d = Doc.XbrlFragments[0].GetPresentableFactTree();
                  //  WalkPresentableTree(d);
                   // var q = from i in d.TopLevelNodes
                          //  select i.NodeLabel;
                    //q.ToList().ForEach(i => Console.WriteLine(i.ToString()));
                    var d = Doc.XbrlFragments[0];
					foreach (Fact f in d.Facts)
					{
						System.Console.WriteLine($"{f.Name}");

						sw.WriteLine($"{f.Name}");
					}
				}
			}
			catch (Exception e)
			{
				System.Console.WriteLine(e.Message);
			}
		}

        //public static void WalkPresentableTree(PresentableFactTree tree)
        //{
        //    foreach (var currentNode in tree.TopLevelNodes)
        //        WalkPresentableTreeNode(currentNode, 0);
        //    sw2.Close();
        //}

        //private static void WalkPresentableTreeNode(PresentableFactTreeNode node, int depth)
        //{

        //    // Indent as necessary, according to depth, so that parent child relationships
        //    // are shown.
        //    for (var indent = 0; indent < depth; indent++)
        //        sw2.Write("    ");

        //    // If the tree node has a fact, then display it.
        //    if (node.NodeFact != null)
        //    {

        //        // Display item details, if this fact is actually an item.
        //        // Tuples are not supported in this code sample.
        //        if (node.NodeFact is Item)
        //        {
        //            var nodeItem = node.NodeFact as Item;
        //            sw2.Write(nodeItem.Name);
        //            sw2.Write(" ");
        //            sw2.Write(nodeItem.Value);
        //        }
        //    }
        //    else
        //    {

        //        // If there is no fact for this node, then display the label.
        //        sw2.Write(node.NodeLabel);
        //    }
        //    sw2.WriteLine("");

        //    // Recursively call into this same method for each of the node's
        //    // child nodes, increasing the depth by one so that the indenting
        //    // reflects the child nodes.
        //    foreach (var childNode in node.ChildNodes)
        //        WalkPresentableTreeNode(childNode, depth + 1);
        //}
    }
}
