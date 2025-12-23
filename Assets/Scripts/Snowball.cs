using System.Collections;
using UnityEngine;

public class Snowball : MonoBehaviour
{
  [SerializeField] private float destroyTime = 10.0f;
  [SerializeField] private bool destroyOnCollision = true;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    StartCoroutine(destroyAfterTime(destroyTime));
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  IEnumerator destroyAfterTime(float time)
  {
    yield return new WaitForSeconds(time);
    Destroy(gameObject);
  }

  void OnCollisionEnter(Collision collision)
  {
    if (destroyOnCollision)
      Destroy(gameObject);
  }

  void OnTriggerEnter(Collider other)
  {
    if (destroyOnCollision)
      Destroy(gameObject);
  }

}
