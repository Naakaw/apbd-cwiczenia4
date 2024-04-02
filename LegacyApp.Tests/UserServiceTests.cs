namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
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
    public void AddUser_ReturnsFalseWhenYoungerThan21()
    {
        // Arrange
        UserService userService = new UserService();
        
        // Act
        var result = userService.AddUser("Jan", "Kowalski", "kowalski@gmail.com", DateTime.Parse("2010-03-21"), 1);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        // Arrange
        UserService userService = new UserService();
        
        // Act
        var result = userService.AddUser("Jan", "Malewski", "malewski@gmail.com", DateTime.Parse("1980-01-01"), 2);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        // Arrange
        UserService userService = new UserService();
        
        // Act
        var result = userService.AddUser("Jan", "Smith", "smith@gmail.com", DateTime.Parse("1980-01-01"), 3);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        // Arrange
        UserService userService = new UserService();
        
        // Act
        var result = userService.AddUser("Jan", "Kwiatkowski", "kwiatkowski@wp.pl", DateTime.Parse("1980-01-01"), 5);
        
        // Assert
        Assert.True(result);
    }
    
    
    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        // Arrange
        UserService userService = new UserService();
        
        // Act
        var result = userService.AddUser("Jan", "Kowalski", "kowalski@wp.pl", DateTime.Parse("1980-01-01"), 5);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        // Arrange
        UserService userService = new UserService();
        
        // Act
        Action result = () => userService.AddUser("Jan", "Andrzejewicz", "andrzejewicz@wp.pl", DateTime.Parse("1999-03-21"), 6);
        
        // Assert
        Assert.Throws<ArgumentException>(result);
    }
    
    
    
    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
    {
        // Arrange
        UserService userService = new UserService();
        
        // Act
        Action result = () => userService.AddUser("Jan", "Kowalski", "kowalski@gmail.com", DateTime.Parse("1999-03-21"), 10);
        
        // Assert
        Assert.Throws<ArgumentException>(result);
    }
}