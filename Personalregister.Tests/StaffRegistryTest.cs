namespace Personalregister.Tests;

public class StaffRegistryTest
{
    [Fact]
    public void AddStaffToRegistry_Success()
    {
        // ARRANGE
        Console.SetIn(new StringReader("Test Testsson\n128000"));

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        // ACT
        StaffRegistry.AddStaffToRegistry();
        
        // ASSERT
        var output = stringWriter.ToString()
            .Split(
                [Environment.NewLine], 
                StringSplitOptions.RemoveEmptyEntries
            );
        
        Assert.Single(StaffRegistry.StaffList);
        Assert.Equal(2, output.Length);
        Assert.Contains("Adding new staff...", output[0]);
        Assert.Contains("Added staff with name Test Testsson and salary 128000 to registry.", output[1]);
        
        // CLEAN UP
        StaffRegistry.StaffList.Clear();
    }

    [Fact]
    public void ListRegistry_Success()
    {
        // ARRANGE
        StaffRegistry.StaffList.Add(new StaffRegistry.Staff("Test Testsson", 1234));
        
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        // ACT
        StaffRegistry.ListRegistry();
        
        // ASSERT
        var output = stringWriter.ToString()
            .Split(
                [Environment.NewLine], 
                StringSplitOptions.RemoveEmptyEntries
            );
        
        Assert.Single(StaffRegistry.StaffList);
        Assert.Equal(2, output.Length);
        Assert.Contains("Listing staff registry...", output[0]);
        Assert.Contains("Test Testsson, 1234", output[1]);
        
        // CLEAN UP
        StaffRegistry.StaffList.Clear();
    }

    [Fact]
    public void Exit_Success()
    {
        // ARRANGE
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        // ACT
        StaffRegistry.Exit();
        
        // ASSERT
        var output = stringWriter.ToString()
            .Split(
                [Environment.NewLine], 
                StringSplitOptions.RemoveEmptyEntries
            );
        
        Assert.Single(output);
        Assert.Contains("Quitting...", output[0]);
        Assert.False(StaffRegistry.Running);
    }
}