using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
        public GameObject enem1;
        public GameObject enem2;
        public GameObject enem3;
        public GameObject enem4;
        //TO PARTICIPANTS:        Add any new enemies here
        //                        Attach the prefab to the object this script is attached to
        //                        You can then create instances of them the same way as the other enemies

        private int waveCount = 0;
        private static System.Random rng;

    // Start is called before the first frame update
    void Start()
    {
        rng = new System.Random();
    }


    public void StartWave(){
        waveCount++;

        switch(waveCount){                  //TO PARTICIPANTS:          Add new cases and functions to create new waves.
            case 1:
                StartCoroutine(Wave1(rng));
                break;
            case 2:
                StartCoroutine(Wave2(rng));
                break;
            case 3:
                StartCoroutine(Wave3(rng));
                break;
            default:                       //TO PARTICIPANTS:          This will trigger when you have no more waves set. Remove th
                StartCoroutine(DefaultWave(rng));
                break;

        }
    }

    IEnumerator Wave1(System.Random rng){
        //all basic enemies
        for (int i = 0; i < 25; i++){             //I know that creating a new random in a for loop will cause all of the number to be the same
            //int r1 = rng.Next();                   //Everything I look at says that passing a static Random and using .Next should solve the problem.
                                                    //It does literally nothing.
            Instantiate(enem1, new Vector3(8, rng.Next(0,3)*2, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Wave2(System.Random rng){
        for (int i = 0; i < 20; i++){
            //basic, slow, fast
            Instantiate(enem1, new Vector3(8, rng.Next(0,3)*2, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
            Instantiate(enem2, new Vector3(8, rng.Next(0,3)*2, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
            Instantiate(enem3, new Vector3(8, rng.Next(0,3)*2, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
        }
        
    }

    IEnumerator Wave3(System.Random rng){
        for (int i = 0; i < 30; i++){
            //most slow/fast, some basic
            Instantiate(enem2, new Vector3(8, rng.Next(0,3)*2, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
            Instantiate(enem3, new Vector3(8, rng.Next(0,3)*2, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
            Instantiate(enem2, new Vector3(8, rng.Next(0,3)*2, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
            Instantiate(enem3, new Vector3(8, rng.Next(0,3)*2, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
            Instantiate(enem1, new Vector3(8, rng.Next(0,3)*2, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator DefaultWave(System.Random rng){
        for (int i = 0; i < 50; i++){
            //most slow/fast, some basic
            Instantiate(enem1, new Vector3(8, rng.Next(0,3)*2, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
            Instantiate(enem1, new Vector3(8, rng.Next(0,3)*2, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
            Instantiate(enem4, new Vector3(8, rng.Next(0,3)*2, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
