using UnityEngine;

public class InputController : MonoBehaviour
{
  [SerializeField] private KeyCode angleUpKey = KeyCode.A;
  [SerializeField] private KeyCode angleDownKey = KeyCode.D;
  [SerializeField] private KeyCode forceUpKey = KeyCode.W;
  [SerializeField] private KeyCode forceDownKey = KeyCode.S;
  [SerializeField] private KeyCode fireKey = KeyCode.LeftShift;
  [SerializeField] private GameObject snowballPrefab;


  [SerializeField] private Transform directionArrow;
  private Vector3 maxAngle = new Vector3(0f, 0f, 0f);
  private Vector3 minAngle = new Vector3(0f, 0f, -270f);

  public float force = 500f;

  
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(angleUpKey))
    {
      directionArrow.Rotate(Vector3.forward, 50 * Time.deltaTime);
      // if (directionArrow.eulerAngles.z > maxAngle.z)
      // {
      //   directionArrow.eulerAngles = maxAngle;
      // }
      Debug.Log(directionArrow.eulerAngles.z);
    }
    if (Input.GetKey(angleDownKey))
    {
      directionArrow.Rotate(Vector3.forward, -50 * Time.deltaTime);
      // if (directionArrow.eulerAngles.z < minAngle.z)
      // {
      //   directionArrow.eulerAngles = minAngle;
      // }

      Debug.Log(directionArrow.eulerAngles.z);
    }

    if (Input.GetKeyDown(fireKey))
    {
      GameObject snowball = Instantiate(snowballPrefab, directionArrow.position, directionArrow.rotation);
      Rigidbody rb = snowball.GetComponent<Rigidbody>();
      rb.AddForce((directionArrow.up) * force, ForceMode.Force);
    }
      
  }
}
