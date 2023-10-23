using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace FPS.Core.Data
{
    [CreateAssetMenu(fileName = "DataHolder", menuName = "GlassyCode/DataHolder")]
    public class DataHolder : ScriptableObject
    {
        [SerializeField] private ScriptableObject[] _allData;
        
        private const string DATA_PATH = "Assets/Data/";
        
#if UNITY_EDITOR
        [ContextMenu("Find all data")]
        public void FindAll()
        {
            var all = new List<ScriptableObject>();
            
            var entityDataType = typeof(Entity);
            var configDataType = typeof(Config);

            var files = AssetDatabase.GetAllAssetPaths();
            var dataFiles = new List<string>();

            foreach(var file in files)
            {
                if (!file.StartsWith(DATA_PATH)) continue;
                
                dataFiles.Add(file);
                var so = AssetDatabase.LoadAssetAtPath<ScriptableObject>(file);
                
                if (so == null) continue;
                
                var type = so.GetType();
                
                if (type.BaseType == configDataType)
                {
                    all.Add(so);
                }
                
                else if (type.BaseType == entityDataType)
                {
                    all.Add(so);
                }
            }

            _allData = all.ToArray();
            EditorUtility.SetDirty(this);
        }
#endif
        public void RegisterAll(DataProvider provider)
        {
            
            #if UNITY_EDITOR
            FindAll();
            #endif

            var entityDataType = typeof(Entity);
            var configDataType = typeof(Config);

            var entities = new Dictionary<Type, List<Entity>>();

            if(_allData != null)
            {
                foreach(var dataElement in _allData)
                {
                    var type = dataElement.GetType();
                    if (type.BaseType == configDataType)
                    {
                        provider.SetConfig(type, (Config) dataElement);
                    } else if (type.BaseType == entityDataType)
                    {
                        if (!entities.ContainsKey(type))
                        {
                            entities.Add(type, new List<Entity>());
                        }
                        entities[type].Add((Entity) dataElement);
                    }
                }
            }
            
            foreach(var entitiesByType in entities)
            {
                provider.SetEntities(entitiesByType.Key, entitiesByType.Value.ToArray());
            }
        }
    }
}