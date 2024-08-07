using UnityEditor;

namespace BuildFileCleaner
{
    [FilePath("ProjectSettings/BuildFileCleanerSettings.asset", FilePathAttribute.Location.ProjectFolder)]
    public class BuildFileCleanerSettings : ScriptableSingleton<BuildFileCleanerSettings>
    {
        public bool Enabled = true;
        public string[] DeleteFilters = { "*_BurstDebugInformation_DoNotShip" };

        public void Save()
        {
            Save(true);
        }
    }
}
