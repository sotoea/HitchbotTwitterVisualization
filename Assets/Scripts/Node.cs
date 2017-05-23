using UnityEngine;
using System.Collections;
//using NUnit.Framework;
using System.Collections.Generic;
using System;


namespace Topology {

	public class Node : MonoBehaviour {

		public string id;
        public string original_id;
		public TextMesh nodeText;
        public float x, y, r, g, b, size;
        public bool news, newsNode;
        public string interactionType;
        public Material neaw;
        public Material notnews;

        //public List<Transform> children;

        void Start(){
            
            Invoke("SetPos", 2);
            Invoke("SetZ", 4);
           // Invoke("SetZAgain", 5.5f);
        }

		void Update () {
			//node text always facing camera
			nodeText.transform.LookAt (Camera.main.transform);
		}

        void SetZ()
        {
            //transform.position = transform.position - Vector3.forward*Vector3.Distance(transform.position, GameObject.Find("@hitchbot").transform.position);// Vector3.forward*Mathf.Pow(Vector3.Distance(transform.position, GameObject.Find("@hitchbot").transform.position), 1.1f)/50;

            transform.position = new Vector3(transform.position.x, transform.position.y, UnityEngine.Random.Range(-1500, 500));
        }

        void SetZAgain()
        {
            if (transform.position.z != 0)
            {
                if(transform.position.x <0)
                    transform.position = new Vector3(transform.position.x + Mathf.Pow(8000/transform.position.z/4,2), transform.position.y, transform.position.z);
                else
                    transform.position = new Vector3(transform.position.x - Mathf.Pow(8000/transform.position.z/4,2), transform.position.y, transform.position.z);
            }
        }

        void SetPos(){
            name = id;
            transform.position = new Vector3(x*6, y*6, 0);
           // Vector3 c = new Vector3(r, g, b).normalized;
            transform.localScale = new Vector3(size, size, size);
           // GetComponent<Renderer>().material.color = new Color(c.x, c.y, c.z);
//            if(newsNode || news){
//                GetComponent<Renderer>().material = notnews;
//            }else{
//                GetComponent<Renderer>().material = neaw;
//            }
            nodeText.text = id;
            nodeText.fontSize += 2;
            //nodeText.gameObject.SetActive(false);

        }
	}

}