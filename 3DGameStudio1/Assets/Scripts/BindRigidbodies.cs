using UnityEngine;
using System.Collections;

public class BindRigidbodies : MonoBehaviour {

    public LayerMask rigidbodyLayer;
    public float breakForce = Mathf.Infinity;
    public float breakTorque = Mathf.Infinity;

	void Awake()
    {
        var colliders = Physics.OverlapSphere(transform.position, transform.localScale.x / 2, rigidbodyLayer.value);

        for (int i = 0; i < colliders.Length-1; i++)
        {
            FixedJoint joint = colliders[i].gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = colliders[i + 1].gameObject.GetComponent<Rigidbody>();
            joint.breakForce = breakForce;
            joint.breakTorque = breakTorque;
        }


        Destroy(gameObject);
    }
}
