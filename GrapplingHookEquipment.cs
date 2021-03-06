using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHookEquipment : MonoBehaviour
{

    public LineRenderer line;
    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask mask;
    public float step = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (joint.distance > 1f)
        
            joint.distance -= step;
        
        else
        {
            line.enabled = false;
            joint.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);

            if(hit.collider!= null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.connectedAnchor = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                joint.distance = Vector2.Distance(transform.position, hit.point);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
                line.GetComponent<roperatio>().grabPos = hit.point;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            joint.enabled = false;
            line.enabled = false;
        }
        if (Input.GetKey (KeyCode.Q))
        {
            line.SetPosition(0, transform.position);
        }
    }
}
