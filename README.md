

---

```markdown
# Manual-Mapper

A lightweight and extensible helper for converting between DTO (Data Transfer Object) and Entity objects in .NET applications.  
Supports custom property mappings and automatic handling of audit fields like `CreatedBy`, `CreatedDate`, `ModifiedBy`, and `ModifiedDate`.

---

## ✨ Features

- Generic conversion from DTO to Entity and vice versa
- Support for custom property mappings
- Automatic population of audit fields (`CreatedBy`, `CreatedDate`, `ModifiedBy`, `ModifiedDate`)
- Clean and reusable implementation with dependency injection support

---

## 📦 Installation

Clone the repository:

```bash
git clone https://github.com/your-username/Manual-Mapper.git
```

Then include the relevant files in your .NET project.

---

## 🧠 Usage

### 1. Define your DTO and Entity

```csharp
public class UserDTO
{
    public string FullName { get; set; }
    public int Age { get; set; }
}

public class UserEntity
{
    public string FullUserName { get; set; }
    public int Age { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
}
```

### 2. Implement ICurrentUserBusiness

```csharp
public class FakeCurrentUserBusiness : ICurrentUserBusiness
{
    public string GetCurrentUserId()
    {
        return Guid.NewGuid().ToString(); // Simulated current user
    }
}
```

### 3. Convert DTO ↔ Entity

```csharp
var currentUser = new FakeCurrentUserBusiness();
var converter = new GenericEntityConverter<UserDTO, UserEntity>(currentUser);

// Custom property mapping
var mappings = new Dictionary<string, string>
{
    { "FullName", "FullUserName" } // DTO → Entity
};

var userDto = new UserDTO { FullName = "John Doe", Age = 30 };
var entity = converter.ToEntity(userDto, null, mappings);

// Convert back to DTO using same mapping
var dto = converter.ToDTO(entity, mappings);
```

---

## 📂 Project Structure

```
Manual-Mapper/
│
├── Helpers/
│   └── GenericEntityConverter.cs   // Core helper for conversion
│
├── Interfaces/
│   └── IEntityConverter.cs         // Interface for the converter
│
├── Models/
│   ├── UserDTO.cs
│   └── UserEntity.cs
│
├── Services/
│   └── ICurrentUserBusiness.cs     // Interface for current user context
│   └── FakeCurrentUserBusiness.cs // Fake implementation for testing
│
├── Program.cs                      // Demo usage
└── README.md
```

---

## 📄 License


**© ngophuocloc0309@gmail.com – All rights reserved.**

This project is licensed for free use.
---

## 🤝 Contributions

Contributions are welcome! Feel free to fork, open issues or submit pull requests to improve the project.


---

## ☕ Buy Me a Coffee

If you find this project helpful, consider supporting my work ❤️

**Bank Info (Vietnam):**  
- **Bank:** Vietcombank  
- **Account Name:** NGO PHUOC LOC  
- **Account Number:** `1037156483`

Your support means a lot! 🙏

