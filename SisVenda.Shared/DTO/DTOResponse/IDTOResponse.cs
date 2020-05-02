namespace SisVenda.Shared.DTOResponse
{
    interface IDTOResponse
    {
        int RecordCounts { get; set; }
        int PageCount { get; set; }
    }
}