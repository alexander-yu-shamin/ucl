using System.Linq;
using UCL.Assets.Scripts.Extensions.ObjectExtension;
using Unity.Collections;
using UnityEngine;

namespace UCL.Assets.Scripts.Components.DesignPatterns.CreationalPatterns
{
    public interface IDontDestroyOnLoad
    {
    }

    public class DontDestroyOnLoad : IDontDestroyOnLoad
    {
    }

    public class DestroyOnLoad : IDontDestroyOnLoad
    {
    }

    public class Singleton<T>  where T : new()
    {
        private static readonly T _instance = new T();
        public static T Instance => _instance;
        public static bool IsAlive => true;

        protected Singleton()
        {
        }
    }

    public class MonoSingleton<T> : MonoSingleton<T, DontDestroyOnLoad> 
        where T: MonoSingleton<T, DontDestroyOnLoad>
    {
    }

    public class MonoSingleton<T, U> : MonoBehaviour
        where T: MonoSingleton<T, U>
        where U: IDontDestroyOnLoad
    {
        private static T _instance = default;

        private static bool _alive = false;

        public static bool IsAlive
        {
            get => _instance != null && _alive;
            private set => _alive = value;
        }

        public static T Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                var instances = FindObjectsOfType<T>(true);
                if (!instances.IsNullOrEmpty())
                {
                    if (instances.Length == 1)
                    {
                        _instance = instances[0];
                        CheckDontDestroyOnLoad(_instance);
                        IsAlive = true;
                        return _instance;
                    }

                    if (instances.Length > 1)
                    {
                        //todo: [logs] add logger
                        foreach (var instance in instances)
                        {
                            Destroy(instance);
                        }
                    }
                }

                var instanceGameObject = new GameObject(typeof(T).Name, typeof(T));
                _instance = instanceGameObject.GetComponent<T>();
                CheckDontDestroyOnLoad(_instance);
                IsAlive = true;
                return _instance;
            }
        }


        public virtual void Awake()
        {
            CheckDontDestroyOnLoad(Instance);
        }

        public virtual void OnDestroy()
        {
            IsAlive = false;
        }

        public virtual void OnApplicationQuit()
        {
            IsAlive = false;
        }

        private static void CheckDontDestroyOnLoad(T instance)
        {
#if !UNITY_EDITOR
            if (typeof(U) == typeof(DontDestroyOnLoad))
            {
                DontDestroyOnLoad(instance);
            }
#endif
        }
    }
}

