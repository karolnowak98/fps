using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FPS.Core.Data
{
    public class DataProvider
    {
        private readonly Dictionary<Type, Config> _configs = new();
        private readonly Dictionary<Type, Entity[]> _entities = new ();
        
        public T GetConfig<T>() where T : Config
        {
            var type = typeof(T);
            
            if (_configs.TryGetValue(type, out var config))
            {
                return (T) config;
            }

            Debug.LogWarning("Config with type: " + type + " not found!!");
            return null;
        }
        
        public T[] GetEntities<T>() where T : Entity
        {
            var type = typeof(T);
            return Array.ConvertAll(_entities[type], x => (T)x);
        }
        
        public void SetConfig<T>(Config config) where T : Config
        { 
            var type = typeof(T);
            SetConfig(type, config);
        }
        
        public void SetConfig(Type type, Config config)
        {
            if (_configs.ContainsKey(type))
            {
                Debug.LogWarning("DataProvider.SetConfig already has " + type);
                return;
            }
            _configs.Add(type, config);
        }
        
        public void SetEntities<T>(T[] entities) where T : Entity
        {
            var type = typeof(T);
            SetEntities(type, entities);
        }
        
        public void SetEntities<T>(Type type, T[] entities) where T : Entity
        {
            if(entities == null || entities.Length == 0)
            {
                Debug.LogWarning("DataProvider.SetEntities is empty for " + type);
            } 
            
            else
            {
                var maxID = entities.Select(entity => entity.ID).Prepend(0).Max();

                var all = new Entity[maxID+1];

                foreach (var entity in entities)
                {
                    var id = entity.ID;
                    all[id] = entity;
                }

                _entities.Add(type, all);
            }
        }
    }
}