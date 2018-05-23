using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class BuildAssetBundle
{
    [MenuItem("AssetBundle/一键打包")]
    private static void BuildBundle()
    {
        string outPath = Application.dataPath + "/MyStudy/AssetBundle/AB";
        if (!Directory.Exists(outPath))     
            Directory.CreateDirectory(outPath);

        BuildPipeline.BuildAssetBundles(outPath, BuildAssetBundleOptions.None,BuildTarget.StandaloneWindows64);
    }
 
    [MenuItem("AssetBundle/一键做标记")]
    private static void MakeAssetBundle()
    {
        string outPath = Application.dataPath + "/MyStudy/Res";
        DirectoryInfo directoryInfo = new DirectoryInfo(outPath);
        FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos();

        foreach (FileSystemInfo item in fileSystemInfos)
        {
            if (item is DirectoryInfo) // 是文件夹的话,拼接路径
            {
                string tempPath =  Path.Combine(outPath, item.Name);
                TraversingFileSystemInfo(tempPath);
            }
        }

    }

    /// <summary>
    /// 遍历场景文件系统
    /// </summary>
    /// <param name="path"></param>
    private static void TraversingFileSystemInfo(string path)
    {
        string textFileName = Application.dataPath + "/MyStudy/"+"Record.txt";
        FileStream fs = new FileStream(textFileName, FileMode.OpenOrCreate);
        StreamWriter sw = new StreamWriter(fs);

        Dictionary<string, string> readDic = new Dictionary<string, string>();
        ChangeHead(textFileName,readDic);

        sw.Close();
        fs.Close();
    }
    
    /// <summary>
    /// 截取相对路径
    /// </summary>
    private static void ChangeHead(string filePath,Dictionary<string,string> dic)
    {
        int tempCount = filePath.IndexOf("Assets");
        filePath.Substring(tempCount);
    }


}
