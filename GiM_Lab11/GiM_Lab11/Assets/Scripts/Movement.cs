using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 10f;
    public GameObject Camera;
    private CharacterController _animator;


    // Use this for initialization
	void Start ()
	{   
	}
	
	// Update is called once per frame
	void Update () {
        Move(
            Input.GetKey("w"),
            Input.GetKey("s"),
            Input.GetKey("a"),
            Input.GetKey("d")
            );
    }

    private void Move(bool forward, bool back, bool left, bool right)
    {
        var position = transform.position;

        if (left != right)
        {
            transform.Rotate(new Vector3(0, (left ? -1 : 1) * Speed * 3, 0));
        }
        if (forward != back)
        {
            position = transform.position + (transform.forward * Speed * (back ? 1 : -1));
//            position.z += (back ? 1 : -1) * Speed;
        }
        position.y = Terrain.activeTerrain.SampleHeight(position)- 0.5f;
        transform.position = position;
    }
}
