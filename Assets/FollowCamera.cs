using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    [SerializeField] Vector3 cameraDistance = new Vector3 (0,0,-10);

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + cameraDistance;
    }
}
