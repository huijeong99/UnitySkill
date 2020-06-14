using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    Rigidbody m_myRigid = null;

    private void OnEnable()
    {
        if (m_myRigid == null)
        {
            m_myRigid = GetComponent<Rigidbody>();
        }

        m_myRigid.velocity = Vector3.zero;
        m_myRigid.AddExplosionForce(1000, transform.position, 1f);

        StartCoroutine(DestroyCube());
    }

    IEnumerator DestroyCube()
    {
        yield return new WaitForSeconds(1f);
        ObjectPoolingManager.instance.InsertQueue(gameObject);
    }
}
