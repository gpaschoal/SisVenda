namespace SisVenda.Shared.DTO.Filters
{
    public interface IFilter
    {
        int RowsByPage { get; set; }
        int PageNumber { get; set; }
        /// <summary>
        /// This method will apply default value for all my parameters
        /// </summary>
        void Normalize();
    }
}
