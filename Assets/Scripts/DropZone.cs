using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour {
    public LayerMask m_LayerMask;

    public SumListener listener;

    private int sum = 0;

    void Start()
    {

    }

    void FixedUpdate()
    {
        MyCollisions();
    }

    void MyCollisions()
    {
        // Use the OverlapBox to detect if there are any other colliders within this box area.
        // Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        int i = 0;
        // Check when there is a new collider coming into contact with the box
         int s = 0;
        while (i < hitColliders.Length)
        {
			foreach (iValue vs in hitColliders[i].gameObject.GetComponents(typeof(iValue))) {
                s += vs.GetValue();
			}
            i++;
        }
        if (s != sum) {
                int old = sum;
                sum = s;
                if (listener != null) {
                    listener.OnSumChanged(old, sum);
                } else {
                    Debug.Log("Sum changed from "+old+" to "+sum+", but no listener was set.");
                }
            }
    }

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
