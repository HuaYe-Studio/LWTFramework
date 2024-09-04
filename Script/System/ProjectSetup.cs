using System;
using UnityEngine;

using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

using static System.IO.Path;
using static UnityEditor.AssetDatabase;
namespace Script.System
{
    public class ProjectSetup
    {
        [MenuItem("Tools/Setup/Import Essential Assets")]
        static void ImportEssentials()
        {
           
        }
        
        [MenuItem("Tools/Setup/Install Essential Packages")]
        public static void InstallPackages()
        {
            string[] packages =
            {
                "git+https://github.com/adammyhre/Unity-Improved-Timers.git",
                "com.unity.inputsystem"
            };//此处添加需要的包
            
            Packages.InstallPackages(packages);
        }
        [MenuItem("Tools/Setup/Install Essential Folders")]    
        public static void Createfolders()
        {
            //此处管理文件夹，可以按需添加
            Floders.Create("_Project","Animation","Art","Materials","Prefabs","Script/Tests","Script/Tests/Editor","Script/Tests/RunTime");
            Refresh();
            Floders.Move("_Project","Scenes");
            Floders.Move("_Project","Settings");
            Floders.Delete("TutorialInfo");
            Refresh();

            const string pathToInputActions = "Assets/InputSystem_Actions.inputactions";

            string destination = "Assets/_Project/Settings/InputSystem_Actions.inputactions";

            MoveAsset(pathToInputActions, destination);

            const string pathToReadme = "Assets/Readme.asset";

            DeleteAsset(pathToReadme);
            Refresh();
        }
        static class Assets
        {
            public static void ImportAsset(string asset, string folder)
            {
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string assetsFolder = Combine(basePath, "Unity/Assets Stroe-5.x");

                ImportPackage(Combine(assetsFolder, folder, asset), false);
            }
            
        }
        
        static class Packages
        {
            private static AddRequest request;
            private static Queue<string> packagesToInstall = new Queue<string>();

            public static void InstallPackages(string[] packages)
            {
                foreach ( string package in packages)
                {
                    packagesToInstall.Enqueue(package);
                }

                if (packagesToInstall.Count > 0)
                {
                    StartNextPackageInstallation();
                }
              
            }

             static async void StartNextPackageInstallation()
             {
                 request = Client.Add(packagesToInstall.Dequeue());

                 while (!request.IsCompleted)
                 {
                     await Task.Delay(10);
                 }

                 
                 if (request.Status==StatusCode.Success) Debug.Log("Installed:"+request.Result.packageId);
                 else if (request.Status >= StatusCode.Failure) Debug.LogError(request.Error.message);


                 if (packagesToInstall.Count>0)
                 {
                     await Task.Delay(1000);
                     StartNextPackageInstallation();
                 }
             }
        }
        static class Floders
        {
            public static void Delete(string folderName)
            {
                string pathToDelete = $"Assets/{folderName}";

                if (IsValidFolder(pathToDelete))
                {
                    DeleteAsset(pathToDelete);
                }
            }
            
            public static void Move(string newParent,string folderName)
            {
                string soursePath = $"Assets/{folderName}";
                if (IsValidFolder(soursePath))
                {
                    string destinationPath = $"Assets/{newParent}/{folderName}";
                    string error = MoveAsset(soursePath, destinationPath);

                    if (!string.IsNullOrEmpty(error))
                    {
                        Debug.LogError($"Failed to move {folderName}:{error}");
                    }
                }
            }
            public static void Create(string root, params string[] folders)
            {
                var fullpath = Combine(Application.dataPath, root);
                if (!Directory.Exists(fullpath))
                {
                    Directory.CreateDirectory(fullpath);
                }

                foreach (var folder in folders)
                {
                    CreateSubFolders(fullpath, folder);
                }
            }

            private static void CreateSubFolders(string rootPath, string folderHierarchy)
            {
                var folders = folderHierarchy.Split('/');
                var currentPath = rootPath;

                foreach (var folder in folders)
                {
                    currentPath = Combine(currentPath, folder);
                    if (!Directory.Exists(currentPath))
                    {
                        Directory.CreateDirectory(currentPath);
                    }
                }
            } 
        }
    }
}