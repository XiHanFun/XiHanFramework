namespace ZhaiFanhuaBlog.Utils.IpLocation.Ip2region;

/// <summary>
/// �������
/// powerd by https://github.com/lionsoul2014/ip2region
/// </summary>
public enum CachePolicyEnum
{
    /// <summary>
    /// no cache , not thread safe!
    /// </summary>
    File,

    /// <summary>
    /// cache vector index , reduce the number of IO operations , not thread safe!
    /// </summary>
    VectorIndex,

    /// <summary>
    /// default cache policy , cache whole xdb file , thread safe
    /// </summary>
    Content
}