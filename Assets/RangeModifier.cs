using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RangeModifier : MonoBehaviour
{
    public Transform enemyPos;
    public float distance;
    public float Radius;
    public GameObject UI;
    public float Raycastlength;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position,enemyPos.position);
        if (distance <= Radius)
        {
            transform.LookAt(enemyPos.position);
        }

        if (distance <= 0.5f)
        {
            UI.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit,Raycastlength,layer))
        {
            Debug.Log("Wall Detected");
        }
        else
        {
            Debug.Log("No Wall Detected");
        }
        Debug.DrawRay(transform.position,transform.forward * Raycastlength, Color.red);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,Radius);
    }
}
