using UnityEngine;
using TMPro;

public class InputController : MonoBehaviour
{
  [SerializeField] private KeyCode angleUpKey = KeyCode.A;
  [SerializeField] private KeyCode angleDownKey = KeyCode.D;
  [SerializeField] private KeyCode forceUpKey = KeyCode.W;
  [SerializeField] private KeyCode forceDownKey = KeyCode.S;
  [SerializeField] private KeyCode fireKey = KeyCode.LeftShift;
  [SerializeField] private GameObject snowballPrefab;


  [SerializeField] private Transform directionArrow;
  [SerializeField] private TMP_Text uiForceText;


  private Vector3 maxAngle = new Vector3(0f, 0f, 0f);
  private Vector3 minAngle = new Vector3(0f, 0f, -270f);

  private float force = 500f;

  private float forceIncrement = 1f;

  
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    uiForceText.text = force.ToString();
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
    }
    if (Input.GetKey(angleDownKey))
    {
      directionArrow.Rotate(Vector3.forward, -50 * Time.deltaTime);
      // if (directionArrow.eulerAngles.z < minAngle.z)
      // {
      //   directionArrow.eulerAngles = minAngle;
      // }

    }

    if (Input.GetKey(forceUpKey))
    {
      force += forceIncrement;
      uiForceText.text = force.ToString();
    }
    if (Input.GetKey(forceDownKey))
    {
      force -= forceIncrement;
      uiForceText.text = force.ToString();
    }

    if (Input.GetKeyDown(fireKey))
    {
      GameObject snowball = Instantiate(snowballPrefab, directionArrow.position, directionArrow.rotation);
      Rigidbody rb = snowball.GetComponent<Rigidbody>();
      rb.AddForce((directionArrow.up) * force, ForceMode.Force);
    }
      
  }
}
