namespace SisVenda.UI.CQRS.Commands
{
    public class PeopleDeleteCommand : IDeleteCommand
    {
        public string Id { get; set; }
    }
}
