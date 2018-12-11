using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame2 : MonoBehaviour {

    [SerializeField]
    float timer;
    public float counter;
    int deadFlowers;

    [SerializeField]
    GameObject weed1;
    [SerializeField]
    GameObject weed2;
    [SerializeField]
    GameObject weed3;
    [SerializeField]
    GameObject weed4;
    [SerializeField]
    GameObject weed5;

    [SerializeField]
    GameObject weedlocation1;
    [SerializeField]
    GameObject weedlocation2;
    [SerializeField]
    GameObject weedlocation3;
    [SerializeField]
    GameObject weedlocation4;
    [SerializeField]
    GameObject weedlocation5;



    // Use this for initialization
    void Start ()
    {
        counter = timer;
        deadFlowers = 0;
        Instantiate(weed1, new Vector3(weedlocation1.transform.position.x, weedlocation1.transform.position.y, weedlocation1.transform.position.z), Quaternion.identity);
        Instantiate(weed2, new Vector3(), Quaternion.identity);
        Instantiate(weed3, new Vector3(), Quaternion.identity);
        Instantiate(weed4, new Vector3(), Quaternion.identity);
        Instantiate(weed5, new Vector3(), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update ()
    {
        counter -= Time.deltaTime;
    }

    public void DeadFlower()
    {
        deadFlowers++;
        if (deadFlowers == 5)
            print(deadFlowers + " " + "WE FUCKING LOST");
    }
}
