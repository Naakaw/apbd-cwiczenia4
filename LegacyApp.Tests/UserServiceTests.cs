namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWehnFirstNameIsEmpty()
    {
        // Arrange
        UserService userService = new UserService();
        
        // Act
        var result = userService.AddUser(null, "Kowalski", "kowalski@gmail.com", DateTime.Parse("1999-03-21"), 1);
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenLastNameIsEmpty()
    {
        // Arrange
        UserService userService = new UserService();
        
        // Act
        var result = userService.AddUser("Jan", null, "kowalski@gmail.com", DateTime.Parse("1999-03-21"), 1);
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenEmailDoesntContainAtSign()
    {
        // Arrange
        UserService userService = new UserService();
        
        // Act
        var result = userService.AddUser("Jan", "Kowalski", "kowalskigmail.com", DateTime.Parse("1999-03-21"), 1);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenEmailDoesntContainDotSign()
    {
        // Arrange
        UserService userService = new UserService();
        
        // Act
        var result = userService.AddUser("Jan", "Kowalski", "kowalski@gmailcom", DateTime.Parse("1999-03-21"), 1);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
    {
        // Arrange
        UserService userService = new UserService();
        
        // Act
        Action result = () => userService.AddUser("Jan", "Kowalski", "kowalskigmail.com", DateTime.Parse("1999-03-21"), 1);
        
        // Assert
        Assert.Throws<ArgumentException>(result);
    }
}