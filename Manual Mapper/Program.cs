
using Manual_Mapper;
using Manual_Mapper.Helper;

ICurrentUserBusiness currentUser = new FakeCurrentUserBusiness();


var converter = new GenericEntityConverter<UserDTO, UserEntity>(currentUser);

// Custom mapping: DTO.FullName => Entity.FullUserName
var customMappings = new Dictionary<string, string>
            {
                { "FullName", "FullUserName" }
            };


var userDto = new UserDTO
{
    FullName = "John Doe",
    Age = 30
};

var userEntity = converter.ToEntity(userDto, null, customMappings);

Console.WriteLine("===== Convert DTO => Entity (Custom Mapping) =====");
Console.WriteLine($"DTO.FullName            : {userDto.FullName}");
Console.WriteLine($"MappedEntity.FullUserName : {userEntity.FullUserName}");
Console.WriteLine($"Age                     : {userEntity.Age}");
Console.WriteLine($"CreatedBy               : {userEntity.CreatedBy}");
Console.WriteLine($"CreatedDate             : {userEntity.CreatedDate}");
Console.WriteLine($"ModifiedBy              : {userEntity.ModifiedBy}");
Console.WriteLine($"ModifiedDate            : {userEntity.ModifiedDate}");
Console.WriteLine("==================================================\n");


var entity = new UserEntity
{
    FullUserName = "Loc",
    Age = 25,
    CreatedBy = Guid.NewGuid(),
    CreatedDate = DateTime.UtcNow.AddDays(-1),
    ModifiedBy = Guid.NewGuid(),
    ModifiedDate = DateTime.UtcNow
};


var dto = converter.ToDTO(entity, customMappings);

Console.WriteLine("===== Convert Entity => DTO (Custom Mapping) =====");
Console.WriteLine($"Entity.FullUserName     : {entity.FullUserName}");
Console.WriteLine($"MappedDTO.FullName      : {dto.FullName}");
Console.WriteLine($"Age                     : {dto.Age}");
Console.WriteLine("==================================================");