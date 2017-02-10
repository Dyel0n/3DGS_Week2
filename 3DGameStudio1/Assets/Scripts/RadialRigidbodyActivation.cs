using UnityEngine;
using System.Collections;

public class RadialRigidbodyActivation : MonoBehaviour {

    public LayerMask activationLayer;
    public float range = 5;
    public float speed = 5;

    void OnEnable()
    {
        var colliders = Physics.OverlapSphere(transform.position, range, activationLayer.value);

        foreach(Collider c in colliders)
        {
            //print(c.gameObject.name)
            //c.gameObject.GetComponent<Rigidbody>().isKinematic = false; OLD
            var rb = c.gameObject.GetComponent<Rigidbody>();
            var distance = Vector3.Distance(transform.position, c.gameObject.transform.position);
            StartCoroutine(ActivateRigidbody(rb, distance / speed));

        }
    }


    IEnumerator ActivateRigidbody(Rigidbody rb, float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.isKinematic = false;
    }
}
