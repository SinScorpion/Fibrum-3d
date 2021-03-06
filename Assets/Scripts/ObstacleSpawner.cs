using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _obstacle;
    [SerializeField] private float _spawnStep;
    [SerializeField] private float _spawnDistance;

    [SerializeField] private Vector2 _sergmentWidth;

    private Transform _myTrans;
    private Vector3 _lastPos;

    private List<Transform> _spawnedObstacles = new List<Transform>();
    public List<Transform> spawnedObstacles { get { _spawnedObstacles.RemoveAll(TransformIsNull); return _spawnedObstacles; } }
 
    bool TransformIsNull(Transform a)
    {
        return a == null;
    }
    // Start is called before the first frame update
    void Start()
    {
        _myTrans = transform;
        _lastPos = _myTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_myTrans.position.z > _lastPos.z + _spawnStep)
        {
            _lastPos.z += _spawnStep;

            Transform newObstacle = _obstacle[Random.Range(0, _obstacle.Length)];

            _spawnedObstacles.Add(Instantiate(newObstacle, new Vector3(
                Random.Range(_sergmentWidth.x, _sergmentWidth.y),
                0, _lastPos.z + _spawnDistance),
                Quaternion.identity));
        }
    }
}
