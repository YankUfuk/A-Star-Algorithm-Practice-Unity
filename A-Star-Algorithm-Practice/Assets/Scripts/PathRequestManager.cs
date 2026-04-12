using UnityEngine;
using System;
using System.Collections.Generic;

public class PathRequestManager : MonoBehaviour
{
    private Queue<PathRequest> pathRequestQueue = new Queue<PathRequest>();
    private static PathRequestManager instance;
    private Pathfinding _pathfinding;
    private bool isProcessing;
    private PathRequest currentPathRequest;

    private void Awake()
    {
        instance = this;
        _pathfinding = GetComponent<Pathfinding>();
    }
    
    public static void RequestPath(Vector3 pathStart, Vector3 pathEnd, Action<Vector3[], bool> callback)
    {
        PathRequest newPathRequest = new PathRequest(pathStart, pathEnd, callback);
        instance.pathRequestQueue.Enqueue(newPathRequest);
        instance.TryProcessNext();
    }

    private void TryProcessNext()
    {
        if (!isProcessing && pathRequestQueue.Count > 0)
        {
            currentPathRequest = pathRequestQueue.Dequeue();
            isProcessing = true;
            _pathfinding.StartFindPath(currentPathRequest.start, currentPathRequest.end);
        }
    }

    public void FinishedProcessingPath(Vector3[] path, bool success)
    {
        currentPathRequest.callback(path, success);
        isProcessing = false;
        TryProcessNext();
    }
    
    private struct PathRequest
    {
        public Vector3 start;
        public Vector3 end;
        public Action<Vector3[], bool> callback;

        public PathRequest(Vector3 _start, Vector3 _end, Action<Vector3[], bool> _callback)
        {
            start = _start;
            end = _end;
            callback = _callback;
        }
    }
}
