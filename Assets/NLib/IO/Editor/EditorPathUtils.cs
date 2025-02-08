#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEditor;

namespace Nitou.IO {

    public static class EditorPathUtils {

        /// <summary>
        /// 選択中のアセットのパスを取得する
        /// </summary>
        public static string GetSelectedAssetPath() =>
            AssetDatabase.GetAssetPath(Selection.activeInstanceID);


        /// --------------------------------------------------------------------
        #region パスの変換（string拡張メソッド）

        /// <summary>
        /// アセットパスを取得する
        /// </summary>
        public static string GetAssetPath(this ScriptableObject scriptableObject) {
            var mono = MonoScript.FromScriptableObject(scriptableObject);
            return AssetDatabase.GetAssetPath(mono).Replace("\\", "/");
        }

        /// <summary>
        /// アセットの親フォルダパスを取得する
        /// </summary>
        public static string GetAssetParentFolderPath(this ScriptableObject scriptableObject, int n = 1) {
            var filePath = scriptableObject.GetAssetPath();

            return PathUtils.GetParentDirectory(filePath, n);
        }
        #endregion


        /// --------------------------------------------------------------------
        // 

        /// <summary>
        /// フォルダのアセットパスを検索して取得する
        /// </summary>
        public static string GetFolderPath(string folderName, string parentFolderName) {

            // ※全ファイルを検索する実装なのに注意
            string[] guids = AssetDatabase.FindAssets(folderName);
            foreach (var guid in guids) {

                // 対象フォルダ情報
                var folderPath = AssetDatabase.GUIDToAssetPath(guid);

                // 親フォルダ情報
                var parentFolderPath = PathUtils.GetDirectoryName(folderPath);
                var parentFolder = PathUtils.GetFileName(parentFolderPath);

                // 親フォルダまで一致しているなら，確定とする
                if (parentFolder == parentFolderName) {
                    return folderPath;
                }
            }

            return "";
        }

    }

}
#endif