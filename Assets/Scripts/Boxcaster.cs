using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxcaster : MonoBehaviour {

    private Vector3 size;
    private float maxDistance;
    public string content;
    public LayerMask m_LayerMask;

    private float width = 0.02f;


	// Use this for initialization
	void Start () {
        maxDistance = gameObject.transform.localScale.z;
        size = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, width);
	}
	
	// Update is called once per frame
	void Update () {
        size = new Vector3(gameObject.transform.localScale.x/2, gameObject.transform.localScale.y/2, width);
        maxDistance = gameObject.transform.localScale.z;
        Vector3 origin = gameObject.transform.position - (gameObject.transform.forward * maxDistance / 2);
        Vector3 direction = gameObject.transform.forward;

        size = size;

        RaycastHit[] hits = Physics.BoxCastAll(
            origin,
            size,
            direction,
            gameObject.transform.localRotation,
            maxDistance,
            m_LayerMask);

        System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

        string result = "";
        content = "";
        foreach (RaycastHit rhit in hits) {
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
