using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerClick : MonoBehaviour
{
    public LayerMask buttonMask = 7;
    UnityEvent onClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, buttonMask))
        {
            if(hit.collider.GetComponent<Button>() != false)
            {
                onClick = hit.collider.GetComponent<Button>().onClick;
                if(Input.GetMouseButtonDown(0))
                {
                    onClick.Invoke();
                }
            }
        }
    }
}
