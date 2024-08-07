using UnityEditor;
using UnityEngine.UIElements;

namespace BuildFileCleaner
{
    public class BuildFileCleanerSettingsProvider : SettingsProvider
    {
        private static readonly string SettingPath = "Project/Build File Cleaner";
        private static readonly string[] Keywords = { };

        private Editor _editor;

        [SettingsProvider]
        public static SettingsProvider CreateProvider()
        {
            return new BuildFileCleanerSettingsProvider(SettingPath, SettingsScope.Project, Keywords);
        }

        public BuildFileCleanerSettingsProvider(string path, SettingsScope scopes, string[] keywords = null) : base(path, scopes, keywords)
        {
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            var settings = BuildFileCleanerSettings.instance;
            Editor.CreateCachedEditor(settings, null, ref _editor);
        }

        public override void OnGUI(string searchContext)
        {
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                _editor.OnInspectorGUI();
                if (check.changed)
                {
                    BuildFileCleanerSettings.instance.Save();
                }
            }
        }
    }
}
