using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is the complex boxcaster made for scanning letters for the spelling game.
 * It relies on boxcasting a very thin block and order collisions by distance. 
 * */
public class Boxcaster : MonoBehaviour {

    private Vector3 size;
    private float maxDistance;
    public string content;
    public LayerMask m_LayerMask;

    private float width = 0.02f; // Want _really_ thin blocks for casting to increase accuracy.


	// Use this for initialization
	void Start () {
        maxDistance = gameObject.transform.localScale.z; // We want to cast in the Z-direction
        size = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, width);
	}
	
	// Update is called once per frame
	void Update () {
	
	// create the very thin sheet that will be used for casting.
        size = new Vector3(gameObject.transform.localScale.x/2, gameObject.transform.localScale.y/2, width);
        
	// Go along the entire 'Z' component of this object
	maxDistance = gameObject.transform.localScale.z;
        
	// Set the origin at the 'wall' of the box at it's "negative Z" direction
	Vector3 origin = gameObject.transform.position - (gameObject.transform.forward * maxDistance / 2);
        Vector3 direction = gameObject.transform.forward;

        size = size;
	
	// Do the raycast 
        RaycastHit[] hits = Physics.BoxCastAll(
            origin,
            size,
            direction,
            gameObject.transform.localRotation,
            maxDistance,
            m_LayerMask);
		
	// Sort along distance.
        System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

        string result = "";
        content = "";
        foreach (RaycastHit rhit in hits) { // Build a string of all letters in the objects hit by the raycast.
            ILetters[] letters = rhit.collider.gameObject.GetComponents<ILetters>();
            foreach (ILetters letter in letters) {
                result += " " + letter.GetLetters();
                content += letter.GetLetters();
            }
        }
        if (result.Length != 0)
            Debug.Log("Result = "+result);
    }



    private void OnDrawGizmos()
    {
	// This is some pretty crappy code duplication of the scanning done in Update()
	// This code illustrates the raycast for the editor.
        maxDistance = gameObject.transform.localScale.z;
        size = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, width);
        size = gameObject.transform.localRotation * size;

        Gizmos.color = Color.green;
        Vector3 origin = gameObject.transform.position;

        
        Vector3 size2 = this.size;

        origin -= gameObject.transform.forward * maxDistance / 2;

        Debug.DrawLine(origin, origin+gameObject.transform.forward*maxDistance);
        Gizmos.DrawCube(origin, size2);
        Gizmos.color = Color.red;
        Gizmos.DrawCube(origin + gameObject.transform.forward*maxDistance, size2);
    }
}
