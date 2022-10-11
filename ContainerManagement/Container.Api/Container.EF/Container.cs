using Container.EF;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container.EF
{
    public interface IEntity { }

    public class BaseEntity<T> : IEntity
    {
        public T Id { get; set; }
    }

    public class Container : BaseEntity<Guid>
    {
        /// <summary>
        /// 容器名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 对应镜像Id
        /// </summary>
        public Guid ImageId { get; set; }

        /// <summary>
        /// 主机地址
        /// </summary>
        public int Host { get; set; }
    }

    public class Image : BaseEntity<Guid>
    {
        /// <summary>
        /// 镜像名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 镜像版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 镜像下载地址
        /// </summary>
        public string Link { get; set; }
    }

}
