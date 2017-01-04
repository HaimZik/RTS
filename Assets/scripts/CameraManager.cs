using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {


    private float newZoom;
    public Vector3 newTarget;
	public float newAngle;
	public float defaultZoom;

	public float moveSpeed;
	public float rotateSpeed;
	private float currentAngle;

	public Transform up;
	public Transform cam;
    public float MinZoom=-4;

    public float NewZoom
    {
        get
        {
            return newZoom;
        }

        set
        {
            newZoom = Mathf.Min(MinZoom,value);
        }
    }

    void Start(){
		currentAngle = 0;
		defaultZoom = 10;
		NewZoom = defaultZoom * -1;
        cam.localPosition = Vector3.forward * NewZoom;
	}

	public void SlideToPosition(Vector3 target){
		newTarget = target;
	}

	public void JumpToPosition(Vector3 target){
		newTarget = target;
		transform.position = target;
	}

	public void SlideToRotation(float angle){
		newAngle = angle;
	}


	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, newTarget, moveSpeed * Time.deltaTime);
		currentAngle = Mathf.Lerp (currentAngle, newAngle, rotateSpeed * Time.deltaTime);
		transform.localEulerAngles = new Vector3 (0,currentAngle,0);
		NewZoom += Input.GetAxis ("Mouse ScrollWheel") * 10;
        cam.localPosition = new Vector3 (0,0,Mathf.Lerp(cam.localPosition.z, NewZoom, 4 * Time.deltaTime));
        JumpToPosition(transform.position+ Time.deltaTime*(Vector3.forward*Input.GetAxis("Vertical") * moveSpeed+ Vector3.right * Input.GetAxis("Horizontal")* moveSpeed)*-newZoom);
      //  print(Input.mousePosition);
	}
}
