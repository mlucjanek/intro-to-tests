namespace Example.Application.Dto;

public sealed class DomainEntityDto
{
    public DomainEntityDto()
    {
    }

    public DomainEntityDto(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }

    public string Name { get; set; }
}
