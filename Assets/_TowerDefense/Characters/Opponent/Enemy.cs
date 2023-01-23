using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private int startX = 2;
    [SerializeField]private int startY = 2;

    [SerializeField]private int endX = -9;
    [SerializeField]private int endY = -9;

    [SerializeField]private float speed = 3.0f;

    private Vector3 targetPosition;



    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(startX, startY, -0.1f);
        targetPosition = new Vector3(endX, endY, -0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        float deltaSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, deltaSpeed);
        //Give it two points, let it move from point A to B
        //Make it so when it gets close to a tower, the tower is attacked
        //Harm will be controlled thru ObjectHealth.cs
        //Having just one enemy is OK for now, but I'm gonna make at least like... 3 towers :)
        transform.Translate(Vector3.left * Time.deltaTime);
    }
}
