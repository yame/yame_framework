using System;

namespace Yame.Core
{
    /// <summary>
    /// 这个类，主要是管理数据连接的名字，
    /// 在使用多数据库时，
    /// 避免在多处写Web.Config中配置数据库连接
    /// </summary>
    public class DBNames
    {
        /// <summary>
        /// 默认连接名称
        /// </summary>
        public const String DefaultName = Yame;

        /// <summary>
        /// 示例Yame
        /// </summary>
        public const String Yame = "db1";

        /// <summary>
        /// 示例平台数据
        /// </summary>
        public const String YameTest = "db2";

    }
}
