using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame2 : MonoBehaviour {

    [SerializeField]
    float timer;
    public float counter;
    int deadFlowers;

    [SerializeField]
    GameObject weed;

    GameObject[] weedLocations;

    List<int> takenNumbers;

    // Use this for initialization
    void Start()
    {
        takenNumbers = new List<int>();
        weedLocations = GameObject.FindGameObjectsWithTag("WeedLocation");
        counter = timer;
        deadFlowers = 0;
        for (int i = 0; i < weedLocations.Length; i++)
        {

            int rnd = Random.Range(0, weedLocations.Length);

            //GameObject weedloc = weedLocations[rnd];
            if(!takenNumbers.Contains(rnd))
            {
                Instantiate(weed, new Vector3(weedLocations[rnd].transform.position.x, weedLocations[rnd].transform.position.y, weedLocations[rnd].transform.position.z), Quaternion.identity);
            }
            else
            {
                print("yolo");
                i--;
            }
            takenNumbers.Add(rnd);
        }
        takenNumbers.Clear();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (counter >= 0)
            counter -= Time.deltaTime;

        if (deadFlowers < 5 && counter <= 0)
        {
            Win();
        }
            
    }

    void Win ()
    {
        print(deadFlowers + " " + "We live to fight another day");
    }

    public void DeadFlower()
    {
        deadFlowers++;
        if (deadFlowers == 5)
            print(deadFlowers + " " + "WE FUCKING LOST");
    }
}
