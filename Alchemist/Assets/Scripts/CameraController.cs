using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void Shake()
    {
        StopAllCoroutines();
        StartCoroutine(ShakeCamera());
    }

    private IEnumerator ShakeCamera()
    {
        transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(.1f);
        transform.position = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(.1f);
        transform.position = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(.1f);
        transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(.1f);
        transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(.1f);
        transform.position = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(.1f);
        transform.position = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(.1f);
        transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
    }
}
