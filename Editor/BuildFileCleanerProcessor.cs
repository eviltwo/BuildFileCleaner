using System.IO;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace BuildFileCleaner
{
    public class BuildFileCleanerProcessor : IPostprocessBuildWithReport
    {
        public int callbackOrder => 0;

        public void OnPostprocessBuild(BuildReport report)
        {
            if (!BuildFileCleanerSettings.instance.Enabled)
            {
                return;
            }

            var outputDir = Directory.GetParent(report.summary.outputPath);
            foreach (var filter in BuildFileCleanerSettings.instance.DeleteFilters)
            {
                var foundDirectories = Directory.GetDirectories(outputDir.FullName, filter, SearchOption.TopDirectoryOnly);
                foreach (var directory in foundDirectories)
                {
                    Directory.Delete(directory, true);
                    Debug.Log($"Deleted directory {directory}");
                }
                var foundFiles = Directory.GetFiles(outputDir.FullName, filter, SearchOption.TopDirectoryOnly);
                foreach (var file in foundFiles)
                {
                    File.Delete(file);
                    Debug.Log($"Deleted file {file}");
                }
            }
        }
    }
}
