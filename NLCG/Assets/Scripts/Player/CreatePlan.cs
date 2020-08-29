using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlan : MonoBehaviour
{
    public GameObject plan;
    public GameObject listdat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject odat = Instantiate(plan, gameObject.transform.position, Quaternion.identity) as GameObject;
            odat.transform.SetParent(listdat.transform);
        }
    }
}
