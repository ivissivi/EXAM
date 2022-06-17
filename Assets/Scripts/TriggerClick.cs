using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerClick : MonoBehaviour
{
    public LayerMask buttonMask = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, buttonMask) && Input.GetMouseButtonDown(0))
        {
            if(hit.collider.GetComponent<Interac)
        }
    }
}
