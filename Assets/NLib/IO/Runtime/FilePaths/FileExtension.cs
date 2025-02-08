using System;

namespace Nitou.IO {

    /// <summary>
    /// ファイル拡張子を表すクラス
    /// </summary>
    public sealed class FileExtension : IEquatable<FileExtension>{

        /// <summary>
        /// 拡張子の文字列（ピリオド付き）．
        /// </summary>
        public string Extension { get; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        private FileExtension(string extension) {
            if (string.IsNullOrWhiteSpace(extension))
                throw new ArgumentException("Extension cannot be null or empty.", nameof(extension));

            if (!extension.StartsWith("."))
                throw new ArgumentException("Extension must start with a dot ('.').", nameof(extension));

            Extension = extension.ToLowerInvariant();
        }

        /// <summary>
        /// 拡張子が一致しているか判定します
        /// </summary>
        public override bool Equals(object obj) {
            return obj is FileExtension other 
                && this.Equals(other);
        }

        /// <summary>
        /// IEquatable 実装
        /// </summary>
        public bool Equals(FileExtension other) {
            if (other is null) return false;
            return Extension == other.Extension;
        }


        /// <summary>
        /// 拡張子の文字列表現を返します
        /// </summary>
        public override string ToString() => Extension;

        /// <summary>
        /// ハッシュ値を返す．
        /// </summary>
        public override int GetHashCode() => Extension.GetHashCode();


        /// ----------------------------------------------------------------------------
        #region Static

        public static bool operator ==(FileExtension left, FileExtension right) {
            if (ReferenceEquals(left, right)) return true; 
            if (left is null || right is null) return false;
            return left.Equals(right);
        }
        public static bool operator !=(FileExtension left, FileExtension right) => !(left == right);

        /// <summary>
        /// 標準的な拡張子を提供
        /// </summary>
        public static class Standard {
            public static readonly FileExtension Txt = new (".txt");
            public static readonly FileExtension Json = new (".json");
            public static readonly FileExtension Csv = new (".csv");
            public static readonly FileExtension Xml = new (".xml");
            public static readonly FileExtension Ini = new (".ini");
            public static readonly FileExtension Jpg = new (".jpg");
            public static readonly FileExtension Png = new (".png");
            public static readonly FileExtension Mp3 = new (".mp3");
            public static readonly FileExtension Mp4 = new (".mp4");
            public static readonly FileExtension Asset = new (".asset");
        }
        #endregion
    }
}
