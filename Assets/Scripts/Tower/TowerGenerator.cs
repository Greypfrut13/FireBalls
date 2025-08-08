using System;
using System.Collections.Generic;
using Tower.Blocks;
using UnityEngine;

namespace Tower
{
    public class TowerGenerator : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _towerSize;

        [SerializeField] private Transform _buildPoint;
        [SerializeField] private TowerBlock _towerBlockPrefab;
        
        private Vector3 _spawnPosition;
        private List<TowerBlock> _towerBlocks = new List<TowerBlock>();

        private void Start()
        {
            _spawnPosition = _buildPoint.position;
            BuilBlocks();
        }

        private void BuilBlocks()
        {
            for (int i = 0; i < _towerSize; i++)
            {
                TowerBlock createdBlock = Instantiate(_towerBlockPrefab, _spawnPosition, Quaternion.identity, transform);
                _towerBlocks.Add(createdBlock);
                
                Vector3 newSpawnPosition = new Vector3(_spawnPosition.x, 
                    _spawnPosition.y + createdBlock.transform.localScale.y
                    , _spawnPosition.z);
                
                _spawnPosition = newSpawnPosition;
            }
        }
    }
}