namespace KarataClub.Domain.People;

public sealed class Person:AuditEntity
{
    public string Name { get; private set; } = default!;
    public string Phone { get; private set; } = default!;
    public string? Email { get; private set; } = default!;
    public string Address { get; private set; } = default!;
    public Member Member =default!;
    public Instructor Instructor=default!;

    private Person(){}
    private Person(Guid id,string name,string phone,string email,string address):base(id){
        Name = name;
        Phone = phone;
        Address = address;
        Email = email;
    }
    public static Result<Person> Create(string name, string phone, string email, string address) {
        if (string.IsNullOrWhiteSpace(name)) return PersonErrors.InvalidName;
        if (string.IsNullOrWhiteSpace(phone)) return PersonErrors.InvalidPhone;
        if (string.IsNullOrWhiteSpace(address)) return PersonErrors.InvalidAddress;
        //if (string.IsNullOrWhiteSpace(email)) return PersonErrors.InvalidEmail;

        return new Person(Guid.NewGuid(),name,phone,email,address);
    }

    public Result<Updated> Update(string name, string email, string phone, string address)
    {

        if (string.IsNullOrWhiteSpace(name)) return PersonErrors.InvalidName;
        if (string.IsNullOrWhiteSpace(phone)) return PersonErrors.InvalidPhone;
        if (string.IsNullOrWhiteSpace(address)) return PersonErrors.InvalidAddress;

        this.Name=name;
        this.Phone=phone;
        this.Email=email;
        this.Address=address;
        return Result.Updated;
    }
}
