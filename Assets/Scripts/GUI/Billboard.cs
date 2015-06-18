using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Billboard : MonoBehaviour
{
    public bool horizontal = false;
    public bool vertical = false;

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

	void LateUpdate ()
	{
        if (transform.rotation != initialRotation)
        {
            if (vertical && horizontal)
                transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
            if (vertical && !horizontal)
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            if (!vertical && horizontal)
                transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);

            if (!vertical && !horizontal)
                transform.rotation = initialRotation;
        }
	}
}
