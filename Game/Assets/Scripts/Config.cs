using UnityEngine;
using System.IO;

namespace Data
{
    public class Config
    {
        private static string game_data = Application.dataPath + "/Config/data.json";
        public static string PathData {
            get { return game_data; }
        }

        /// <summary>
        /// Saves the given object to a JSON file
        /// </summary>
        /// <param name="filePath">Path to the JSON file</param>
        /// <param name="data">Object to save</param>
        public static void SaveToJson<T>(string filePath, T data)
        {
            try
            {
                if (data == null)
                {
                    Debug.LogError("Error: Object to save is null");
                    return;
                }

                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    Debug.Log($"Directory created: {directory}");
                }

                string jsonData = JsonUtility.ToJson(data, true);

                File.WriteAllText(filePath, jsonData);
                Debug.Log($"Data successfully saved to: {filePath}");
            }
            catch (System.ArgumentException ex)
            {
                Debug.LogError($"Error in path: {ex.Message}");
            }
            catch (System.IO.IOException ex)
            {
                Debug.LogError($"Error in input/output: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Unknown error during saving: {ex.Message}");
            }
        }

        /// <summary>
        /// Reads a JSON file and populates the given object
        /// </summary>
        /// <param name="filePath">Path to the JSON file</param>
        /// <param name="data">Object to populate (passed by reference)</param>
        /// <returns>true if successfully read, false if error</returns>
        public static bool LoadFromJson<T>(string filePath, ref T data)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Debug.LogWarning($"File not found: {filePath}");
                    return false;
                }

                string jsonData = File.ReadAllText(filePath);

                if (string.IsNullOrWhiteSpace(jsonData))
                {
                    Debug.LogWarning($"File is empty: {filePath}");
                    return false;
                }

                // Deserialize JSON in the object
                data = JsonUtility.FromJson<T>(jsonData);

                Debug.Log($"Data successfully read from: {filePath}");
                return true;
            }
            catch (System.ArgumentException ex)
            {
                Debug.LogError($"Error in path: {ex.Message}");
                return false;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Debug.LogError($"File not found: {ex.Message}");
                return false;
            }
            catch (System.IO.IOException ex)
            {
                Debug.LogError($"Error in input/output: {ex.Message}");
                return false;
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Error during JSON deserialization: {ex.Message}");
                return false;
            }
        }
    }
}
