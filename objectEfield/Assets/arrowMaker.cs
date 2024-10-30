using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowMaker : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform parentT;
    private bool isGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initially do not create arrows
    }

    // Method called when the object is grabbed
    public void OnGrab()
    {
        if (!isGrabbed)
        {
            CreateArrows();
            isGrabbed = true; // Prevent multiple calls
        }
    }

    private void CreateArrows()
    {
        for (int i = 0; i < 360; i += 15) // This is phi
        {
            for (int j = 0; j < 180; j += 15) // This is theta
            {
                var arrow = Instantiate(arrowPrefab, parentT);
                Vector3 arrowDir = new Vector3(
                    Mathf.Sin(j * Mathf.Deg2Rad) * Mathf.Cos(i * Mathf.Deg2Rad),
                    Mathf.Sin(j * Mathf.Deg2Rad) * Mathf.Sin(i * Mathf.Deg2Rad),
                    Mathf.Cos(j * Mathf.Deg2Rad)
                );

                arrow.transform.Translate(0.1f * arrowDir);
                
                var arrow2 = Instantiate(arrowPrefab, parentT);
                arrow2.transform.Translate(0.4f * arrowDir);
                arrow2.transform.Rotate(Mathf.Sin(j * Mathf.Deg2Rad) * Mathf.Cos(i * Mathf.Deg2Rad), 
                                        Mathf.Sin(j * Mathf.Deg2Rad) * Mathf.Sin(i * Mathf.Deg2Rad), 
                                        Mathf.Cos(j * Mathf.Deg2Rad));
                arrow2.transform.localEulerAngles = new Vector3(
                    Mathf.Sin(j * Mathf.Deg2Rad) * Mathf.Cos(i * Mathf.Deg2Rad),
                    Mathf.Sin(j * Mathf.Deg2Rad) * Mathf.Sin(i * Mathf.Deg2Rad),
                    Mathf.Cos(j * Mathf.Deg2Rad)
                );

                arrow.transform.LookAt(parentT);
                arrow2.transform.LookAt(parentT);
            }
        }
    }

    // Called when the object is released
    public void OnRelease()
    {
        // Optional: handle behavior when released, if needed
        isGrabbed = false;
    }
}
