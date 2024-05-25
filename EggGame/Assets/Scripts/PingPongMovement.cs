using UnityEngine;

public class PingPongMovement : MonoBehaviour, IMovement
{
    [SerializeField] private Transform leftPos;
    [SerializeField] private Transform rightPos;
    [SerializeField] private float speed;

    private bool _movingRight = true;

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (_movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= rightPos.position.x - 1)
            {
                _movingRight = false;
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= leftPos.position.x + 1)
            {
                _movingRight = true;
            }
        }
    }
}


public interface IMovement
{
    void Move();
}
