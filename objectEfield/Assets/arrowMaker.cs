using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowMaker : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform parentT;

    // Start is called before the first frame update
    void Start()
    {
        int arrowCount = 10; // Number of additional arrows
        float baseDistance = 0.4f; // Starting distance
        float distanceIncrement = 0.30f; // Distance increment for each set of arrows

        for (int i = 0; i < 360; i += 15) // This is phi
        {
            for (int j = 0; j < 180; j += 15) // This is theta
            {
                // Create arrows at increasing distances
                for (int k = 0; k < arrowCount; k++)
                {
                    float currentDistance = baseDistance + k * distanceIncrement;
                    var arrow = Instantiate<GameObject>(arrowPrefab, parentT);
                    Vector3 arrowDir = new Vector3(Mathf.Sin(j * Mathf.Deg2Rad) * Mathf.Cos(i * Mathf.Deg2Rad),
                                                    Mathf.Sin(j * Mathf.Deg2Rad) * Mathf.Sin(i * Mathf.Deg2Rad),
                                                    Mathf.Cos(j * Mathf.Deg2Rad));
                    arrow.transform.Translate(currentDistance * arrowDir);

                    // Rotate the arrow to face the center
                    arrow.transform.LookAt(parentT);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
