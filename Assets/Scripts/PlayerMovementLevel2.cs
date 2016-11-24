using UnityEngine;

[System.Serializable]
public class SpaceSize
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMovementLevel2 : MonoBehaviour
{
    public SpaceSize boundary;
    public float speed;

    private Vector3 newPosition;
    private Vector3 movement;

    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        newPosition = transform.position + (movement * speed * Time.deltaTime);
        if (newPosition.x >= boundary.xMin && newPosition.x <= boundary.xMax &&
            newPosition.z >= boundary.zMin && newPosition.z <= boundary.zMax)
        {
            transform.position = newPosition;
        }
    }
}
