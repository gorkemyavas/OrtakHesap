using System.Collections.Generic;

namespace OrtakHesap.Models
{
    public class PagedResponseDto<T>
    {

        public Result<T> Result { get; set; }
        public object TargetUrl { get; set; }
        public bool Success { get; set; }
        public object Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool Abp { get; set; }
    }
    public partial class Result<T>
    {
        public long TotalCount { get; set; }
        public List<T> Items { get; set; }
    }
}
