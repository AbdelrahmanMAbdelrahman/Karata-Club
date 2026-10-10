namespace KarataClub.Domain.People;

public sealed class Person:AuditEntity
{
    public string Name { get; private set; } = default!;
    public string Phone { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Address { get; private set; } = default!;
    public Member Member =default!;
    public Instructor Instructor=default!;

    public Person(){}
    public Person(Guid id,string name,string phone,string email,string address):base(id){
        Name = name;
        Phone = phone;
        Address = address;
        Email = email;
    }
    public Result<Person> Create(string name, string phone, string email, string address) {
        if (string.IsNullOrWhiteSpace(name)) return PersonErrors.InvalidName;
        if (string.IsNullOrWhiteSpace(phone)) return PersonErrors.InvalidPhone;
        if (string.IsNullOrWhiteSpace(email)) return PersonErrors.InvalidEmail;
        if (string.IsNullOrWhiteSpace(address)) return PersonErrors.InvalidAddress;

        return new Person(Guid.NewGuid(),name,phone,email,address);
    }
}
