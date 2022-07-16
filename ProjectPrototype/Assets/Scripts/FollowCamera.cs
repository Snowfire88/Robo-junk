using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        transform.position = new Vector3(510, 1, player.position.z);
    }
}
