using VM.Domain.Contracts.Presistence;

namespace VM.Presistence.Repository
{
    public class PageResult<T> : IPageResult<T>
    {
        public int Count { get; set; }
        public IEnumerable<T> Results { get; set; }

    }
}
