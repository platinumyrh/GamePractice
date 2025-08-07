using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 4f;

    private int currentIndex = 0;
    private int direction = 1; // 1 表示向前，-1 表示向后

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (waypoints.Length < 2) return;

        Transform target = waypoints[currentIndex];
        Vector3 dir = (target.position - transform.position).normalized;

        // 移动
        transform.position += dir * speed * Time.deltaTime;

        // 设置动画方向
        animator.SetFloat("MoveX", dir.x);
        animator.SetFloat("MoveY", dir.y);

        // 到达目标点
        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            currentIndex += direction;

            // 到达两端，改变方向
            if (currentIndex >= waypoints.Length)
            {
                currentIndex = waypoints.Length - 2;
                direction = -1;
            }
            else if (currentIndex < 0)
            {
                currentIndex = 1;
                direction = 1;
            }
        }
    }
}
