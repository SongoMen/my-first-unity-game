using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{

    public float rotateSpeed = 2.0f;

    private bool rotating;

    void Update()
    {
        StartCoroutine(TurnTowards(-transform.forward));
    }

    IEnumerator TurnTowards(Vector3 lookAtTarget)
    {

        if (rotating == false)
        {

            Quaternion newRotation = Quaternion.LookRotation(lookAtTarget - transform.position);
            newRotation.x = 0;
            newRotation.z = 0;

            for (float u = 0.0f; u <= 1.0f; u += Time.deltaTime * rotateSpeed)
            {
                rotating = true;
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, u);

                yield return null;
            }
            rotating = false;
        }
    }
}