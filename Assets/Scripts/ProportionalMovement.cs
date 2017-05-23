using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ProportionalMovement : MonoBehaviour {
    Vector3 prevPos;
    public int range = 100;
    public int factor = 500;
    public int proportional = 0;

    void Start(){
        prevPos = transform.position;
    }
	// Update is called once per frame
	void Update()
    {
        Collider[] c = Physics.OverlapSphere(transform.position, range);
        //if (prevPos == transform.position)
        //{
            foreach (Collider col in c)
            {
            //Debug.Log((Vector3.Distance(transform.position, col.transform.position)));
                col.transform.position += (transform.position - prevPos) * (factor*proportional)/(Vector3.Distance(transform.position, col.transform.position));
            }
        //}

        prevPos = transform.position;
	}
}
