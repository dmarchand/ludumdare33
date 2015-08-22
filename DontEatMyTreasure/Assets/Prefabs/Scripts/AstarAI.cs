using UnityEngine;
using System.Collections;
//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use pathfinding
using Pathfinding;

public class AstarAI : MonoBehaviour
{
    private Seeker seeker;
    private GameObject CurrentTarget;

    //The calculated path
    public Path path;

    //The AI's speed per second
    public float speed = 2;

    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    private bool isPaused;

    public void Pause()
    {
        isPaused = true;
    }

    public void UnPause()
    {
        isPaused = false;
        seeker.StartPath(transform.position, CurrentTarget.transform.position, OnPathComplete);
    }

    void NewPath()
    {
        var targets = GameObject.FindGameObjectsWithTag("Treasure");

        if (targets.Length <= 0)
        {
            //gg
            Debug.Log("Game Over");
            Application.LoadLevel(0);
            return;
        }

        float shortestDist = 999999999999999999f;
        GameObject shortestDistTarget = null;

        foreach (var target in targets)
        {

            float currentDist = Mathf.Abs(Vector3.Distance(this.transform.position, target.transform.position));
            if (currentDist < shortestDist)
            {
                shortestDist = currentDist;
                shortestDistTarget = target;
            }
        }

        CurrentTarget = shortestDistTarget;
        CurrentTarget.GetComponent<TreasureChest>().OnTreasureOpened += NewPath;
        //Start a new path to the targetPosition, return the result to the OnPathComplete function
        seeker.StartPath(transform.position, CurrentTarget.transform.position, OnPathComplete);
    }

    public void Start()
    {
        seeker = GetComponent<Seeker>();

        NewPath();
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
        if (!p.error)
        {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
        }
    }

    public void FixedUpdate()
    {
        if (path == null || isPaused)
        {
            //We have no path to move after yet
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            Debug.Log("End Of Path Reached");
            return;
        }

        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;
        this.gameObject.transform.Translate(dir);

        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
}