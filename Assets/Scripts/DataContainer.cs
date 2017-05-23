using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContainer : MonoBehaviour {

    public List<GameObject> nodes = new List<GameObject>();
    public List<GameObject> edges = new List<GameObject>();

    struct nodeStruct{
        public string id;
        public TextMesh nodeText;
        public float x, y, r, g, b, size;
        public bool news, newsNode;
        public string interactionType;
    }

    struct edgeStruct{

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
