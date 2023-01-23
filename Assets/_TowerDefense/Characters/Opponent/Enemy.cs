using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Give it two points, let it move from point A to B
        //Make it so when it gets close to a tower, the tower is attacked
        //Harm will be controlled thru ObjectHealth.cs
        //Having just one enemy is OK for now, but I'm gonna make at least like... 3 towers :)
        transform.Translate(Vector3.left * Time.deltaTime);
    }
}
