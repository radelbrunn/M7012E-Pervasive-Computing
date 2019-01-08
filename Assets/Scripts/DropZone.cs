using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour {
    public LayerMask m_LayerMask; // Allows filtering collisions on layers. Set the appropriate layers in the unity editor. 

    public SumListener listener; // The listener of sum changed. Public so it may be set from the editor. 

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
        // Create overlap box around the center of the object. It should have the sides of the scale of the object.
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        int i = 0;
        // Check when there is a new collider coming into contact with the box
         int s = 0;
        while (i < hitColliders.Length) // Check each and every collider
        { // Iterate only over those implementing iValue. This is to avoid scanning the Players hands.
			foreach (iValue vs in hitColliders[i].gameObject.GetComponents(typeof(iValue))) {
                s += vs.GetValue(); // Sum up all values from objects in the area. 
			}
            i++;
        }
        if (s != sum) { // Only updates the listener if there has been a change of sum.
                int old = sum;
                sum = s;
                if (listener != null) {
                    listener.OnSumChanged(old, sum);
                } else {
                    Debug.Log("Sum changed from "+old+" to "+sum+", but no listener was set.");
                }
            }
    }

    // Use gizmos to allow viewing the bounds of the drop zone in scene mode, while remaining hidden in play mode.
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
