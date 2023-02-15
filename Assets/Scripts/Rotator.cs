using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public enum RotateDirection
    {
        CLOCKWIZE = -1, ANTI_CLOCEWISE = 1
    }

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private RotateDirection _rotateDirection;

    private void Start()
    {
        // change direction randomly
        StartCoroutine(ChangeDirection());
    }


    private void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * 10 *  _rotationSpeed * (int)(_rotateDirection)));
    }


    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        _rotateDirection = Random.value > 0.5f ? RotateDirection.CLOCKWIZE : RotateDirection.ANTI_CLOCEWISE;
    }
}
