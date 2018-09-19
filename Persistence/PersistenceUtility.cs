using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Varguiniano.ScriptableCore.Persistence
{
    /// <inheritdoc />
    /// <summary>
    /// Class that helps with saving scriptable objects to json and make data persistent.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Core/Persistence/PersistenceUtility")]
    public class PersistenceUtility : ScriptableObject
    {
        /// <summary>
        /// Identifier for the files to save.
        /// </summary>
        public string PersisterName;

        /// <summary>
        /// List of objects to persist.
        /// </summary>
        public List<PersistentScriptableObject> ObjectsToPersist = new List<PersistentScriptableObject>();

        /// <summary>
        /// Saves the given scriptable objects to the persistent data path.
        /// </summary>
        public bool SaveToFiles() => SaveToFiles(PersisterName, ObjectsToPersist);

        /// <summary>
        /// Saves the given scriptable objects to the persistent data path.
        /// </summary>
        /// <param name="persisterName">Meta name to give to those files for identification.</param>
        /// <param name="objectsToPersist">List of objects to persist.</param>
        /// <returns>True if it was successful.</returns>
        private static bool SaveToFiles(string persisterName, List<PersistentScriptableObject> objectsToPersist)
        {
            var path = Application.persistentDataPath + "\\" + persisterName;
            
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                var di = new DirectoryInfo(path);

                foreach (var file in di.GetFiles()) file.Delete();
                foreach (var dir in di.GetDirectories()) dir.Delete(true);

                for (var i = 0; i < objectsToPersist.Count; i++)
                {
                    var json = objectsToPersist[i].ToPersistentJson();
                    File.WriteAllText(path + $"/{persisterName}_{i}.pso", json);
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return false;
            }
        }

        /// <summary>
        /// Loads the stored jsons back into the persistent objects.
        /// </summary>
        public bool LoadFromFiles() => LoadFromFiles(PersisterName);

        /// <summary>
        /// Loads the stored jsons back into the persistent objects.
        /// </summary>
        /// <param name="persisterName">Meta name given to those files for identification.</param>
        /// <returns>True if it was successful.</returns>
        private bool LoadFromFiles(string persisterName)
        {
            var path = Application.persistentDataPath + "\\" + persisterName;

            try
            {
                for (var i = 0; i < ObjectsToPersist.Count; i++)
                    if (File.Exists(path + $"/{persisterName}_{i}.pso"))
                        ObjectsToPersist[i]
                            .LoadFromPersistentJson(File.ReadAllText(path + $"/{persisterName}_{i}.pso"));
                    else
                        Debug.LogWarning(path + $"/{persisterName}_{i}.pso wasn't found! There may be data loss");
                return true;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return false;
            }
        }
    }
}