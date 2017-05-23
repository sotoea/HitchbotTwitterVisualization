/*
 * Copyright 2014 Jason Graves (GodLikeMouse/Collaboradev)
 * http://www.collaboradev.com
 *
 * This file is part of Unity - Topology.
 *
 * Unity - Topology is free software: you can redistribute it 
 * and/or modify it under the terms of the GNU General Public 
 * License as published by the Free Software Foundation, either 
 * version 3 of the License, or (at your option) any later version.
 *
 * Unity - Topology is distributed in the hope that it will be useful, 
 * but WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with Unity - Topology. If not, see http://www.gnu.org/licenses/.
 */

using UnityEngine;
using System.Collections;

namespace Topology {

	public class Link : MonoBehaviour {

		public string id;
        public bool news;
		public Node source;
		public Node target;
		public string sourceId;
		public string targetId;
		public string status;
		public bool loaded = false;
        public string interactionType;

        bool newss = false;
        int type = 0;

       // private Material mat;

		private LineRenderer lineRenderer;

		void Start () {
            if(source == null){
                Destroy(GetComponent<LineRenderer>());
                Destroy(GetComponent<Link>());
            }
          //  mat = new Material(Shader.Find("Unlit/Color"));
            Invoke("Render", 0.2f);
            lineRenderer = GetComponent<LineRenderer>();

            Invoke("SetZ", 4);
		}

        void SetZ()
        {
            //transform.position = transform.position - Vector3.forward*Vector3.Distance(transform.position, GameObject.Find("@hitchbot").transform.position);// Vector3.forward*Mathf.Pow(Vector3.Distance(transform.position, GameObject.Find("@hitchbot").transform.position), 1.1f)/50;

            if(type == 1)
                transform.position = new Vector3(transform.position.x, transform.position.y, UnityEngine.Random.Range(-700, 700));
            else if(type == 2)
                transform.position = new Vector3(transform.position.x, transform.position.y, UnityEngine.Random.Range(-1500, -800));
            else if(type == 3)
                transform.position = new Vector3(transform.position.x, transform.position.y, UnityEngine.Random.Range(800, 1500));
        }

        void Render()
        {


            // lineRenderer = gameObject.AddComponent<LineRenderer>();
            Color c;
            if (newss)
            {
                if (source.news || source.newsNode)
                    c = Color.green;
                else
                    c = new Color(0.7f, 0.2f, 0.2f, 0.5f);
                c.a = 0.5f;
            }
            else
            {
                if (interactionType == "Retweet")
                {
                    c = Color.blue;
                    type = 1;
                }
                else if (interactionType == "Hashtag")
                {    
                    c = Color.red;
                    type = 2;
                }
                else if (interactionType == "Mention")
                {       
                    c = Color.yellow;
                    type = 3;
                }
                else
                    c = Color.gray;
                c.a = 0.5f;
            }

          //  mat.color = c;

            //GL.PushMatrix();
            //mat.SetPass(0);
            //GL.LoadIdentity();
            //GL.Begin(GL.LINES);
            //GL.Color(Color.red);
            //GL.Vertex(source.transform.position);
            //GL.Vertex(target.transform.position);
            //GL.End();
            //GL.PopMatrix();

            //draw line
            lineRenderer.material = new Material (Shader.Find("Unlit/Color"));
            lineRenderer.material.SetColor ("_Color", c);
            lineRenderer.SetWidth(0.5f, 0.5f);
            lineRenderer.SetVertexCount(2);
            lineRenderer.SetPosition(0, source.transform.position);
            lineRenderer.SetPosition(1, target.transform.position);
            //gameObject.GetComponent<Renderer>().material.color = c;
        }
		void Update()
        {
            lineRenderer.SetPosition(0, source.transform.position);
            lineRenderer.SetPosition(1, target.transform.position);
//
//            if (source && target && !loaded)
//            {
//                //draw links as full duplex, half in each direction
//                //Vector3 m = (target.transform.position - source.transform.position)/2 + source.transform.position;
//                lineRenderer.SetPosition(0, source.transform.position);
//                lineRenderer.SetPosition(1, target.transform.position);
//            
//
//                loaded = true;
//            }
            
        }
	}

}