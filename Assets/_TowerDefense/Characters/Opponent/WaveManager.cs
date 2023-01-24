using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Enemy enem1;
    public Enemy enem2;
    public Enemy enem3;
    public Enemy enem4;

    [SerializeField] private float timeBetweenSpawnWave1 = 1f;
    [SerializeField] private float timeBetweenSpawnWave2 = 1f;
    [SerializeField] private float timeBetweenSpawnWave3 = 1f;

    //TO PARTICIPANTS:        Add any new enemies here
    //                        Attach the prefab to the object this script is attached to
    //                        You can then create instances of them the same way as the other enemies

    private int waveCount;

    // Start is called before the first frame update
    private void Start()
    {
    }


    public void StartWave()
    {
        waveCount++;

        switch (waveCount)
        {
            //TO PARTICIPANTS:          Add new cases and functions to create new waves.
            case 1:
                StartCoroutine(Wave1());
                break;
            case 2:
                StartCoroutine(Wave2());
                break;
            case 3:
                StartCoroutine(Wave3());
                break;
            default: //TO PARTICIPANTS:          This will trigger when you have no more waves set. Remove th
                StartCoroutine(DefaultWave());
                break;
        }
    }

    private IEnumerator Wave1()
    {
        //all basic enemies
        for (var i = 0; i < 25; i++)
        {
            var rand = Random.Range(-1, 3) * 2;
            print(rand);

            var newGuy = Instantiate(enem1.gameObject, new Vector2(8, rand), Quaternion.identity);
            newGuy.GetComponent<Enemy>().SetY(rand, rand);

            yield return new WaitForSeconds(timeBetweenSpawnWave1);
        }
    }

    private IEnumerator Wave2()
    {
        for (var i = 0; i < 20; i++)
        {
            var rand = Random.Range(-1, 2);
            print(rand);
            //basic, slow, fast
            Instantiate(enem1.gameObject, new Vector3(8, rand, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawnWave2);
            Instantiate(enem2.gameObject, new Vector3(8, rand, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawnWave2);
            Instantiate(enem3.gameObject, new Vector3(8, rand, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawnWave2);
        }
    }

    private IEnumerator Wave3()
    {
        for (var i = 0; i < 30; i++)
        {
            var rand = Random.Range(-1, 2);
            //most slow/fast, some basic
            Instantiate(enem2.gameObject, new Vector3(8, rand, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawnWave3);
            Instantiate(enem3.gameObject, new Vector3(8, rand, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawnWave3);
            Instantiate(enem2.gameObject, new Vector3(8, rand, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawnWave3);
            Instantiate(enem3.gameObject, new Vector3(8, rand, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawnWave3);
            Instantiate(enem1.gameObject, new Vector3(8, rand, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawnWave3);
        }
    }

    private IEnumerator DefaultWave()
    {
        for (var i = 0; i < 50; i++)
        {
            var rand = Random.Range(-1, 2);

            //most slow/fast, some basic
            Instantiate(enem1.gameObject, new Vector3(8, rand, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawnWave3);
            Instantiate(enem1.gameObject, new Vector3(8, rand, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawnWave3);
            Instantiate(enem4.gameObject, new Vector3(8, rand, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawnWave3);
        }
    }
}