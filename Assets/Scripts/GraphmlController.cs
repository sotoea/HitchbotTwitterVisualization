using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;


namespace Topology
{

    public class GraphmlController : MonoBehaviour
    {

       // public DataContainer DC;
        public Node nodePrefab;
        public Link linkPrefab;

        private Hashtable nodes;
        private Hashtable links;
        private GUIText statusText;
        private int nodeCount = 0;
        private int linkCount = 0;
        private GUIText nodeCountText;
        private GUIText linkCountText;

        int x = 0;

        private string h1, h2, key, g, nodeS, nodeF, edgeS, edgeF;
        private string dNewsnodes, dSize, dr, dg, db, dx, dy, dSource, dTarget, dInteraction, dOriginalID, dNews, dWeight;
        private string original_id;

        //Method for loading the GraphML layout file
        private IEnumerator LoadLayout()
        {

            h1 = "<?xml";
            h2 = "<graphml";
            key = "<key";
            g = "<graph";

            nodeS = "<node id=";
            nodeF = "</node>";
            edgeS = "<edge source=";
            edgeF = "</edge>";

            dNewsnodes = "<data key=\"newsnodes\">";
            dSize = "<data key=\"size\">";
            dr = "<data key=\"r\">";
            dg = "<data key=\"g\">";
            db = "<data key=\"b\">";
            dx = "<data key=\"x\">";
            dy = "<data key=\"y\">";
            dSource = "<data key=\"source\">";
            dTarget = "<data key=\"target\"/>";
            dInteraction = "<data key=\"interaction type\">";
            dOriginalID = "<data key=\"original id\">";
            dNews = "<data key=\"news\">";
            dWeight = "<data key=\"weight\">";

            original_id = "<data key=\"original id\">";

            string sourceFile = Application.dataPath + "/Data/C.txt";
            statusText.text = "Loading file: " + sourceFile;

            //determine which platform to load for
//					string xml = null;
//					if(Application.isWebPlayer){
//							WWW www = new WWW (sourceFile);
//							yield return www;
//							xml = www.text;
//					}
//					else{
            statusText.text = "Loading Topology";
            StreamReader sr = new StreamReader(sourceFile);

            while (!sr.EndOfStream && x == 0)
            {
                
                string line = sr.ReadLine();

                if ("</graph>" == line)
                {
                    sr.ReadLine ();
                }

                else if (nodeS == line.Substring(0, nodeS.Length))
                {
                    //print("Node Start ");
                    Node nodeObj = Instantiate(nodePrefab);
                    nodeObj.id = line.Substring(nodeS.Length + 1, (line.Length - 2) - (nodeS.Length + 1));
                   // print(nodeObj.id);
                    line = sr.ReadLine();
                    nodeCount++;
                        nodeCountText.text = "Nodes: " + nodeCount;
                    while (nodeF != line.Substring(0, nodeF.Length))
                    {
                        if(dTarget == line)
                            line = sr.ReadLine ();

                        if (dr == line.Substring(0, dr.Length))
                        {
                            nodeObj.r = float.Parse(line.Substring(dr.Length, (line.Length - 7) - (dr.Length)));
                            //print("Red = " + line.Substring(dr.Length, (line.Length - 7) - (dr.Length)));
                        }
                        else if (dg == line.Substring(0, dg.Length))
                        {
                            nodeObj.g = float.Parse(line.Substring(dg.Length, (line.Length - 7) - (dg.Length)));
                            //print("Green = " + line.Substring(dg.Length, (line.Length - 7) - (dg.Length)));
                        }
                        else if (db == line.Substring(0, db.Length))
                        {
                            nodeObj.b = float.Parse(line.Substring(db.Length, (line.Length - 7) - (db.Length)));
                           // print("Blue = " + line.Substring(db.Length, (line.Length - 7) - (db.Length)));
                        }
                        else if (dx == line.Substring(0, dx.Length))
                        {
                            nodeObj.x = float.Parse(line.Substring(dx.Length, (line.Length - 7) - (dx.Length)));
                           // print("X = " + line.Substring(dx.Length, (line.Length - 7) - (dx.Length)));
                        }
                        else if (dy == line.Substring(0, dy.Length))
                        {
                            nodeObj.y = float.Parse(line.Substring(dy.Length, (line.Length - 7) - (dy.Length)));
                            //print("Y = " + line.Substring(dy.Length, (line.Length - 7) - (dy.Length)));
                        }
                        else if (dNews == line.Substring(0, dNews.Length))
                        {
                            if(line.Substring(dNews.Length, (line.Length - 7) - (dNews.Length)) == "yes" )
                                nodeObj.newsNode = true;
                            else
                                nodeObj.newsNode = false;
                            //print("News = " + line.Substring(dNews.Length, (line.Length - 7) - (dNews.Length)));
                        }
                        else if (dSize == line.Substring(0, dSize.Length))
                        {
                            nodeObj.size = float.Parse(line.Substring(dSize.Length, (line.Length - 7) - (dSize.Length)));
                            //print("Size = " + line.Substring(dSize.Length, (line.Length - 7) - (dSize.Length)));
                        }
                        else if (dSource == line.Substring(0, dSource.Length))
                        {
                            nodeObj.id = line.Substring(dSource.Length, (line.Length - 7) - (dSource.Length));
                            //print("Source = " + line.Substring(dSource.Length, (line.Length - 7) - (dSource.Length)));
                        }
                        else if (dNewsnodes == line.Substring(0, dNewsnodes.Length))
                        {
                            if(line.Substring(dNewsnodes.Length, (line.Length - 7) - (dNewsnodes.Length)) == "true")
                                nodeObj.newsNode = true;
                            else
                                nodeObj.newsNode = false;
                           // print("NewsNode = " + line.Substring(dNewsnodes.Length, (line.Length - 7) - (dNewsnodes.Length)));
                        }
                        //*else if (dInteraction == line.Substring(0, dInteraction.Length))
                        //*{
                        //*    nodeObj.interactionType = line.Substring(dInteraction.Length, (line.Length - 7) - (dInteraction.Length));
                        //*    //print("Interaction = " + line.Substring(dInteraction.Length, (line.Length - 7) - (dInteraction.Length)));
                        //*}

                        
                        line = sr.ReadLine();
                        statusText.text = "Loading Topology: Node " + nodeObj.id;
                    }
                    //GameObject n = nodeObj.gameObject;
                    //DC.nodes.Add(n);
                    //Destroy(nodeObj.gameObject);
                    //print("Node End");
            
                }
                else if (edgeS == line.Substring(0, edgeS.Length))
                {
                  
                    linkCount++;
                        linkCountText.text = "Edges: " + linkCount;
                    Link linkObj = Instantiate (linkPrefab);
                   // print("Edge Start");

                    char deliminator = '\"';
                    string[] data = line.Split (deliminator);

                    linkObj.id = data[1];
                    linkObj.source = GameObject.Find(data[1]).GetComponent <Node>();
                    Node temp = GameObject.Find(data[3]).GetComponent<Node>();
                    linkObj.target = temp;
                   // temp.children.Add(linkObj.source.transform);


                    statusText.text = "Loading Topology: Edge " + linkObj.id;
                    line = sr.ReadLine();
                    line = sr.ReadLine();
                    line = sr.ReadLine();
                   // print("Interaction = " + line.Substring(dInteraction.Length, (line.Length - 7) - (dInteraction.Length)));
                   // line =sr.ReadLine ();
                    //line =sr.ReadLine ();
                    if( dInteraction == line.Substring(0, dInteraction.Length))
                        linkObj.interactionType = line.Substring(dInteraction.Length, (line.Length - 7) - (dInteraction.Length));
                    line = sr.ReadLine();
                    line = sr.ReadLine();
                    if(line.Substring(dNews.Length, (line.Length - 7) - (dNews.Length)) == "yes"){
                        linkObj.news = true;
                    }else{
                        linkObj.news = false;
                    }
                   // print("News = " + line.Substring(dNews.Length, (line.Length - 7) - (dNews.Length)));
                    line = sr.ReadLine ();

                    if(edgeF == line.Substring(0, edgeF.Length))
                        print("Edge End");

                    }
                else if (h1 == line.Substring(0, h1.Length))
                {
                    print("Header 1");
                }
                else if (h2 == line.Substring(0, h2.Length))
                {
                    print("Header 2");
                }
                else if (key == line.Substring(0, key.Length))
                {
                    print("key");
                }
                else if (g == line.Substring(0, g.Length))
                {
                    print("g");
                }

                yield return null;

            }
            statusText.text = "";

            sr.Close();
            yield return true;
        }

        //Method for mapping links to nodes
        private void MapLinkNodes()
        {
            foreach (string key in links.Keys)
            {
                Link link = links[key] as Link;
                link.source = nodes[link.sourceId] as Node;
                link.target = nodes[link.targetId] as Node;
            }
        }

        void Start()
        {
            nodes = new Hashtable();
            links = new Hashtable();

            //initial stats
            nodeCountText = GameObject.Find("NodeCount").GetComponent<GUIText>();
            nodeCountText.text = "Nodes: 0";
            linkCountText = GameObject.Find("LinkCount").GetComponent<GUIText>();
            linkCountText.text = "Edges: 0";
            statusText = GameObject.Find("StatusText").GetComponent<GUIText>();
            statusText.text = "";

            StartCoroutine(LoadLayout());
        }

    }
}
