using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // [SerializeField]
    // private Vector2 Origin;
    // [SerializeField]
    // private Vector2 Goal;
    //Maybe replace with node-based
    
    [SerializeField]private int startX = 2;   //start & goal locations 
    [SerializeField]private int startY = 2;

    [SerializeField]private int endX = -9;
    [SerializeField]private int endY = -9;

    [SerializeField]private float speed = 3.0f; //speed
    [SerializeField]private float damage = 20.0f;  //damage dealt to towers
    [SerializeField]private float attackspeed = 1.0f; //how quickly it attacks

    private Vector3 targetPosition;

    private bool moving = true;

    private bool rotation = false;



    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(startX, startY, -0.1f);
        targetPosition = new Vector3(endX, endY, -0.1f);
        
        StartCoroutine(Wiggle());
    }

    // Update is called once per frame
    void Update()
    {
        if(moving){
            //We need to make the thing move if its moving...
        }
        
    }

    IEnumerator Wiggle(){
        while(true){
            if(rotation){
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 30);
                rotation = !rotation;
            } else{
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -30);
                rotation = !rotation;
            }
        yield return new WaitForSeconds(0.5f);     //TODO: to make it look better, have a random offset once we get rng unfucked.
        }
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("collided");
        if(other.tag == "tower"){
            moving = false;
            ObjectHealth towerhealth = other.GetComponent<ObjectHealth>();
            StartCoroutine(AttackMode(other, towerhealth));
            
        }

    }

    public void YourHonor(){
        Debug.Log("League of Legends");
        Destroy(gameObject);              //Death
    }

    IEnumerator AttackMode(Collider other, ObjectHealth towerhealth){
        bool attacking = true;
        while(attacking){
            towerhealth.Attacked(damage);
            yield return new WaitForSeconds(attackspeed);
            if(other == null){
                attacking = false;
            }
        }
    }

    public void SetY(int origin, int goal)
    {
        startY = origin;
        endY = goal;    
    }

    //protected abstract void OnContact(); If I want to set this up so the mantis can teleport. low priority
}
