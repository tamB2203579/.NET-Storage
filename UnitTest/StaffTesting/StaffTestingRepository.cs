using Moq;
using StaffsAPI.Data;

public class StaffTestingRepository
{
  Mock<IEmployeeRepository> mock;
  StaffsContext context;
  IEmployeeRepository employeeRepository;
  public static List<Employee> expectedList { get; set; }

  public StaffTestingRepository()
  {
    mock = new Mock<IEmployeeRepository>();
    context = new StaffsContext();
    employeeRepository = new EmployeeRepository(context);
    expectedList = new List<Employee>();
    expectedList.Add(new Employee()
    {
      EmployeeId = 1,
      FirstName = "John",
      LastName = "Doe",
      DateofBirth = new DateTime(1990, 1, 15),
      DepartmentId = 2,
      GenderId = 1,
      Email = "john.doe@example.com"
    });
    expectedList.Add(new Employee()
    {
      EmployeeId = 2,
      FirstName = "Jane",
      LastName = "Smith ",
      DateofBirth = new DateTime(1988, 6, 10),
      DepartmentId = 1,
      GenderId = 2,
      Email = "jane.smith@example.com"
    });
    expectedList.Add(new Employee()
    {
      EmployeeId = 3,
      FirstName = "Emily",
      LastName = "Johnson",
      DateofBirth = new DateTime(1991, 3, 22),
      DepartmentId = 3,
      GenderId = 2,
      Email = "emily.johnson@example.com"
    });
  }

  [Fact]
  public async void GetEmployee()
  {
    var staff = from emp in expectedList
                where emp.EmployeeId == 2
                select emp;
    var expectedStaff = (staff == null) ? null : staff.FirstOrDefault();
    mock.Setup(x => x.GetEmployee(2)).ReturnsAsync(expectedStaff);
    var resuilt = await employeeRepository.GetEmployee(2);
    Assert.Equal(expectedStaff.EmployeeId, resuilt.EmployeeId);
  }

  [Theory]
  [InlineData(1)]
  [InlineData(2)]
  [InlineData(3)]
  public async void GetStaffById(int id)
  {
    var staff = from emp in expectedList
                where emp.EmployeeId == id
                select emp;
    var expectedStaff = (staff == null) ? null : staff.FirstOrDefault();
    mock.Setup(x => x.GetEmployee(id)).ReturnsAsync(expectedStaff);
    var result = await employeeRepository.GetEmployee(id);
    Assert.Equal(expectedStaff.EmployeeId, result.EmployeeId);
  }
  [Fact]
  public async void AddStaff()
  {
    var newStaff = new Employee()
    {
      EmployeeId = 4,
      FirstName = "Samantha",
      LastName = "Williams",
      DateofBirth = new DateTime(1989, 10, 12),
      DepartmentId = 2,
      GenderId = 2,
      Email = "samantha.williams@example.com"
    };
    expectedList.Add(newStaff);
    var expectedStaff = newStaff;
    mock.Setup(x => x.AddEmployee(newStaff)).ReturnsAsync(expectedStaff);
    var result = await employeeRepository.AddEmployee(newStaff);
    Assert.Equal(expectedStaff.FirstName, result.FirstName);
  }



  [Fact]
  public async void GetAllStaffs()
  {
    mock.Setup(x => x.GetEmployees()).ReturnsAsync(expectedList);
    var result = await employeeRepository.GetEmployees();
    Assert.Equal(expectedList.Count + 1, result.Count());
  }

  [Theory]
  [InlineData(1, "John", "Doe", "john.updated@example.com", 2, 1)]
  [InlineData(2, "Jane", "Smith", "jane.updated@example.com", 1, 2)]
  public async void UpdateStaff(int id, string updatedFirstName, string updatedLastName, string updatedEmail, int updatedDepartmentId, int updatedGenderId)
  {
    var staffToUpdate = expectedList.FirstOrDefault(e => e.EmployeeId == id);
    if (staffToUpdate != null)
    {
      staffToUpdate.FirstName = updatedFirstName;
      staffToUpdate.LastName = updatedLastName;
      staffToUpdate.Email = updatedEmail;
      staffToUpdate.DepartmentId = updatedDepartmentId;
      staffToUpdate.GenderId = updatedGenderId;
    }

    mock.Setup(x => x.UpdateEmployee(It.IsAny<Employee>())).ReturnsAsync(staffToUpdate);

    var updatedStaff = new Employee
    {
      EmployeeId = id,
      FirstName = updatedFirstName,
      LastName = updatedLastName,
      Email = updatedEmail,
      DepartmentId = updatedDepartmentId,
      GenderId = updatedGenderId
    };

    var result = await employeeRepository.UpdateEmployee(updatedStaff);

    Assert.Equal(updatedFirstName, result.FirstName);
    Assert.Equal(updatedLastName, result.LastName);
    Assert.Equal(updatedEmail, result.Email);
  }

  [Fact]
  public async void DeleteStaff()
  {
    int idToDelete = 4;
    var staffToDelete = expectedList.FirstOrDefault(e => e.EmployeeId == idToDelete);
    if (staffToDelete != null)
    {
      expectedList.Remove(staffToDelete);
    }

    mock.Setup(x => x.DeleteEmployee(idToDelete)).ReturnsAsync(staffToDelete);

    var result = await employeeRepository.DeleteEmployee(idToDelete);

    Assert.Equal(staffToDelete?.EmployeeId, result?.EmployeeId);
    Assert.DoesNotContain(staffToDelete, expectedList);
  }
}
