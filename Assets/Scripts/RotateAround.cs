using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

	public Transform target; // the object to rotate around
    public float period = 1f; // number of days to complete rotation/revolution 

    void Start() {
        if (target == null)
        {
            target = this.gameObject.transform;
            Debug.Log("RotateAround target not specified. Defaulting to parent GameObject");
        }
        transform.RotateAround(target.transform.position, target.transform.up, Random.Range(0, 360f));
    }

	// Update is called once per frame
	void Update () {
		// RotateAround takes three arguments, first is the Vector to rotate around
		// second is the axis to rotate around that vector
		// third is the degrees to rotate, in this case the speed per second
		transform.RotateAround(target.transform.position, target.transform.up, (360 / period) * Time.deltaTime * GameManager.instance.timeScale);
	}
}
