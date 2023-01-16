using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private static float jumpTime = 20f;


    [SerializeField] public MapBehaviour _currentMap;
    [SerializeField] public int _playerIndex = 0;
    [SerializeField] public int _mapSpotIndex { private set; get; } = 0;
    [SerializeField] private int _mapSpotTarget = 0;
    public int MapSpotTarget => _mapSpotTarget;


    private MapSpot _oldSpot;
    private MapSpot _currentSpot;
    private MapSpot CurrentSpot => _currentSpot;

    private Transform _visualsRef;

    private void Start()
    {
        _currentSpot = _currentMap.Route[0];
        _oldSpot = _currentSpot;

        _visualsRef = transform.Find("Visuals");
    }

    public bool OnTile(int index) => Vector3.Distance(_currentMap.Route[index].transform.position, transform.position) < 0.2f;


    private void Update()
    {
        _currentSpot = _currentMap.Route[_mapSpotIndex];
        if (_jumpToNextTile < 1f) _jumpToNextTile += Time.deltaTime / Mathf.Max(Vector3.Distance(_currentSpot.transform.position, _oldSpot.transform.position), 8f) * jumpTime;

        transform.position = Vector3.Lerp(_oldSpot.transform.position, _currentSpot.transform.position, _jumpToNextTile);
        print(_jumpToNextTile);
        Vector3 offset = new Vector3(0f, Mathf.Sin(Mathf.Clamp(_jumpToNextTile, 0f, 1f) * Mathf.PI) * Mathf.Max(2f, (_currentSpot.transform.position.y - _oldSpot.transform.position.y)/2f), 0f);
        _visualsRef.position = transform.position + offset;

        if (Vector3.Distance(transform.position, _currentSpot.transform.position) < 0.1f && _jumpToNextTile > 1f)
        {
            if (_playerIndex != _mapSpotIndex)
            {
                SetTile(_playerIndex);
                _jumpToNextTile = 0f;
            }
        }
    }

    private float _jumpToNextTile = 0f;
    public void SetTile(int index)
    {
        if (index > _currentMap.Route.Length) return;
        _oldSpot = _currentMap.Route[_mapSpotIndex];
        _mapSpotIndex = index;
    }

}
