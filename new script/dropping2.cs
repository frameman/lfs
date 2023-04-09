using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropping2 : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject spawnOnTopOf;
    public PhysicMaterial cubePhysicMaterial;
    public actives Act;
    public int m_sec = 5;
    public bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Act.moveTo5){
            print("flag= "+flag);
        
            if(flag)
            {
                print("dropfood");
                Vector3 spawnPos = spawnOnTopOf.transform.position + new Vector3(0f, spawnOnTopOf.transform.localScale.y * 0.5f + 50f, 0f);

                for (int i = 0; i < 10; i++)
                {   
                    Vector3 pos = spawnPos + new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
                    Quaternion rot = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
                    GameObject cube = Instantiate(cubePrefab, pos, rot);
                    //cube.GetComponent<Collider>().material = cubePhysicMaterial; 
                    //cube.GetComponent<Rigidbody>().AddForce(Vector3.down * 10f, ForceMode.Impulse);
                }
                
                StartCoroutine(DelayedMovement5());
            }
            else{
                print("in");
            }
        }
    }
    IEnumerator DelayedMovement5()
    {
        flag = false;
        yield return new WaitForSeconds(5f);
        flag = true;
        
    }
}
